using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Services.MailService
{
    public class MailSenderService
    {
        public static async Task<bool> Send(IMessage message)
        {
            try
            {
                MailAddress mailAdressFrom = new MailAddress(message.MailAdressFrom);
                MailAddress mailAdressTo = new MailAddress(message.MailAdressTo);
                MailMessage mailMessage = new MailMessage(mailAdressFrom, mailAdressTo);
                mailMessage.Subject = message.MailSubject;
                mailMessage.Body = message.MailBody;

                SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                client.Credentials = new NetworkCredential(message.MailAdressFrom, "ljhrppygwbeexmiz");
                client.EnableSsl = true;
                await Task.Run(() =>
                {
                    client.Send(mailMessage);

                });
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
