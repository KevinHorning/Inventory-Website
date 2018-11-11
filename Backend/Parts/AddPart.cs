using CTG.Database;
using CTG.Database.MSSQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Parts
{
    class AddPart
    {
        public static async Task addPart(String name, String serialNumber, int count, int partType)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try 
            {
                var namePair = new KeyValuePair<string, object>("name", name);
                var serialNumberPair = new KeyValuePair<String, object>("serialNumber", serialNumber);
                var countPair = new KeyValuePair<String, object>("count", count);
                var partTypePair = new KeyValuePair<String, object>("partType", partType);
                var values = new[] { namePair, serialNumberPair, countPair, partTypePair };

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query query = QBuilder.BuildInsertQuery("parts", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), query.QueryString, query.Parameters).Wait();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
