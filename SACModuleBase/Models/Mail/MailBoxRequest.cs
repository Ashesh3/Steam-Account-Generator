using System.Net;

namespace SACModuleBase.Models.Mail
{
    public class MailBoxRequest
    {
        public string Login { get; private set; }
        public IWebProxy Proxy { get; private set; }

        public MailBoxRequest(string login, IWebProxy proxy)
        {
            Login = login;
            Proxy = proxy;
        }
    }
}
