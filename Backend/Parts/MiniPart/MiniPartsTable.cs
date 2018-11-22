using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Parts.MiniPart
{
    public class MiniPartsTable
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public MiniPartsTable()
        {
            Synchronize().Wait();
        }

        public static MiniPartsTable GetMiniPartsTable()
        {
            return new MiniPartsTable();
        }

        public async Task Synchronize()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'parts'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                Headers = new string[headerTable.Length - 1];
                for (int i = 0; i < 4; i++)
                {
                    Headers[i] = (string)headerTable[i][0];
                }

                Query getDataQuery = new Query { QueryString = "SELECT partID, name, SKU, serialNumber, count FROM parts" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                MiniPart[] data = new MiniPart[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new MiniPart
                    {
                        partID = (int)dataTable[i][0],
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