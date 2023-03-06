using CamerasDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services.Interface
{
    public interface IAuth
    {
        Task<IUser> CheckLoginPassword(string login, string password);
        Task<IUser> Login(TextBox login, TextBox password);
    }
}
