using System;
using System.Diagnostics;

namespace SteamAccCreator.Models
{
    [Serializable]
    [DebuggerDisplay("{ApiKey}")]
    public class RuCaptchaConfig
    {
        public string ApiKey { get; set; } = "";
    }
}
