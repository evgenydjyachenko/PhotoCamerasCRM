using CamerasDb.Model;
using CamerasDb.Model.Interface;
using CamerasDb.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace CamerasDb.Services.DataService
{
    public class DeleteDataDbService : DataDbService, IDelDb
    {
        int amount;
        public static DeleteDataDbService Instance { get => DeleteDataDbServiceCreate.instance; }
        private class DeleteDataDbServiceCreate
        {
            static DeleteDataDbServiceCreate() { }
            internal static readonly DeleteDataDbService instance = new DeleteDataDbService();
        }
        public async Task<bool> DeleteDataAsync(DataGridView dataGridView, string tableName, Table table)
        {
            
            switch (tableName)
            {
                case "Фотоаппараты":
                    return await DeleteProductAsync(dataGridView, table);
                case "Закупки":
                    return await DeletePurchaseAsync(table);
                case "Магазины":
                    return await DeleteStoreAsync(table);
                case "Запчасти":
                    return await DeleteSparePartAsync(table);
                case "Производители":
                    return await DeleteManufacturerAsync(table);
                case "Производство":
                    return await DeleteProductionAsync(table);
            }
            return false;
        }
        public async Task<bool> DeleteProductAsync(DataGridView dataGridView, Table table)
        {
            Product product = null;
            Product temp = new Product();
            
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[1]);
                if (combobox != null)
                {
                    switch (combobox)
                    {
                        case "По Id продукта":
                            product = _context.Products.Include("SpareParts").Include("Productions").Include("Purchases").FirstOrDefault(p => p.Id == table.Product_Id.Value);
                            break;
                        case "По названию продукта":
                            product = _context.Products.Include("SpareParts").Include("Productions").Include("Purchases").FirstOrDefault(p => p.ModelName == table.ModelName.Text);
                            break;
                    }

                    if (product != null)
                    {
                        product.SpareParts.ToList().ForEach(p => temp.SpareParts.Add(p));
                        if (product.SpareParts.Count > 0)
                        {
                            amount = product.SpareParts.Count;
                            for (int i = 0; i < amount; i++)
                            {
                                var sparepartId = _context.Products.Include("SpareParts").FirstOrDefault().SpareParts.FirstOrDefault().Id;
                                var findedSparepart = _context.SpareParts.Include("Product").FirstOrDefault(s => s.Id == sparepartId);

                                _context.SpareParts.Remove(findedSparepart);
                            }
                            _context.Products.Include("SpareParts").FirstOrDefault(p => p.Id == product.Id).SpareParts.Clear();
                        }

                        if (product.Productions.Count > 0)
                        {
                            product.Productions.ToList().ForEach(p => temp.Productions.Add(p));
                            amount = product.Productions.Count;
                            for (int i = 0; i < amount; i++)
                            {
                                var findedProductionId = _context.Products.Include("Productions").FirstOrDefault(p => p.Id == table.Product_Id.Value).Productions.FirstOrDefault().Id;
                                var production = _context.Productions.Include("Products").FirstOrDefault(p => p.Id == findedProductionId);

                                _context.Productions.Remove(production);
                            }
                            _context.Products.Include("Productions").FirstOrDefault(p => p.Id == product.Id).Productions.Clear();

                        }

                        if (product.Purchases.Count > 0)
                        {
                            product.Purchases.ToList().ForEach(p => temp.Purchases.Add(p));

                            product = _context.Products.Include("Purchases").Include("Purchases.Store").FirstOrDefault(p => p.Id == table.Product_Id.Value);
                            amount = product.Purchases.Count;

                            for (int i = 0; i < amount; i++)
                            {
                                var findedPurchaseId = _context.Products.Include("Purchases").FirstOrDefault(p => p.Id == table.Product_Id.Value).Purchases.FirstOrDefault().Id;
                                var purchase = await _context.Purchases.Include("Store").FirstOrDefaultAsync(p => p.Id == findedPurchaseId);

                                var findedStore = _context.Stores.FirstOrDefault(s => s.Id == purchase.Store.Id);
                                var findedpurchaseInStore = _context.Stores.Include("Purchases").FirstOrDefault(s => s.Id == purchase.Store.Id).Purchases.FirstOrDefault(p => p.Id == purchase.Id);
                                findedStore.Purchases.Remove(findedpurchaseInStore);
                                _context.Purchases.Remove(purchase);
                            }

                            _context.Products.Include("Purchases").FirstOrDefault(p => p.Id == product.Id).Purchases.Clear();
                        }

                        _context.Products.Remove(product);

                        await _context.SaveChangesAsync();
                        dataGridView.Refresh();

                        await OrderService.Instance.CloseOrderToWorkerAsync(temp);
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
        public async Task<bool> DeletePurchaseAsync(Table table)
        {        
            Purchase purchase = null;
            
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[1]);

                if (combobox != null)
                {
                    switch (combobox)
                    {
                        case "По Id закупки":
                            purchase = await _context.Purchases.Include("Products").Include("Store").Include("Worker").Include("Worker.Orders").FirstOrDefaultAsync(p => p.Id == table.Purchase_Id.Value);
                            break;
                        case "По дате закупки":
                            purchase = await _context.Purchases.Include("Products").Include("Store").Include("Worker").Include("Worker.Orders").FirstOrDefaultAsync(p => p.Date == table.PurchaseDate.Value);
                            break;
                    }

                    if (purchase != null)
                    {
                        Purchase temp = new Purchase() { Id = purchase.Id, Worker = purchase.Worker };
                        purchase.Products.Clear();

                        var store = _context.Stores.Include("Purchases").FirstOrDefault(s => s.Id == purchase.Store.Id).Purchases.Remove(purchase);
                        var worker = _context.Workers.Include("Purchases").FirstOrDefault(w => w.Id == purchase.Worker.Id).Purchases.Remove(purchase);

                        _context.Purchases.Remove(purchase);

                        await _context.SaveChangesAsync();

                        await OrderService.Instance.CloseOrderToWorkerAsync(temp);
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
        public async Task<bool> DeleteStoreAsync(Table table)
        {
            Store store = null;
            Store temp = new Store();

            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[1]);

                if (combobox != null)
                {
                    switch (combobox)
                    {
                        case "По Id магазина":
                            store = await _context.Stores.Include("Purchases").Include("Purchases.Worker").FirstOrDefaultAsync(s => s.Id == table.Store_Id.Value);
                            break;
                        case "По названию магазина":
                            store = await _context.Stores.Include("Purchases").Include("Purchases.Worker").FirstOrDefaultAsync(s => s.Name == table.StoreName.Text);
                            break;
                    }

                    if (store != null)
                    {
                        store.Purchases.ToList().ForEach(p => temp.Purchases.Add(p));

                        amount = store.Purchases.Count;
                        for (int i = 0; i < amount; i++)
                        {
                            var findedPurchaseInStore = (_context.Stores.Include("Purchases").Include("Purchases.Worker").FirstOrDefault(s => s.Id == table.Store_Id.Value)).Purchases.FirstOrDefault(p => p.Store.Id == store.Id);

                            _context.Purchases.Remove(findedPurchaseInStore);
                        }

                        store.Purchases.Clear();
                        _context.Stores.Remove(store);
                        await _context.SaveChangesAsync();

                        await OrderService.Instance.CloseOrderToWorkerAsync(temp);
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
        public async Task<bool> DeleteSparePartAsync(Table table)
        {
            SparePart sparepart = null;

            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[1]);

                if (combobox != null)
                {
                    switch (combobox)
                    {
                        case "По Id запчасти":
                            sparepart = await _context.SpareParts.FirstOrDefaultAsync(s => s.Id == table.SparePart_Id.Value);
                            break;
                        case "По названию запчасти":
                            sparepart = await _context.SpareParts.FirstOrDefaultAsync(s => s.Name == table.SparePartName.Text);
                            break;
                    }

                    if (sparepart != null)
                    {
                        _context.SpareParts.Remove(sparepart);
                        await _context.SaveChangesAsync();
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
        public async Task<bool> DeleteManufacturerAsync(Table table)
        {
            Manufacturer manufacturer = null;
            Manufacturer temp = new Manufacturer();
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[1]);

                if (combobox != null)
                {
                    switch (combobox)
                    {
                        case "По Id производителя":
                            manufacturer = await _context.Manufacturers.Include("SpareParts").Include("Productions").FirstOrDefaultAsync(m => m.Id == table.Manufacturer_Id.Value);
                            break;
                        case "По названию производителя":
                            manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Name == table.ManufacturerName.Text);
                            break;
                    }

                    if (manufacturer != null)
                    {
                        if ((manufacturer.SpareParts.Count) > 0)
                        {
                            manufacturer.SpareParts.ToList().ForEach(p => temp.SpareParts.Add(p));
                            amount = manufacturer.SpareParts.Count;

                            for (int i = 0; i < amount; i++)
                            {
                                var findedSparePart = _context.SpareParts.Include("Manufacturer").FirstOrDefault(s => s.Manufacturer.Id == manufacturer.Id);

                                _context.SpareParts.Remove(findedSparePart);
                            }
                            _context.Manufacturers.Include("SpareParts").FirstOrDefault(m => m.Id == table.Manufacturer_Id.Value).SpareParts.Clear();
                        }

                        if ((manufacturer.Productions.Count) > 0)
                        {
                            manufacturer.Productions.ToList().ForEach(p => temp.Productions.Add(p));

                            amount = manufacturer.Productions.Count;
                            for (int i = 0; i < amount; i++)
                            {
                                var prodId = manufacturer.Productions.FirstOrDefault().Id;

                                var findedProduction = _context.Productions.Include("Manufacturer").FirstOrDefault(p => p.Manufacturer.Id == manufacturer.Id);


                                _context.Productions.Remove(findedProduction);
                            }

                            _context.Manufacturers.Include("Productions").FirstOrDefault(m => m.Id == table.Manufacturer_Id.Value).Productions.Clear();
                        }

                        _context.Manufacturers.Remove(manufacturer);
                        await _context.SaveChangesAsync();

                        await OrderService.Instance.CloseOrderToWorkerAsync(temp);
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
        public async Task<bool> DeleteProductionAsync(Table table)
        {                   
            Production production = null;
           
            try
            {
                var combobox = table.CheckComboBox(table.comboBoxes[1]);

                if (combobox != null)
                {
                    switch (combobox)
                    {
                        case "По Id производства":
                            production = await _context.Productions.Include("Products").Include("Manufacturer").Include("Worker").Include("Worker.Orders").FirstOrDefaultAsync(p => p.Id == table.Prod_Id.Value);
                            break;
                        case "По дате производства":
                            production = await _context.Productions.Include("Products").Include("Worker").Include("Worker.Orders").FirstOrDefaultAsync(p => p.Date == table.ProdDate.Value);
                            break;
                        default:
                            break;
                    }

                    if (production != null)
                    {
                        Production temp = new Production() { Id = production.Id, Worker = production.Worker };
                        production.Products.Clear();

                        var manufacturer = _context.Manufacturers.Include("Productions").FirstOrDefault(m => m.Id == production.Manufacturer.Id).Productions.Remove(production);
                        var worker = _context.Workers.Include("Productions").FirstOrDefault(w => w.Id == production.Worker.Id).Productions.Remove(production);

                        _context.Productions.Remove(production);

                        await _context.SaveChangesAsync();
                        await OrderService.Instance.CloseOrderToWorkerAsync(temp);

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
    }
}
