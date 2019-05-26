using MailKit.Net.Imap;
using SACModuleBase.Models;
using SACModuleBase.Models.Mail;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace SampleModule
{
    [Guid("C89C87D9-D9FE-447B-85A6-92203F0C3397")]
    public class MailBox : SACModuleBase.ISACHandlerMailBox
    {
        private const string IMAP_HOST = "imap.rambler.ru";
        private const int IMAP_PORT = 993;
        private const bool IMAP_SSL = true;
        private const string IMAP_AUTH_LOGIN = ""; // mail
        private const string IMAP_AUTH_PASSW = ""; // password

        public bool ModuleEnabled { get; set; } = true;
        public string ModuleName => "IMAP rambler mail handler";
        public Version ModuleVersion => new Version("1.0.0.0");

        public MailBoxResponse GetMailBox(MailBoxRequest request)
            => new MailBoxResponse(IMAP_AUTH_LOGIN);

        public IReadOnlyCollection<MailBoxMailItem> GetMails(MailBoxResponse response)
        {
            var mails = new List<MailBoxMailItem>();
            using (var client = new ImapClient())
            {
                client.Connect(IMAP_HOST, IMAP_PORT, IMAP_SSL);
                client.Authenticate(IMAP_AUTH_LOGIN, IMAP_AUTH_PASSW);

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
            return new ReadOnlyCollection<MailBoxMailItem>(mails);
        }

        public void ModuleInitialize(SACInitialize initialize) { }
    }
}
