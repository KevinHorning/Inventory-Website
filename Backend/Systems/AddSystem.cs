using CTG.Database;
using CTG.Database.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Systems
{
    class AddSystem
    {
        public static void addSystem(String name, String SKU, String serialNumber, int systemTemplatesID)
        {
            Synchronize(name, SKU, serialNumber, systemTemplatesID).Wait();
        }

        public static async Task Synchronize(String name, String SKU, String serialNumber, int systemTemplateID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                //TODO check for name and serialNumber duplication
                var namePair = new KeyValuePair<String, object>("name", name);
                var SKUpair = new KeyValuePair<String, object>("SKU", SKU);
                var serialNumberPair = new KeyValuePair<String, object>("serialNumber", serialNumber);
                var systemTemplateIDpair = new KeyValuePair<String, object>("systemTemplateID", systemTemplateID);
                var values = new[] { namePair, SKUpair, serialNumberPair, systemTemplateIDpair};

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query insertQuery = QBuilder.BuildInsertQuery("systems", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
