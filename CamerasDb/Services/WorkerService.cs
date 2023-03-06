using CamerasDb.Model;
using CamerasDb.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services
{
    public class WorkerService: IWorker
    {
        private readonly AppDbContext _context;

        private WorkerService()
        {
            _context = new AppDbContext();
        }

        public static WorkerService Instance { get => WorkerServiceCreate.instance; }
        private class WorkerServiceCreate
        {
            static WorkerServiceCreate() { }
            internal static readonly WorkerService instance = new WorkerService();   
        }

        public async Task<Worker> GetWorkerAsync(int workerId)
        {
            return await _context.Workers.Include("Manager").Include("Orders").Include("Productions").Include("Purchases").Include("Purchases.Store").Include("Productions.Manufacturer").FirstOrDefaultAsync(w => w.Id == workerId);
        }

        public async Task<List<Worker>> GetWorkersAsync(Managerr manager)
        {
            return await _context.Workers.Include("Manager").Include("Orders").Where(w => w.Manager.Id == manager.Id).ToListAsync();
        }
        public async Task<List<Worker>> GetWorkersListAsync()
        {
            return await _context.Workers.Include("Manager").Include("Orders").ToListAsync();

        }
        public async Task<List<Worker>> GetUnallocatedWorkersListAsync()
        {
            return await _context.Workers.Where(w => w.Manager == null).ToListAsync();
        }

        public async Task<List<Worker>> GetSubordinateWorkersAsync(Managerr manager)
        {
            try
            {
                List<Worker> workers = null;
                List<Worker> workersList = new List<Worker>();

                    workers = _context.Workers.ToList().Where(w => w.Manager != null).Where(w => w.Manager.Id == manager.Id).ToList();

                return workers;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<bool> GetWorkerStatisticAsync(Worker worker, ListBox closedOrders, ListBox openedOrders, ListBox overdueOrders, ListBox cancelledOrders, Label ordersAmount, Label userInfo)
        {
            try
            {
                userInfo.Text = $"Работник: {worker.Name} {worker.SureName}";
                ordersAmount.Text = $"Всего заказов: {worker.Orders.Count}";
                var findedWorker = await _context.Workers.Include("Orders").Include("Manager").Include("Productions").Include("Purchases").Include("Purchases.Store").FirstOrDefaultAsync(w => w.Id == worker.Id);

                foreach (var order in findedWorker.Orders)
                {
                    switch (order.Status)
                    {
                        case "Выполнен":
                            closedOrders.Invoke(new Action(() => closedOrders.Items.Add(order)));
                            break;
                        case "В работе":
                            openedOrders.Invoke(new Action(() => openedOrders.Items.Add(order)));
                            break;
                        case "Просрочен":
                            overdueOrders.Invoke(new Action(() => overdueOrders.Items.Add(order)));
                            break;
                        case "Отменён":
                            cancelledOrders.Invoke(new Action(() => cancelledOrders.Items.Add(order)));
                            break;
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

    }
}
