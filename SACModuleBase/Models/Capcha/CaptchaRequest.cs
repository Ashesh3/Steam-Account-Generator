using System.Net;

namespace SACModuleBase.Models.Capcha
{
    public class CaptchaRequest
    {
        /// <summary>
        /// Base64 image
        /// </summary>
        public string CaptchaImage { get; private set; }
        public IWebProxy Proxy { get; private set; }

        public CaptchaRequest(string captchaImage, IWebProxy proxy)
        {
            CaptchaImage = captchaImage;
            Proxy = proxy;
        }
    }
}
