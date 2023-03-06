using CamerasDb.Model;
using CamerasDb.Services.Interface;
using CamerasDb.View;
using CamerasDb.View.QueryView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services
{
    public class EntityQuery: IQuery
    {
        private readonly AppDbContext _context;

        private EntityQuery()
        {
            _context = new AppDbContext();
        }

        public static EntityQuery Instance { get => QueryServiceCreate.instance; }

        private class QueryServiceCreate
        {
            static QueryServiceCreate() { }
            internal static readonly EntityQuery instance = new EntityQuery();
        }

        public async Task<bool> SelectQuery(DataGridView dataGridView, Table table)
        {
            try
            {
                switch (table.QueryListBox.SelectedIndex)
                {
                    case 0:
                        return await Query1(dataGridView);
                    case 1:
                        return await Query2(dataGridView);
                    case 2:
                        return await Query3(dataGridView);
                    case 3:
                        return await Query4(dataGridView);
                    case 4:
                        return await Query5(dataGridView);
                    case 5:
                        return await Query6(dataGridView);
                    case 6:
                        return await Query7(dataGridView);
                    case 7:
                        return await Query8(dataGridView);
                    default:
                        return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }         
        }

        public async Task<bool> Query1(DataGridView dataGridView)//найти самый дорогой,дешевый и среднюю стоимость
        {
            try
            {
                var res = (from products in _context.Products
                           select new
                           {
                               Самый_дорогой = (from products2 in _context.Products
                                                select products2.Price).Max(),
                               Самый_дешевый = (from products3 in _context.Products
                                                select products3.Price).Min(),
                               Средняя_цена = (from products4 in _context.Products
                                               select products4.Price).Average(),
                           }).Take(1).ToList();

                return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
            }
            catch (Exception)
            {
                throw new Exception();
            }          
        }

        public async Task<bool> Query2(DataGridView dataGridView)//найти в заданных пределах стоимости и заданного производителя
        {
            Query2Form form = new Query2Form();
            
            if (form.ShowDialog() == DialogResult.Cancel)
            {

                try
                {
                    var res = (from products in _context.Products
                               join productions in _context.Productions on products.Id equals productions.Products.FirstOrDefault().Id
                               join manufacturers in _context.Manufacturers on productions.Manufacturer.Id equals manufacturers.Id
                               where products.Price <= form.Price2_NumericUpDown.Value && products.Price >= form.Price1_NumericUpDown.Value
                               where manufacturers.Name == form.manufacturer_ComboBox.Text
                               select new
                               {
                                   products.Id,
                                   Продукт = products.ModelName,
                                   Цена = products.Price,
                                   Производитель = manufacturers.Name
                                                   
                               }).ToList();

                    return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> Query3(DataGridView dataGridView)//проданные фотоаппараты за определенный период времени
        {
            Query3_7Form form = new Query3_7Form();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                try
                {
                    var res = (from products in _context.Products
                               join purchases in _context.Purchases on products.Id equals purchases.Products.FirstOrDefault().Id
                               where purchases.Date <= form.date2_DateTimePicker2.Value && purchases.Date >= form.date1_DateTimePicker1.Value
                               select new
                               {
                                   products.Id,
                                   Продукт = products.ModelName,
                                   Количество = purchases.Amount,
                                   Дата_закупки = purchases.Date
                               }).ToList();
                    return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Query4(DataGridView dataGridView)//самая популярная модель(продано наибольшее кол-во)
        {
            try
            {
                var res = (from purchases in _context.Purchases
                           join products in _context.Products on purchases.Products.FirstOrDefault().Id equals products.Id                         
                           group new 
                           { 
                               purchases, 
                               products 
                           } by products.ModelName into newTable
                           select new 
                           { 
                               Продукт = newTable.Key, 
                               Проданное_количество = newTable.Sum(x => x.purchases.Amount) 
                           }).OrderByDescending(p => p.Проданное_количество).Take(1).ToList();
                return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<bool> Query5(DataGridView dataGridView)//все фотоаппараты от заданного производителя, чья стоимость больше выбранного фотоаппарата
        {
            Query5Form form = new Query5Form();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                try
                {
                    var res = (from products in _context.Products
                               join productions in _context.Productions on products.Id equals productions.Products.FirstOrDefault().Id
                               join manufacturers in _context.Manufacturers on productions.Manufacturer.Id equals manufacturers.Id
                               where manufacturers.Name == ((Manufacturer)form.manufacturer_ComboBox.SelectedItem).Name
                               where products.Price > ((Product)form.products_ComboBox.SelectedItem).Price
                               select new
                               {
                                   products.Id,
                                   Продукт = products.ModelName,
                                   Цена = products.Price,
                                   Производитель = manufacturers.Name
                               }).ToList();
                        return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Query6(DataGridView dataGridView)//фотоаппараты, стоимость которых меньше заданной от заданного производителя
        {
            Query6Form form = new Query6Form();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                try
                {
                    var res = (from products in _context.Products
                               join productions in _context.Productions on products.Id equals productions.Products.FirstOrDefault().Id
                               join manufacturers in _context.Manufacturers on productions.Manufacturer.Id equals manufacturers.Id
                               where manufacturers.Name == ((Manufacturer)form.manufacturer_ComboBox.SelectedItem).Name
                               where products.Price < form.Price_NumericUpDown.Value
                               select new
                               {
                                   products.Id,
                                   Продукт = products.ModelName,
                                   Цена = products.Price,
                                   Производитель = manufacturers.Name
                               }).ToList();
                    return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return false;
            }         
        }

        public async Task<bool> Query7(DataGridView dataGridView)//Cредняя стоимость фотоаппаратов, проданных за определенный период времени
        {
            Query3_7Form form = new Query3_7Form();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                try
                {
                    var res = (from products in _context.Products
                               join purchases in _context.Purchases on products.Id equals purchases.Products.FirstOrDefault().Id
                               where purchases.Date.Day <= form.date2_DateTimePicker2.Value.Day && purchases.Date.Day >= form.date1_DateTimePicker1.Value.Day
                               select new
                               {
                                   Период_продаж = "",
                                   От = form.date1_DateTimePicker1.Value.Date,
                                   До = form.date2_DateTimePicker2.Value.Date,
                                   Средняя_стоимость = (from products2 in _context.Products
                                                        join purchases2 in _context.Purchases on products2.Id equals purchases2.Products.FirstOrDefault().Id
                                                        where purchases2.Date.Day <= form.date2_DateTimePicker2.Value.Day && purchases2.Date.Day >= form.date1_DateTimePicker1.Value.Day
                                                        select products2.Price* purchases2.Amount).Average(),
                               }).Take(1).ToList();
                    return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Query8(DataGridView dataGridView)//все фотоаппараты, чья стоимость выше средней заданного производителя
        {
            Query8Form form = new Query8Form();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                try
                {
                    var res = (from products in _context.Products
                               join productions in _context.Productions on products.Id equals productions.Products.FirstOrDefault().Id                             
                               where products.Price > (from products2 in _context.Products
                                                       join productions2 in _context.Productions on products2.Id equals productions2.Products.FirstOrDefault().Id
                                                       join manufacturers2 in _context.Manufacturers on productions2.Manufacturer.Id equals manufacturers2.Id
                                                       where manufacturers2.Name == ((Manufacturer)form.manufacturer_ComboBox.SelectedItem).Name
                                                       select products2.Price).Average()
                               select new
                               {
                                   Продукт = products.ModelName,
                                   Цена = products.Price
                               }).ToList();


                    return await DataDbService.Instance.CheckDataAsync(dataGridView, res);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return false;
            }
        }
    }
}
