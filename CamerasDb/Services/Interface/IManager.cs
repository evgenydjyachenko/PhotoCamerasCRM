using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace CamerasDb.Model.Interface
{
    public interface IManager
    {

        Task<bool> AllocateWorkerToManager(Managerr manager, Worker worker);
        Task<Managerr> GetManagerAsync(int managerId);
        Task<List<Managerr>> GetManagersListAsync();
        Task<bool> GetManagerStatisticAsync(Managerr manager, ListBox closedOrders, ListBox openedOrders, ListBox overdueOrders, ListBox cancelledOrders, Label ordersAmount, Label userInfo);

    }
}
