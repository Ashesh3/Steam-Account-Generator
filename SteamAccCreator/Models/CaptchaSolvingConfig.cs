namespace SteamAccCreator.Models
{
    public class CaptchaSolvingConfig
    {
        public bool Enabled { get; set; }
        public bool HandMode { get; set; }
        public Enums.CaptchaService Service { get; set; }
        public CaptchaSolutionsConfig CaptchaSolutions { get; set; } = new CaptchaSolutionsConfig();
        public RuCaptchaConfig RuCaptcha { get; set; } = new RuCaptchaConfig();
    }
}
