using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.Services;
using CamerasDb.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace CamerasDb
{
    public class DataDbService
    {
        protected AppDbContext _context;

        protected string tableName = "";
        IList list = null;
        protected DataDbService()
        {
            _context = new AppDbContext();
        }

        public static DataDbService Instance { get => DataDbServiceCreate.instance; }
        private class DataDbServiceCreate
        {
            static DataDbServiceCreate() { }
            internal static readonly DataDbService instance = new DataDbService();
        }
        public async Task<string> GetDbInfo(IUser user)
        {
            try
            {
                string res = "";
                await Task.Run(() =>
                {
                    res = "Всего моделей фотоаппаратов: " + (GetProductsListAsync().Result.Count).ToString() + "\n"
                    + "Всего магазинов: " + (GetStoresListAsync().Result.Count).ToString() + "\n"
                    + "Всего производителей: " + (GetManufacturersListAsync().Result.Count).ToString() + "\n"
                    + "Всего наименований запчастей: " + (GetSparePartsListAsync().Result.Count).ToString() + "\n";

                    if (user is Managerr manager)
                    {
                       res += "Заказов на закупку: " + (GetPurchasesListAsync(manager).Result.Count).ToString() + "\n"
                    + "Заказов на производстве: " + (GetProductionsListAsync(manager).Result.Count).ToString() + "\n" + "\n";
                    }
                    else if (user is Director director)
                    {
                        res += "Всего заказов" + (OrderService.Instance.GetOrderListAsync().Result.Count) + "\n"
                        +"Заказов на закупку: " + (GetPurchasesListAsync().Result.Count).ToString() + "\n"
                    + "Заказов на производстве: " + (GetProductionsListAsync().Result.Count).ToString() + "\n"
                    + "Всего менеджеров: " + (ManagerService.Instance.GetManagersListAsync().Result.Count).ToString() + "\n"
                    + "Всего работников " + (WorkerService.Instance.GetWorkersListAsync().Result.Count).ToString() + "\n" + "\n";              
                    }
                });
                return res;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public async Task<string> ShowTableAsync(DataGridView dataGridView, ToolStripComboBox comboBox, Table table, IUser user)
        {                      
            try
            {                          
                if (comboBox.SelectedItem != null)
                {
                    var temp = comboBox.SelectedItem.ToString();
                    await OrderService.Instance.UpdateOrderDateStatusAsync();
                    await Task.Run(() =>
                    {
                        switch (temp)
                        {
                            case "Фотоаппараты":
                                dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from products in _context.Products
                                                                                                select new
                                                                                                {
                                                                                                    products.Id,
                                                                                                    Продукт = products.ModelName,
                                                                                                    Цена = products.Price
                                                                                                }).ToList()));
                                break;
                            case "Закупки":
                                if (user is Managerr)
                                {
                                    dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from purchases in _context.Purchases
                                                                                                    join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                                                                                    join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                                                                                    join workers in _context.Workers on purchases.Worker.Id equals workers.Id
                                                                                                    join managers in _context.Managers on table.UserId.Value equals managers.Workers.FirstOrDefault().Manager.Id
                                                                                                    join orders in _context.Orders on purchases.Id equals orders.OrderId
                                                                                                    where orders.Name == "Закупки"
                                                                                                    where purchases.Worker.Manager.Id == managers.Id
                                                                                                    select new
                                                                                                    {
                                                                                                        purchases.Id,
                                                                                                        Дата = purchases.Date,
                                                                                                        Количество = purchases.Amount,
                                                                                                        Магазин = purchases.Store.Name,
                                                                                                        Продукт = products.ModelName,
                                                                                                        Сотрудник = workers.Name + workers.SureName,
                                                                                                        Статус_заказа = orders.Status
                                                                                                    }).ToList()));
                                }
                                else if (user is Worker)
                                {
                                    dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from purchases in _context.Purchases
                                                                                                    join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                                                                                    join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                                                                                    join orders in _context.Orders on purchases.Id equals orders.OrderId
                                                                                                    where orders.Name == "Закупки"
                                                                                                    where purchases.Worker.Id == table.UserId.Value
                                                                                                    select new
                                                                                                    {
                                                                                                        purchases.Id,
                                                                                                        Дата = purchases.Date,
                                                                                                        Количество = purchases.Amount,
                                                                                                        Магазин = purchases.Store.Name,
                                                                                                        Продукт = products.ModelName,
                                                                                                        Статус_заказа = orders.Status
                                                                                                    }).ToList()));
                                }
                                break;
                            case "Производство":
                                if (user is Managerr)
                                {
                                    dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from production in _context.Productions
                                                                                                    join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                                                                                    join products in _context.Products on production.Products.FirstOrDefault().Id equals products.Id
                                                                                                    join workers in _context.Workers on production.Worker.Id equals workers.Id
                                                                                                    join managers in _context.Managers on table.UserId.Value equals managers.Workers.FirstOrDefault().Manager.Id
                                                                                                    join orders in _context.Orders on production.Id equals orders.OrderId
                                                                                                    where orders.Name == "Производство"
                                                                                                    where production.Worker.Manager.Id == managers.Id
                                                                                                    select new
                                                                                                    {
                                                                                                        production.Id,
                                                                                                        Дата = production.Date,
                                                                                                        Количество = production.Amount,
                                                                                                        Производитель = production.Manufacturer.Name,
                                                                                                        Продукт = products.ModelName,
                                                                                                        Сотрудник = workers.Name + workers.SureName,
                                                                                                        Статус_заказа = orders.Status
                                                                                                    }).ToList()));
                                }
                                else if (user is Worker)
                                {
                                    dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from production in _context.Productions
                                                                                                    join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                                                                                    join products in _context.Products on production.Products.FirstOrDefault().Id equals products.Id
                                                                                                    join orders in _context.Orders on production.Id equals orders.OrderId
                                                                                                    where orders.Name == "Производство"
                                                                                                    where production.Worker.Id == table.UserId.Value
                                                                                                    select new
                                                                                                    {
                                                                                                        production.Id,
                                                                                                        Дата = production.Date,
                                                                                                        Количество = production.Amount,
                                                                                                        Производитель = production.Manufacturer.Name,
                                                                                                        Продукт = products.ModelName,
                                                                                                        Статус_заказа = orders.Status
                                                                                                    }).ToList()));
                                }
                                break;
                            case "Запчасти":
                                dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from sparepart in _context.SpareParts
                                                                                                join manufacturer in _context.Manufacturers on sparepart.Manufacturer.Id equals manufacturer.Id
                                                                                                join product in _context.Products on sparepart.Product.Id equals product.Id
                                                                                                select new
                                                                                                {
                                                                                                    sparepart.Id,
                                                                                                    Запчасть = sparepart.Name,
                                                                                                    Цена = sparepart.Price,
                                                                                                    Производитель = sparepart.Manufacturer.Name,
                                                                                                    Продукт = product.ModelName
                                                                                                }).ToList()));
                                break;
                            case "Производители":
                                dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from manufacturer in _context.Manufacturers
                                                                                                select new
                                                                                                {
                                                                                                    manufacturer.Id,
                                                                                                    Производитель = manufacturer.Name,
                                                                                                    Количество_заказов = manufacturer.Productions.Count,
                                                                                                    Количество_запчастей = manufacturer.SpareParts.Count
                                                                                                }).ToList())); ;
                                break;
                            case "Магазины":
                                dataGridView.Invoke(new Action(() => dataGridView.DataSource = (from store in _context.Stores
                                                                                                select new
                                                                                                {
                                                                                                    store.Id,
                                                                                                    Магазин = store.Name,
                                                                                                    Количество_заказов = store.Purchases.Count
                                                                                                }).ToList()));
                                break;
                            case "Запросы":
                                dataGridView.Invoke(new Action(() => dataGridView.DataSource = null));
                                break;
                            default:
                                break;
                        }
                    });

                    tableName = comboBox.Text;
                }
                else
                {
                    return "";
                }                           
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return tableName;
        }

        public async Task<bool> SaveDataAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<bool> CheckDataAsync(DataGridView dataGridView, IList list)
        {
            try
            {
                if (list !=null)
                {
                    if (list.Count > 0)
                    {
                        await Task.Run(() =>
                        {
                            dataGridView.Invoke(new Action(() => dataGridView.DataSource = list));
                        });

                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
        public async Task<Purchase> GetPurchaseAsync(object searchType)
        {
            if (searchType is int purchaseId)
            {
                return await _context.Purchases.Include("Worker").Include("Store").Include("Products").FirstOrDefaultAsync(p => p.Id == purchaseId);
            }
            else if (searchType is DateTime purchaseDate)
            {
                return await _context.Purchases.Include("Worker").Include("Store").Include("Products").FirstOrDefaultAsync(p => p.Date == purchaseDate);
            }
            else
            {
                return null;
            }
        }
        public async Task<Production> GetProductionAsync(object searchType)
        {
            if (searchType is int productionId)
            {
                return await _context.Productions.Include("Worker").Include("Manufacturer").Include("Products").FirstOrDefaultAsync(p => p.Id == productionId);
            }
            else if (searchType is DateTime prodDate)
            {
                return await _context.Productions.Include("Worker").Include("Manufacturer").Include("Products").FirstOrDefaultAsync(p => p.Date == prodDate);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Product>> GetProductsListAsync()
        {
            return await _context.Products.Include("Productions").Include("Purchases").ToListAsync();
        }
        public async Task<List<Store>> GetStoresListAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<List<Manufacturer>> GetManufacturersListAsync()
        {
            return await _context.Manufacturers.ToListAsync();
        }
        public async Task<List<Purchase>> GetPurchasesListAsync()
        {
            return await _context.Purchases.Include("Store").Include("Products").ToListAsync();
        }
        public async Task<List<Purchase>> GetPurchasesListAsync(Managerr manager)
        {
            return await _context.Purchases.Include("Worker").Include("Worker.Manager").Where(p => p.Worker.Manager.Id == manager.Id).ToListAsync();
        }
        public async Task<List<Production>> GetProductionsListAsync()
        {
            return await _context.Productions.Include("Manufacturer").Include("Products").ToListAsync();
        }
        public async Task<List<Production>> GetProductionsListAsync(Managerr manager)
        {
            return await _context.Productions.Include("Worker").Include("Worker.Manager").Where(p => p.Worker.Manager.Id == manager.Id).ToListAsync();
        }
        public async Task<List<SparePart>> GetSparePartsListAsync()
        {
            return await _context.SpareParts.ToListAsync();
        }
    }
}
