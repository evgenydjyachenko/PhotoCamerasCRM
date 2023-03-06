using CamerasDb.Model;
using CamerasDb.Services.DataService;
using CamerasDb.Services.TableService;
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
using CamerasDb.Services.MailService;
using CamerasDb.Migrations;
using CamerasDb.Services.QueryServic;

namespace CamerasDb.View.ManagerView
{
    public partial class ManagerTableForm : Form
    {
        ManagerTable managerTable;
        string tableName = "", changedTableName = "";
        Managerr manager;
        ADOQuery query;
        public ManagerTableForm(Managerr manager)
        {
            InitializeComponent();
            managerTable = new ManagerTable(this, manager);
            query = new ADOQuery();

            this.manager = manager;

            this.Size = new Size(870, 950);
            dataGridView1.Location = new Point(25, 100);
            dataGridView1.Size = new Size(800, 500);

            this.Load +=UserForm_Load;
            this.toolStripComboBox1.SelectedIndexChanged +=ToolStripComboBox1_SelectedIndexChanged;

            toolStripComboBox1.Items.Add("Фотоаппараты");
            toolStripComboBox1.Items.Add("Закупки");
            toolStripComboBox1.Items.Add("Производство");
            toolStripComboBox1.Items.Add("Запчасти");
            toolStripComboBox1.Items.Add("Производители");
            toolStripComboBox1.Items.Add("Магазины");
            toolStripComboBox1.Items.Add("Запросы");
        }

        private void refresh_ToolStripButton_Click_1(object sender, EventArgs e)
        {
            ToolStripComboBox1_SelectedIndexChanged(sender, e);
        }
        private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            managerTable.UpdateComboBox(managerTable.comboBoxes[0], 1);
        }
        private void DeleteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            managerTable.UpdateComboBox(managerTable.comboBoxes[1], 2);
        }
        private async void save_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (await DataDbService.Instance.SaveDataAsync() == true)
                {
                    MessageBox.Show("Данные успешно сохранены!", "Сообщение");
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения данных!", "Сообщение");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
        }        
        private async void SortButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await SortDataDbService.Instance.SortDataAsync(dataGridView1, tableName, managerTable) != true)
                {
                    MessageBox.Show("Ошибка сортировки! Проверьте параметры", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }          
        }
        private async void DeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await DeleteDataDbService.Instance.DeleteDataAsync(dataGridView1, tableName, managerTable) == true)
                {
                    MessageBox.Show("Данные успешно удалены!", "Сообщение");
                    UpdateTable();
                }
                else
                {
                    MessageBox.Show("Некорректный ввод данных! Проверьте данные и параметры", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
            
        }
        private async void SearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await SearchDataDbService.Instance.SearchDataAsync(dataGridView1, tableName, managerTable) != true)
                {
                    MessageBox.Show("Ошибка поиска! Проверьте данные и параметры", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }           
        }
        private async void AddButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await AddDataDbService.Instance.AddDataAsync(tableName, managerTable, manager) == true)
                {
                    MessageBox.Show("Данные успешно добавлены!", "Сообщение");
                    UpdateTable();
                }
                else
                {
                    MessageBox.Show("Некорректный ввод данных! Проверьте данные и параметры", "Ошибка");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }          
        }

        private async void EntityQueryButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await EntityQuery.Instance.SelectQuery(dataGridView1, managerTable) != true)
                {
                    MessageBox.Show("Запрос не выполнен!", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }         
        }

        private void ADOQueryButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (managerTable.ADOQueryText.Text != "" && managerTable.ADOQueryText.Text != "Поле для ввода запроса(синтаксис как в T-SQL):")
                {
                    if (query.SendQuery(dataGridView1, managerTable) != true)
                    {
                        MessageBox.Show("Запрос не выполнен! Проверьте правильность написания запроса", "Сообщение");
                    }
                }
                else
                {
                    MessageBox.Show("Введите запрос!", "Сообщение");
                }                              
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка отправки запроса! Проверьте корректность синтаксиса.", "Ошибка");
            }
        }

        private async void UpdateTable()
        {
            try
            {
                tableName = await DataDbService.Instance.ShowTableAsync(dataGridView1, toolStripComboBox1, managerTable, manager);
                if (tableName != "")
                {
                    if (changedTableName != tableName)
                    {
                        switch (tableName)
                        {
                            case "Запросы":
                                await managerTable.UpdateTabControl();                              
                                break;
                            case "Закупки":
                            case "Производство":
                                managerTable.HideTable();
                                break;
                            case "Фотоаппараты":
                            case "Запчасти":
                            case "Производители":
                            case "Магазины":
                                await managerTable.UpdateTableLayoutPanel(tableName);
                                break;
                        }
                        changedTableName = tableName;
                    }                    
                }
                else
                {
                    MessageBox.Show("Выберите таблицу!", "Ошибка");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }           
        }

        private void SendMessageToDev()
        {
            this.Visible = false;
            if (new MessageForm().ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        private void написатьРазработчикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessageToDev();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            onlineUser_Label.Text = $"В сети: {manager.Name} {manager.SureName}";
            managerTable.CreateEventComboBox(SearchComboBox_SelectedIndexChanged, DeleteComboBox_SelectedIndexChanged);
            managerTable.CreateEventSearchButton(SearchButtonClick);
            managerTable.CreateEventAddButton(AddButtonClick);
            managerTable.CreateEventDeleteButton(DeleteButtonClick);
            managerTable.CreateEventSortButton(SortButtonClick);
            managerTable.CreateEventEntityQueryButton(EntityQueryButtonClick);
            managerTable.CreateEventADOQueryButton(ADOQueryButtonClick);
        }
    }
}
