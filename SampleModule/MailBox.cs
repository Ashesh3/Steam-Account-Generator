using MailKit.Net.Imap;
using SACModuleBase.Attributes;
using SACModuleBase.Models;
using SACModuleBase.Models.Mail;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleModule
{
    [SACModuleInfo("C89C87D9-D9FE-447B-85A6-92203F0C3397", "IMAP mail handler", "1.0.0.0")]
    public class MailBox : SACModuleBase.ISACHandlerMailBox
    {
        public bool ModuleEnabled { get; set; } = true;

        private ConfigManager<Models.MailConfig> Config;
        public void ModuleInitialize(SACInitialize initialize)
        {
            Config = new ConfigManager<Models.MailConfig>(initialize.ConfigurationPath, "mail.json",
                new Models.MailConfig(), Misc.MailBoxConfigSync);
            if (!Config.Load())
                Config.Save();
        }

        public MailBoxResponse GetMailBox(MailBoxRequest request)
        {
            if (!Config.Load())
            {
                Config.Save();
                return null;
            }
            return new MailBoxResponse(Config.Running.Email);
        }

        public IReadOnlyCollection<MailBoxMailItem> GetMails(MailBoxResponse response)
        {
            var mails = new List<MailBoxMailItem>();
            if (Config.Load())
            {
                using (var client = new ImapClient())
                {
                    client.Connect(Config.Running.Host, Config.Running.Port, Config.Running.UseSsh);
                    client.Authenticate(Config.Running.Email, Config.Running.Password);

                    var inbox = client.Inbox;
                    inbox.Open(MailKit.FolderAccess.ReadWrite);
                    var unreadIndex = inbox.FirstUnread;
                    if (unreadIndex > 0)
                    {
                        var inboxMail = inbox.GetMessage(unreadIndex);
                        inbox.SetFlags(unreadIndex, MailKit.MessageFlags.Seen, true);
                        var mail = new MailBoxMailItem(inboxMail.From?.FirstOrDefault()?.Name ?? "unknown",
                            inboxMail.To?.FirstOrDefault()?.Name ?? "unknown",
                            inboxMail.Subject ?? "none",
                            inboxMail.HtmlBody ?? inboxMail.TextBody ?? "none");
                        mails.Add(mail);
                    }
                }
            }
            return new ReadOnlyCollection<MailBoxMailItem>(mails);
        }
    }
}
