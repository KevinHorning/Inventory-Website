using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Systems.CondensedSystems
{
    class SpecificTypeSystemTable
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public SpecificTypeSystemTable(string SKU)
        {
            Synchronize(SKU).Wait();
        }

        public static SpecificTypeSystemTable GetSpecificTypeSystemTable(string SKU)
        {
            return new SpecificTypeSystemTable(SKU);
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

                System[] data = new System[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new System
                    {
                        itemID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        SKU = (string)dataTable[i][2],
                        serialNumber = (string)dataTable[i][3],
                        systemTempateID = (int)dataTable[i][4]
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
