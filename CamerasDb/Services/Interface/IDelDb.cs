using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Model.Interface
{
    public interface IDelDb
    {
        Task<bool> DeleteDataAsync(DataGridView dataGridView, string tableName, Table table);
        Task<bool> DeleteProductAsync(DataGridView dataGridView, Table table);
        Task<bool> DeletePurchaseAsync(Table table);
        Task<bool> DeleteStoreAsync(Table table);
        Task<bool> DeleteSparePartAsync(Table table);
        Task<bool> DeleteManufacturerAsync(Table table);
        Task<bool> DeleteProductionAsync(Table table);
    }
}
