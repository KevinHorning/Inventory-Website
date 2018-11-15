using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Systems.SelectSystem
{
    public class DuplicateSystemsTable
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public DuplicateSystemsTable(string SKU)
        {
            Synchronize(SKU).Wait();
        }

        public static SubSystemsTable GetDuplicateSystemsTable(string SKU)
        {
            return new SubSystemsTable();
        }

        public async Task Synchronize(String SKU)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'systems'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                Headers = new string[headerTable.Length];
                for (int i = 0; i < headerTable.Length; i++)
                {
                    Headers[i] = (string)headerTable[i][0];
                }

                Query getDataQuery = new Query { QueryString = "SELECT * FROM systems WHERE SKU = " + SKU };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
