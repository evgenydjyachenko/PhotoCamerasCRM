using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Model.Interface
{
    public interface ISearchDb
    {
        Task<bool> SearchDataAsync(DataGridView dataGridView, string tableName, Table table);
        Task<bool> SearchProductionAsync(DataGridView dataGridView, Table table);
        Task<bool> SearchPurchaseAsync(DataGridView dataGridView, Table table);
        Task<bool> SearchProductAsync(DataGridView dataGridView, Table table);
        Task<bool> SearchSparePartAsync(DataGridView dataGridView, Table table);
        Task<bool> SearchManufacturerAsync(DataGridView dataGridView, Table table);
        Task<bool> SearchStoreAsync(DataGridView dataGridView, Table table);
        
    }
}
