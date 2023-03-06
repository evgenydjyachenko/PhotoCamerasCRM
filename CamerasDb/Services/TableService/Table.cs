using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace CamerasDb.View
{   
    public abstract class Table
    {
        public TextBox ModelName = new TextBox() { Location = new Point(200, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };
        public TextBox NewModelName = new TextBox() { Location = new Point(10, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };
        public TextBox StoreName = new TextBox() { Location = new Point(200, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };
        public TextBox NewStoreName = new TextBox() { Location = new Point(200, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };
        public TextBox ManufacturerName = new TextBox() { Location = new Point(200, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };
        public TextBox NewManufacturerName = new TextBox() { Location = new Point(200, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };
        public TextBox SparePartName = new TextBox() { Location = new Point(200, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };
        public TextBox NewSparePartName = new TextBox() { Location = new Point(200, 10), Size = new Size(180, 30), Anchor = AnchorStyles.None };

        public NumericUpDown NewPrice = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Price = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Price2 = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown NewAmount = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Amount = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Product_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown NewProduct_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Model_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Purchase_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Prod_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Store_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown SparePart_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown SearchedSparePart_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown UserId = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        public NumericUpDown Manufacturer_Id = new NumericUpDown() { Location = new Point(200, 10), Size = new Size(180, 30), Maximum = 1000000, Anchor = AnchorStyles.None };
        
        public DateTimePicker NewProdDate = new DateTimePicker() { Location = new Point(200, 10), Size = new Size(180, 30), Format = DateTimePickerFormat.Short, Anchor = AnchorStyles.None };
        public DateTimePicker NewPurchaseDate = new DateTimePicker() { Location = new Point(200, 10), Size = new Size(180, 30), Format = DateTimePickerFormat.Short, Anchor = AnchorStyles.None };
        public DateTimePicker ProdDate = new DateTimePicker() { Location = new Point(200, 10), Size = new Size(180, 30), Format = DateTimePickerFormat.Short, Anchor = AnchorStyles.None };
        public DateTimePicker PurchaseDate = new DateTimePicker() { Location = new Point(200, 10), Size = new Size(180, 30), Format = DateTimePickerFormat.Short, Anchor = AnchorStyles.None };

        public ListBox QueryListBox = new ListBox() { Location = new Point(10, 10), Size = new Size(770, 200) };


        public ComboBox[] comboBoxes;

        protected Button[] buttons; //addButton, searchButton, sortButton, deleteButton           
        protected Point point1;
        protected Point point2;
        protected Size size;
        protected Font font1;
        protected Form form;
        protected DateTimePickerFormat dateFormat;
        protected decimal maxValue;
        protected AnchorStyles center;

        protected TableLayoutPanel panel;
        protected TabControl tabControl;
        protected bool flag = false;
        protected int amount, amount2 = 0;

        public Table(Form form)
        {
            this.form = form;

            panel = new TableLayoutPanel();
            panel.Location = new System.Drawing.Point(25, 600);
            panel.Name = "TableLayoutPanel1";
            panel.Size = new System.Drawing.Size(800, 300);
            panel.BackColor = Color.LightBlue;
            size = new Size(180, 30);
            center = AnchorStyles.None;
            point1 = new Point(200, 10);
            point2 = new Point(10, 50);      
            font1 = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dateFormat = DateTimePickerFormat.Short;
            maxValue = 1000000;
            center = AnchorStyles.None;

            for (int i = 0, j = 0; i < panel.ColumnCount; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            }

            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            panel.Controls.Add(UserId);
            this.UserId.Visible = false;
        }
        public abstract Task<int> ChangeTable(object tableType);

        public abstract void UpdateComboBox(ComboBox comboBox, int index);
        
        public string CheckComboBox(ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                return comboBox.SelectedItem.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
