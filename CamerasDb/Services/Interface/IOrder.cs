using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model.Interface
{
    public interface IOrder
    {
        Task<List<Order>> GetCancelledOrdersListAsync(Managerr manager);
        Task<List<Order>> GetCancelledOrdersListAsync();
        Task<List<Order>> GetClosedOrdersListAsync(Managerr manager);
        Task<List<Order>> GetClosedOrdersListAsync();
        Task<List<Order>> GetOverdueOrdersListAsync(Managerr manager);
        Task<List<Order>> GetOverdueOrdersListAsync();
        Task<List<Order>> GetOrdersInWorkListAsync();
        Task<Order> GetOrderAsync(int orderId);
        Task<List<Order>> GetUnallocatedOrdersListAsync(Managerr manager);
        Task<List<Order>> GetUnallocatedOrdersListAsync();
        Task<bool> AddOrderToWorkerAsync(Worker worker, Table table, IObject obj);
        Task<bool> CloseOrderToWorkerAsync(IObject obj);
        Task<bool> UpdateOrderDateStatusAsync();
        Task<bool> DeleteOrdersFromWorkerAsync(Worker worker);
        Task<Worker> AssignOrderToWorkerAsync(Worker worker, Order order);
        Task<string> GetDetailedOrderInfoAsync(Order order);
        Task<string> GetOrdersInfoAsync(IUser user);

    }
}
