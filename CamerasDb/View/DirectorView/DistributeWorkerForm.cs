using CamerasDb.Model;
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

namespace CamerasDb.View.Admin
{
    public partial class DistributeWorkerForm : Form
    {
        ManagerService managerService = ManagerService.Instance;
        WorkerService workerService = WorkerService.Instance;
        List<Managerr> managers = null;
        List<Worker> subordinatedWorkers = null;
        List<Worker> unallocatedWorkers = null;
        Worker worker = null;
        Managerr manager = null;
        public DistributeWorkerForm()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"SelectManagerTheme.jpg");
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Load+=SelectManagerForm_Load;
            managers_ListBox.SelectedIndexChanged +=Managers_ListBox_SelectedIndexChanged;
        }

        private bool CheckSelect()
        {
            if (managers_ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите менеджера!", "Сообщение");
                return false;
            }
            else if (unallocatedWorkers_ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите работника!", "Сообщение");
                return false;
            }
            return true;
        }
        private async void Managers_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                manager_TreeView.Nodes.Clear();

                Managerr manager = (Managerr)managers_ListBox.SelectedItem;
                if (manager != null)
                {
                    TreeNode managerNode = new TreeNode($"{manager.Id} {manager.Name} {manager.SureName}");
                    await Task.Run(() =>
                    {
                        subordinatedWorkers = workerService.GetSubordinateWorkersAsync(manager).Result;
                    });
                    workersAmount_Label.Text = $"Работников в подчинении: {subordinatedWorkers.Count}";

                    if (subordinatedWorkers.Count == 0)
                    {

                        MessageBox.Show($"У менеджера {manager.Name} {manager.SureName} нет никого в подчинении", "Сообщение");
                    }
                    else
                    {
                        foreach (var workers in manager.Workers)
                        {
                            managerNode.Nodes.Add(new TreeNode($"{workers.Id} {workers.Name} {workers.SureName}"));
                        }
                        manager_TreeView.Nodes.Add(managerNode);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
        }

        private async Task<bool> UpdateInfo()
        {
            try
            {
                unallocatedWorkers_ListBox.Items.Clear();
                managers_ListBox.Items.Clear();
                await Task.Run(() =>
                {
                    managers = managerService.GetManagersListAsync().Result;
                    unallocatedWorkers = workerService.GetUnallocatedWorkersListAsync().Result;
                });
                managers.ForEach(w => managers_ListBox.Items.Add(w));
                unallocatedWorkers.ForEach(u => unallocatedWorkers_ListBox.Items.Add(u));
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
            return false;
        }

        private async void SelectManagerForm_Load(object sender, EventArgs e)
        {
            await UpdateInfo();
        }

        private async void allocateWorker_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckSelect() == true)
                {
                    worker = (Worker)unallocatedWorkers_ListBox.SelectedItem;
                    manager = (Managerr)managers_ListBox.SelectedItem;
                    if (await managerService.AllocateWorkerToManager(manager, worker) == true)
                    {
                        MessageBox.Show($"Работник(Id:{worker.Id}) {worker.Name} {worker.SureName} успешно закреплен за менеджером(Id:{manager.Id}) {manager.Name} {manager.SureName}");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка распределения работника!", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
            await UpdateInfo();
           
        }

        private void adminMenu_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
