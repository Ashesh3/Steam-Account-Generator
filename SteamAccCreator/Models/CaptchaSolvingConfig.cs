using System;
using System.Diagnostics;

namespace SteamAccCreator.Models
{
    [Serializable]
    [DebuggerDisplay("on={Enabled}|hand={HandMode}|service={Service}")]
    public class CaptchaSolvingConfig
    {
        public bool Enabled { get; set; } = false;
        public bool HandMode { get; set; } = false;
        public Enums.CaptchaService Service { get; set; }
        public CaptchaSolutionsConfig CaptchaSolutions { get; set; } = new CaptchaSolutionsConfig();
        public RuCaptchaConfig RuCaptcha { get; set; } = new RuCaptchaConfig();
    }
}
