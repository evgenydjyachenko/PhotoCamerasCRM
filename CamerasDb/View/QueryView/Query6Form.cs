using CamerasDb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.View.QueryView
{
    public partial class Query6Form : Form
    {
        List<Manufacturer> manufacturers = null;
        public Query6Form()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"AuthorizationTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Load+=Query6Form_Load;
        }

        private async void Query6Form_Load(object sender, EventArgs e)
        {
            manufacturers =  await DataDbService.Instance.GetManufacturersListAsync();
            manufacturers.ForEach(m => manufacturer_ComboBox.Items.Add(m));
        }

        private void Query6_Button_Click(object sender, EventArgs e)
        {
            if (manufacturer_ComboBox.SelectedIndex != -1 && Price_NumericUpDown.Value!= 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Некорректный ввод!", "Сообщение");
            }
        }
    }
}
