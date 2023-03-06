using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Services.MailService
{
    public abstract class Message
    {
        public string MailAdressFrom { get; set; } = "frantivn@djyachenko.ru";
        public string MailAdressTo { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
    }
}
