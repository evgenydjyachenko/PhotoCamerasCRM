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

namespace CamerasDb.View.Admin
{
    public partial class AddUserForm : Form
    {
        IUser user;
        public AddUserForm(IUser user)
        {
            InitializeComponent();
            this.user = user;
            pictureBox1.Image = new Bitmap(@"UserTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Load +=AddUserForm_Load;
            CheckUser();
            access_ComboBox.SelectedIndex = 0;
        }

        private void CheckUser()
        {
            access_ComboBox.Items.Clear();
            if (user is Managerr manager)
            {
                access_ComboBox.Items.Add("Менеджер");
            }
            else if (user is Worker worker)
            {
                access_ComboBox.Items.Add("Работник");
            }
            else
            {
                MessageBox.Show("Ошибка выбора пользователя!", "Ошибка");
            }
        }

        private async void addUser_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (await AccountService.Instance.Registration(userName_TextBox.Text, userSureName_TextBox.Text, email_TextBox.Text, access_ComboBox.SelectedItem.ToString()) == true)
                {
                    MessageBox.Show($"{access_ComboBox.SelectedItem.ToString()} {userName_TextBox.Text} {userSureName_TextBox.Text} успешно добавлен(а)!", "Cообщение");
                }
                else
                {
                    MessageBox.Show("Ошибка ввода данных!", "Ошибка");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
            userName_TextBox.Text = userSureName_TextBox.Text = email_TextBox.Text = "";
        }

        private void adminMenu_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
