using CamerasDb.Migrations;
using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.Services;
using CamerasDb.Services.MailService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Managerr = CamerasDb.Model.Managerr;

namespace CamerasDb
{
    public class DirectorService
    {
        private readonly AppDbContext _context;
        DataDbService dbService = DataDbService.Instance;
        WorkerService workerService = WorkerService.Instance;
        ManagerService managerService = ManagerService.Instance;

        private DirectorService()
        {
            _context = new AppDbContext();
        }
        public static DirectorService Instance { get => AdminServiceCreate.instance; }
        private class AdminServiceCreate
        {
            static AdminServiceCreate() { }
            internal static readonly DirectorService instance = new DirectorService();
        }

        public async Task<List<IUser>> GetUsers()
        {
            List<IUser> users = new List<IUser>();

            await Task.Run(() =>
            {
                workerService.GetWorkersListAsync().Result.ForEach(u => users.Add(u));
                managerService.GetManagersListAsync().Result.ForEach(u => users.Add(u));
            });

            return users;
        }        
    }
}

