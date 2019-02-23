using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using SteamAccCreator.Gui;
using Image = System.Drawing.Image;

namespace SteamAccCreator.Web
{
    public class HttpHandler
    {
        public CookieContainer _cookieJar = new CookieContainer();

        private readonly RestClient _client = new RestClient();

        private readonly RestRequest _request = new RestRequest();
        private readonly MainForm _formreq = new MainForm();

        private string _captchaGid = string.Empty;
        private string _sessionId = string.Empty;

        public bool UseProxy { get; set; }

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
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }

        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
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

        private string GetMD5()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }
        public string[] GetCaptchaImage(ref string _status,bool usetwocap = false)
        {
            string[] sols = { "" };

            _status = "Getting Captcha...";
          //  mainForm.UpdateStatus();

            //load Steam page
            _client.BaseUrl = JoinUri;
            if (_formreq.proxy == true)
            {
                _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
            }
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
            if (_formreq.proxy == true)
            {
                _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
            }
           
            string finalpayload = "";
            for(int i = 0;i<1;i++)
            {
                _status = "Getting Captcha.. "+(i/10)*100+"%";
               // mainForm.UpdateStatus(_index, _status);

                var captchaResponse = _client.DownloadData(_request);
                string cap1 = getbasefromimage(captchaResponse);
     
                    finalpayload = cap1;

            }
            _status = "Recognizing Captcha!";
            if (usetwocap)
            {
                _client.BaseUrl = new Uri("http://2captcha.com");
                var srequest = new RestSharp.RestRequest("in.php", RestSharp.Method.POST);
                srequest.AddParameter("key", MainForm.twocapkey);
                srequest.AddParameter("body", "data:image/jpg;base64," + finalpayload);
                srequest.AddParameter("method", "base64");
                srequest.AddParameter("soft_id", "2370");
                srequest.AddParameter("json", "0");

                var responsecapx = _client.Execute(srequest);
                var respp = responsecapx.Content.Split(new string[] { "|" }, StringSplitOptions.None);
                if (respp[0] != "OK")
                {
                    MessageBox.Show(responsecapx.Content);
                    return sols;
                }
                else
                {
                    
                    try
                    {
                        var id = respp[1];
                        srequest.Parameters.Clear();
                        Thread.Sleep(10000);
                        _client.BaseUrl = new Uri("http://2captcha.com");
                        srequest = new RestSharp.RestRequest("res.php", RestSharp.Method.POST);
                        srequest.AddParameter("key", MainForm.twocapkey);
                        srequest.AddParameter("action", "get");
                        srequest.AddParameter("id",id);
                        srequest.AddParameter("soft_id", "2370");
                        srequest.AddParameter("json", "0");
                        responsecapx = _client.Execute(srequest);
                        respp = responsecapx.Content.Split(new string[] { "|" }, StringSplitOptions.None);
                        if (respp[0] != "OK")
                        {
                            Thread.Sleep(6000);
                            _client.BaseUrl = new Uri("http://2captcha.com");
                            srequest = new RestSharp.RestRequest("res.php", RestSharp.Method.POST);
                            srequest.AddParameter("key", MainForm.twocapkey);
                            srequest.AddParameter("action", "get");
                            srequest.AddParameter("id", id);
                            srequest.AddParameter("soft_id", "2370");
                            srequest.AddParameter("json", "0");
                            responsecapx = _client.Execute(srequest);
                            respp = responsecapx.Content.Split(new string[] { "|" }, StringSplitOptions.None);
                            if (respp[0] != "OK")
                            {
                                return sols;
                            }
                            else
                            {
                                sols[0] = respp[1];
                                return sols;
                            }
                        }else
                        {
                           
                            sols[0] = respp[1];
                            return sols;

                        }

                    }
                    catch (Exception)
                    {
                        return sols;
                    }

                }


            }
            else
            {
                _client.BaseUrl = new Uri("http://api.captchasolutions.com/");
                var request = new RestSharp.RestRequest("solve", RestSharp.Method.POST);
                request.AddParameter("p", "base64");
                request.AddParameter("captcha", "data:image/jpg;base64," + finalpayload);
                request.AddParameter("key", MainForm.apixkey);
                request.AddParameter("secret", MainForm.secxkey);
                request.AddParameter("out", "txt");


                var responsecap = _client.Execute(request);
                string replacement = Regex.Replace(responsecap.Content, @"\t|\n|\r", "");
                if (responsecap.Content == "\n\t\t\t\t\t\t<captchasolutions>\n\t\t\t\t\t\t\t<decaptcha>\n\t\t\t\t\t\t\t\tError: You have 0 balance left in your account.\n\t\t\t\t\t\t\t</decaptcha>\n\t\t\t\t\t\t</captchasolutions>\n\t\t\t\t\t\n\t\n\n\n")
                {
                    MessageBox.Show(responsecap.Content);
                    return sols;

                }
                sols[0] = replacement;
                return sols;
            }


        }

        public string getbasefromimage(byte[] captcha)
        {
            using (var ms = new MemoryStream(captcha))
            {
                using (Image image = Image.FromStream(ms))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            }

        }

        public bool CreateAccount(string email, string[] captchaText, ref string status,int n)
        {
            ;
            _client.BaseUrl = VerifyCaptchaUri;
            if (captchaText == null)
                return false;
            string scaptchaText = captchaText[n];
            if (_formreq.proxy == true)
            {
                _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
            }
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
                if ((captchaText.Length-1) < (n+1))
                    return false;
                else
                     return CreateAccount(email, captchaText, ref status,n+1);
            }

            if (!bEmailAvail)
            {
                //seems to always return true even if email is already in use
                status = Error.EMAIL_ERROR;
                return false;
            }

            //Send request again
            _client.BaseUrl = AjaxVerifyCaptchaUri;
            if (_formreq.proxy == true)
            {
                _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
            }
            _request.AddParameter("captchagid", _captchaGid);
            _request.AddParameter("captcha_text", scaptchaText);
            _request.AddParameter("email", email);

            response = _client.Execute(_request);
            _request.Parameters.Clear();
            //dynamic jsonResponse;
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
                            break;
                    }
                    return false;
                }
               
            
            
           

            _sessionId = jsonResponse.sessionid;
            status = "Waiting for email to be verified";

            }
            catch (Exception)
            {
                
            }

            return true;
        }

        public bool CheckEmailVerified(ref string status)
        {
            _client.BaseUrl = AjaxCheckEmailVerifiedUri;
            if (_formreq.proxy == true)
            {
                _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
            }
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

        public bool CompleteSignup(string alias, string password, ref string status, ref long steamId,bool addcsgo)
        {
            if (!CheckAlias(alias, ref status))
                return false;
            if (!CheckPassword(password, alias, ref status))
                return false;

            _client.BaseUrl = CreateAccountUri;
            if (_formreq.proxy == true)
            {
                _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
            }
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
                status = "Account created";
                //disable guard
                _client.FollowRedirects = false;
                _client.CookieContainer = _cookieJar;
                _client.BaseUrl = new Uri("https://store.steampowered.com/twofactor/manage_action");
                if (_formreq.proxy == true)
                {
                    _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
                }
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
                if (_formreq.proxy == true)
                {
                    _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
                }
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
                if (addcsgo)
                {
                    _client.BaseUrl = new Uri("https://store.steampowered.com/checkout/addfreelicense");
                    if (_formreq.proxy == true)
                    {
                        _client.Proxy = new WebProxy(_formreq.proxyval, _formreq.proxyport);
                    }
                    _request.Method = Method.POST;
                    _request.AddParameter("action", "add_to_cart");
                    _request.AddParameter("subid", 303386);
                    _request.AddParameter("sessionid", sess);
                    var responce111 = _client.Execute(_request);
                    _client.FollowRedirects = true;
                }

                return true;
            }
            status = jsonResponse.details;
            return false;
        }

        private static bool CheckAlias(string alias, ref string status)
        {
            var tempClient = new RestClient(CheckAvailUri);
            var tempRequest = new RestRequest(Method.POST);
            tempRequest.AddParameter("accountname", alias);
            tempRequest.AddParameter("count", "1");

            var response = tempClient.Execute(tempRequest);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            if (jsonResponse.bAvailable == "true")
                return true;
            status = Error.ALIAS_UNAVAILABLE;
            return false;
        }

        private static bool CheckPassword(string password, string alias, ref string status)
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
            status = Error.PASSWORD_UNSAFE;
            return false;
        }


    }
}
