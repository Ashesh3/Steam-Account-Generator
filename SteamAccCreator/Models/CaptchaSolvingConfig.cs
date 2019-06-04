using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace SteamAccCreator.Models
{
    [Serializable]
    [DebuggerDisplay("Service")]
    public class CaptchaSolvingConfig
    {
        [JsonIgnore]
        public bool Enabled => Service != Enums.CaptchaService.None;
        public Enums.CaptchaService Service { get; set; }
        [JsonIgnore]
        public int ServiceIndex
        {
            get => ((int)Service) + 1;
            set => Service = (Enums.CaptchaService)(value - 1);
        }
        public CaptchaSolutionsConfig CaptchaSolutions { get; set; } = new CaptchaSolutionsConfig();
        public RuCaptchaConfig RuCaptcha { get; set; } = new RuCaptchaConfig();
    }
}
