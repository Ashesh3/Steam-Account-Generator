using System;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class ProxyConfig
    {
        public bool Enabled { get; set; }
        public string Host { get; set; }
        public int Port { get; set; } = 1;
    }
}
