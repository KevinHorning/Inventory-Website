using CTG.Database;
using CTG.Database.MSSQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Equipment
{
    class AddEquipment
    {
        public static void addPart(String name, String location)
        {
            Synchronize(name, location).Wait();
        }

        public static async Task Synchronize(String name, String location)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                var namePair = new KeyValuePair<string, object>("name", name);
                var locationPair = new KeyValuePair<string, object>("location", location);
                var values = new[] { namePair, locationPair};

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query insertQuery = QBuilder.BuildInsertQuery("equipment", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
