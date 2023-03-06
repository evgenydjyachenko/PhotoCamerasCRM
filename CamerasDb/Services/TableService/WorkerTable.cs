using CamerasDb.Model;
using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services.TableService
{
    public class WorkerTable: Table
    {
        Worker worker;    
        public WorkerTable(Form form, IUser user) : base(form)
        {
            this.worker = (Worker)user;
            UserId.Value = worker.Id;

            panel = new TableLayoutPanel();
            panel.Location = new System.Drawing.Point(25, 600);
            panel.Name = "TableLayoutPanel1";
            panel.Size = new System.Drawing.Size(800, 300);
            panel.BackColor = Color.LightBlue;
            panel.ColumnCount = 4;
            panel.RowCount = 5;
            point1 = new Point(200, 10);
            point2 = new Point(10, 50);

            //tablelayoutpanel
            buttons = new Button[] { new Button() { Name = "addButton", Text = "Добавить", Font = font1, Location = point2, Size = size },
            new Button() { Name = "searchButton", Text = "Найти", Font = font1, Location = point2, Size = size },
            new Button() { Name = "closeButton", Text = "Закрыть", Font = font1, Location = point2, Size = size },
            new Button() { Name = "sortButton", Text = "Сортировать", Font = font1, Location = point2, Size = size }};

            comboBoxes = new ComboBox[] { new ComboBox() { Name = "searchCombobox", Location = point2, Size = size },
                new ComboBox() { Name = "deleteCombobox", Location = point2, Size = size },
                new ComboBox(){ Name = "sortCombobox", Location = point2, Size = size },
                new ComboBox() {Name = "descAscCombobox", Location = point2, Size = size } };

            panel.Controls.Add(new Label() { Location = point1, Text = "Добавление заказа", AutoSize = true, Font = font1, Anchor = center }, 0, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Поиск заказа", AutoSize = true, Font = font1, Anchor = center }, 1, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Закрытие заказа", AutoSize = true, Font = font1, Anchor = center }, 2, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Сортировка заказов", AutoSize = true, Font = font1, Anchor = center }, 3, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Тип поиска", AutoSize = true }, 1, 1);
            panel.Controls.Add(new Label() { Location = point1, Text = "Тип закрытия", AutoSize = true }, 2, 1);
            panel.Controls.Add(new Label() { Location = point1, Text = "Тип сортировки", AutoSize = true }, 3, 1);

            panel.Controls.Add(comboBoxes[0], 1, 2);
            panel.Controls.Add(comboBoxes[1], 2, 2);
            panel.Controls.Add(comboBoxes[2], 3, 2);
            panel.Controls.Add(comboBoxes[3], 3, 3); comboBoxes[3].Items.Add("По возрастанию"); comboBoxes[3].Items.Add("По убыванию");

            for (int i = 0; i < buttons.Length; i++)
            {
                panel.Controls.Add(buttons[i], i, 9);
            }

            amount = panel.Controls.Count;
        }

        public void CreateEventComboBox(EventHandler e, EventHandler e2)
        {
            comboBoxes[0].SelectedIndexChanged +=e;
            comboBoxes[1].SelectedIndexChanged +=e2;
        }

        public void CreateEventAddOrderButton(EventHandler e)
        {
            buttons[0].Click += e;
        }
        public void CreateEventCloseOrderButton(EventHandler e)
        {
            buttons[2].Click += e;
        }
        public void CreateEventSortOrderButton(EventHandler e)
        {
            buttons[3].Click +=e;
        }
        public void CreateEventSearchOrderButton(EventHandler e)
        {
            buttons[1].Click +=e;
        }
        public override async Task<int> ChangeTable(object tableType)
        {
            flag = false;

            while (panel.Controls.Count != amount)
            {
                panel.Controls.RemoveAt(panel.Controls.Count - 1);
            }

            if (comboBoxes != null)
            {
                for (int i = 0; i < comboBoxes.Length-1; i++)
                {
                    comboBoxes[i].Items.Clear();
                    comboBoxes[i].Text = "";
                }
            }        
            return 0;
        }

        public async Task<int> UpdateTableLayoutPanel(string tableName)
        {
            
            await ChangeTable(panel as object);
            this.panel.Visible = true;
 
            switch (tableName)
            {
                case "Закупки":
                    comboBoxes[0].Items.Add("По Id закупки"); comboBoxes[0].Items.Add("По дате закупки"); comboBoxes[0].Items.Add("По названию магазина"); comboBoxes[0].Items.Add("По Id продукта");
                    comboBoxes[1].Items.Add("По Id закупки");
                    comboBoxes[2].Items.Add("По дате закупки"); comboBoxes[2].Items.Add("По названию магазина"); comboBoxes[2].Items.Add("По названию продукта"); comboBoxes[2].Items.Add("По количеству");

                    panel.Controls.Add(new Label() { Location = point1, Text = "Дата закупки", AutoSize = true, Anchor = center }, 0, 1); 
                    panel.Controls.Add(new Label() { Location = point1, Text = "Количество(шт)", AutoSize = true, Anchor = center }, 0, 3);
                    panel.Controls.Add(new Label() { Location = point1, Text = "Магазин", AutoSize = true, Anchor = center }, 0, 5);
                    panel.Controls.Add(new Label() { Location = point1, Text = "Id продукта", AutoSize = true, Anchor = center }, 0, 7);

                    panel.Controls.Add(NewPurchaseDate, 0, 2);
                    panel.Controls.Add(NewAmount, 0, 4);
                    panel.Controls.Add(NewStoreName, 0, 6);
                    panel.Controls.Add(NewProduct_Id, 0, 8);
                    break;

                case "Производство":
                    comboBoxes[0].Items.Add("По Id производства"); comboBoxes[0].Items.Add("По дате производства"); comboBoxes[0].Items.Add("По названию производителя"); comboBoxes[0].Items.Add("По Id продукта");
                    comboBoxes[1].Items.Add("По Id производства");
                    comboBoxes[2].Items.Add("По дате производства"); comboBoxes[2].Items.Add("По названию производителя"); comboBoxes[2].Items.Add("По названию продукта"); comboBoxes[2].Items.Add("По количеству");

                    panel.Controls.Add(new Label() { Location = point1, Text = "Дата производства", AutoSize = true, Anchor = center }, 0, 1);
                    panel.Controls.Add(new Label() { Location = point1, Text = "Количество(шт)", AutoSize = true, Anchor = center }, 0, 3);
                    panel.Controls.Add(new Label() { Location = point1, Text = "Производитель", AutoSize = true, Anchor = center }, 0, 5);
                    panel.Controls.Add(new Label() { Location = point1, Text = "Id продукта", AutoSize = true, Anchor = center }, 0, 7);

                    panel.Controls.Add(NewProdDate, 0, 2);
                    panel.Controls.Add(NewAmount, 0, 4);
                    panel.Controls.Add(NewManufacturerName, 0, 6);
                    panel.Controls.Add(NewProduct_Id, 0, 8);
                    break;
                default:
                    this.panel.Visible = false;
                    return 0;
                  
            }
            amount2 = panel.Controls.Count;
            
            form.Controls.Add(this.panel);

            return 0;
        }

        public override void UpdateComboBox(ComboBox comboBox, int index)
        {
            if (flag == true)
            {
                while (panel.Controls.Count != amount2)
                {
                    panel.Controls.RemoveAt(panel.Controls.Count - 1);
                }
            }
            switch (comboBox.SelectedItem.ToString())
            {
                case "По Id производства":
                    Prod_Id = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Prod_Id, index, 3);
                    break;

                case "По Id продукта":
                    Product_Id = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Product_Id, index, 3);
                    break;
                case "По Id закупки":
                    Purchase_Id = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Purchase_Id, index, 3);
                    break;
                case "По количеству":
                    Amount = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Amount, index, 3);
                    break;
                case "По названию продукта":
                    ModelName = new TextBox() { Location = point1, Size = size };
                    panel.Controls.Add(ModelName, index, 3);
                    break;
                case "По названию магазина":
                    StoreName = new TextBox() { Location = point1, Size = size };
                    panel.Controls.Add(StoreName, index, 3);
                    break;
                case "По названию производителя":
                    ManufacturerName = new TextBox() { Location = point1, Size = size, Anchor = center };
                    panel.Controls.Add(ManufacturerName, index, 3);
                    break;
                case "По дате производства":
                    ProdDate = new DateTimePicker() { Location = point1, Size = size, Format = dateFormat };
                    panel.Controls.Add(ProdDate, index, 3);
                    break;
                case "По дате закупки":
                    PurchaseDate = new DateTimePicker() { Location = point1, Size = size, Format = dateFormat };
                    panel.Controls.Add(PurchaseDate, index, 3);
                    break;
            }
            flag = true;
        }     
    }
}

