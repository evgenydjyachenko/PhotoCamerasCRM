using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CamerasDb.Services
{
    public class OrderService: IOrder
    {
        private readonly AppDbContext _context;

        private OrderService()
        {
            _context = new AppDbContext();  
        }
        public static OrderService Instance { get => WorkerServiceCreate.instance; }

        private class WorkerServiceCreate
        {
            static WorkerServiceCreate() { }

            internal static readonly OrderService instance = new OrderService();
        }
        public async Task<List<Order>> GetOrderListAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<List<Order>> GetCancelledOrdersListAsync(Managerr manager)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in await WorkerService.Instance.GetWorkersAsync(manager))
            {
                foreach (var order in item.Orders)
                {
                    if (order.Status == "Отменён")
                    {
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public async Task<List<Order>> GetCancelledOrdersListAsync()
        {
            return await _context.Orders.Include("Worker").Include("Worker.Manager").Where(o => o.Status == "Отменён").ToListAsync();
        }

        public async Task<List<Order>> GetClosedOrdersListAsync(Managerr manager)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in await WorkerService.Instance.GetWorkersAsync(manager))
            {
                foreach (var order in item.Orders)
                {
                    if (order.Status == "Выполнен")
                    {
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public async Task<List<Order>> GetClosedOrdersListAsync()
        {
            return await _context.Orders.Include("Worker").Include("Worker.Manager").Where(o => o.Status == "Выполнен").ToListAsync();
        }
        public async Task<List<Order>> GetOverdueOrdersListAsync(Managerr manager)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in await WorkerService.Instance.GetWorkersAsync(manager))
            {
                foreach (var order in item.Orders)
                {
                    if (order.Status == "Просрочен")
                    {
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public async Task<List<Order>> GetOverdueOrdersListAsync()
        {
            return await _context.Orders.Include("Worker").Include("Worker.Manager").Where(o => o.Status == "Просрочен").ToListAsync();
        }
        public async Task<List<Order>> GetOrdersInWorkListAsync(Managerr manager)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in await WorkerService.Instance.GetWorkersAsync(manager))
            {
                foreach (var order in item.Orders)
                {
                    if (order.Status == "В работе")
                    {
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public async Task<List<Order>> GetOrdersInWorkListAsync()
        {
            return await _context.Orders.Include("Worker").Include("Worker.Manager").Where(o => o.Status == "В работе").ToListAsync();
        }
        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _context.Orders.Include("Worker").Include("Worker.Manager").FirstOrDefaultAsync(o => o.OrderId == orderId);
        }
        public async Task<List<Order>> GetUnallocatedOrdersListAsync(Managerr manager)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in await WorkerService.Instance.GetWorkersAsync(manager))
            {
                foreach (var order in item.Orders)
                {
                    if (order.Status == "Не распределен")
                    {
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public async Task<List<Order>> GetUnallocatedOrdersListAsync()
        {
            return await _context.Orders.Include("Worker").Include("Worker.Manager").Where(o => o.Status == "Не распределен" || o.Worker == null).ToListAsync();
        }
        public async Task<Order> CanceldOrderAsync(Order order)
        {
            try
            {
                order.Status = "Отменён";           
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<Order> CloseOrderAsync(Order order)
        {
            try
            {
                order.Status = "Выполнен";
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception)
            {

                throw new Exception();
            }       
        }
        public async Task<bool> AddOrderToWorkerAsync(Worker worker, Table table, IObject obj)
        {
            try
            {
                Order order = new Order()
                {
                    CloseDate = table.PurchaseDate.Value.Date,
                    Worker = await _context.Workers.Include("Orders").FirstOrDefaultAsync(w => w.Id == worker.Id),
                    Status = "В работе"
                };
                if (obj is Purchase)
                {
                    order.Name = "Закупки";
                    Purchase purchase = (Purchase)obj;
                    var orderId = await _context.Purchases.Include("Worker").FirstOrDefaultAsync(p => p.Id == purchase.Id);
                    order.OrderId = orderId.Id;
                }
                else if (obj is Production)
                {
                    order.Name = "Производство";
                    Production production = (Production)obj;
                    var orderId = await _context.Productions.Include("Worker").FirstOrDefaultAsync(p => p.Id == production.Id);
                    order.OrderId = orderId.Id;
                }
                order.Worker.Orders.Add(order);

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<bool> CloseOrderToWorkerAsync(IObject obj)
        {
            Order order = null;
          
            try
            {
                if (obj is Purchase purchase)
                {
                    order = await GetOrderAsync(purchase.Id);
                    if (order != null)
                    {
                        await CloseOrderAsync(order);
                        return true;
                    }
                }
                if (obj is Production prod)
                {
                    order = await GetOrderAsync(prod.Id);
                    if (order != null)
                    {
                        await CloseOrderAsync(order);
                        return true;
                    }
                }
                if (obj is Product product)
                {
                    foreach (var item in product.Purchases)
                    {
                        order = await GetOrderAsync(item.Id);
                        if (order != null)
                        {
                            await CanceldOrderAsync(order);
                        }
                    }

                    foreach (var item in product.Productions)
                    {
                        order = await GetOrderAsync(item.Id);
                        if (order != null)
                        {
                            await CanceldOrderAsync(order);
                        }
                    }
                }
                if (obj is Store store)
                {
                    foreach (var item in store.Purchases)
                    {
                        order = await GetOrderAsync(item.Id);
                        if (order != null)
                        {
                            await CanceldOrderAsync(order);
                        }
                    }
                }
                if (obj is Manufacturer manufacturer)
                {
                    foreach (var item in manufacturer.Productions)
                    {
                        order = await GetOrderAsync(item.Id);
                        if (order != null)
                        {
                            await CanceldOrderAsync(order);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return true;  
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }      
        public async Task<bool> UpdateOrderDateStatusAsync()
        {
            try
            {
                var Purchases = _context.Purchases.ToList();
                var Productions = _context.Productions.ToList();

                if (Purchases.Count != 0)
                {
                    foreach (var item in Purchases)
                    {
                        
                        if (item.Date < DateTime.Now.Date)
                        {
                            var purchase = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == item.Id);
                            if (purchase != null)
                            {
                                purchase.Status= "Просрочен";
                            }
                        }                     
                    }
                }
                if (Productions.Count != 0)
                {
                    foreach (var item in Productions)
                    {
                       
                        if (item.Date < DateTime.Now.Date)
                        {
                            var production = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == item.Id);
                            if (production != null)
                            {
                                production.Status= "Просрочен";
                            }
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }                     
        }
        public async Task<bool> DeleteOrdersFromWorkerAsync(Worker worker)
        {       
            try
            {            
                if (worker.Orders.Count > 0)
                {                  
                    foreach (var order in worker.Orders)
                    {                        
                        var findedOrder = _context.Orders.Include("Worker").FirstOrDefault(o => o.OrderId == order.OrderId);

                        if (findedOrder.Status == "Выполнен" || findedOrder.Status == "Отменён")
                        {
                            _context.Orders.Remove(findedOrder);
                        }
                        else
                        {
                            
                            findedOrder.Status = "Не распределен";
                            _context.Orders.AddOrUpdate(findedOrder);
                        }
                    }
                    
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }                        
        }
        public async Task<Worker> AssignOrderToWorkerAsync(Worker worker, Order order)
        {
            List<Production> prodlist;
            List<Purchase> purchaselist;
            Production findedProduction;
            Purchase findedPurchase;
            try
            {     
                var findedOrder = await _context.Orders.Include("Worker").FirstOrDefaultAsync(o => o.OrderId == order.OrderId); //GetOrderAsync(order.OrderId);
                var findedWorker = await _context.Workers.Include("Orders").Include("Manager").FirstOrDefaultAsync(w => w.Id == worker.Id); //WorkerService.Instance.GetWorkerAsync(worker.Id);

                if (findedOrder != null && findedWorker!= null)
                {
                    switch (order.Name)
                    {
                        case "Производство":
                            prodlist = _context.Productions.Include("Manufacturer").Include("Products").Include("Worker").ToList().Where(p => p.Worker == null).ToList();
                            findedProduction = prodlist.FirstOrDefault(p => p.Id == order.OrderId);
                            findedProduction.Worker = findedWorker;
                            findedProduction.Date = findedOrder.CloseDate = findedProduction.Date < DateTime.Now.Date ? DateTime.Now.Date : findedProduction.Date;

                            break;
                        case "Закупки":
                            purchaselist = _context.Purchases.Include("Store").Include("Products").Include("Worker").ToList().Where(p => p.Worker == null).ToList();
                            findedPurchase = purchaselist.FirstOrDefault(p => p.Id == order.OrderId);
                            findedPurchase.Worker = findedWorker;
                            findedPurchase.Date = findedOrder.CloseDate = findedPurchase.Date < DateTime.Now.Date ? DateTime.Now.Date : findedPurchase.Date;
                            break;
                    }
                   
                    findedOrder.Status = "В работе";
                    findedOrder.Worker = findedWorker;
                    //_context.Orders.AddOrUpdate(findedOrder);

                    await _context.SaveChangesAsync();
                    return findedWorker;
                }                              
                else
                {
                    return null;
                }                 
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<string> GetDetailedOrderInfoAsync(Order order)
        {
            try
            {          
                string res = "";
                
                await Task.Run(() =>
                {
                    switch (order.Name)
                    {
                        case "Закупки":
                            foreach (var item in DataDbService.Instance.GetPurchasesListAsync().Result)
                            {
                                if (item.Id == GetOrderAsync(order.OrderId).Result.OrderId)
                                {
                                    res = $"Id заказа: {item.Id} \nДата закрытия: {item.Date} \nФотоаппарат: {item.Products.FirstOrDefault().ModelName} \nКоличество: {item.Amount} \nМагазин: {item.Store.Name}\n";

                                }
                            }
                            break;
                        case "Производство":
                            foreach (var item in DataDbService.Instance.GetProductionsListAsync().Result)
                            {
                                if (item.Id == GetOrderAsync(order.OrderId).Result.OrderId)
                                {
                                    res = $"Id заказа: {item.Id} \nДата закрытия: {item.Date} \nФотоаппарат: {item.Products.FirstOrDefault().ModelName} \nКоличество: {item.Amount} \nПроизводитель: {item.Manufacturer.Name}\n";
                                }
                            }
                            break;
                    }
                });
                return res;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<string> GetOrdersInfoAsync(IUser user)
        {
            try
            {               
                string res = "";
                if (user is Managerr manager)
                {
                    var findedmanager = await ManagerService.Instance.GetManagerAsync(manager.Id);
                    await Task.Run(() =>
                    {
                        res = "Заказов в работе: " + (GetOrdersInWorkListAsync(manager).Result.Count).ToString() + "\n"
                        + "Выполненных заказов: " + (GetClosedOrdersListAsync(manager).Result.Count).ToString() + "\n"
                        + "Отмененных заказов: " + (GetCancelledOrdersListAsync(manager).Result.Count).ToString() + "\n"
                        + "Просроченных заказов: " + (GetOverdueOrdersListAsync(manager).Result.Count).ToString() + "\n"
                        + "Нераспределенных заказов:" + (GetUnallocatedOrdersListAsync(manager).Result.Count) + "\n" + "\n";
                    });
                }
                else if (user is Director)
                {
                    await Task.Run(() =>
                    {
                        res = "Заказов в работе: " + (GetOrdersInWorkListAsync().Result.Count).ToString() + "\n"
                       + "Выполненных заказов: " + (GetClosedOrdersListAsync().Result.Count).ToString() + "\n"
                       + "Отмененных заказов: " + (GetCancelledOrdersListAsync().Result.Count).ToString() + "\n"
                       + "Просроченных заказов: " + (GetOverdueOrdersListAsync().Result.Count).ToString() + "\n"
                       + "Нераспределенных заказов:" + (GetUnallocatedOrdersListAsync().Result.Count).ToString() + "\n" + "\n";
                    });            
                }                
                return res;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }   
}
