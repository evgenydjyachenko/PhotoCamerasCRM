using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services
{
    public class SearchDataDbService : DataDbService, ISearchDb
    {
        
        string combobox;
        public static SearchDataDbService Instance { get => SearchDataDbServiceCreate.instance; }
        private class SearchDataDbServiceCreate
        {
            static SearchDataDbServiceCreate() { }
            internal static readonly SearchDataDbService instance = new SearchDataDbService();
        }
        public async Task<bool> SearchDataAsync(DataGridView dataGridView, string tableName, Table table)
        {
            try
            {
                switch (tableName)
                {
                    case "Фотоаппараты":
                        return await SearchProductAsync(dataGridView, table);
                    case "Закупки":
                        return await SearchPurchaseAsync(dataGridView, table);
                    case "Производство":
                        return await SearchProductionAsync(dataGridView, table);
                    case "Запчасти":
                        return await SearchSparePartAsync(dataGridView, table);
                    case "Производители":
                        return await SearchManufacturerAsync(dataGridView, table);
                    case "Магазины":
                        return await SearchStoreAsync(dataGridView, table);
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception();
            }          
        }

        public async Task<bool> SearchProductionAsync(DataGridView dataGridView, Table table)
        {
            IList res = null;
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[0]);

                if (combobox != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox)
                        {
                            case "По Id производства":
                                res = (from productions in _context.Productions
                                       join product in _context.Products on productions.Products.FirstOrDefault().Id equals product.Id
                                       join orders in _context.Orders on productions.Id equals orders.OrderId
                                       where productions.Worker.Id == table.UserId.Value
                                       where productions.Id == table.Prod_Id.Value
                                       select new
                                       {
                                           productions.Id,
                                           Дата = productions.Date,
                                           Количество = productions.Amount,
                                           Производитель = productions.Manufacturer.Name,
                                           Продукт = product.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;

                            case "По Id продукта":
                                res  = (from productions in _context.Productions
                                        join product in _context.Products on productions.Products.FirstOrDefault().Id equals product.Id
                                        join orders in _context.Orders on productions.Id equals orders.OrderId
                                        where productions.Worker.Id == table.UserId.Value
                                        where product.Id == table.Product_Id.Value
                                        select new
                                        {/////
                                            productions.Id,
                                            Дата = productions.Date,
                                            Количество = productions.Amount,
                                            Производитель = productions.Manufacturer.Name,
                                            Продукт = product.ModelName,
                                            Статус_заказа = orders.Status
                                        }).ToList();
                                break;

                            case "По количеству":
                                res = (from productions in _context.Productions
                                       join product in _context.Products on productions.Products.FirstOrDefault().Id equals product.Id
                                       join orders in _context.Orders on productions.Id equals orders.OrderId
                                       where productions.Worker.Id == table.UserId.Value
                                       where productions.Amount == (int)table.Amount.Value
                                       select new
                                       {
                                           productions.Id,
                                           Дата = productions.Date,
                                           Количество = productions.Amount,
                                           Производитель = productions.Manufacturer.Name,
                                           Продукт = product.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;

                            case "По названию производителя":
                                res = (from productions in _context.Productions
                                       join product in _context.Products on productions.Products.FirstOrDefault().Id equals product.Id
                                       join orders in _context.Orders on productions.Id equals orders.OrderId
                                       where productions.Worker.Id == table.UserId.Value
                                       where productions.Manufacturer.Name == table.ManufacturerName.Text
                                       select new
                                       {
                                           productions.Id,
                                           Дата = productions.Date,
                                           Количество = productions.Amount,
                                           Производитель = productions.Manufacturer.Name,
                                           Продукт = product.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;

                            case "По дате производства":
                                res = (from productions in _context.Productions
                                       join product in _context.Products on productions.Products.FirstOrDefault().Id equals product.Id
                                       join orders in _context.Orders on productions.Id equals orders.OrderId
                                       where productions.Worker.Id == table.UserId.Value
                                       where productions.Date.Day == table.ProdDate.Value.Day
                                       select new
                                       {
                                           productions.Id,
                                           Дата = productions.Date,
                                           Количество = productions.Amount,
                                           Производитель = productions.Manufacturer.Name,
                                           Продукт = product.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;
                            default:
                                break;
                        }
                    });
                    return await CheckDataAsync(dataGridView, res);
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

        public async Task<bool> SearchPurchaseAsync(DataGridView dataGridView, Table table)
        {
            IList res = null;
            try
            {               
                var combobox = table.CheckComboBox(table.comboBoxes[0]);
                
                if (combobox != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox)
                        {
                            case "По Id закупки":
                                res = (from purchases in _context.Purchases
                                       join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                       join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                       join orders in _context.Orders on purchases.Id equals orders.OrderId
                                       where purchases.Worker.Id == table.UserId.Value
                                       where purchases.Id == table.Purchase_Id.Value
                                       select new
                                       {
                                           purchases.Id,
                                           Дата = purchases.Date,
                                           Количество = purchases.Amount,
                                           Магазин = purchases.Store.Name,
                                           Продукт = products.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;
                            case "По дате закупки":
                                res = (from purchases in _context.Purchases
                                       join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                       join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                       join orders in _context.Orders on purchases.Id equals orders.OrderId
                                       where purchases.Worker.Id == table.UserId.Value
                                       where purchases.Date.Day == table.PurchaseDate.Value.Day
                                       select new
                                       {
                                           purchases.Id,
                                           Дата = purchases.Date,
                                           Количество = purchases.Amount,
                                           Магазин = purchases.Store.Name,
                                           Продукт = products.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;
                            case "По количеству":
                                res = (from purchases in _context.Purchases
                                       join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                       join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                       join orders in _context.Orders on purchases.Id equals orders.OrderId
                                       where purchases.Worker.Id == table.UserId.Value
                                       where purchases.Amount == table.Amount.Value
                                       select new
                                       {
                                           purchases.Id,
                                           Дата = purchases.Date,
                                           Количество = purchases.Amount,
                                           Магазин = purchases.Store.Name,
                                           Продукт = products.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;
                            case "По названию магазина":
                                res = (from purchases in _context.Purchases
                                       join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                       join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                       join orders in _context.Orders on purchases.Id equals orders.OrderId
                                       where purchases.Worker.Id == table.UserId.Value
                                       where stores.Name == table.StoreName.Text
                                       select new
                                       {
                                           purchases.Id,
                                           Дата = purchases.Date,
                                           Количество = purchases.Amount,
                                           Магазин = purchases.Store.Name,
                                           Продукт = products.ModelName,
                                           Статус_заказа = orders.Status
                                       }).ToList();
                                break;
                            case "По Id продукта":
                                res  = (from purchases in _context.Purchases
                                        join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                        join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                        join orders in _context.Orders on purchases.Id equals orders.OrderId
                                        where purchases.Worker.Id == table.UserId.Value
                                        where products.Id == table.Product_Id.Value
                                        select new
                                        {/////
                                            purchases.Id,
                                            Дата = purchases.Date,
                                            Количество = purchases.Amount,
                                            Магазин = purchases.Store.Name,
                                            Продукт = products.ModelName,
                                            Статус_заказа = orders.Status
                                        }).ToList();
                                break;
                            default:
                                break;
                        }
                    });
                    return await CheckDataAsync(dataGridView, res);
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

        public async Task<bool> SearchProductAsync(DataGridView dataGridView, Table table)
        {
            IList res = null;
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[0]);
                if (combobox != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox)
                        {
                            case "По Id продукта":
                                res = (from products in _context.Products
                                       where products.Id == table.Product_Id.Value
                                       select new
                                       {
                                           products.Id,
                                           Продукт = products.ModelName,
                                           Цена = products.Price
                                       }).ToList();
                                break;
                            case "По названию продукта":
                                res = (from products in _context.Products
                                       where products.ModelName == table.ModelName.Text
                                       select new
                                       {
                                           products.Id,
                                           Продукт = products.ModelName,
                                           Цена = products.Price
                                       }).ToList();
                                break;
                            case "По цене":
                                res = (from products in _context.Products
                                       where products.Price >= table.Price.Value && products.Price <= table.Price2.Value
                                       select new
                                       {
                                           products.Id,
                                           Продукт = products.ModelName,
                                           Цена = products.Price
                                       }).ToList();
                                break;
                            default:
                                break;
                        }
                    });
                    return await CheckDataAsync(dataGridView, res);
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

        public async Task<bool> SearchSparePartAsync(DataGridView dataGridView, Table table)
        {
            IList res = null;
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[0]);
                if (combobox != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox)
                        {
                            case "По Id запчасти":
                                res = (from sparepart in _context.SpareParts
                                       join manufacturer in _context.Manufacturers on sparepart.Manufacturer.Id equals manufacturer.Id
                                       join product in _context.Products on sparepart.Product.Id equals product.Id
                                       where sparepart.Id == table.SparePart_Id.Value
                                       select new
                                       {
                                           sparepart.Id,
                                           Запчасть = sparepart.Name,
                                           Цена = sparepart.Price,
                                           Производитель = sparepart.Manufacturer.Name,
                                           Продукт = product.ModelName

                                       }).ToList();
                                break;
                            case "По названию запчасти":
                                res = (from sparepart in _context.SpareParts
                                       join manufacturer in _context.Manufacturers on sparepart.Manufacturer.Id equals manufacturer.Id
                                       join product in _context.Products on sparepart.Product.Id equals product.Id
                                       where sparepart.Name == table.SparePartName.Text
                                       select new
                                       {
                                           sparepart.Id,
                                           Запчасть = sparepart.Name,
                                           Цена = sparepart.Price,
                                           Производитель = sparepart.Manufacturer.Name,
                                           Продукт = product.ModelName

                                       }).ToList();
                                break;
                            case "По цене":
                                res = (from sparepart in _context.SpareParts
                                       join manufacturer in _context.Manufacturers on sparepart.Manufacturer.Id equals manufacturer.Id
                                       join product in _context.Products on sparepart.Product.Id equals product.Id
                                       where sparepart.Price >= table.Price.Value && sparepart.Price <= table.Price2.Value
                                       select new
                                       {
                                           sparepart.Id,
                                           Запчасть = sparepart.Name,
                                           Цена = sparepart.Price,
                                           Производитель = sparepart.Manufacturer.Name,
                                           Продукт = product.ModelName

                                       }).ToList();
                                break;
                            case "По названию производителя":
                                res = (from sparepart in _context.SpareParts
                                       join manufacturer in _context.Manufacturers on sparepart.Manufacturer.Id equals manufacturer.Id
                                       join product in _context.Products on sparepart.Product.Id equals product.Id
                                       where manufacturer.Name == table.ManufacturerName.Text
                                       select new
                                       {
                                           sparepart.Id,
                                           Запчасть = sparepart.Name,
                                           Цена = sparepart.Price,
                                           Производитель = sparepart.Manufacturer.Name,
                                           Продукт = product.ModelName

                                       }).ToList();
                                break;
                            default:
                                break;
                        }
                    });
                    return await CheckDataAsync(dataGridView, res);
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

        public async Task<bool> SearchManufacturerAsync(DataGridView dataGridView, Table table)
        {
            IList res = null;
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[0]);
                if (combobox != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox)
                        {
                            case "По Id производителя":
                                res = (from manufacturer in _context.Manufacturers
                                       where manufacturer.Id == table.Manufacturer_Id.Value
                                       select new
                                       {
                                           manufacturer.Id,
                                           Производитель = manufacturer.Name,
                                           Количество_заказов = manufacturer.Productions.Count,
                                           Количество_запчастей = manufacturer.SpareParts.Count
                                       }).ToList();
                                break;
                            case "По названию производителя":
                                res = (from manufacturer in _context.Manufacturers
                                       where manufacturer.Name == table.ManufacturerName.Text
                                       select new
                                       {
                                           manufacturer.Id,
                                           Производитель = manufacturer.Name,
                                           Количество_заказов = manufacturer.Productions.Count,
                                           Количество_запчастей = manufacturer.SpareParts.Count
                                       }).ToList();
                                break;
                        }
                    });
                    return await CheckDataAsync(dataGridView, res);
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

        public async Task<bool> SearchStoreAsync(DataGridView dataGridView, Table table)
        {
            IList res = null;
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[0]);
                if (combobox != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox)
                        {
                            case "По Id магазина":
                                res = (from store in _context.Stores
                                       where store.Id == table.Store_Id.Value
                                       select new
                                       {
                                           store.Id,
                                           Магазин = store.Name,
                                           Количество_заказов = store.Purchases.Count
                                       }).ToList();
                                break;
                            case "По названию магазина":
                                res = (from store in _context.Stores
                                       where store.Name == table.StoreName.Text
                                       select new
                                       {
                                           store.Id,
                                           Магазин = store.Name,
                                           Количество_заказов = store.Purchases.Count
                                       }).ToList();
                                break;
                        }
                    });
                    return await CheckDataAsync(dataGridView, res);
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
