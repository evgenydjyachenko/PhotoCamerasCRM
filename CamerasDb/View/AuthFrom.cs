using CamerasDb.Model;
using CamerasDb.Services;
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

namespace CamerasDb
{
    public partial class AuthFrom : Form
    {
        public AuthFrom()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"AuthorizationTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        
            this.Load +=AuthFrom_Load;
            auth_Button.Click +=Auth_Button_Click;           
        }

        private async void AuthFrom_Load(object sender, EventArgs e)
        {           
        }

        private async void Auth_Button_Click(object sender, EventArgs e)
        {
            //await Task.Run(() =>
            //{
            //    new LoadForm().Show();
            //});
            try
            {
                await AuthService.Instance.Login(login_TextBox, password_TextBox);
                login_TextBox.Text = password_TextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }      
        }

        private void registration_Button_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            if (new RegistrationForm().ShowDialog() == DialogResult.Cancel)
            {
                login_TextBox.Text = password_TextBox.Text = "";
                this.Visible = true;
            }
        }
    }
}
