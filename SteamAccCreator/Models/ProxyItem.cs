using Newtonsoft.Json;
using pYove;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class ProxyItem
    {
        public bool Enabled { get; set; } = false;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 0;
        public Enums.ProxyType ProxyType { get; set; } = Enums.ProxyType.Unknown;
        [JsonIgnore]
        public Enums.ProxyStatus Status { get; set; } = Enums.ProxyStatus.Unknown;

        public string UserName { get; set; }
        public string Password { get; set; }

        public ProxyItem(string plain)
        {
            var match = Regex.Match(plain, @"((http[s]?|socks[45]?)\:\/\/)?(([^:]+)\:([^@]+)\@)?([^:]+)\:(\d+)[\/$]?", RegexOptions.IgnoreCase);
            if (!match.Success)
                throw new Exception("Cannot parse this proxy!");

            Enabled = true;

            UserName = match.Groups[4].Value;
            Password = match.Groups[5].Value;

            Host = match.Groups[6].Value;
            Port = int.Parse(match.Groups[7].Value);
            if (Port < 0) Port = 0;
            if (Port > 65535) Port = 65535;

            var type = match.Groups[2].Value.ToLower();
            switch (type)
            {
                case "http":
                    ProxyType = Enums.ProxyType.Http;
                    break;
                case "https":
                    ProxyType = Enums.ProxyType.Https;
                    break;
                case "socks4":
                    ProxyType = Enums.ProxyType.Socks4;
                    break;
                case "socks":
                case "socks5":
                    ProxyType = Enums.ProxyType.Socks5;
                    break;
            }
        }
        public ProxyItem(string host, int port, Enums.ProxyType type)
            : this(host, port, type, null, null) { }
        public ProxyItem(string host, int port, Enums.ProxyType type, string user, string password)
        {
            Enabled = true;
            Host = host;
            Port = port;
            ProxyType = type;
            UserName = user;
            Password = password;
        }

        public IWebProxy ToWebProxy()
        {
            var credentials = default(ICredentials);
            if (!string.IsNullOrEmpty(UserName) &&
                !string.IsNullOrEmpty(Password))
            {
                credentials = new NetworkCredential(UserName, Password);
            }

            if (Port < 0) Port = 0;
            if (Port > 65535) Port = 65535;

            switch (ProxyType)
            {
                case Enums.ProxyType.Socks4:
                    return new ProxyClient(Host, Port, pYove.ProxyType.Socks4) { Credentials = credentials };
                case Enums.ProxyType.Socks5:
                    return new ProxyClient(Host, Port, pYove.ProxyType.Socks5) { Credentials = credentials };
                case Enums.ProxyType.Http:
                case Enums.ProxyType.Https:
                case Enums.ProxyType.Unknown:
                default:
                    return new WebProxy(Host, Port) { Credentials = credentials };
            }
        }
    }
}
