using SACModuleBase.Models.Mail;
using System.Collections.Generic;

namespace SACModuleBase
{
    public interface ISACHandlerMailBox
    {
        MailBoxResponse GetMailBox(MailBoxRequest request);
        IReadOnlyCollection<MailBoxMailItem> GetMails(MailBoxResponse response);
    }
}
