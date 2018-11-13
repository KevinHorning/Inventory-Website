using CTG.Database;
using CTG.Database.MSSQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Parts
{
    class AddPart
    {
        public static async Task addPart(String name, String SKU, string serialNumber, int count)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try 
            {
                //TODO check for name and serialNumber duplication
                var namePair = new KeyValuePair<string, object>("name", name);
                var SKUpair = new KeyValuePair<String, object>("SKU", SKU);
                var serialNumberPair = new KeyValuePair<String, object>("serialNumber", serialNumber);
                var countPair = new KeyValuePair<String, object>("count", count);
                var values = new[] { namePair, SKUpair, serialNumberPair, countPair};

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
