using Backend.Verification;
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
        // return values
        // false = error, serialNumber already exists
        // true = success
        public static Boolean addSystem(String name, String SKU, String serialNumber, int systemTemplateID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                if (!SerialNumberVerification.Verify(serialNumber))
                {
                    return false;
                }

                var namePair = new KeyValuePair<String, object>("name", name);
                var SKUpair = new KeyValuePair<String, object>("SKU", SKU);
                var serialNumberPair = new KeyValuePair<String, object>("serialNumber", serialNumber);
                var systemTemplateIDpair = new KeyValuePair<String, object>("systemTemplateID", systemTemplateID);
                var values = new[] { namePair, SKUpair, serialNumberPair, systemTemplateIDpair};

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query insertQuery = QBuilder.BuildInsertQuery("systems", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();

                return true;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();     
            }           
        }
    }
}
