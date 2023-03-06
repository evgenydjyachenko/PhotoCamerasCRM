using CamerasDb.Services.DataService;
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
using CamerasDb.Model.Interface;
using CamerasDb.Model;
using CamerasDb.View.ManagerView;
using CamerasDb.Services.MailService;
using CamerasDb.Migrations;

namespace CamerasDb.View.ManagerView
{
    public partial class ManagerForm : Form
    {
        ManagerService managerService = ManagerService.Instance;
        OrderService orderService = OrderService.Instance;
        WorkerService workerService = WorkerService.Instance;
        DataDbService dataDbService = DataDbService.Instance;
        Managerr manager;
        Worker worker = null;
        List<Worker> workers = null;
        List<Order> unallocatedOrders = null;
        
        public ManagerForm(Managerr manager)
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"ManagerTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(1425, 550);
            this.manager = manager;           
            this.Load +=ManagerForm_Load;
            this.workers_ListBox.SelectedIndexChanged+=Workers_ListBox_SelectedIndexChanged;
            this.unallocatedOrders_ListBox.SelectedIndexChanged+=UnallocatedOrders_ListBox_SelectedIndexChanged;
        }

        private void UnallocatedOrders_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.distributeOrder_Button.Enabled = true;
        }

        private void Workers_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.showWorker_Button.Enabled = true;
        }

        private void openDb_Button_Click(object sender, EventArgs e)
        {
            showManagerForm();
        }
        private void dbToolStripButton_Click(object sender, EventArgs e)
        {
            showManagerForm();
        }

        private void userToolStripButton_Click(object sender, EventArgs e)
        {
            showWorker_Button_Click(sender, e);
        }
        private void showWorker_Button_Click(object sender, EventArgs e)
        {
            if (workers_ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника","Сообщение");
            }
            else
            {
                showWorkerInfo();
            }
        }

        private async void showWorkerInfo()
        {
            Worker selectedWorker = (Worker)workers_ListBox.SelectedItem;
            await Task.Run(() =>
            {
                workers = workerService.GetWorkersListAsync().Result;
                worker = workerService.GetWorkerAsync(selectedWorker.Id).Result;
            });

            this.Visible = false;
            if (new UserStatisticForm(worker).ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
                await UpdateInfo();
            }               
        }

        private async void showManagerForm()
        {
            this.Visible = false;

            if (new ManagerTableForm(manager).ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
                await UpdateInfo();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (new MessageForm().ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;            
            }
        }

        private async void showOrderInfo()
        {
            this.Visible = false;

            if (new OrderInfoForm(manager,(Order)unallocatedOrders_ListBox.SelectedItem).ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
                await UpdateInfo();
            }
        }
        private void openOrder_Button_Click(object sender, EventArgs e)
        {
            if (unallocatedOrders_ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите заказ!","Сообщение");
            }
            else
            {
                showOrderInfo();
            }
        }

        private async Task<bool> UpdateInfo()
        {
            try
            {
                workers_ListBox.Items.Clear();
                unallocatedOrders_ListBox.Items.Clear();

                db_Label.Text = await dataDbService.GetDbInfo(manager) + await orderService.GetOrdersInfoAsync(manager);

                await Task.Run(() =>
                {
                    workers = workerService.GetSubordinateWorkersAsync(manager).Result;
                    unallocatedOrders = orderService.GetUnallocatedOrdersListAsync().Result;

                });
                workers.ForEach(w => workers_ListBox.Items.Add(w));
                unallocatedOrders.ForEach(o => unallocatedOrders_ListBox.Items.Add(o));
                workersList_Label.Text = $"Работников в подчинении: {workers.Count}";
                unallocatedOrders_Label.Text = $"Нераспределенных заказов: {unallocatedOrders.Count}";

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
            return false;
        }

        private async void ManagerForm_Load(object sender, EventArgs e)
        {
            onlineUser_Label.Text = $"В сети: {manager.Name} {manager.SureName}";
            this.distributeOrder_Button.Enabled = false;
            this.showWorker_Button.Enabled = false;
            await UpdateInfo();
        }

    }
}