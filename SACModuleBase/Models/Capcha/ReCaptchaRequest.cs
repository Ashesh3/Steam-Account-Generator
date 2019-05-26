namespace SACModuleBase.Models.Capcha
{
    public class ReCaptchaRequest
    {
        /// <summary>
        /// ReCaptcha page URL
        /// </summary>
        public string Url { get; private set; }
        /// <summary>
        /// ReCaptcha site-key
        /// </summary>
        public string SiteKey { get; private set; }

        public ReCaptchaRequest(string siteKey, string url)
        {
            Url = url;
            SiteKey = siteKey;
        }
    }
}
