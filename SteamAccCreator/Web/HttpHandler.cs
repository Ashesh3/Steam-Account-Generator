using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SteamAccCreator.Gui;
using SteamAccCreator.Interfaces;
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

        public static Uri TwoCaptchaDomain = new Uri((Program.UseRuCaptchaDomain) ? "http://rucaptcha.com" : "http://2captcha.com");
        public static Uri CaptchasolutionsDomain = new Uri("http://api.captchasolutions.com/");

        private static readonly Regex CaptchaRegex = new Regex(@"\/rendercaptcha\?gid=([0-9]+)\D");
        private static readonly Regex BoolRegex = new Regex(@"(true|false)");
        private static readonly Regex SteamProfileRegex = new Regex(@"\/profiles\/(\d+)", RegexOptions.IgnoreCase);

        public HttpHandler(MainForm main, Models.ProxyConfig proxyConfig)
        {
            FormMain = main;
            ProxyConfig = proxyConfig;

            _client.CookieContainer = _cookieJar;
        }

        public Image GetCaptchaImageraw()
        {
            Logger.Trace("Starting loading captcha image...");

            if (!GetRecaptcha(3, out var _siteKey, out _captchaGid, out var isRecaptcha))
            {
                Logger.Warn("Cannot get captcha GID...");
                return null;
            }

            //download and return captcha image
            _client.BaseUrl = new Uri($"{Defaults.Web.STEAM_RENDER_CAPTCHA_ADDRESS}?gid={_captchaGid}");
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

            var proxyEnabled = FormMain.ProxyManager.Enabled;
            var proxy = (proxyEnabled) ? FormMain.ProxyManager.WebProxy : default(IWebProxy);

            Logger.Trace($"Setting request config: url = {uri}");
            _client.BaseUrl = uri;
            Logger.Trace($"Setting request config: proxy = {((proxyEnabled) ? proxy?.ToString() ?? "NULL" : "disabled")}");
            _client.Proxy = (proxyEnabled) ? proxy : default(IWebProxy);
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

        public bool GetRecaptcha(uint retryCount, out string siteKey, out string gid, out bool? isRecaptcha)
        {
            for (uint i = 0; i < retryCount; i++)
            {
                if (GetRecaptcha(out siteKey, out gid, out isRecaptcha))
                    return true;
            }

            siteKey = gid = string.Empty; isRecaptcha = null;
            return false;
        }
        public bool GetRecaptcha(out string siteKey, out string gid, out bool? isRecaptcha)
        {
            siteKey = string.Empty; gid = string.Empty; isRecaptcha = null;
            try
            {
                SetConfig(Defaults.Web.STEAM_JOIN_URI, Method.GET);
                var response = _client.Execute(_request);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(response.Content);

                try
                {
                    isRecaptcha = doc.GetElementbyId("captchaImg") == null;
                }
                catch (HtmlAgilityPack.NodeNotFoundException) { isRecaptcha = false; }
                catch (Exception ex) { Logger.Error("Something went wrong...", ex); }

                try
                {
                    var captchaGid = doc.GetElementbyId("captchagid");
                    if (captchaGid != null)
                    {
                        gid = captchaGid.GetAttributeValue("value", string.Empty);
                    }
                }
                catch (HtmlAgilityPack.NodeNotFoundException nfNode)
                {
                    Logger.Error("Captcha gid not found.", nfNode);
                }

                try
                {
                    var recaptcha = doc.GetElementbyId("g-recaptcha");
                    var account_form_box = doc.GetElementbyId("account_form_box");
                    if (account_form_box == null && (isRecaptcha ?? false))
                        return false;

                    var join_form = account_form_box?.ChildNodes?.FirstOrDefault(x => x?.GetClasses()?.Any(c => (c?.ToLower() ?? "") == "join_form") ?? false);
                    if (join_form == null && (isRecaptcha ?? false))
                        return false;

                    var g_recaptcha = join_form?.ChildNodes?.FirstOrDefault(x => x?.GetClasses()?.Any(c => (c?.ToLower() ?? "") == "g-recaptcha") ?? false);
                    if (g_recaptcha == null && (isRecaptcha ?? false))
                        return false;

                    siteKey = g_recaptcha?.GetAttributeValue("data-sitekey", string.Empty) ?? "";
                }
                catch (HtmlAgilityPack.NodeNotFoundException nfNode)
                {
                    Logger.Error("Captcha data-sitekey not found.", nfNode);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Getting recaptcha using /join/ url: something TOTALLY went wrong.", ex);
            }
            return false;
        }

        public Captcha.CaptchaSolution SolveCaptcha(Action<string> updateStatus, Models.Configuration config)
        {
            Logger.Debug("Getting captcha...");
            updateStatus?.Invoke("Getting captcha...");

            var captchaConfig = config.Captcha;

            if (!GetRecaptcha(3, out string _siteKey, out _captchaGid, out bool? isRecaptcha))
                return new Captcha.CaptchaSolution(true, "Get captcha info error!", captchaConfig);

            if (string.IsNullOrEmpty(_captchaGid))
                return new Captcha.CaptchaSolution(true, "Getting captcha GID error!", captchaConfig);

            var captchaPayload = string.Empty;
            if (isRecaptcha.HasValue && !isRecaptcha.Value)
            {
                //download and return captcha image
                SetConfig($"{Defaults.Web.STEAM_RENDER_CAPTCHA_ADDRESS}?gid={_captchaGid}", Method.GET);
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
            }

            // recognize captcha
            Logger.Debug("Recognizing captcha...");
            updateStatus("Recognizing captcha...");
            switch (captchaConfig.Service)
            {
                case Enums.CaptchaService.Captchasolutions:
                    {
                        if (!captchaConfig.Enabled)
                            goto default;

                        var _params = new Dictionary<string, object>()
                        {
                            { "key", captchaConfig.CaptchaSolutions.ApiKey },
                            { "secret", captchaConfig.CaptchaSolutions.ApiSecret },
                            { "out", "txt" },
                        };

                        if (isRecaptcha.HasValue && isRecaptcha.Value)
                        {
                            _params.Add("p", "nocaptcha");
                            _params.Add("googlekey", _siteKey);
                            _params.Add("pageurl", Defaults.Web.STEAM_JOIN_ADDRESS);
                        }
                        else
                        {
                            _params.Add("p", "base64");
                            _params.Add("captcha", $"data:image/jpg;base64,{captchaPayload}");
                        }

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
                        if (!captchaConfig.Enabled)
                            goto default;

                        Logger.Debug("Recognizing captcha via TwoCaptcha/RuCaptcha");

                        var _params = new Dictionary<string, object>()
                        {
                            { "key", captchaConfig.RuCaptcha.ApiKey },
                            { "soft_id", "2370" },
                            { "json", "0" }
                        };

                        if (isRecaptcha.HasValue && isRecaptcha.Value)
                        {
                            _params.Add("googlekey", _siteKey);
                            _params.Add("method", "userrecaptcha");
                            _params.Add("pageurl", Defaults.Web.STEAM_JOIN_ADDRESS);
                        }
                        else
                        {
                            _params.Add("body", $"data:image/jpg;base64,{captchaPayload}");
                            _params.Add("method", "base64");
                        }

                        var _captchaIdResponse = TwoCaptcha("in.php", _params);

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
                        var retryCount = (isRecaptcha.HasValue && isRecaptcha.Value)
                            ? 10
                            : 3;
                        for (int i = 0; (Program.EndlessTwoCaptcha) ? true : i < retryCount; i++)
                        {
                            Logger.Debug($"TwoCaptcha/RuCaptcha requesting solution... Try {i + 1}{(Program.EndlessTwoCaptcha ? "" : $" of {retryCount}")}");
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
                case Enums.CaptchaService.Module:
                    {
                        try
                        {
                            if (isRecaptcha.HasValue && !isRecaptcha.Value)
                            {
                                var imageCaptchas = FormMain.ModuleManager.Modules.GetCaptchaSolvers();
                                if (imageCaptchas.Count() < 1)
                                    goto default;

                                var anyRetryAvailable = false;
                                for (int i = 0; i < imageCaptchas.Count(); i++)
                                {
                                    var ic = imageCaptchas.ElementAt(i);
                                    var icResponse = ic.Solve(new SACModuleBase.Models.Capcha.CaptchaRequest(captchaPayload, FormMain.ProxyManager.WebProxy));
                                    var icStatus = icResponse?.Status ?? SACModuleBase.Enums.Captcha.CaptchaStatus.CannotSolve;
                                    if (icStatus == SACModuleBase.Enums.Captcha.CaptchaStatus.Success)
                                        return new Captcha.CaptchaSolution(icResponse.Solution, icResponse?.ToString(), captchaConfig);

                                    switch (icStatus)
                                    {
                                        case SACModuleBase.Enums.Captcha.CaptchaStatus.RetryAvailable:
                                            anyRetryAvailable = true;
                                            continue;
                                        case SACModuleBase.Enums.Captcha.CaptchaStatus.Failed:
                                        case SACModuleBase.Enums.Captcha.CaptchaStatus.CannotSolve:
                                            continue;
                                    }
                                }
                                return new Captcha.CaptchaSolution(anyRetryAvailable, "Something went wrong...", captchaConfig);
                            }
                            else
                            {
                                var reCaptchas = FormMain.ModuleManager.Modules.GetReCaptchaSolvers();
                                if (reCaptchas.Count() < 1)
                                    goto default;

                                var anyRetryAvailable = false;
                                for (int i = 0; i < reCaptchas.Count(); i++)
                                {
                                    var rc = reCaptchas.ElementAt(i);
                                    var rcResponse = rc.Solve(new SACModuleBase.Models.Capcha.ReCaptchaRequest(_siteKey, Defaults.Web.STEAM_JOIN_ADDRESS));
                                    var rcStatus = rcResponse?.Status ?? SACModuleBase.Enums.Captcha.CaptchaStatus.CannotSolve;
                                    if (rcStatus == SACModuleBase.Enums.Captcha.CaptchaStatus.Success)
                                        return new Captcha.CaptchaSolution(rcResponse.Solution, rcResponse?.ToString(), captchaConfig);

                                    switch (rcStatus)
                                    {
                                        case SACModuleBase.Enums.Captcha.CaptchaStatus.RetryAvailable:
                                            anyRetryAvailable = true;
                                            continue;
                                        case SACModuleBase.Enums.Captcha.CaptchaStatus.Failed:
                                        case SACModuleBase.Enums.Captcha.CaptchaStatus.CannotSolve:
                                            continue;
                                    }
                                }
                                return new Captcha.CaptchaSolution(anyRetryAvailable, "Something went wrong...", captchaConfig);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error($"Module solving error.", ex);
                        }
                    }
                    return new Captcha.CaptchaSolution(true, "Something went wrong.", captchaConfig);
                default:
                    {
                        try
                        {
                            var recap = isRecaptcha.HasValue && isRecaptcha.Value;
                            using (var dialog = (recap)
                                ? FormMain.ExecuteInvoke(() => new ReCaptchaDialog(config, FormMain.ProxyManager.Current) as ICaptchaDialog)
                                : new CaptchaDialog(this, updateStatus, config))
                            {
                                var solution = default(Captcha.CaptchaSolution);
                                var dialogResult = DialogResult.None;
                                if (recap)
                                    dialogResult = FormMain.ExecuteInvokeLock(() => dialog.ShowDialog(out solution));
                                else // for image captcha we don't wait other windowses
                                    dialogResult = dialog.ShowDialog(out solution);

                                if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Cancel)
                                {
                                    solution = solution ?? new Captcha.CaptchaSolution(true, "Something went wrong...", config.Captcha);
                                    if (recap)
                                        _captchaGid = (string.IsNullOrEmpty(solution?.Id)) ? _captchaGid : solution?.Id ?? "";

                                    return solution;
                                }
                                else
                                    return new Captcha.CaptchaSolution(false, "Captcha not recognized!", config.Captcha);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Manual captcha error.", ex);
                        }
                    }
                    return new Captcha.CaptchaSolution(true, "Something went wrong.", captchaConfig);
            }
        }

        private int CreateFailedCount = 0;
        public bool CreateAccount(string email, Captcha.CaptchaSolution captcha, Action<string> updateStatus, ref bool stop)
        {
            if (CreateFailedCount >= 3)
            {
                Logger.Warn("FAILED! Current IP seems to be banned. Endless captcha detected.");
                updateStatus?.Invoke("FAILED! Current IP seems to be banned. Endless captcha detected.");
                stop = true;
                return false;
            }

            if (!(captcha?.Solved ?? false))
            {
                Logger.Warn("Captcha not solved. Cannot create account.");
                return false;
            }

            Logger.Debug("Creating account...");

            //Send request again
            SetConfig(Defaults.Web.STEAM_AJAX_VERIFY_EMAIL_URI, Method.POST);
            _request.AddParameter("captchagid", _captchaGid);
            _request.AddParameter("captcha_text", captcha.Solution);
            _request.AddParameter("email", email);

            var response = _client.Execute(_request);
            if (!response.IsSuccessful)
            {
                Logger.Warn($"HTTP Error: {response.StatusCode}");
                updateStatus($"HTTP Error: {response.StatusCode}");
                return false;
            }

            _request.Parameters.Clear();
            try
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                var succesCode = 0;
                try
                {
                    succesCode = (jsonResponse?.success as Newtonsoft.Json.Linq.JValue)?.ToObject<int?>() ?? 0;
                }
                catch (Exception ex)
                {
                    Logger.Error("Cannot get success code.", ex);
                }

                if (jsonResponse.success != 1)
                {
                    switch (succesCode)
                    {
                        case 62:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.SIMILIAR_MAIL}");
                            updateStatus(Error.SIMILIAR_MAIL);
                            stop = true;
                            return false;
                        case 13:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.INVALID_MAIL}");
                            updateStatus(Error.INVALID_MAIL);
                            stop = true;
                            return false;
                        case 17:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.TRASH_MAIL}");
                            updateStatus(Error.TRASH_MAIL);
                            stop = true;
                            return false;
                        case 101: // Please verify your humanity by re-entering the characters below.
                            Logger.Warn("Creating account error: Wrong captcha");
                            updateStatus(Error.WRONG_CAPTCHA);

                            if (captcha.Config != null)
                            {
                                if (captcha.Config.Service == Enums.CaptchaService.RuCaptcha &&
                                    captcha.Config.RuCaptcha.ReportBad)
                                {
                                    TwoCaptchaReport(captcha, false);
                                }
                            }
                            stop = !FormMain.ProxyManager.GetNew();
                            CreateFailedCount++;
                            return false;
                        case 84:
                            {
                                Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.PROBABLY_IP_BAN}");
                                updateStatus(Error.PROBABLY_IP_BAN);
                                stop = !FormMain.ProxyManager.GetNew();
                                CreateFailedCount++;
                            }
                            return false;
                        default:
                            Logger.Warn($"Creating account error: #{jsonResponse.success} / {Error.UNKNOWN}");
                            updateStatus(Error.UNKNOWN);
                            stop = !FormMain.ProxyManager.GetNew();
                            CreateFailedCount++;
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

            SetConfig(Defaults.Web.STEAM_AJAX_CHECK_VERIFIED_URI, Method.POST);
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
                    shouldRetry = FormMain.ProxyManager.GetNew();
                    break;
            }
            return false;
        }

        public bool CompleteSignup(string alias, string password,
            Action<string> updateStatus,
            ref long steamId, ref int gamesNotAdded,
            IEnumerable<Models.GameInfo> addThisGames,
            Models.ProfileConfig profileConfig)
        {
            Logger.Trace("Creating account: compliting signup...");

            if (!CheckAlias(alias, updateStatus))
                return false;
            if (!CheckPassword(password, alias, updateStatus))
                return false;

            SetConfig(Defaults.Web.STEAM_CREATE_ACCOUNT_URI, Method.POST);
            _request.AddParameter("accountname", alias);
            _request.AddParameter("password", password);
            _request.AddParameter("creation_sessionid", _sessionId);
            _request.AddParameter("count", "1");
            _request.AddParameter("lt", "0");

            var response = _client.Execute(_request);

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            if (jsonResponse.bSuccess == "true")
            {
                Logger.Debug("Creating account: Account created");
                updateStatus?.Invoke("Account created");
                //disable guard
                Logger.Debug("Creating account: Disabling guard");
                _client.FollowRedirects = false;
                SetConfig("https://store.steampowered.com/twofactor/manage", Method.POST);
                _request.AddParameter("action", "none");
                _request.AddParameter("sessionid", _sessionId);
                _request.AddParameter("none_authenticator_check", "on");
                var response1 = _client.Execute(_request);
                var sessionId = "";

                var cookies = _cookieJar.GetCookies(new Uri("https://store.steampowered.com/"));
                foreach (Cookie cookie in cookies)
                {
                    _cookieJar.Add(new Uri("https://steamcommunity.com"), cookie);

                    if (cookie.Name.ToLower() == "sessionid")
                    {
                        sessionId = cookie?.Value ?? "";
                    }
                }

                if (string.IsNullOrEmpty(sessionId))
                {
                    Logger.Warn($"SessionID cookie not found for: {alias}");
                    updateStatus?.Invoke("Account seems created but SessionID cookie not found. Cannot disable guard, add game(s), set profile.");
                    return true;
                }

                SetConfig("https://store.steampowered.com/twofactor/manage_action", Method.POST);
                _request.AddParameter("action", "actuallynone");
                _request.AddParameter("sessionid", sessionId);
                var response11 = _client.Execute(_request);
                _client.FollowRedirects = true;

                var _steamIdRegex = SteamProfileRegex.Match(response1?.Content ?? "");
                if (!_steamIdRegex.Success)
                    _steamIdRegex = SteamProfileRegex.Match(response11?.Content ?? "");

                if (_steamIdRegex.Success)
                {
                    Logger.Trace($"Creating account: SteamID64 found ({_steamIdRegex.Groups[1].Value}).");
                    steamId = long.Parse(_steamIdRegex.Groups[1].Value);
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
                        _request.AddParameter("sessionid", sessionId);
                        var responce111 = _client.Execute(_request);
                        _client.FollowRedirects = true;

                        addSuccess = Regex.IsMatch(responce111?.Content ?? "", $"steam://subscriptioninstall/{game.SubId}", RegexOptions.IgnoreCase);
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

                if ((profileConfig?.Enabled ?? false) && steamId > 0)
                {
                    Logger.Debug("Updating profile info...");
                    updateStatus("Updating profile info...");

                    var profCli = new RestClient("https://steamcommunity.com")
                    {
                        CookieContainer = _cookieJar
                    };
                    var profReq = new RestRequest($"/profiles/{steamId}/edit", Method.POST);
                    profReq.AddHeader("Referer", $"https://steamcommunity.com/profiles/{steamId}/edit?welcomed=1");
                    profReq.AddParameter("sessionID", sessionId);
                    profReq.AddParameter("type", "profileSave");
                    profReq.AddParameter("personaName", profileConfig.Name);
                    profReq.AddParameter("real_name", profileConfig.RealName);
                    profReq.AddParameter("country", profileConfig.Country);
                    profReq.AddParameter("state", profileConfig.State);
                    profReq.AddParameter("city", profileConfig.City);
                    if (profileConfig.Url)
                        profReq.AddParameter("customURL", alias);
                    profReq.AddParameter("summary", profileConfig.Bio);

                    var profRes = profCli.Execute(profReq);

                    if (System.IO.File.Exists(profileConfig?.Image ?? ""))
                    {
                        var imageInfo = new FileInfo(profileConfig.Image);
                        if (imageInfo.Length <= MainForm.PHOTO_MAX_SIZE)
                        {
                            Logger.Debug("Uploading image...");
                            updateStatus("Uploading image...");

                            var photoReq = new RestRequest("/actions/FileUploader", Method.POST, DataFormat.Json)
                            {
                                JsonSerializer = new RestSharp.Serializers.Newtonsoft.Json.NewtonsoftJsonSerializer()
                            };

                            photoReq.AddParameter("MAX_FILE_SIZE", $"{MainForm.PHOTO_MAX_SIZE}");
                            photoReq.AddParameter("type", "player_avatar_image");
                            photoReq.AddParameter("sId", $"{steamId}");
                            photoReq.AddParameter("sessionid", $"{sessionId}");
                            photoReq.AddParameter("doSub", "1");
                            photoReq.AddParameter("json", "1");
                            photoReq.AddFile("avatar", imageInfo.FullName);

                            var resp = profCli.Execute<Models.Steam.UploadProfileImage>(photoReq);
                            var imgUploadOk = resp?.Data?.Success ?? false;
                            if (imgUploadOk)
                                Logger.Debug("Uploading image done!");
                            else
                                Logger.Debug("Something went wrong with uloading image");
                        }
                    }

                    Logger.Debug("Updating profile info done!");
                }

                Logger.Debug("Creating account: done!");
                return true;
            }
            Logger.Debug($"Creating account: {jsonResponse.details}");
            updateStatus?.Invoke((jsonResponse.details as object)?.ToString() ?? "Accounts seems to be created but something broken...");
            return false;
        }

        private bool CheckAlias(string alias, Action<string> statusUpdate)
        {
            Logger.Debug("Checking alias (login)...");

            var tempClient = new RestClient(Defaults.Web.STEAM_CHECK_AVAILABLE_URI);
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

        private bool CheckPassword(string password, string alias, Action<string> updateStatus)
        {
            Logger.Debug("Checking password...");

            var tempClient = new RestClient(Defaults.Web.STEAM_CHECK_AVAILABLE_PASSWORD_URI)
            {
                CookieContainer = _cookieJar,
                Proxy = FormMain?.ProxyManager?.WebProxy
            };
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
