using System;
using System.Collections.Generic;

namespace SteamAccCreator.Models
{
    [Serializable]
    public class Configuration
    {
        public MailConfig Mail { get; set; } = new MailConfig();
        public CredentialConfig Login { get; set; } = new CredentialConfig();
        public CredentialConfig Password { get; set; } = new CredentialConfig();
        public GamesConfig Games { get; set; } = new GamesConfig();
        public ProfileConfig Profile { get; set; } = new ProfileConfig();
        public CaptchaSolvingConfig Captcha { get; set; } = new CaptchaSolvingConfig();
        public OutputConfig Output { get; set; } = new OutputConfig();
        public ProxyConfig Proxy { get; set; } = new ProxyConfig();

        public void FixNulls()
        {
            Mail = Mail ?? new MailConfig();
            Login = Login ?? new CredentialConfig();
            Password = Password ?? new CredentialConfig();
            Games = Games ?? new GamesConfig();
            Profile = Profile ?? new ProfileConfig();
            Captcha = Captcha ?? new CaptchaSolvingConfig();
            Output = Output ?? new OutputConfig();
            Proxy = Proxy ?? new ProxyConfig();
        }

        public Configuration Clone()
            => this.DeepClone();
    }
}
