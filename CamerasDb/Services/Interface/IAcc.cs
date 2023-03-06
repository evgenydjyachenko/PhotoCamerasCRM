using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public interface IAcc
    {
        Task<Managerr> AddManagerAccAsync(Managerr manager, string email);
        Task<Worker> AddWorkerAccAsync(Worker worker, string emai);
        Task<Director> AddDirectorAccAsync(Director admin, string emai);
        Task<bool> DeleteWorkerAccAsync(Worker worker);
        Task<bool> DeleteManagerAccAsync(Managerr manager);
        Task<bool> DeleteAdminAccAsync(Director admin);
        Task<IUser> GetObjectAsync(IUser user, string login);
        Task<bool> Registration(string name, string surename, string email, string access);
    }
}
