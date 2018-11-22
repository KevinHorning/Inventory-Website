using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Parts
{
    public class PartsTable
    {
        public System.String[] Headers { get; set; }
        public Part[] Data { get; set; }
        
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

                //Headers = new string[headerTable.Length];
                var listHeaders = new List<String>();
                for (int i = 0; i < headerTable.Length; i++)
                {
                    listHeaders.Add((string)headerTable[i][0]);
                    //Headers[i] = (string)headerTable[i][0];                   
                }        
                listHeaders.Add("serializable");
                Headers = listHeaders.ToArray();

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
                    if ((int)dataTable[i][4] > 1)
                        data[i].serializable = false;
                    else
                        data[i].serializable = true;
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
