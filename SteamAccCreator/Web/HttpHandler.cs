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

        public bool UseProxy { get; set; }
        public string ProxyHost { get; private set; }
        public int ProxyPort { get; private set; }

        private static readonly Uri JoinUri = new Uri("https://store.steampowered.com/join/");
        private static readonly Uri CaptchaUri = new Uri("https://store.steampowered.com/login/rendercaptcha?gid=");
        private static readonly Uri VerifyCaptchaUri = new Uri("https://store.steampowered.com/join/verifycaptcha/");
        private static readonly Uri AjaxVerifyCaptchaUri = new Uri("https://store.steampowered.com/join/ajaxverifyemail");
        private static readonly Uri AjaxCheckEmailVerifiedUri = new Uri("https://store.steampowered.com/join/ajaxcheckemailverified");
        private static readonly Uri CheckAvailUri = new Uri("https://store.steampowered.com/join/checkavail/");
        private static readonly Uri CheckPasswordAvailUri = new Uri("https://store.steampowered.com/join/checkpasswordavail/");
        private static readonly Uri CreateAccountUri = new Uri("https://store.steampowered.com/join/createaccount/");

        private static readonly Uri TwoCaptchaDomain = new Uri((Program.UseRuCaptchaDomain) ? "http://rucaptcha.com" : "http://2captcha.com");

        private static readonly Regex CaptchaRegex = new Regex(@"\/rendercaptcha\?gid=([0-9]+)\D");
        private static readonly Regex BoolRegex = new Regex(@"(true|false)");

        public HttpHandler(bool useProxy, string proxyHost, int proxyPort)
        {
            UseProxy = useProxy;
            ProxyHost = proxyHost;
            ProxyPort = proxyPort;
        }

        public Image GetCaptchaImageraw()
        {
            //load Steam page
            _client.BaseUrl = JoinUri;
            _request.Method = Method.GET;
            var response = _client.Execute(_request);

            //Store captcha ID
            _captchaGid = CaptchaRegex.Matches(response.Content)[0].Groups[1].Value;

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
            _client.BaseUrl = new Uri("http://api.captchasolutions.com/");
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
            if (clearRequest)
                _request.Parameters.Clear();

            _client.BaseUrl = uri;
            _client.Proxy = (UseProxy) ? new WebProxy(ProxyHost, ProxyPort) : default(IWebProxy);
            _request.Method = method;
            ServicePointManager.SecurityProtocol = securityProtocol;
        }

        public bool TwoCaptchaReport(Captcha.CaptchaSolution solution, bool good)
        {
            var _reportResponse = TwoCaptcha("res.php",
                new Dictionary<string, object>()
                {
                    { "key", solution.Config.RuCaptcha.ApiKey },
                    { "action", (good) ? "reportgood" : "reportbad" },
                    { "id", solution.Id },
                    { "json", "0" },
                });
            return _reportResponse?.FirstOrDefault()?.ToUpper() == "OK_REPORT_RECORDED";
        }

        public Captcha.CaptchaSolution SolveCaptcha(Action<string> updateStatus, Models.CaptchaSolvingConfig captchaConfig)
        {
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
                    updateStatus($"Downloading captcha: Try {i + 1}/3");

                    var _captchaResp = _client.DownloadData(_request);
                    captchaPayload = GetBase64FromImage(_captchaResp);

                    break;
                }
                catch { captchaPayload = string.Empty; }
            }

            // recognize captcha
            updateStatus("Recognizing Captcha...");
            switch (captchaConfig.Service)
            {
                case Enums.CaptchaService.Captchasolutions:
                    {
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
                            return new Captcha.CaptchaSolution(true, _resp, captchaConfig);

                        return new Captcha.CaptchaSolution(true, Regex.Replace(_resp, @"\t|\n|\r", ""), null);
                    }
                case Enums.CaptchaService.RuCaptcha:
                    {
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

                        Thread.Sleep(TimeSpan.FromSeconds(20));

                        var solution = string.Empty;
                        for (int i = 0; i < 3; i++)
                        {
                            var _captchaResponse = TwoCaptcha("res.php",
                                new Dictionary<string, object>()
                                {
                                    { "key", captchaConfig.RuCaptcha.ApiKey },
                                    { "action", "get" },
                                    { "id", _captchaId },
                                    { "json", "0" },
                                });

                            var _status = _captchaResponse?.FirstOrDefault()?.ToUpper() ?? "UNKNOWN";
                            switch (_status)
                            {
                                case "OK":
                                    return new Captcha.CaptchaSolution(_captchaResponse.ElementAt(1), _captchaId, captchaConfig);
                                case "CAPCHA_NOT_READY":
                                case "ERROR_NO_SLOT_AVAILABLE":
                                    Thread.Sleep(6000);
                                    continue;
                                default:
                                    return new Captcha.CaptchaSolution(true, _status, captchaConfig);
                            }
                        }
                    }
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
                return false;

            SetConfig(VerifyCaptchaUri, Method.POST);
            _request.AddParameter("captchagid", _captchaGid);
            _request.AddParameter("captcha_text", captcha.Solution);
            _request.AddParameter("email", email);
            _request.AddParameter("count", "1");
            var response = _client.Execute(_request);

            _request.Parameters.Clear();

            if (!response.IsSuccessful)
            {
                updateStatus(Error.HTTP_FAILED);
                return false;
            }

            var matches = BoolRegex.Matches(response.Content);
            var bCaptchaMatches = bool.Parse(matches[0].Value);
            var bEmailAvail = bool.Parse(matches[1].Value);

            if (!bCaptchaMatches)
            {
                updateStatus(Error.WRONG_CAPTCHA);


                if (captcha.Config.Service == Enums.CaptchaService.RuCaptcha &&
                    captcha.Config.RuCaptcha.ReportBad)
                {
                    TwoCaptchaReport(captcha, false);
                }
                return false;
            }

            if (!bEmailAvail)
            {
                //seems to always return true even if email is already in use
                updateStatus(Error.EMAIL_ERROR);
                stop = true;
                return false;
            }

            //Send request again
            _client.BaseUrl = AjaxVerifyCaptchaUri;
            if (UseProxy)
                _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

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
                            updateStatus(Error.SIMILIAR_MAIL);
                            break;
                        case 13:
                            updateStatus(Error.INVALID_MAIL);
                            break;
                        case 17:
                            updateStatus(Error.TRASH_MAIL);
                            break;
                        default:
                            updateStatus(Error.UNKNOWN);
                            stop = true;
                            break;
                    }
                    return false;
                }

                _sessionId = jsonResponse.sessionid;
                updateStatus("Waiting for email to be verified");
            }
            catch { }

            return true;
        }

        public bool CheckEmailVerified(ref string status)
        {
            _client.BaseUrl = AjaxCheckEmailVerifiedUri;
            if (UseProxy)
                _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

            _request.Method = Method.POST;
            _request.AddParameter("creationid", _sessionId);

            var response = _client.Execute(_request);

            _request.Parameters.Clear();

            switch (response.Content)
            {
                case "1":
                    status = "Email confirmed..Done!";

                    return true;

                case "42":
                case "29":
                    //CheckEmailVerified(ref status);
                    status = Error.REGISTRATION;
                    break;

                case "27":
                    status = Error.TIMEOUT;
                    break;

                case "36":
                case "10":
                    status = Error.MAIL_UNVERIFIED;
                    break;

                default:
                    status = Error.UNKNOWN;
                    break;
            }
            return false;
        }

        public bool CompleteSignup(string alias, string password, Action<string> updateStatus, ref long steamId, ref int gamesNotAdded, IEnumerable<Models.GameInfo> addThisGames)
        {
            if (!CheckAlias(alias, updateStatus))
                return false;
            if (!CheckPassword(password, alias, updateStatus))
                return false;

            _client.BaseUrl = CreateAccountUri;
            if (UseProxy)
                _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

            _request.Method = Method.POST;
            _request.AddParameter("accountname", alias);
            _request.AddParameter("password", password);
            _request.AddParameter("creation_sessionid", _sessionId);
            _request.AddParameter("count", "1");
            _request.AddParameter("lt", "0");

            var response = _client.Execute(_request);
            var sessionCookie = response.Cookies.SingleOrDefault(x => x.Name == "steamLoginSecure");
            if (sessionCookie != null)
            {
                _cookieJar.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
            }

            _request.Parameters.Clear();

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            if (jsonResponse.bSuccess == "true")
            {
                updateStatus?.Invoke("Account created");
                //disable guard
                _client.FollowRedirects = false;
                _client.CookieContainer = _cookieJar;
                _client.BaseUrl = new Uri("https://store.steampowered.com/twofactor/manage_action");
                if (UseProxy)
                    _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

                _request.Method = Method.POST;
                _request.AddParameter("action", "actuallynone");
                _request.AddParameter("sessionid", _sessionId);
                var response1 = _client.Execute(_request);
                var sess = "";
                sessionCookie = response1.Cookies.SingleOrDefault(x => x.Name == "sessionid");
                if (sessionCookie != null)
                {
                    _cookieJar.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
                    sess = sessionCookie.Value;
                }
                _request.Parameters.Clear();
                _client.CookieContainer = _cookieJar;
                _client.BaseUrl = new Uri("https://store.steampowered.com/twofactor/manage_action");
                if (UseProxy)
                    _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

                _request.Method = Method.POST;
                _request.AddParameter("action", "actuallynone");
                _request.AddParameter("sessionid", sess);
                _request.AddParameter("none_authenticator_check", "on");
                var response11 = _client.Execute(_request);
                _client.FollowRedirects = true;

                var _steamRegex = Regex.Match(response11?.Content ?? "", @"\/profiles\/(\d+)", RegexOptions.IgnoreCase);
                if (_steamRegex.Success)
                    steamId = long.Parse(_steamRegex.Groups[1].Value);

                _request.Parameters.Clear();
                gamesNotAdded = 0;
                foreach (var game in addThisGames)
                {
                    if (game == null)
                        continue;

                    try
                    {
                        _client.BaseUrl = new Uri("https://store.steampowered.com/checkout/addfreelicense");
                        if (UseProxy)
                            _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

                        updateStatus($"Adding game: {game.Name}");

                        _request.Method = Method.POST;
                        _request.AddParameter("action", "add_to_cart");
                        _request.AddParameter("subid", game.SubId);
                        _request.AddParameter("sessionid", sess);
                        var responce111 = _client.Execute(_request);
                        _client.FollowRedirects = true;
                    }
                    catch { gamesNotAdded++; }

                    if (game != addThisGames.Last())
                        Thread.Sleep(500);
                }

                return true;
            }
            updateStatus?.Invoke(jsonResponse.details);
            return false;
        }

        private static bool CheckAlias(string alias, Action<string> statusUpdate)
        {
            var tempClient = new RestClient(CheckAvailUri);
            var tempRequest = new RestRequest(Method.POST);
            tempRequest.AddParameter("accountname", alias);
            tempRequest.AddParameter("count", "1");

            var response = tempClient.Execute(tempRequest);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            if (jsonResponse.bAvailable == "true")
                return true;

            statusUpdate?.Invoke(Error.ALIAS_UNAVAILABLE);
            return false;
        }

        private static bool CheckPassword(string password, string alias, Action<string> updateStatus)
        {
            var tempClient = new RestClient(CheckPasswordAvailUri);
            var tempRequest = new RestRequest(Method.POST);
            tempRequest.AddParameter("password", password);
            tempRequest.AddParameter("accountname", alias);
            tempRequest.AddParameter("count", "1");

            var response = tempClient.Execute(tempRequest);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            if (jsonResponse.bAvailable == "true")
                return true;

            updateStatus?.Invoke(Error.PASSWORD_UNSAFE);
            return false;
        }
    }
}
