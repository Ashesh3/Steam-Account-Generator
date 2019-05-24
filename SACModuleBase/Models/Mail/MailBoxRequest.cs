namespace SACModuleBase.Models.Mail
{
    public class MailBoxRequest
    {
        public string Login { get; private set; }

        public MailBoxRequest(string login)
        {
            Login = login;
        }
    }
}
