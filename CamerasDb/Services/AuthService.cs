using CamerasDb.Migrations;
using CamerasDb.Model;
using CamerasDb.Services;
using CamerasDb.Services.Interface;
using CamerasDb.View;
using CamerasDb.View.ManagerView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Director = CamerasDb.Model.Director;
using Managerr = CamerasDb.Model.Managerr;

namespace CamerasDb
{
    public class AuthService: IAuth
    {
        private readonly AppDbContext _context;
        private readonly IEncrypt _encrypt;
        List<DbSet<object>> users = new List<DbSet<object>>() ;

        public AuthService()
        {
            _context = new AppDbContext();
            _encrypt = new Encrypt();           
        }

        public static AuthService Instance { get => AuthnServiceCreate.instance; }
        private class AuthnServiceCreate
        {
            static AuthnServiceCreate() { }

            internal static readonly AuthService instance = new AuthService();
        }
        
        public async Task<IUser> CheckLoginPassword(string login, string password)
        {

           
            try
            {                                    
                if (await _context.Workers.FirstOrDefaultAsync(p => p.Login == login) != null)
                {
                    Worker worker = await _context.Workers.FirstOrDefaultAsync(p => p.Login == login);
                    if (await _encrypt.VerifyPassword(password,worker.Password,worker.Salt) == true)
                    {
                        return worker;
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!","Сообщение");
                        return null;
                    }
                }
                
                else if (await _context.Managers.FirstOrDefaultAsync(p => p.Login == login) != null)
                {
                    Managerr manager = await _context.Managers.FirstOrDefaultAsync(p => p.Login == login);
                    if (await _encrypt.VerifyPassword(password, manager.Password, manager.Salt) == true)
                    {
                        return manager;
                    }
                    else
                    {
                        MessageBox.Show("неверный пароль!");
                        return null;
                    }
                }
                
                else if (await _context.Directors.FirstOrDefaultAsync(p => p.Login == login) != null)
                {
                    Director director = await _context.Directors.FirstOrDefaultAsync(p => p.Login == login);
                    if (await _encrypt.VerifyPassword(password, director.Password, director.Salt) == true)
                    {
                        return director;
                    }
                    else
                    {
                        MessageBox.Show("неверный пароль!");
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show($"Пользователя с именем {login} в базе данных не существует. Попробуйте заново.", "Сообщение");
                    return null;
                }            
            }
            catch (Exception)
            {
                throw new Exception();               
            }                     
        }

        public async Task<IUser> Login(TextBox login, TextBox password)
        {          
            try
            {
                IUser user = await CheckLoginPassword(login.Text, password.Text);
                
                if (user != null)
                {
                    MessageBox.Show("Авторизация прошла успешно", "Сообщение");

                    if (user is Managerr)
                    {
                        new ManagerForm((Managerr)user).ShowDialog();
                    }
                    else if (user is Worker)
                    {
                        new WorkerTableForm((Worker)user).ShowDialog();
                    }
                    else if (user is Director)
                    {
                        new DirectorForm((Director)user).ShowDialog();
                    }
                    return user;
                }
                password.Text = login.Text = "";
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
            return null;
        }     
    }
}
