using CamerasDb.Migrations;
using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.Services;
using CamerasDb.Services.DataService;
using CamerasDb.Services.MailService;
using CamerasDb.Services.TableService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace CamerasDb.View
{
    public partial class WorkerTableForm : Form
    {
        WorkerTable workerTable;
        string tableName = "";
        Worker worker;
        public WorkerTableForm(Worker worker)
        {
            InitializeComponent();
            workerTable = new WorkerTable(this, worker);
            this.worker = worker;

            toolStripComboBox1.Items.Add("Фотоаппараты");
            toolStripComboBox1.Items.Add("Закупки");
            toolStripComboBox1.Items.Add("Производство");
            toolStripComboBox1.Items.Add("Запчасти");
            toolStripComboBox1.Items.Add("Производители");
            toolStripComboBox1.Items.Add("Магазины");
            
            this.Size = new Size(870, 950);
            dataGridView1.Location = new Point(25, 100);
            dataGridView1.Size = new Size(800, 500);

            this.Load +=UserForm_Load;
            this.toolStripComboBox1.SelectedIndexChanged +=ToolStripComboBox1_SelectedIndexChanged;
        }
        private void refresh_ToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripComboBox1_SelectedIndexChanged(sender, e);
        }
        private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
        private void SearchOrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            workerTable.UpdateComboBox(workerTable.comboBoxes[0], 1);
        }
        private void CloseOrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            workerTable.UpdateComboBox(workerTable.comboBoxes[1], 2);
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
        private async void SearchOrderButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await SearchDataDbService.Instance.SearchDataAsync(dataGridView1, tableName, workerTable) != true)
                {
                    MessageBox.Show("Ошибка поиска! Проверьте данные и параметры", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
        }
        private async void SortOrderButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await SortDataDbService.Instance.SortDataAsync(dataGridView1, tableName, workerTable) != true)
                {
                    MessageBox.Show("Ошибка сортировки! Проверьте параметры", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
        }
        private async void AddOrderButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await AddDataDbService.Instance.AddDataAsync(tableName, workerTable, worker) == true)
                {
                    MessageBox.Show("Заказ успешно добавлен!", "Сообщение");
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
        private async void CloseOrderButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await DeleteDataDbService.Instance.DeleteDataAsync(dataGridView1, tableName, workerTable) == true)
                {
                    MessageBox.Show("Заказ успешно закрыт!", "Сообщение");
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
        private async void UpdateTable()
        {
            try
            {
                tableName = await DataDbService.Instance.ShowTableAsync(dataGridView1, toolStripComboBox1, workerTable, worker);
                if (tableName != "")
                {
                    await workerTable.UpdateTableLayoutPanel(tableName);
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
       
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SendMessageToDev()
        {
            this.Visible = false;
            if (new MessageForm().ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        private void message_ToolStripButton_Click(object sender, EventArgs e)
        {
            SendMessageToDev();
        }

        private void написатьРазработчикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessageToDev();
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            onlineUser_Label.Text = $"В сети: {worker.Name} {worker.SureName}";
            workerTable.CreateEventComboBox(SearchOrderComboBox_SelectedIndexChanged, CloseOrderComboBox_SelectedIndexChanged);
            workerTable.CreateEventAddOrderButton(AddOrderButtonClick);
            workerTable.CreateEventCloseOrderButton(CloseOrderButtonClick);
            workerTable.CreateEventSortOrderButton(SortOrderButtonClick);
            workerTable.CreateEventSearchOrderButton(SearchOrderButtonClick);
        }
    }
}
