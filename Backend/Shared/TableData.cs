using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Shared
{
    class TableData
    {
        private static String[] headers;
        private static Object[] data;

        public static Tuple<String[], Object[]> GetTableData(String tableName)
        {
            Synchronize(tableName).Wait();
            return Tuple.Create(headers, data);
        }

        public static async Task Synchronize(String tableName)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            Query query = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'" };
            var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), query.QueryString).ConfigureAwait(false);

            headers = new string[headerTable.Length];
            for (int i = 0; i < headerTable.Length; i++)
            {
                headers[i] = (string)headerTable[i][0];
            }

            Query query2 = new Query { QueryString = "SELECT * FROM " + tableName };
            var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), query2.QueryString).ConfigureAwait(false);

            data = new object[dataTable.Length * dataTable[0].Length];
            int j, count;
            for (j = count = 0; j < dataTable.Length; j++)
            {
                for (int k = 0; k < dataTable[0].Length; k++, count++)
                {
                    data[count] = dataTable[j][k];
                }
            }
        }
    }
}