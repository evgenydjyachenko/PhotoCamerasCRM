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
    public partial class Query8Form : Form
    {
        List<Manufacturer> manufacturers = null;
        public Query8Form()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"AuthorizationTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Load+=Query8Form_Load;
        }

        private async void Query8Form_Load(object sender, EventArgs e)
        {
            manufacturers =  await DataDbService.Instance.GetManufacturersListAsync();
            manufacturers.ForEach(m => manufacturer_ComboBox.Items.Add(m));
        }

        private void Query8_Button_Click(object sender, EventArgs e)
        {
            if (manufacturer_ComboBox.SelectedIndex != -1)
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
