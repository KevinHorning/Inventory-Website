using CTG.Database;
using System;
using System.Threading.Tasks;
using Backend.Parts;

namespace Backend.Shared
{
    public class TableData
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public TableData(String tableName)
        {
            Synchronize(tableName).Wait();
        }

        public static TableData getTableData(String tableName)
        {
            return new TableData(tableName);
        }

        public async Task Synchronize(String tableName)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            Query query = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'" };
            var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), query.QueryString).ConfigureAwait(false);

            Headers = new string[headerTable.Length];
            for (int i = 0; i < headerTable.Length; i++)
            {
                Headers[i] = (string)headerTable[i][0];
            }

            Query query2 = new Query { QueryString = "SELECT * FROM " + tableName };
            var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), query2.QueryString).ConfigureAwait(false);
                  
            Backend.Parts.Part[] data = new Part[dataTable.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new Backend.Parts.Part
                {
                    partID = dataTable[i][0],
                    name = dataTable[i][1],
                    serialNumber = dataTable[i][2],
                    count = dataTable[i][3],
                    partType = dataTable[i][4]
                };
            }
            Data = data;
        }
    }
}
