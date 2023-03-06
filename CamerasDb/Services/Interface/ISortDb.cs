using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Model.Interface
{
    public interface ISortDb
    {
        Task<bool> SortDataAsync(DataGridView dataGridView, string tableName, Table table);
        Task<bool> SortProductAsync(DataGridView dataGridView, Table table);
        Task<bool> SortPurchaseAsync(DataGridView dataGridView, Table table);
        Task<bool> SortStoreAsync(DataGridView dataGridView, Table table);
        Task<bool> SortSparePartAsync(DataGridView dataGridView, Table table);
        Task<bool> SortManufacturerAsync(DataGridView dataGridView, Table table);
        Task<bool> SortProductionAsync(DataGridView dataGridView, Table table, string tableName);
    }
}
