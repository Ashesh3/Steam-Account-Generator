using System;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class CaptchaSolutionsConfig : RuCaptchaConfig
    {
        public string ApiSecret { get; set; } = "";
    }
}
