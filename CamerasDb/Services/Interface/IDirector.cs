using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model.Interface
{
    public interface IDirector
    {
        Managerr GetManagerAsync(int managerId);
        Task<List<Managerr>> GetManagersListAsync();
        Task<List<IUser>> GetUsers();

    }
}
