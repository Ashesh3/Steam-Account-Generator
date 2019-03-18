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
            _client.BaseUrl = new Uri("http://2captcha.com");
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

        public string[] GetCaptchaImage(ref string _status, Models.CaptchaSolvingConfig captchaConfig)
        {
            _status = "Getting Captcha...";

            //load Steam page
            _client.BaseUrl = JoinUri;
            if (UseProxy)
                _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

            _request.Method = Method.GET;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = _client.Execute(_request);

            //Store captcha ID
            try
            {
                _captchaGid = CaptchaRegex.Matches(response.Content)[0].Groups[1].Value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show(response.Content);
                MessageBox.Show(response.ErrorException.ToString());
                MessageBox.Show(response.StatusCode.ToString());
            }
            //download and return captcha image
            _client.BaseUrl = new Uri(CaptchaUri + _captchaGid);
            if (UseProxy)
                _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

            string finalpayload = "";
            for (int i = 0; i < 1; i++)
            {
                _status = "Getting Captcha.. " + (i / 10) * 100 + "%";
                // mainForm.UpdateStatus(_index, _status);

                var captchaResponse = _client.DownloadData(_request);
                string cap1 = getbasefromimage(captchaResponse);

                finalpayload = cap1;

            }
            _status = "Recognizing Captcha!";

            switch (captchaConfig.Service)
            {
                case Enums.CaptchaService.Captchasolutions:
                    {
                        var _resp = Captchasolutions("solve",
                            new Dictionary<string, object>()
                            {
                                { "p", "base64" },
                                { "captcha", $"data:image/jpg;base64,{finalpayload}" },
                                { "key", captchaConfig.CaptchaSolutions.ApiKey },
                                { "secret", captchaConfig.CaptchaSolutions.ApiSecret },
                                { "out", "txt" },
                            });

                        if (Regex.IsMatch(_resp, @"Error:\s(.+)", RegexOptions.IgnoreCase))
                        {
                            MessageBox.Show(_resp);
                            return new[] { "" };
                        }

                        return new[] { Regex.Replace(_resp, @"\t|\n|\r", "") };
                    }
                case Enums.CaptchaService.RuCaptcha:
                    {
                        try
                        {
                            var _resp = TwoCaptcha("in.php",
                                new Dictionary<string, object>()
                                {
                                { "key", captchaConfig.RuCaptcha.ApiKey },
                                { "body", $"data:image/jpg;base64,{finalpayload}" },
                                { "method", "base64" },
                                { "soft_id", "2370" },
                                { "json", "0" },
                                });

                            if (_resp[0] != "OK")
                            {
                                MessageBox.Show(string.Join("|", _resp));
                                return new[] { "" };
                            }

                            Thread.Sleep(10000);
                            _resp = TwoCaptcha("res.php",
                                new Dictionary<string, object>()
                                {
                                { "key", captchaConfig.RuCaptcha.ApiKey },
                                { "action", "get" },
                                { "id", _resp[1] },
                                { "soft_id", "2370" },
                                { "json", "0" },
                                });

                            if (_resp[0] == "OK")
                                return new[] { "" };

                            Thread.Sleep(6000);
                            _resp = TwoCaptcha("res.php",
                                new Dictionary<string, object>()
                                {
                                { "key", captchaConfig.RuCaptcha.ApiKey },
                                { "action", "get" },
                                { "id", _resp[1] },
                                { "soft_id", "2370" },
                                { "json", "0" },
                                });

                            if (_resp[0] != "OK")
                                return new string[0];

                            return new[] { _resp[1] };
                        }
                        catch
                        {
                            return new[] { "" };
                        }
                    }
                case Enums.CaptchaService.Unknown:
                default:
                    {
                        using (var dialog = new CaptchaDialog(this, ref _status, captchaConfig))
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                                return new[] { dialog.txtCaptcha.Text };
                        }
                    }
                    break;
            }

            return new[] { "" };
        }

        public string getbasefromimage(byte[] captcha)
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

        public bool CreateAccount(string email, string[] captchaText, ref string status, int n, ref bool stop)
        {
            _client.BaseUrl = VerifyCaptchaUri;
            if (captchaText == null)
                return false;
            string scaptchaText = captchaText[n];
            if (UseProxy)
                _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

            _request.Method = Method.POST;
            _request.AddParameter("captchagid", _captchaGid);
            _request.AddParameter("captcha_text", scaptchaText);
            _request.AddParameter("email", email);
            _request.AddParameter("count", "1");
            var response = _client.Execute(_request);

            _request.Parameters.Clear();

            if (!response.IsSuccessful)
            {
                status = Error.HTTP_FAILED;
                //return false;
            }

            var matches = BoolRegex.Matches(response.Content);
            var bCaptchaMatches = bool.Parse(matches[0].Value);
            var bEmailAvail = bool.Parse(matches[1].Value);

            if (!bCaptchaMatches)
            {
                status = Error.WRONG_CAPTCHA;
                if ((captchaText.Length - 1) < (n + 1))
                    return false;
                else
                    return CreateAccount(email, captchaText, ref status, n + 1, ref stop);
            }

            if (!bEmailAvail)
            {
                //seems to always return true even if email is already in use
                status = Error.EMAIL_ERROR;
                stop = true;
                return false;
            }

            //Send request again
            _client.BaseUrl = AjaxVerifyCaptchaUri;
            if (UseProxy)
                _client.Proxy = new WebProxy(ProxyHost, ProxyPort);

            _request.AddParameter("captchagid", _captchaGid);
            _request.AddParameter("captcha_text", scaptchaText);
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
                            status = Error.SIMILIAR_MAIL;
                            break;
                        case 13:
                            status = Error.INVALID_MAIL;
                            break;
                        case 17:
                            status = Error.TRASH_MAIL;
                            break;
                        default:
                            status = Error.UNKNOWN;
                            stop = true;
                            break;
                    }
                    return false;
                }

                _sessionId = jsonResponse.sessionid;
                status = "Waiting for email to be verified";
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

        public bool CompleteSignup(string alias, string password, Action<string> updateStatus, ref long steamId, IEnumerable<Models.GameInfo> addThisGames)
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
                foreach (var game in addThisGames)
                {
                    if (game == null)
                        continue;

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
