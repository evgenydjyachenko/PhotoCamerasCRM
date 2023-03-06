using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using CamerasDb.Model;
using CamerasDb.Services;
using CamerasDb.View.Admin;
using CamerasDb.Services.MailService;
using CamerasDb.View.ManagerView;

namespace CamerasDb.View
{
    public partial class DirectorForm : Form
    {
        DirectorService directorService = DirectorService.Instance;
        DataDbService dataDbService = DataDbService.Instance;
        WorkerService workerService = WorkerService.Instance;
        ManagerService managerService = ManagerService.Instance;
        AccountService accountService = AccountService.Instance;
        OrderService orderService = OrderService.Instance;

        Director director;
        List<Managerr> managers = null;
        List<Worker> unallocatedWorkers = null;
        List<Worker> workers = null;

        int users = 0;
    
        public DirectorForm(Director director)
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"AdminTheme.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(1140, 530);
            this.director = director;

            this.Load +=AdminForm_Load;
            this.workers_ListBox.SelectedIndexChanged+=Workers_ListBox_SelectedIndexChanged;
            this.managers_ListBox.SelectedIndexChanged+=Managers_ListBox_SelectedIndexChanged;
            this.unallocatedWorkers_ListBox.SelectedIndexChanged+=UnallocatedWorkers_ListBox_SelectedIndexChanged;
        }
        private void UnallocatedWorkers_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            appointManager_Button.Enabled = true;
        }

        private void Managers_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteManager_Button.Enabled = true;
            managerInfo_Button.Enabled = true;
        }

        private void Workers_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteWorker_Button.Enabled = true;
            workerInfo_Button.Enabled = true;
        }
        private async void SendMessageToDev()
        {

            this.Visible = false;
            if (new MessageForm().ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
                await UpdateInfo();
            }
        }
        public async void ShowAddUserForm(IUser user, object sender, EventArgs e)
        {
            this.Visible = false;
            if (new AddUserForm(user).ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
                await UpdateInfo();
            }
        }
        private async Task<bool> UpdateInfo()
        {
            try
            {
                managers_ListBox.Items.Clear();
                workers_ListBox.Items.Clear();
                unallocatedWorkers_ListBox.Items.Clear();
                db_Label.Text = await dataDbService.GetDbInfo(director) + await orderService.GetOrdersInfoAsync(director);
                await Task.Run(() =>
                {
                    users = directorService.GetUsers().Result.Count;
                    unallocatedWorkers = workerService.GetUnallocatedWorkersListAsync().Result;    
                    workers = workerService.GetWorkersListAsync().Result.Where(w => w.Manager != null).ToList();
                    managers = managerService.GetManagersListAsync().Result;
                });
                usersAmount_Label.Text = $"Всего сотрудников в компании: {users}";             
               
                managers.ForEach(w => managers_ListBox.Items.Add(w));
                workers.ForEach(w => workers_ListBox.Items.Add(w)); 
                unallocatedWorkers.ForEach(o => unallocatedWorkers_ListBox.Items.Add(o));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
                return false;
            }
        }
        private async void managerInfo_Button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var manager = await managerService.GetManagerAsync(((Managerr)managers_ListBox.SelectedItem).Id);
            if (new UserStatisticForm(manager).ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        private async void workerInfo_Button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var worker = await workerService.GetWorkerAsync(((Worker)workers_ListBox.SelectedItem).Id);
            if (new UserStatisticForm(worker).ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        private async void deleteManager_Button_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < managers_ListBox.Items.Count; i++)
                {
                    if (managers[i]== managers[managers_ListBox.SelectedIndex])
                    {
                        if (await accountService.DeleteManagerAccAsync(managers[i]) == true)
                        {
                            MessageBox.Show($"Менеджер(Id:{managers[i].Id}) {managers[i].Name} {managers[i].SureName} удален из БД", "Сообщение");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления!", "Ошибка");
                        }
                    }
                }
                await UpdateInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
        }

        private async void deleteWorker_Button_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < workers_ListBox.Items.Count; i++)
                {
                    if (workers[i] == workers[workers_ListBox.SelectedIndex])
                    {
                        if (await accountService.DeleteWorkerAccAsync(workers[i]) == true)
                        {
                            MessageBox.Show($"Работник(Id:{workers[i].Id}) {workers[i].Name} {workers[i].SureName} удален из БД");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления!", "Ошибка");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
            await UpdateInfo();
        }

        private async void appointManager_Button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (new DistributeWorkerForm().ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
                await UpdateInfo();
            }
        }

        private void addManager_Button_Click(object sender, EventArgs e)
        {
            ShowAddUserForm(new Managerr(), sender, e);
        }
        private void addWorker_Button_Click(object sender, EventArgs e)
        {
            ShowAddUserForm(new Worker(), sender, e);
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Название приложения:{Application.CompanyName} ");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SendMessageToDev();
        }

        private void написатьРазработчикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessageToDev();
        }
        
        private async void AdminForm_Load(object sender, EventArgs e)
        {
            onlineUser_Label.Text = $"В сети: {director.Name} {director.SureName}";
            deleteManager_Button.Enabled = false;
            deleteWorker_Button.Enabled = false;
            managerInfo_Button.Enabled = false;
            workerInfo_Button.Enabled = false;
            appointManager_Button.Enabled = false;
            await UpdateInfo();
        }
    }
}
