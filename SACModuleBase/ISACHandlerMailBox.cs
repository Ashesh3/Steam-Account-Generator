using SACModuleBase.Models.Mail;
using System.Collections.Generic;

namespace SACModuleBase
{
    public interface ISACHandlerMailBox : ISACBase
    {
        MailBoxResponse GetMailBox(MailBoxRequest request);
        IReadOnlyCollection<MailBoxMailItem> GetMails(MailBoxResponse response);
    }
}
