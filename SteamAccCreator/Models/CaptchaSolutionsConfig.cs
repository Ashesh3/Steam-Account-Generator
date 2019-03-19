using System;
using System.Diagnostics;

namespace SteamAccCreator.Models
{
    [Serializable]
    [DebuggerDisplay("{ApiKey}:{ApiSecret}")]
    public class CaptchaSolutionsConfig : RuCaptchaConfig
    {
        public string ApiSecret { get; set; } = "";
    }
}
