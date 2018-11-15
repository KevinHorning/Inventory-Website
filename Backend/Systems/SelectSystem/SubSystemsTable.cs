using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Systems.SelectSystem
{
    public class SubSystemsTable
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public SubSystemsTable()
        {
            Synchronize().Wait();
        }

        public static SubSystemsTable GetSubSystemsTable()
        {
            return new SubSystemsTable();
        }

        public async Task Synchronize()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'systems'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                Headers = new string[headerTable.Length];
                for (int i = 0; i < 4; i++)
                {
                    Headers[i] = (string)headerTable[i][0];
                }

                Query getDataQuery = new Query { QueryString = "SELECT systemID, name, SKU, serialNumber FROM systems" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                SubSystem[] data = new SubSystem[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new SubSystem
                    {
                        itemID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        SKU = (string)dataTable[i][2],
                        serialNumber = (string)dataTable[i][3]
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
