using System;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class CredentialConfig
    {
        public bool Random { get; set; }
        public bool Neat { get; set; }
        public string Value { get; set; }
    }
}
