using CamerasDb.Model;
using CamerasDb.Services.TableService;
using CamerasDb.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamerasDb.Services.QueryServic
{
    public class ADOQuery
    {
        AppDbContext appDbContext = new AppDbContext();
        DataSet data = new DataSet();
        SqlConnection sqlConnection;
        SqlDataAdapter adapter;

        public ADOQuery()
        {
            sqlConnection = new SqlConnection($"{appDbContext.Database.Connection.ConnectionString}");           
        }

        public bool SendQuery(DataGridView dataGridView, ManagerTable managerTable)
        {          
            try
            {
                if (data.Tables.Count > 0)
                {
                    data.Tables[0].Rows.Clear();
                }
                
                adapter = new SqlDataAdapter($"{managerTable.ADOQueryText.Text}", sqlConnection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.Fill(data);
                dataGridView.DataSource = data.Tables[0]; 
                           
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }           
        }
    }
}
