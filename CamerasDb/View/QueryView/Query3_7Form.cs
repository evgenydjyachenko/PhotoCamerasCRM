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
    public partial class Query3_7Form : Form
    {
        public Query3_7Form()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"AuthorizationTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void Query3_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
