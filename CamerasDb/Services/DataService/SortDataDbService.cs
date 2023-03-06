using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services.DataService
{
    public class SortDataDbService: DataDbService, ISortDb
    {    
        IList res = null;
        string combobox, combobox2;
        public static SortDataDbService Instance { get => SortDataDbServiceCreate.instance; }
        private class SortDataDbServiceCreate
        {
            static SortDataDbServiceCreate() { }
            internal static readonly SortDataDbService instance = new SortDataDbService();
        }

        

        public async Task<bool> SortDataAsync(DataGridView dataGridView, string tableName, Table table)
        {

            switch (tableName)
            {
                case "Фотоаппараты":
                    return await SortProductAsync(dataGridView, table);
                case "Закупки":
                    return await SortPurchaseAsync(dataGridView, table);
                case "Магазины":
                    return await SortStoreAsync(dataGridView, table);
                case "Запчасти":
                    return await SortSparePartAsync(dataGridView, table);
                case "Производители":
                    return await SortManufacturerAsync(dataGridView, table);
                case "Производство":
                    return await SortProductionAsync(dataGridView, table, tableName);
            }
            return false;
        }

        public async Task<bool> SortProductAsync(DataGridView dataGridView, Table table)
        {
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[2]);
                var combobox2 = table.CheckComboBox(table.comboBoxes[3]);
                
                if (combobox != null && combobox2 != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox2)
                        {
                            case "По возрастанию":
                                switch (combobox)
                                {
                                    case "По названию продукта":
                                        res = (from products in _context.Products
                                               orderby products.ModelName
                                               select new
                                               {
                                                   products.Id,
                                                   Продукт = products.ModelName,
                                                   Цена = products.Price
                                               }).ToList();
                                        break;
                                    case "По цене":
                                        res = (from products in _context.Products
                                               orderby products.Price
                                               select new
                                               {
                                                   products.Id,
                                                   Продукт = products.ModelName,
                                                   Цена = products.Price
                                               }).ToList();
                                        break;
                                }
                                break;
                            case "По убыванию":
                                switch (combobox)
                                {
                                    case "По названию продукта":
                                        res = (from products in _context.Products
                                               orderby products.ModelName descending
                                               select new
                                               {
                                                   products.Id,
                                                   Продукт = products.ModelName,
                                                   Цена = products.Price
                                               }).ToList();
                                        break;
                                    case "По цене":
                                        res = (from products in _context.Products
                                               orderby products.Price descending
                                               select new
                                               {
                                                   products.Id,
                                                   Продукт = products.ModelName,
                                                   Цена = products.Price
                                               }).ToList();
                                        break;
                                }
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

        public async Task<bool> SortPurchaseAsync(DataGridView dataGridView, Table table)
        {
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[2]);
                var combobox2 = table.CheckComboBox(table.comboBoxes[3]);

                if (combobox != null && combobox2 != null)
                {

                    await Task.Run(() =>
                    {
                        switch (combobox2)
                        {
                            case "По возрастанию":
                                switch (combobox)
                                {
                                    case "По дате закупки":
                                        res = (from purchases in _context.Purchases
                                               join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                               join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                               join orders in _context.Orders on purchases.Id equals orders.OrderId
                                               where purchases.Worker.Id == table.UserId.Value
                                               orderby purchases.Date
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
                                               orderby purchases.Amount
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
                                               orderby stores.Name
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
                                    case "По названию продукта":
                                        res = (from purchases in _context.Purchases
                                               join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                               join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                               join orders in _context.Orders on purchases.Id equals orders.OrderId
                                               where purchases.Worker.Id == table.UserId.Value
                                               orderby products.ModelName
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
                                }
                                break;
                            case "По убыванию":
                                switch (combobox)
                                {
                                    case "По дате закупки":
                                        res = (from purchases in _context.Purchases
                                               join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                               join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                               join orders in _context.Orders on purchases.Id equals orders.OrderId
                                               where purchases.Worker.Id == table.UserId.Value
                                               orderby purchases.Date descending
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
                                               orderby purchases.Amount descending
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
                                               orderby stores.Name descending
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
                                    case "По названию продукта":
                                        res = (from purchases in _context.Purchases
                                               join stores in _context.Stores on purchases.Store.Id equals stores.Id
                                               join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id
                                               join orders in _context.Orders on purchases.Id equals orders.OrderId
                                               where purchases.Worker.Id == table.UserId.Value
                                               orderby products.ModelName descending
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
                                }
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

        public async Task<bool> SortProductionAsync(DataGridView dataGridView, Table table, string tableName)
        {
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[2]);
                var combobox2 = table.CheckComboBox(table.comboBoxes[3]);

                if (combobox != null && combobox2 != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox2)
                        {
                            case "По возрастанию":
                                switch (combobox)
                                {
                                    case "По дате производства":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby production.Date
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                    case "По количеству":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby production.Amount
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                    case "По названию производителя":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby production.Manufacturer.Name
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                    case "По названию продукта":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby product.ModelName
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                }
                                break;
                            case "По убыванию":
                                switch (combobox)
                                {
                                    case "По дате производства":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby production.Date descending
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                    case "По количеству":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby production.Amount descending
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                    case "По названию производителя":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby production.Manufacturer.Name descending
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                    case "По названию продукта":
                                        res = (from production in _context.Productions
                                               join manufacturer in _context.Manufacturers on production.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on production.Products.FirstOrDefault().Id equals product.Id
                                               join orders in _context.Orders on production.Id equals orders.OrderId
                                               where production.Worker.Id == table.UserId.Value
                                               orderby product.ModelName descending
                                               select new
                                               {
                                                   production.Id,
                                                   Дата = production.Date,
                                                   Количество = production.Amount,
                                                   Производитель = production.Manufacturer.Name,
                                                   Продукт = product.ModelName,
                                                   Статус_заказа = orders.Status
                                               }).ToList();
                                        break;
                                }
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

        public async Task<bool> SortSparePartAsync(DataGridView dataGridView, Table table)
        {
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[2]);
                var combobox2 = table.CheckComboBox(table.comboBoxes[3]);

                if (combobox != null && combobox2 != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox2)
                        {
                            case "По возрастанию":
                                switch (combobox)
                                {
                                    case "По названию запчасти":
                                        res = (from sparepart in _context.SpareParts
                                               join manufacturer in _context.Manufacturers on sparepart.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on sparepart.Product.Id equals product.Id
                                               orderby sparepart.Name
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
                                               orderby sparepart.Price
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
                                               orderby sparepart.Manufacturer.Name
                                               select new
                                               {
                                                   sparepart.Id,
                                                   Запчасть = sparepart.Name,
                                                   Цена = sparepart.Price,
                                                   Производитель = sparepart.Manufacturer.Name,
                                                   Продукт = product.ModelName
                                               }).ToList();
                                        break;
                                }
                                break;
                            case "По убыванию":
                                switch (combobox)
                                {
                                    case "По названию запчасти":
                                        res = (from sparepart in _context.SpareParts
                                               join manufacturer in _context.Manufacturers on sparepart.Manufacturer.Id equals manufacturer.Id
                                               join product in _context.Products on sparepart.Product.Id equals product.Id
                                               orderby sparepart.Name descending
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
                                               orderby sparepart.Price descending
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
                                               orderby sparepart.Manufacturer.Name descending
                                               select new
                                               {
                                                   sparepart.Id,
                                                   Запчасть = sparepart.Name,
                                                   Цена = sparepart.Price,
                                                   Производитель = sparepart.Manufacturer.Name,
                                                   Продукт = product.ModelName
                                               }).ToList();
                                        break;
                                }
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

        public async Task<bool> SortManufacturerAsync(DataGridView dataGridView, Table table)
        {
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[2]);
                var combobox2 = table.CheckComboBox(table.comboBoxes[3]);

                if (combobox != null && combobox2 != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox2)
                        {
                            case "По возрастанию":
                                switch (combobox)
                                {
                                    case "По названию производителя":
                                        res = (from manufacturer in _context.Manufacturers
                                               orderby manufacturer.Name
                                               select new
                                               {
                                                   manufacturer.Id,
                                                   Производитель = manufacturer.Name,
                                                   Количество_заказов = manufacturer.Productions.Count,
                                                   Количество_запчастей = manufacturer.SpareParts.Count
                                               }).ToList();
                                        break;
                                    case "По количеству запчастей":
                                        res = (from manufacturer in _context.Manufacturers
                                               orderby manufacturer.SpareParts.Count
                                               select new
                                               {
                                                   manufacturer.Id,
                                                   Производитель = manufacturer.Name,
                                                   Количество_заказов = manufacturer.Productions.Count,
                                                   Количество_запчастей = manufacturer.SpareParts.Count
                                               }).ToList();
                                        break;
                                    case "По количеству заказов":
                                        res = (from manufacturer in _context.Manufacturers
                                               orderby manufacturer.Productions.Count
                                               select new
                                               {
                                                   manufacturer.Id,
                                                   Производитель = manufacturer.Name,
                                                   Количество_заказов = manufacturer.Productions.Count,
                                                   Количество_запчастей = manufacturer.SpareParts.Count
                                               }).ToList();
                                        break;
                                }
                                break;
                            case "По убыванию":
                                switch (combobox)
                                {
                                    case "По названию производителя":
                                        res = (from manufacturer in _context.Manufacturers
                                               orderby manufacturer.Name descending
                                               select new
                                               {
                                                   manufacturer.Id,
                                                   Производитель = manufacturer.Name,
                                                   Количество_заказов = manufacturer.Productions.Count,
                                                   Количество_запчастей = manufacturer.SpareParts.Count
                                               }).ToList();
                                        break;
                                    case "По количеству запчастей":
                                        res = (from manufacturer in _context.Manufacturers
                                               orderby manufacturer.SpareParts.Count descending
                                               select new
                                               {
                                                   manufacturer.Id,
                                                   Производитель = manufacturer.Name,
                                                   Количество_заказов = manufacturer.Productions.Count,
                                                   Количество_запчастей = manufacturer.SpareParts.Count
                                               }).ToList();
                                        break;
                                    case "По количеству заказов":
                                        res = (from manufacturer in _context.Manufacturers
                                               orderby manufacturer.Productions.Count descending
                                               select new
                                               {
                                                   manufacturer.Id,
                                                   Производитель = manufacturer.Name,
                                                   Количество_заказов = manufacturer.Productions.Count,
                                                   Количество_запчастей = manufacturer.SpareParts.Count
                                               }).ToList();
                                        break;
                                }
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

        public async Task<bool> SortStoreAsync(DataGridView dataGridView, Table table)
        {
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[2]);
                var combobox2 = table.CheckComboBox(table.comboBoxes[3]);

                if (combobox != null && combobox2 != null)
                {
                    await Task.Run(() =>
                    {
                        switch (combobox2)
                        {
                            case "По возрастанию":
                                switch (combobox)
                                {
                                    case "По названию магазина":
                                        res = (from store in _context.Stores
                                               orderby store.Name
                                               select new
                                               {
                                                   store.Id,
                                                   Магазин = store.Name,
                                                   Количество_заказов = store.Purchases.Count
                                               }).ToList();
                                        break;
                                    case "По количеству заказов":
                                        res = (from store in _context.Stores
                                               orderby store.Purchases.Count
                                               select new
                                               {
                                                   store.Id,
                                                   Магазин = store.Name,
                                                   Количество_заказов = store.Purchases.Count
                                               }).ToList();
                                        break;
                                }
                                break;
                            case "По убыванию":
                                switch (combobox)
                                {
                                    case "По названию магазина":
                                        res = (from store in _context.Stores
                                               orderby store.Name descending
                                               select new
                                               {
                                                   store.Id,
                                                   Магазин = store.Name,
                                                   Количество_заказов = store.Purchases.Count
                                               }).ToList();
                                        break;
                                    case "По количеству заказов":
                                        res = (from store in _context.Stores
                                               orderby store.Purchases.Count descending
                                               select new
                                               {
                                                   store.Id,
                                                   Магазин = store.Name,
                                                   Количество_заказов = store.Purchases.Count
                                               }).ToList();
                                        break;
                                }
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
