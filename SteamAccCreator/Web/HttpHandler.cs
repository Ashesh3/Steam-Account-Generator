using Newtonsoft.Json;
using RestSharp;
using SteamAccCreator.Gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace SteamAccCreator.Web
{
    public class HttpHandler
    {
        public CookieContainer _cookieJar = new CookieContainer();

        private readonly RestClient _client = new RestClient();
        private readonly RestRequest _request = new RestRequest();

        private string _captchaGid = string.Empty;
        private string _sessionId = string.Empty;

        private readonly MainForm FormMain;
        private readonly Models.ProxyConfig ProxyConfig;

        private static readonly Uri JoinUri = new Uri("https://store.steampowered.com/join/");
        private static readonly Uri CaptchaUri = new Uri("https://store.steampowered.com/login/rendercaptcha?gid=");
        private static readonly Uri VerifyCaptchaUri = new Uri("https://store.steampowered.com/join/verifycaptcha/");
        private static readonly Uri AjaxVerifyCaptchaUri = new Uri("https://store.steampowered.com/join/ajaxverifyemail");
        private static readonly Uri AjaxCheckEmailVerifiedUri = new Uri("https://store.steampowered.com/join/ajaxcheckemailverified");
        private static readonly Uri CheckAvailUri = new Uri("https://store.steampowered.com/join/checkavail/");
        private static readonly Uri CheckPasswordAvailUri = new Uri("https://store.steampowered.com/join/checkpasswordavail/");
        private static readonly Uri CreateAccountUri = new Uri("https://store.steampowered.com/join/createaccount/");

        public static Uri TwoCaptchaDomain = new Uri((Program.UseRuCaptchaDomain) ? "http://rucaptcha.com" : "http://2captcha.com");
        public static Uri CaptchasolutionsDomain = new Uri("http://api.captchasolutions.com/");

        private static readonly Regex CaptchaRegex = new Regex(@"\/rendercaptcha\?gid=([0-9]+)\D");
        private static readonly Regex BoolRegex = new Regex(@"(true|false)");

        public HttpHandler(MainForm main, Models.ProxyConfig proxyConfig)
        {
            FormMain = main;
            ProxyConfig = proxyConfig;
        }

        public Image GetCaptchaImageraw()
        {
            Logger.Trace("Loading captcha image raw...");
            //load Steam page
            _client.BaseUrl = JoinUri;
            _request.Method = Method.GET;
            var response = _client.Execute(_request);

            //Store captcha ID
            _captchaGid = CaptchaRegex.Matches(response.Content)[0].Groups[1].Value;
            Logger.Trace($"Captcha GID: {_captchaGid}");

            //download and return captcha image
            _client.BaseUrl = new Uri(CaptchaUri + _captchaGid);
            var captchaResponse = _client.DownloadData(_request);
            using (var ms = new MemoryStream(captchaResponse))
            {
                return Image.FromStream(ms);
            }
        }

        private string[] TwoCaptcha(string resource, Dictionary<string, object> args)
        {
            _client.BaseUrl = TwoCaptchaDomain;
            var srequest = new RestRequest(resource, Method.POST);
            foreach (var key in args)
            {
                srequest.AddParameter(key.Key, key.Value);
            }
            var responsecap = _client.Execute(srequest);
            return responsecap.Content.Split(new string[] { "|" }, StringSplitOptions.None);
        }

        private string Captchasolutions(string resource, Dictionary<string, object> args)
        {
            _client.BaseUrl = CaptchasolutionsDomain;
            var srequest = new RestRequest(resource, Method.POST);
            foreach (var key in args)
            {
                srequest.AddParameter(key.Key, key.Value);
            }
            var responsecap = _client.Execute(srequest);
            return responsecap.Content;
        }

        public string GetBase64FromImage(byte[] captcha)
        {
            using (var ms = new MemoryStream(captcha))
            {
                using (var image = Image.FromStream(ms))
                {
                    using (var m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        var imageBytes = m.ToArray();

                        return Convert.ToBase64String(imageBytes);
                    }
                }
            }
        }

        private void SetConfig(string uri, Method method, SecurityProtocolType securityProtocol = SecurityProtocolType.Tls12, bool clearRequest = true)
            => SetConfig(new Uri(uri), method, securityProtocol, clearRequest);
        private void SetConfig(Uri uri, Method method, SecurityProtocolType securityProtocol = SecurityProtocolType.Tls12, bool clearRequest = true)
        {
            Logger.Trace("Setting request config...");

            if (clearRequest)
            {
                Logger.Trace("Setting request config: clearing old request param-s");
                _request.Parameters.Clear();
            }

            Logger.Trace($"Setting request config: url = {uri}");
            _client.BaseUrl = uri;
            Logger.Trace($"Setting request config: proxy = {((ProxyConfig.Enabled) ? FormMain?.CurrentProxy?.ToString() ?? "NULL" : "disabled")}");
            _client.Proxy = (ProxyConfig.Enabled) ? FormMain.CurrentProxy : default(IWebProxy);
            Logger.Trace($"Setting request config: method = {method.ToString()}");
            _request.Method = method;
            Logger.Trace($"Setting request config: security protocol = {securityProtocol.ToString()}");
            ServicePointManager.SecurityProtocol = securityProtocol;
            Logger.Trace($"Setting request config: done");
        }

        public bool TwoCaptchaReport(Captcha.CaptchaSolution solution, bool good)
        {
            Logger.Trace("TwoCaptcha/RuCaptcha reporting...");
            var _reportResponse = TwoCaptcha("res.php",
                new Dictionary<string, object>()
                {
                    { "key", solution.Config.RuCaptcha.ApiKey },
                    { "action", (good) ? "reportgood" : "reportbad" },
                    { "id", solution.Id },
                    { "json", "0" },
                });
            Logger.Trace($"TwoCaptcha/RuCaptcha reporting: {_reportResponse?.FirstOrDefault()?.ToUpper()}");
            return _reportResponse?.FirstOrDefault()?.ToUpper() == "OK_REPORT_RECORDED";
        }

        public Captcha.CaptchaSolution SolveCaptcha(Action<string> updateStatus, Models.CaptchaSolvingConfig captchaConfig)
        {
            Logger.Debug("Getting captcha...");
            updateStatus?.Invoke("Getting captcha...");

            //Store captcha ID
            SetConfig(JoinUri, Method.GET);
            var response = _client.Execute(_request);
            try
            {
                _captchaGid = CaptchaRegex.Matches(response.Content)[0].Groups[1].Value;
            }
            catch (Exception e)
            {
                Logger.Error("Captcha error.", e);
                updateStatus($"Captcha error: {e.Message}");
                return new Captcha.CaptchaSolution(true, $"{e}\n\n{response.ResponseStatus}", captchaConfig);
            }

            //download and return captcha image
            SetConfig($"{CaptchaUri}{_captchaGid}", Method.GET);
            var captchaPayload = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Logger.Debug($"Downloading captcha: Try {i + 1}/3");
                    updateStatus($"Downloading captcha: Try {i + 1}/3");

                    var _captchaResp = _client.DownloadData(_request);
                    captchaPayload = GetBase64FromImage(_captchaResp);

                    break;
                }
                catch (Exception ex)
                {
                    Logger.Error("Downloading captcha error.", ex);
                    captchaPayload = string.Empty;
                }
            }

            // recognize captcha
            Logger.Debug("Recognizing captcha...");
            updateStatus("Recognizing captcha...");
            switch (captchaConfig.Service)
            {
                case Enums.CaptchaService.Captchasolutions:
                    {
                        Logger.Debug("Recognizing captcha via Captchasolutions...");
                        var _resp = Captchasolutions("solve",
                            new Dictionary<string, object>()
                            {
                                { "p", "base64" },
                                { "captcha", $"data:image/jpg;base64,{captchaPayload}" },
                                { "key", captchaConfig.CaptchaSolutions.ApiKey },
                                { "secret", captchaConfig.CaptchaSolutions.ApiSecret },
                                { "out", "txt" },
                            });

                        if (Regex.IsMatch(_resp, @"Error:\s(.+)", RegexOptions.IgnoreCase))
                        {
                            Logger.Warn($"Captchasolutions error:\n{_resp}\n====== END ======");
                            return new Captcha.CaptchaSolution(true, _resp, captchaConfig);
                        }

                        var solution = Regex.Replace(_resp, @"\t|\n|\r", "");
                        Logger.Debug($"Captchasolutions: {solution}");
                        return new Captcha.CaptchaSolution(solution, null, captchaConfig);
                    }
                case Enums.CaptchaService.RuCaptcha:
                    {
                        Logger.Debug("Recognizing captcha via TwoCaptcha/RuCaptcha");
                        var _captchaIdResponse = TwoCaptcha("in.php",
                            new Dictionary<string, object>()
                            {
                                { "key", captchaConfig.RuCaptcha.ApiKey },
                                { "body", $"data:image/jpg;base64,{captchaPayload}" },
                                { "method", "base64" },
                                { "soft_id", "2370" },
                                { "json", "0" },
                            });

                        var _captchaStatus = _captchaIdResponse?.FirstOrDefault()?.ToUpper() ?? "UNKNOWN";
                        Logger.Debug($"TwoCaptcha/RuCaptcha image upload response: {_captchaStatus}");
                        switch (_captchaStatus)
                        {
                            case "OK":
                                break;
                            case "ERROR_NO_SLOT_AVAILABLE":
                                Thread.Sleep(6000);
                                return new Captcha.CaptchaSolution(true, _captchaStatus, captchaConfig);
                            default:
                                return new Captcha.CaptchaSolution(false, _captchaStatus, captchaConfig);
                        }

                        var _captchaId = _captchaIdResponse.ElementAt(1);
                        Logger.Debug($"TwoCaptcha/RuCaptcha ID: {_captchaId}");

                        Thread.Sleep(TimeSpan.FromSeconds(20));

                        var solution = string.Empty;
                        for (int i = 0; i < 3; i++)
                        {
                            Logger.Debug($"TwoCaptcha/RuCaptcha requesting solution... Try {i} of 3");
                            var _captchaResponse = TwoCaptcha("res.php",
                                new Dictionary<string, object>()
                                {
                                    { "key", captchaConfig.RuCaptcha.ApiKey },
                                    { "action", "get" },
                                    { "id", _captchaId },
                                    { "json", "0" },
                                });

                            var _status = _captchaResponse?.FirstOrDefault()?.ToUpper() ?? "UNKNOWN";
                            Logger.Debug($"TwoCaptcha/RuCaptcha solving status: {_status}");
                            switch (_status)
                            {
                                case "OK":
                                    {
                                        var _solution = new Captcha.CaptchaSolution(_captchaResponse.ElementAt(1), _captchaId, captchaConfig);
                                        Logger.Debug($"TwoCaptcha/RuCaptcha solution: {_solution.Solution}");
                                        return _solution;
                                    }
                                case "CAPCHA_NOT_READY":
                                case "ERROR_NO_SLOT_AVAILABLE":
                                    Thread.Sleep(6000);
                                    continue;
                                default:
                                    return new Captcha.CaptchaSolution(true, _status, captchaConfig);
                            }
                        }
                    }
                    Logger.Debug("TwoCaptcha/RuCaptcha somethig went wrong.");
                    return new Captcha.CaptchaSolution(true, "Something went wrong", captchaConfig);
                default:
                    {
                        using (var dialog = new CaptchaDialog(this, updateStatus, captchaConfig))
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                                return dialog.Solution;
                        }
                    }
                    return new Captcha.CaptchaSolution(false, "Can't solve captcha!", captchaConfig);
            }
        }

        public bool CreateAccount(string email, Captcha.CaptchaSolution captcha, Action<string> updateStatus, ref bool stop)
        {
            if (!(captcha?.Solved ?? false))
            {
                Logger.Warn("Captcha not solved. Cannot create account.");
                return false;
            }

            Logger.Debug("Creating account...");

            SetConfig(VerifyCaptchaUri, Method.POST);
            _request.AddParameter("captchagid", _captchaGid);
            _request.AddParameter("captcha_text", captcha.Solution);
            _request.AddParameter("email", email);
            _request.AddParameter("count", "1");
            var response = _client.Execute(_request);

            _request.Parameters.Clear();

            if (!response.IsSuccessful)
            {
                Logger.Warn($"Creating account error: {Error.HTTP_FAILED}");
                updateStatus(Error.HTTP_FAILED);
                return false;
            }

            var matches = BoolRegex.Matches(response.Content);
            var bCaptchaMatches = bool.Parse(matches[0].Value);
            var bEmailAvail = bool.Parse(matches[1].Value);

            if (!bCaptchaMatches)
            {
                Logger.Warn("Creating account error: Wrong captcha");
                updateStatus(Error.WRONG_CAPTCHA);

                if (captcha.Config != null &&
                    captcha.Config.Service == Enums.CaptchaService.RuCaptcha &&
                    captcha.Config.RuCaptcha.ReportBad)
                {
                    TwoCaptchaReport(captcha, false);
                }
                return false;
            }

            if (!bEmailAvail)
            {
                //seems to always return true even if email is already in use
                Logger.Warn("Creating account error: Email probably in use");
                updateStatus(Error.EMAIL_ERROR);
                stop = true;
                return false;
            }

            //Send request again
            SetConfig(AjaxVerifyCaptchaUri, Method.POST);
            _request.AddParameter("captchagid", _captchaGid);
            _request.AddParameter("captcha_text", captcha.Solution);
            _request.AddParameter("email", email);

            response = _client.Execute(_request);
            _request.Parameters.Clear();
            try
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                if (jsonResponse.success != 1)
                {
                    switch (jsonResponse.success)
                    {
                        case 62:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.SIMILIAR_MAIL}");
                            updateStatus(Error.SIMILIAR_MAIL);
                            break;
                        case 13:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.INVALID_MAIL}");
                            updateStatus(Error.INVALID_MAIL);
                            break;
                        case 17:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.TRASH_MAIL}");
                            updateStatus(Error.TRASH_MAIL);
                            break;
                        default:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.UNKNOWN}");
                            updateStatus(Error.UNKNOWN);
                            stop = !FormMain.UpdateProxy();
                            break;
                    }
                    return false;
                }

                Logger.Trace($"Creating account, SessionID: {_sessionId}");
                _sessionId = jsonResponse.sessionid;

                Logger.Debug("Creating account: Waiting for email to be verified");
                updateStatus("Waiting for email to be verified");
            }
            catch { }

            return true;
        }

        public bool CheckEmailVerified(Action<string> updateStatus, ref bool shouldRetry)
        {
            Logger.Trace("Creating account: checking mail is verified");

            SetConfig(AjaxCheckEmailVerifiedUri, Method.POST);
            _request.AddParameter("creationid", _sessionId);

            var response = _client.Execute(_request);
            switch (response.Content)
            {
                case "1":
                    Logger.Debug("Creating account: Email confirmed, done!");
                    updateStatus?.Invoke("Email confirmed, done!");
                    return true;
                case "42":
                case "29":
                    Logger.Warn($"Creating account error: #{response.Content} / {Error.REGISTRATION}");
                    updateStatus?.Invoke(Error.REGISTRATION);
                    break;
                case "27":
                    Logger.Warn($"Creating account error: #{response.Content} / {Error.TIMEOUT}");
                    updateStatus?.Invoke(Error.TIMEOUT);
                    break;
                case "36":
                case "10":
                    Logger.Warn($"Creating account error: #{response.Content} / {Error.MAIL_UNVERIFIED}");
                    updateStatus?.Invoke(Error.MAIL_UNVERIFIED);
                    break;
                default:
                    Logger.Warn($"Creating account error: #{response.Content} / {Error.UNKNOWN}");
                    updateStatus?.Invoke(Error.UNKNOWN);
                    shouldRetry = FormMain.UpdateProxy();
                    break;
            }
            return false;
        }

        public bool CompleteSignup(string alias, string password, Action<string> updateStatus, ref long steamId, ref int gamesNotAdded, IEnumerable<Models.GameInfo> addThisGames)
        {
            Logger.Trace("Creating account: compliting signup...");

            if (!CheckAlias(alias, updateStatus))
                return false;
            if (!CheckPassword(password, alias, updateStatus))
                return false;

            SetConfig(CreateAccountUri, Method.POST);
            _request.AddParameter("accountname", alias);
            _request.AddParameter("password", password);
            _request.AddParameter("creation_sessionid", _sessionId);
            _request.AddParameter("count", "1");
            _request.AddParameter("lt", "0");

            var response = _client.Execute(_request);
            var sessionCookie = response.Cookies.SingleOrDefault(x => x.Name == "steamLoginSecure");
            if (sessionCookie != null)
            {
                Logger.Trace("Creating account: Session cookie found.");
                _cookieJar.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
            }

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            if (jsonResponse.bSuccess == "true")
            {
                Logger.Debug("Creating account: Account created");
                updateStatus?.Invoke("Account created");
                //disable guard
                Logger.Debug("Creating account: Disabling guard");
                _client.FollowRedirects = false;
                _client.CookieContainer = _cookieJar;
                SetConfig("https://store.steampowered.com/twofactor/manage_action", Method.POST);
                _request.AddParameter("action", "actuallynone");
                _request.AddParameter("sessionid", _sessionId);
                var response1 = _client.Execute(_request);
                var sess = "";
                sessionCookie = response1.Cookies.SingleOrDefault(x => x.Name == "sessionid");
                if (sessionCookie != null)
                {
                    Logger.Trace("Creating account: SessionID cookie found.");
                    _cookieJar.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
                    sess = sessionCookie.Value;
                }
                _client.CookieContainer = _cookieJar;
                SetConfig("https://store.steampowered.com/twofactor/manage_action", Method.POST);
                _request.AddParameter("action", "actuallynone");
                _request.AddParameter("sessionid", sess);
                _request.AddParameter("none_authenticator_check", "on");
                var response11 = _client.Execute(_request);
                _client.FollowRedirects = true;

                var _steamRegex = Regex.Match(response11?.Content ?? "", @"\/profiles\/(\d+)", RegexOptions.IgnoreCase);
                if (_steamRegex.Success)
                {
                    Logger.Trace($"Creating account: SteamID64 found ({_steamRegex.Groups[1].Value}).");
                    steamId = long.Parse(_steamRegex.Groups[1].Value);
                }

                gamesNotAdded = 0;
                foreach (var game in addThisGames)
                {
                    if (game == null)
                        continue;

                    var addSuccess = false;

                    try
                    {
                        Logger.Debug($"Creating account: Adding game({game.SubId}:{game.Name})");
                        updateStatus($"Adding game: {game.Name}");

                        SetConfig("https://store.steampowered.com/checkout/addfreelicense", Method.POST);
                        _request.AddParameter("action", "add_to_cart");
                        _request.AddParameter("subid", game.SubId);
                        _request.AddParameter("sessionid", sess);
                        var responce111 = _client.Execute(_request);
                        _client.FollowRedirects = true;

                        if (!Regex.IsMatch(responce111.Content, @"problem\sadding\sthis\sproduct", RegexOptions.IgnoreCase))
                            addSuccess = true;
                    }
                    catch { }

                    if (!addSuccess)
                    {
                        gamesNotAdded++;
                        Logger.Warn($"Creating account: Adding game({game.SubId}:{game.Name}) failed!");
                    }

                    if (game != addThisGames.Last())
                        Thread.Sleep(500);
                }

                Logger.Debug("Creating account: done!");
                return true;
            }
            Logger.Debug($"Creating account: {jsonResponse.details}");
            updateStatus?.Invoke(jsonResponse.details);
            return false;
        }

        private static bool CheckAlias(string alias, Action<string> statusUpdate)
        {
            Logger.Debug("Checking alias (login)...");

            var tempClient = new RestClient(CheckAvailUri);
            var tempRequest = new RestRequest(Method.POST);
            tempRequest.AddParameter("accountname", alias);
            tempRequest.AddParameter("count", "1");

            var response = tempClient.Execute(tempRequest);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            if (jsonResponse.bAvailable == "true")
            {
                Logger.Debug("Checking alias (login): OK");
                return true;
            }

            Logger.Warn($"Checking alias (login): {Error.ALIAS_UNAVAILABLE}");
            statusUpdate?.Invoke(Error.ALIAS_UNAVAILABLE);
            return false;
        }

        private static bool CheckPassword(string password, string alias, Action<string> updateStatus)
        {
            Logger.Debug("Checking password...");

            var tempClient = new RestClient(CheckPasswordAvailUri);
            var tempRequest = new RestRequest(Method.POST);
            tempRequest.AddParameter("password", password);
            tempRequest.AddParameter("accountname", alias);
            tempRequest.AddParameter("count", "1");

            var response = tempClient.Execute(tempRequest);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            if (jsonResponse.bAvailable == "true")
            {
                Logger.Debug("Checking password: OK");
                return true;
            }

            Logger.Debug($"Checking password: {Error.PASSWORD_UNSAFE}");
            updateStatus?.Invoke(Error.PASSWORD_UNSAFE);
            return false;
        }
    }
}
