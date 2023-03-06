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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CamerasDb.View.ManagerView
{
    public partial class OrderInfoForm : Form
    {
        WorkerService workerService = WorkerService.Instance;
        OrderService orderService = OrderService.Instance;
        Order order;
        Managerr manager;
        public OrderInfoForm(Managerr manager, Order order)
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"OrderInfoTheme.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            distribute_Button.BackColor = Color.Blue;
            this.order = order;
            this.manager = manager;
            this.Load+=OrderInfoForm_Load;
        }

        private async void OrderInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                workers_Listbox.Items.Clear();
                orderInfo_Label.Text = $"{await orderService.GetDetailedOrderInfoAsync(order)}";
                List<Worker> workers = null;
                await Task.Run(() =>
                {
                    workers = workerService.GetSubordinateWorkersAsync(manager).Result;
                });
                workers.ForEach(w => workers_Listbox.Items.Add(w));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }                     
        }
        private async void distributeOrder()
        {
            try
            {
                Worker worker = (Worker)workers_Listbox.SelectedItem;
                if (await OrderService.Instance.AssignOrderToWorkerAsync(worker, order) != null)
                {
                    MessageBox.Show($"Заказ№{order.OrderId} успешно закреплен за работником {worker.Name} {worker.SureName}");
                }
                else
                {
                    MessageBox.Show("Ошибка переопределения заказа!", "Ошибка");
                }
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
            this.Close();
        }

        private void distribute_Button_Click(object sender, EventArgs e)
        {
           
            if (workers_Listbox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника", "Сообщение");
            }
            else
            {
                distributeOrder();
            }
        }

        private void managerMenu_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void workerId_TextBox_TextChanged(object sender, EventArgs e)
        {
            List<Worker> workersList = new List<Worker>();
            if (workerId_TextBox.Text != "")
            {
                foreach (Worker item in workers_Listbox.Items)
                {
                    if (item.Name.Contains(workerId_TextBox.Text) || item.SureName.Contains(workerId_TextBox.Text))
                    {
                        workersList.Add(item);
                    }
                }
                workers_Listbox.Items.Clear();
                workersList.ForEach(c => workers_Listbox.Items.Add(c));
            }
            else
            {
                workers_Listbox.Items.Clear();
                OrderInfoForm_Load(this, null);
            }
        }
    }
}
