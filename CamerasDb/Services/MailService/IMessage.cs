using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Services.MailService
{
    public interface IMessage
    {
        string MailAdressFrom { get; set; }
        string MailAdressTo { get; set; }
        string MailSubject { get; set; }
        string MailBody { get; set; }
    }
}
