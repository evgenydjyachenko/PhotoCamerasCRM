using CamerasDb.Model;
using CamerasDb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CamerasDb.View.ManagerView
{
    public partial class UserStatisticForm : Form
    {
        WorkerService workerService = WorkerService.Instance;
        ManagerService managerService = ManagerService.Instance;
        IUser user;

        public UserStatisticForm(IUser user)
        {
            InitializeComponent();
            this.user = user;
            this.Load +=WorkerInfoForm_Load;    
            
        }

        private async void WorkerInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (user is Worker worker)
                {
                    await workerService.GetWorkerStatisticAsync(worker, closedOrders_ListBox, openedOrders_ListBox, overdueOrders_ListBox, cancelledOrders_ListBox, allWorkerOrdersAmount_Label, user_Label);
                }
                else if (user is Managerr manager)
                {
                    await managerService.GetManagerStatisticAsync(manager, closedOrders_ListBox, openedOrders_ListBox, overdueOrders_ListBox, cancelledOrders_ListBox, allWorkerOrdersAmount_Label, user_Label);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
        }

        private void managerMenu_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
