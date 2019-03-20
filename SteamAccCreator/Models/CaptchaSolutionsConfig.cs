using System;
using System.Diagnostics;

namespace SteamAccCreator.Models
{
    [Serializable]
    [DebuggerDisplay("{ApiKey}:{ApiSecret}")]
    public class CaptchaSolutionsConfig
    {
        public string ApiKey { get; set; } = "";
        public string ApiSecret { get; set; } = "";
    }
}
