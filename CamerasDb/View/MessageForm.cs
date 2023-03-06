using CamerasDb.Model;
using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services.MailService
{
    public partial class MessageForm : Form
    {       
        public MessageForm()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"MessageTheme.JPG");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.FormClosing+=MessageForm_FormClosing;
        }

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new DirectorForm(new Director()).ShowDialog();
        }

        private async void sendMessage_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if ((subjectMessage_TextBox.Text != "" && subjectMessage_TextBox.Text != "Введите свой адрес эл.почты...")
                && (messageBody_TextBox.Text != "" && messageBody_TextBox.Text != "Введите сообщение...")
                && mailAdress_TextBox.Text != "" && mailAdress_TextBox.Text != "Введите свой адрес эл.почты...")
                {
                    DeveloperMessage developerMessage = new DeveloperMessage(mailAdress_TextBox.Text, subjectMessage_TextBox.Text, messageBody_TextBox.Text);
                    if (await MailSenderService.Send(developerMessage) == true)
                    {
                        MessageBox.Show("Письмо успешно отправлено! Спасибо за обратную связь :)", "Сообщение");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }         
        }
    }
}
