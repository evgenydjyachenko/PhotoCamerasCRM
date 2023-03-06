
using CamerasDb.Model;
using CamerasDb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CamerasDb.View
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"RegistrationTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            this.WindowState = System.Windows.Forms.FormWindowState.Normal;

            access_ComboBox.SelectedIndex = 0;
        }
        private void Clear()
        {
            access_ComboBox.SelectedIndex = 0;
            userName_TextBox.Text = "";
            userSureName_TextBox.Text = "";
            email_TextBox.Text = "";
        }

        private async void sendToEmail_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (await AccountService.Instance.Registration(userName_TextBox.Text, userSureName_TextBox.Text, email_TextBox.Text, access_ComboBox.SelectedItem.ToString()) == true)
                {
                    MessageBox.Show($"На эл.адрес {email_TextBox.Text} было отправлено письмо с логином и паролем для доступа в приложение. " +
                   $"Если Вы не получили письмо, проверьте раздел 'спам' или попробуйте еще раз.", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Ошибка ввода данных!", "Сообщение");
                }
                            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }                       
        }
    }
}
