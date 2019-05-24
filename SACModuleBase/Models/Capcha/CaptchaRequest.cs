namespace SACModuleBase.Models.Capcha
{
    public class CaptchaRequest
    {
        /// <summary>
        /// Base64 image
        /// </summary>
        public string CaptchaImage { get; private set; }

        public CaptchaRequest(string captchaImage)
        {
            CaptchaImage = captchaImage;
        }
    }
}
