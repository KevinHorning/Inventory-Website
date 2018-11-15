using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Parts
{
    public class PartsTable
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public PartsTable()
        {
            Synchronize().Wait();
        }

        public static PartsTable GetPartsTable()
        {
            return new PartsTable();
        }

        public async Task Synchronize()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try 
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'parts'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                Headers = new string[headerTable.Length];
                for (int i = 0; i < headerTable.Length; i++)
                {
                    Headers[i] = (string)headerTable[i][0];
                }

                Query getDataQuery = new Query { QueryString = "SELECT * FROM parts" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                Part[] data = new Part[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new Part
                    {
                        itemID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        SKU = (string)dataTable[i][2],
                        serialNumber = (string)dataTable[i][3],
                        count = (int)dataTable[i][4]
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
