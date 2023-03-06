using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.Services.MailService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services
{
    public class AccountService: IAcc
    {
        private readonly AppDbContext _context;
        private readonly IEncrypt _encrypt;

        private AccountService()
        {
            _context = new AppDbContext();
            _encrypt = new Encrypt();
        }
        public static AccountService Instance { get => AccountServiceCreate.instance; }

        private class AccountServiceCreate
        {
            static AccountServiceCreate() { }
            internal static readonly AccountService instance = new AccountService();
        }

        public async Task<Managerr> AddManagerAccAsync(Managerr manager, string email)
        {
            try
            {
                if (_context.Managers.Count() == 0)
                {
                    manager.Login = "Manager_1";
                }
                else
                {
                    var Id = (_context.Managers.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1);
                    manager.Login = "Manager_" + Id;
                }
                manager.Password = Guid.NewGuid().ToString().Substring(0, 8);
                manager.Salt = Guid.NewGuid().ToString();
                RegistrationMessage registrationMessage = new RegistrationMessage(manager.Name, manager.SureName, manager.Login, manager.Password) { MailAdressTo = email };
                await MailSenderService.Send(registrationMessage);

                manager.Password = await _encrypt.HashPassword(manager.Password, manager.Salt);

                _context.Managers.Add(manager);
                await _context.SaveChangesAsync();
                return manager;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<Worker> AddWorkerAccAsync(Worker worker, string emai)
        {
            try
            {
                if (_context.Workers.Count() == 0)
                {
                    worker.Login = "Worker_1";
                }
                else
                {
                    var Id = (_context.Workers.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1);
                    worker.Login = "Worker_" + Id;
                }

                worker.Password = Guid.NewGuid().ToString().Substring(0, 8);
                worker.Salt = Guid.NewGuid().ToString();

                RegistrationMessage registrationMessage = new RegistrationMessage(worker.Name, worker.SureName, worker.Login, worker.Password) { MailAdressTo = emai };
                await MailSenderService.Send(registrationMessage);

                worker.Password = await _encrypt.HashPassword(worker.Password, worker.Salt);
                _context.Workers.Add(worker);

                await _context.SaveChangesAsync();
                return worker;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<Director> AddDirectorAccAsync(Director director, string emai)
        {
            try
            {
                if (_context.Directors.Count() == 0)
                {
                    director.Login = "Director_1";
                }
                else
                {
                    var Id = (_context.Directors.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1);
                    director.Login = "Director_" + Id;
                }
                director.Password = Guid.NewGuid().ToString().Substring(0, 8);
                director.Salt = Guid.NewGuid().ToString();
                RegistrationMessage registrationMessage = new RegistrationMessage(director.Name, director.SureName, director.Login, director.Password) { MailAdressTo = emai };
                await MailSenderService.Send(registrationMessage);
                director.Password = await _encrypt.HashPassword(director.Password, director.Salt);

                _context.Directors.Add(director);
                await _context.SaveChangesAsync();
                return director;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<bool> DeleteWorkerAccAsync(Worker worker)
        {
            Worker temp = new Worker();
            try
            {
                Worker selectedWorker = (Worker)(await GetObjectAsync(worker, worker.Login));
                if (selectedWorker != null)
                {                  
                    foreach(var item in selectedWorker.Orders)
                    {
                        temp.Orders.Add(item);
                    }
                    
                    selectedWorker.Orders.Clear();selectedWorker.Purchases.Clear();selectedWorker.Productions.Clear();
                                                                        
                    await _context.SaveChangesAsync();
                    
                    _context.Workers.Remove(selectedWorker);
                    await _context.SaveChangesAsync();
                    await OrderService.Instance.DeleteOrdersFromWorkerAsync(temp);
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
        public async Task<bool> DeleteManagerAccAsync(Managerr manager)
        {
            try
            {
                var res = await GetObjectAsync(manager, manager.Login);
                if (res != null)
                {
                    manager = (Managerr)res;
                    manager.Workers.Clear();
                    _context.Managers.Remove(manager);
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
        public async Task<bool> DeleteAdminAccAsync(Director director)
        {
            try
            {
                var res = await GetObjectAsync(director, director.Login);
                if (res != null)
                {
                    _context.Directors.Remove((Director)res);
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
        public async Task<bool> Registration(string name, string surename, string email, string access)
        {
            if (name != "" && surename != "" && email != "")
            {
                try
                {
                    switch (access)
                    {
                        case "Работник":
                            await AddWorkerAccAsync(new Worker() { Name = name, SureName = surename }, email);
                            break;
                        case "Менеджер":
                            await AddManagerAccAsync(new Managerr() { Name = name, SureName = surename }, email);
                            break;
                        case "Администратор":
                            await AddDirectorAccAsync(new Director() { Name = name, SureName = surename }, email);
                            break;
                        default:
                            return false;
                    }
                }
                catch (Exception)
                {

                    throw new Exception();
                }

                return true;
            }
            return false;
        }
        public async Task<IUser> GetObjectAsync(IUser user, string login)
        {
            if (user is Worker)
            {
                return await _context.Workers.Include("Manager").Include("Orders").Include("Purchases").Include("Purchases.Store").Include("Productions").Include("Productions.Manufacturer").FirstOrDefaultAsync(u => u.Login == login);
            }

            else if (user is Managerr)
            {
                return await _context.Managers.Include("Workers").FirstOrDefaultAsync(u => u.Login == login);
            }
            else
            {
                return null;
            }

        }
    }
}
