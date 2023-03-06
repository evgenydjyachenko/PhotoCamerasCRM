using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services.MailService
{
    public class RegistrationMessage:Message, IMessage
    {
        public RegistrationMessage(string name, string surename, string login, string password)
        {
            MailSubject = "Регистрация в приложении CamerasDb!";
            MailBody = $"Здравствуйте, {name} {surename}!\nВаш логин: {login} пароль: {password}";
        }       
    }
}
