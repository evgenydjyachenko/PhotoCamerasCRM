using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Model.Interface
{
    public interface IWorker
    {
        Task<Worker> GetWorkerAsync(int workerId);
        Task<List<Worker>> GetWorkersAsync(Managerr manager);
        Task<List<Worker>> GetWorkersListAsync();
        Task<List<Worker>> GetUnallocatedWorkersListAsync();
        Task<List<Worker>> GetSubordinateWorkersAsync(Managerr manager);
        Task<bool> GetWorkerStatisticAsync(Worker worker, ListBox closedOrders, ListBox openedOrders, ListBox overdueOrders, ListBox cancelledOrders, Label ordersAmount, Label workerInfo);
    }
}
