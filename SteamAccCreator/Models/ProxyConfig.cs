using System;
using System.Collections.Generic;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class ProxyConfig
    {
        public bool Enabled { get; set; } = false;
        public IEnumerable<ProxyItem> List { get; set; } = new ProxyItem[0];
    }
}
