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
            try
            {
                string dataxx = jsonResponse.First.ToString();
                string[] words = (Regex.Split(dataxx, "stoken="));
                string[] words9 = (Regex.Split(words[1], "&"));
                string[] words1 = (Regex.Split(dataxx, "creationid="));
                string[] words2 = Regex.Split(words1[1], " ");
                var tokenUri = "stoken=" + words9[0] + "&creationid=" + words2[0];
                ConfirmSteamAccount($"{Defaults.Web.STEAM_ACCOUNT_VERIFY_ADDRESS}?{tokenUri}");

                Logger.Trace("Confirming mail: done?");
            }
            catch (Exception ex)
            {
                Logger.Error($"Confirming mail: Error", ex);
            }
        }

        private void ConfirmSteamAccount(string url)
        {
            var client = new RestClient(url)
            {
                Proxy = Proxy?.ToWebProxy()
            };
            var request = new RestRequest(Method.GET);
            client.Execute(request);
        }
    }
}
