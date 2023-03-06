using CamerasDb.Model;
using CamerasDb.View;
using CamerasDb.View.ManagerView;
using CamerasDb.View.QueryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthFrom());
            //Application.Run(new ManagerTableForm(new Managerr()));
          
        }

    }
}
