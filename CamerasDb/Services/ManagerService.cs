using CamerasDb.Model;
using CamerasDb.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services
{
    public class ManagerService: IManager
    {
        private readonly AppDbContext _context;
        private ManagerService()
        {
            _context = new AppDbContext();
        }
        public static ManagerService Instance { get => ManagerServiceCreate.instance; }
        private class ManagerServiceCreate
        {
            static ManagerServiceCreate() { }
            internal static readonly ManagerService instance = new ManagerService();
        }
        public async Task<Managerr> GetManagerAsync(int managerId)
        {
            return await _context.Managers.Include("Workers").Include("Workers.Orders").FirstOrDefaultAsync(m => m.Id == managerId);
        }
        
        public async Task<List<Managerr>> GetManagersListAsync()
        {
            return await _context.Managers.Include("Workers").ToListAsync();
        }

        public async Task<bool> AllocateWorkerToManager(Managerr manager, Worker worker)
        {          
            try
            {
                var findedManager = _context.Managers.Include("Workers").FirstOrDefault(m => m.Id == manager.Id);
                //var findedWorker = await workerService.GetWorkerAsync(worker.Id);//было
                var findedWorker = await _context.Workers.Include("Manager").FirstOrDefaultAsync(w => w.Id == worker.Id);//стало

                findedWorker.Manager = findedManager;
                findedManager.Workers.Add(findedWorker);
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }          
        }

        public async Task<bool> GetManagerStatisticAsync(Managerr manager, ListBox closedOrders, ListBox openedOrders, ListBox overdueOrders, ListBox cancelledOrders, Label ordersAmount, Label userInfo)
        {
            try
            {
                userInfo.Text = $"Менеджер: {manager.Name} {manager.SureName}";
                ordersAmount.Text = $"В подчинении работников: {WorkerService.Instance.GetSubordinateWorkersAsync(manager).Result.Count}";
                var findedManager = await GetManagerAsync(manager.Id);
                var workers = await WorkerService.Instance.GetSubordinateWorkersAsync(findedManager);

                foreach (var worker in workers)
                {
                    foreach(var order in worker.Orders)
                    {
                        switch (order.Status)
                        {
                            case "Выполнен":
                                closedOrders.Invoke(new Action(() => closedOrders.Items.Add(order + $" Работник: {worker.Name} {worker.SureName}")));
                                break;
                            case "В работе":
                                openedOrders.Invoke(new Action(() => openedOrders.Items.Add(order + $" Работник: {worker.Name} {worker.SureName}")));
                                break;
                            case "Просрочен":
                                overdueOrders.Invoke(new Action(() => overdueOrders.Items.Add(order + $" Работник: {worker.Name} {worker.SureName}")));
                                break;
                            case "Отменён":
                                cancelledOrders.Invoke(new Action(() => cancelledOrders.Items.Add(order + $" Работник: {worker.Name} {worker.SureName}")));
                                break;
                        }
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
