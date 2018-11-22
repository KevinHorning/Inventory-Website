using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Systems
{
    public class SystemsTable
    {
        public String[] Headers { get; set; }
        public System[] Data { get; set; }

        public SystemsTable()
        {
            Synchronize().Wait();
        }

        public static SystemsTable GetSystemsTable()
        {
            return new SystemsTable();
        }

        public async Task Synchronize()
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
                Headers[Headers.Length - 1] = "serializable";

                Query getDataQuery = new Query { QueryString = "SELECT * FROM systems" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                System[] data = new System[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new System
                    {
                        itemID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        SKU = (string)dataTable[i][2],
                        serialNumber = (string)dataTable[i][3],
                        systemTempateID = (int)dataTable[i][4],
                    };
                }
                Data = data;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}