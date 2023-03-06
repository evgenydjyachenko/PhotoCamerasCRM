using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model.Interface
{
    public interface IAddDb
    {
        Task<bool> AddDataAsync(string tableName, Table table, IUser user);
        Task<bool> AddProductAsync(Table table);
        Task<bool> AddPurchaseAsync(Worker user, Table table);
        Task<bool> AddStoreAsync(Table table);
        Task<bool> AddSparePartAsync(Table table);
        Task<bool> AddManufacturerAsync(Table table);
        Task<bool> AddProductionAsync(Worker user, Table table);

    }
}
