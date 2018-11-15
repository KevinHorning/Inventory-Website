using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Equipment
{
    public class EquipmentTable
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public EquipmentTable()
        {
            Synchronize().Wait();
        }

        public static EquipmentTable GetEquipmentTable()
        {
            return new EquipmentTable();
        }

        public async Task Synchronize()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'equipment'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                Headers = new string[headerTable.Length];
                for (int i = 0; i < headerTable.Length; i++)
                {
                    Headers[i] = (string)headerTable[i][0];
                }

                Query getDataQuery = new Query { QueryString = "SELECT * FROM equipment" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                Equipment[] data = new Equipment[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new Equipment
                    {
                        equipmentID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        location = (string)dataTable[i][2],
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
