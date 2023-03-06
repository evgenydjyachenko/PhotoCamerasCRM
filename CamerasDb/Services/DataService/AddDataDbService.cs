using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using CamerasDb.Services;
using System.Drawing.Printing;
using System.Collections;

namespace CamerasDb.Services
{
    public class AddDataDbService : DataDbService, IAddDb
    {       
        public static AddDataDbService Instance { get => AddDataDbServiceCreate.instance; }
        private class AddDataDbServiceCreate
        {
            static AddDataDbServiceCreate() { }
            internal static readonly AddDataDbService instance = new AddDataDbService();
        }
        public async Task<bool> AddDataAsync(string tableName, Table table, IUser user)
        {
            switch (tableName)
            {
                case "Фотоаппараты":
                    return await AddProductAsync(table);
                case "Закупки":
                    return await AddPurchaseAsync((Worker)user, table);
                case "Производство":
                    return await AddProductionAsync((Worker)user, table);
                case "Запчасти": 
                    return await AddSparePartAsync(table);
                case "Производители":
                    return await AddManufacturerAsync(table);
                case "Магазины":
                    return await AddStoreAsync(table);
                default:
                    return false;
            }
        }
        public async Task<bool> AddProductAsync(Table table)
        {
            try
            {
                Product newProduct = new Product() { ModelName = table.NewModelName.Text, Price = table.NewPrice.Value };
                if (newProduct.ModelName != "" && newProduct.Price > 0)
                {
                    _context.Products.Add(newProduct);

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

        public async Task<bool> AddPurchaseAsync(Worker worker, Table table)
        {
            try
            {
                Purchase newPurchase = new Purchase()
                {

                    Date = table.NewPurchaseDate.Value.Date,
                    Amount = (int)table.NewAmount.Value,
                    Store = _context.Stores.Include("Purchases").FirstOrDefault(s => s.Name == table.NewStoreName.Text),
                    Worker = _context.Workers.Include("Purchases").FirstOrDefault(w => w.Id == worker.Id)

                };
                var findedProduct = _context.Products.Include("Purchases").FirstOrDefault(p => p.Id == table.NewProduct_Id.Value);
                if (findedProduct != null && newPurchase.Amount > 0 && newPurchase.Store != null && newPurchase.Worker != null/* && newPurchase.Date >= DateTime.Today*/)
                {
                    newPurchase.Products.Add(findedProduct);
                    var findedStore = _context.Stores.Include("Purchases").FirstOrDefault(s => s.Name == newPurchase.Store.Name);
                    findedStore.Purchases.Add(newPurchase);
                    newPurchase.Worker.Purchases.Add(newPurchase);

                    _context.Purchases.Add(newPurchase);
                    await _context.SaveChangesAsync();

                    await OrderService.Instance.AddOrderToWorkerAsync(worker, table, newPurchase);
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

        public async Task<bool> AddStoreAsync(Table table)
        {
            try
            {
                Store newStore = new Store() { Name = table.NewStoreName.Text };

                if (newStore.Name != "")
                {
                    _context.Stores.Add(newStore);
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

        public async Task<bool> AddSparePartAsync(Table table)
        {
            try
            {
                SparePart newSparePart = new SparePart()
                {
                    Name = table.NewSparePartName.Text,
                    Price = table.NewPrice.Value,
                    Manufacturer = _context.Manufacturers.Include("SpareParts").FirstOrDefault(m => m.Name == table.NewManufacturerName.Text),
                    Product = _context.Products.Include("SpareParts").FirstOrDefault(p => p.Id == table.Product_Id.Value)
                };
                
                if (newSparePart.Product != null && newSparePart.Manufacturer != null && newSparePart.Name != "" && newSparePart.Price > 0)
                {
                    newSparePart.Manufacturer.SpareParts.Add(newSparePart);
                    newSparePart.Product.SpareParts.Add(newSparePart);
                    _context.SpareParts.Add(newSparePart);

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

        public async Task<bool> AddManufacturerAsync(Table table)
        {
            try
            {
                Manufacturer newManufacturer = new Manufacturer() { Name = table.NewManufacturerName.Text };

                if (newManufacturer.Name != "")
                {
                    _context.Manufacturers.Add(newManufacturer);
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

        public async Task<bool> AddProductionAsync(Worker worker, Table table)
        {
            try
            {
                Production newProduction = new Production()
                {
                    Date = table.NewProdDate.Value.Date,
                    Amount = (int)table.NewAmount.Value,
                    Manufacturer =  _context.Manufacturers.Include("Productions").FirstOrDefault(m => m.Name == table.NewManufacturerName.Text),
                    Worker = _context.Workers.Include("Productions").FirstOrDefault(w => w.Id == worker.Id)
                };
                var product = _context.Products.Include("Productions").FirstOrDefault(p => p.Id == table.NewProduct_Id.Value);

                if (product != null && newProduction.Manufacturer != null &&newProduction.Worker != null && newProduction.Amount > 0 /* && newProduction.Date >= DateTime.Today*/)
                {
                    product.Productions.Add(newProduction);
                    newProduction.Products.Add(product);
                    newProduction.Manufacturer.Productions.Add(newProduction);
                    newProduction.Worker.Productions.Add(newProduction);
                    
                    _context.Productions.Add(newProduction);
                    await _context.SaveChangesAsync();

                    await OrderService.Instance.AddOrderToWorkerAsync(worker, table, newProduction);
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
    }
}
