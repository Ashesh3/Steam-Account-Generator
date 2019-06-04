using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModule
{
    public static class Misc
    {
        public static object CaptchaConfigSync = new object(); // for sync config across all parts of module
        public static object MailBoxConfigSync = new object();

        public static string[] TwoCaptcha(string resource, Dictionary<string, object> args)
        {
            var _client = new RestClient("http://2captcha.com/");
            var srequest = new RestRequest(resource, Method.POST);
            foreach (var key in args)
            {
                srequest.AddParameter(key.Key, key.Value);
            }
            var responsecap = _client.Execute(srequest);
            return responsecap.Content.Split(new string[] { "|" }, StringSplitOptions.None);
        }
    }
}
