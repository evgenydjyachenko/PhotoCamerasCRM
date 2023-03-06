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
    public partial class Query5Form : Form
    {
        List<Manufacturer> manufacturers = null;
        List<Product> products = null;
        public Query5Form()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"AuthorizationTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Load+=Query5Form_Load;
            this.manufacturer_ComboBox.SelectedIndexChanged+=Manufacturer_ComboBox_SelectedIndexChanged;
        }

        private void Manufacturer_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            products.Where(p => p.Productions.FirstOrDefault().Manufacturer.Name == ((Manufacturer)manufacturer_ComboBox.SelectedItem).Name).ToList().ForEach(p => products_ComboBox.Items.Add(p));
        }

        private async void Query5Form_Load(object sender, EventArgs e)
        {
            manufacturers =  await DataDbService.Instance.GetManufacturersListAsync();
            manufacturers.ForEach(m => manufacturer_ComboBox.Items.Add(m));
            products = await DataDbService.Instance.GetProductsListAsync();        
        }

        private void Query5_Button_Click(object sender, EventArgs e)
        {
            if (manufacturer_ComboBox.SelectedIndex != -1 && products_ComboBox.SelectedIndex != -1)
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
