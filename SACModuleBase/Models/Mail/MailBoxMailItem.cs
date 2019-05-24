namespace SACModuleBase.Models.Mail
{
    public class MailBoxMailItem
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }

        public MailBoxMailItem(string from, string to, string title, string body)
        {
            From = from;
            To = to;
            Title = title;
            Body = body;
        }
    }
}
