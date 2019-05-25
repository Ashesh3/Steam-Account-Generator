using Newtonsoft.Json;
using RestSharp;
using System;
using System.Text.RegularExpressions;

namespace SteamAccCreator.Web
{
    public class MailHandler
    {
        public static Uri MailboxUri = new Uri(Defaults.Mail.MAILBOX_ADDRESS);
        public static bool IsMailBoxCustom = false;

        public static int CheckUserMailVerifyCount = Defaults.Mail.COUNT_OF_CHECKS_MAIL_USER;
        public static int CheckRandomMailVerifyCount = Defaults.Mail.COUNT_OF_CHECKS_MAIL_AUTO;

        private readonly Models.ProxyItem Proxy;
        private readonly bool IsCustomDomain;

        private static readonly Regex RegexToken = new Regex("stoken=([^&$]+)", RegexOptions.IgnoreCase);
        private static readonly Regex RegexCreationId = new Regex("creationid=([^&$]+)", RegexOptions.IgnoreCase);

        public MailHandler(Models.ProxyItem proxy, bool isCustomDomain)
        {
            Proxy = proxy;
            IsCustomDomain = isCustomDomain;
        }

        public void ConfirmMail(string address)
        {
            Logger.Trace($"Confirming mail: {address}");

            System.Threading.Thread.Sleep(5000);

            var _client = new RestClient(MailboxUri);
            var _request = new RestRequest((IsCustomDomain) ? "v2" : "", Method.GET);
            _request.AddParameter("e", address);

            var response = _client.Execute(_request);
            dynamic jsonResponse;
            try
            {
                jsonResponse = JsonConvert.DeserializeObject(response.Content);
            }
            catch (JsonException jEx)
            {
                Logger.Error("Confirming mail: JSON deserialize error.", jEx);

                jsonResponse = "";
                return;
            }
            catch (Exception ex)
            {
                Logger.Error("Confirming mail: Error.", ex);

                jsonResponse = "";
                return;
            }

            var content = jsonResponse.First.ToString() as string;
            var url = GetConfirmUrl(content);
            if (string.IsNullOrEmpty(url))
            {
                Logger.Warn("URL is empty!");
                return;
            }
            if (!ConfirmSteamAccount(url))
                Logger.Warn("Account seems isn't confirmed...");
        }

        public string GetConfirmUrl(string content)
        {
            Logger.Trace("Parsing confirm url...");
            try
            {
                var creationId = RegexCreationId.Match(content);
                var token = RegexToken.Match(content);

                return $"{Defaults.Web.STEAM_ACCOUNT_VERIFY_ADDRESS}?stoken={token.Groups[1].Value}&creationid={creationId.Groups[1].Value}";
            }
            catch (Exception ex)
            {
                Logger.Error($"Parsing confirm url: Error", ex);
            }
            return string.Empty;
        }

        public bool ConfirmSteamAccount(string url)
        {
            var client = new RestClient(url)
            {
                Proxy = Proxy?.ToWebProxy()
            };
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return response.IsSuccessful;
        }
    }
}
