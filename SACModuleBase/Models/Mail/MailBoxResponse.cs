namespace SACModuleBase.Models.Mail
{
    public class MailBoxResponse
    {
        public string Email { get; private set; }

        public MailBoxResponse(string email)
        {
            Email = email;
        }
    }
}
