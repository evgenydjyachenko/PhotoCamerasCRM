using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services.TableService
{
    public class ManagerTable : Table
    {
        Managerr manager;
        Button EntityQueryButton, ADOQUeryButton;
        public TextBox ADOQueryText;
        public ManagerTable(Form form, Managerr manager) : base(form)
        {
            this.manager = manager;
            UserId.Value = manager.Id;

            //tablelayoutpanel
            buttons = new Button[] { new Button() { Name = "addButton", Text = "Добавить", Font = font1, Location = point2, Size = size },
            new Button() { Name = "searchButton", Text = "Найти", Font = font1, Location = point2, Size = size },
            new Button() { Name = "deleteButton", Text = "Удалить", Font = font1, Location = point2, Size = size },
            new Button() { Name = "sortButton", Text = "Сортировать", Font = font1, Location = point2, Size = size }};

            comboBoxes = new ComboBox[] { new ComboBox() { Name = "searchCombobox", Location = point2, Size = size },
                new ComboBox() { Name = "deleteCombobox", Location = point2, Size = size },
                new ComboBox(){ Name = "sortCombobox", Location = point2, Size = size },
                new ComboBox() {Name = "descAscCombobox", Location = point2, Size = size } };


            panel.Controls.Add(new Label() { Location = point1, Text = "Добавление данных", AutoSize = true, Font = font1 }, 0, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Поиск данных", AutoSize = true, Font = font1 }, 1, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Удаление данных", AutoSize = true, Font = font1 }, 2, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Сортировка данных", AutoSize = true, Font = font1 }, 3, 0);
            panel.Controls.Add(new Label() { Location = point1, Text = "Тип поиска", AutoSize = true }, 1, 1);
            panel.Controls.Add(new Label() { Location = point1, Text = "Тип удаления", AutoSize = true }, 2, 1);
            panel.Controls.Add(new Label() { Location = point1, Text = "Тип сортировки", AutoSize = true }, 3, 1);

            panel.Controls.Add(comboBoxes[0], 1, 2);
            panel.Controls.Add(comboBoxes[1], 2, 2); comboBoxes[1].Items.Add("По id");
            panel.Controls.Add(comboBoxes[2], 3, 2); comboBoxes[2].Items.Add("По id");
            panel.Controls.Add(comboBoxes[3], 3, 3); comboBoxes[3].Items.Add("По возрастанию"); comboBoxes[3].Items.Add("По убыванию");


            for (int i = 0; i < 4; i++)
            {
                panel.Controls.Add(buttons[i], i, 9);
            }

            amount = panel.Controls.Count;

            //tabcontrol
            ADOQueryText = new TextBox() { Location = new Point(10, 10), Multiline = true, Size = new Size(770, 200), Text = "Поле для ввода запроса(синтаксис как в T-SQL):" };

            QueryListBox = new ListBox() { Location = new Point(10, 10), Size = new Size(770, 200) };

            tabControl = new TabControl();
            tabControl.Location = new System.Drawing.Point(25, 600);
            tabControl.Name = "TabControl1";
            tabControl.Size = new System.Drawing.Size(800, 300);

            EntityQueryButton = new Button() { Location = new Point(10, 210), Size = new Size(770, 50), Text = "Выполнить запрос", Font = font1 };
            ADOQUeryButton = new Button() { Location = new Point(10, 210), Size = new Size(770, 50), Text = "Выполнить запрос", Font = font1 };

            QueryListBox.Items.Add("Найти самый дорогой фотоаппарат, самый дешевый, среднюю стоимость");
            QueryListBox.Items.Add("Найти фотоаппарат в заданном ценовом диапазоне для заданного производителя");
            QueryListBox.Items.Add("Найти фотоаппараты проданные за определенный период времени");
            QueryListBox.Items.Add("Найти самую популярную модель(продано наибольшее количество)");
            QueryListBox.Items.Add("Найти все фотоаппараты, поступившие от заданного производителя, чья стоимость больше, чем стоимость заданного фотоаппарата");
            QueryListBox.Items.Add("Найти фотоаппараты от заданного производителя, чья стоимость меньше заданной");
            QueryListBox.Items.Add("Найти среднюю стоимость фотоаппаратов, проданных за определенный период времени");
            QueryListBox.Items.Add("Найти все фотоаппараты, чья стоимость выше, чем средняя стоимость фотоаппарата для заданного производителя");

            tabControl.TabPages.Add(new TabPage("Коллекция запросов"));
            tabControl.TabPages.Add(new TabPage("Написать запрос"));
            tabControl.TabPages[0].Controls.Add(QueryListBox);
            tabControl.TabPages[0].Controls.Add(EntityQueryButton);
            tabControl.TabPages[1].Controls.Add(ADOQueryText);
            tabControl.TabPages[1].Controls.Add(ADOQUeryButton);

            form.Controls.Add(tabControl);

            tabControl.Visible = false;

        }
        public void CreateEventComboBox(EventHandler e, EventHandler e2)
        {
            comboBoxes[0].SelectedIndexChanged +=e;
            comboBoxes[1].SelectedIndexChanged +=e2;
        }
        public void CreateEventAddButton(EventHandler e)
        {
            buttons[0].Click += e;
        }
        public void CreateEventSearchButton(EventHandler e)
        {
            buttons[1].Click += e;
        }
        public void CreateEventDeleteButton(EventHandler e)
        {
            buttons[2].Click += e;
        }
        public void CreateEventSortButton(EventHandler e)
        {
            buttons[3].Click +=e;
        }
        public void CreateEventEntityQueryButton(EventHandler e)
        {
            EntityQueryButton.Click+= e;
        }

        public void CreateEventADOQueryButton(EventHandler e)
        {
            ADOQUeryButton.Click+=e;
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

            try
            {
                await Task.Run(() =>
                {
                    if (form.InvokeRequired == true)
                    {
                        if (tableType is TableLayoutPanel)
                        {
                            if (form.Controls.Contains(tabControl) == true)
                            {
                                form.Invoke(new Action(() => tabControl.Visible = false));
                            }
                            form.Invoke(new Action(() => panel.Visible = true));
                        }
                        else if (tableType is TabControl)
                        {
                            if (form.Controls.Contains(panel) == true)
                            {
                                form.Invoke(new Action(() => panel.Visible = false));
                            }
                            form.Invoke(new Action(() => tabControl.Visible = true));
                        }
                    }
                });
            }
            catch (Exception)
            {

                throw new Exception("Ошибка с потоком");
            }
            return 0;
        }

        public void HideTable()
        {
            this.tabControl.Visible = false;
            this.panel.Visible = false;
        }

        public async Task<int> UpdateTableLayoutPanel(string tableName)
        {
           
            await ChangeTable(panel as object);
            this.panel.Visible = true;


            switch (tableName)
            {
                case "Фотоаппараты":
                    comboBoxes[0].Items.Add("По Id продукта"); comboBoxes[0].Items.Add("По цене"); comboBoxes[0].Items.Add("По названию продукта"); 
                    comboBoxes[1].Items.Add("По Id продукта"); comboBoxes[1].Items.Add("По названию продукта");
                    comboBoxes[2].Items.Add("По названию продукта"); comboBoxes[2].Items.Add("По цене"); 

                    panel.Controls.Add(new Label() { Location = point1, Text = "Название продукта", Size = size }, 0, 1); 
                    panel.Controls.Add(new Label() { Location = point1, Text = "Цена", Size = size }, 0, 3); 
                    panel.Controls.Add(NewModelName, 0, 2);
                    panel.Controls.Add(NewPrice, 0, 4);
                    break;              

                case "Запчасти":
                    comboBoxes[0].Items.Add("По Id запчасти"); comboBoxes[0].Items.Add("По названию запчасти"); comboBoxes[0].Items.Add("По цене"); comboBoxes[0].Items.Add("По названию производителя");
                    comboBoxes[1].Items.Add("По Id запчасти"); comboBoxes[1].Items.Add("По названию запчасти"); 
                    comboBoxes[2].Items.Add("По названию запчасти"); comboBoxes[2].Items.Add("По цене"); comboBoxes[2].Items.Add("По названию производителя");

                    panel.Controls.Add(new Label() { Location = point1, Text = "Название запчасти", Size = size }, 0, 1); 
                    panel.Controls.Add(new Label() { Location = point1, Text = "Цена", Size = size }, 0, 3);  
                    panel.Controls.Add(new Label() { Location = point1, Text = "Название производителя", Size = size }, 0, 5); 
                    panel.Controls.Add(new Label() { Location = point1, Text = "Id продукта", Size = size }, 0, 7);
                    panel.Controls.Add(NewSparePartName, 0, 2);
                    panel.Controls.Add(NewPrice, 0, 4);
                    panel.Controls.Add(NewManufacturerName, 0, 6);
                    panel.Controls.Add(Product_Id, 0, 8);
                    break;

                case "Производители":
                    comboBoxes[0].Items.Add("По Id производителя"); comboBoxes[0].Items.Add("По названию производителя");
                    comboBoxes[1].Items.Add("По Id производителя"); comboBoxes[1].Items.Add("По названию производителя"); 
                    comboBoxes[2].Items.Add("По названию производителя"); comboBoxes[2].Items.Add("По количеству заказов"); comboBoxes[2].Items.Add("По количеству запчастей");

                    panel.Controls.Add(new Label() { Location = point1, Text = "Название производителя", Size = size }, 0, 1); 
                    panel.Controls.Add(NewManufacturerName, 0, 2);
                    break;

                case "Магазины":
                    comboBoxes[0].Items.Add("По Id магазина"); comboBoxes[0].Items.Add("По названию магазина"); 
                    comboBoxes[1].Items.Add("По Id магазина"); comboBoxes[1].Items.Add("По названию магазина"); 
                    comboBoxes[2].Items.Add("По названию магазина"); comboBoxes[2].Items.Add("По количеству заказов");

                    panel.Controls.Add(new Label() { Location = point1, Text = "Название магазина", Size = size }, 0, 1); 
                    panel.Controls.Add(NewStoreName, 0, 2);
                    break;
            }

            amount2 = panel.Controls.Count;

            form.Controls.Add(panel);

            return 0;
        }
        public async Task<int> UpdateTabControl()
        {
            await ChangeTable(tabControl as object);
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
                case "По Id магазина":
                    Store_Id = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Store_Id, index, 3);
                    break;
                case "По Id запчасти":
                    SparePart_Id = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(SparePart_Id, index, 3);
                    break;
                case "По Id производства":
                    Prod_Id = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Prod_Id, index, 3);
                    break;
                case "По Id производителя":
                    Manufacturer_Id = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Manufacturer_Id, index, 3);
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
                case "По цене":
                    panel.Controls.Add(new Label() { Location = point1, Text = "Введите диапазон цен \n от", AutoSize = true }, index, 3);
                    panel.Controls.Add(new Label() { Location = point1, Text = "до", AutoSize = true }, index, 5);
                    Price = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    Price2 = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Price, index, 4);
                    panel.Controls.Add(Price2, index, 6);
                    break;
                case "По названию продукта":
                    ModelName = new TextBox() { Location = point1, Size = size };
                    panel.Controls.Add(ModelName, index, 3);
                    break;
                case "По названию запчасти":
                    SparePartName = new TextBox() { Location = point1, Size = size, Anchor = center };
                    panel.Controls.Add(SparePartName, index, 3);
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
                case "По количеству заказов":
                    Amount = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Amount, index, 3);
                    break;
                case "По количеству запчастей":
                    Amount = new NumericUpDown() { Location = point1, Size = size, Maximum = maxValue };
                    panel.Controls.Add(Amount, index, 3);
                    break;
            }
            flag = true;
        }

    }
}
