using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Services.MailService
{
    public class DeveloperMessage : Message, IMessage
    {
        public DeveloperMessage(string mailAdressFrom, string subject, string message)
        {
            MailAdressTo = "franti1992@gmail.com";
            MailSubject = subject;
            MailBody = message;
            MailAdressFrom = mailAdressFrom;
        }
    }
}
