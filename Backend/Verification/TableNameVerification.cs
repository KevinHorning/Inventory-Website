using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Verification

{
    public class TableNameVerification
    {
        public static Boolean Verify(String tableName)
        {
            var task = Synchronize(tableName).Result;
            return task;
        }

        public static async Task<bool> Synchronize(String tableName)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                Query getTableNamesQuery = new Query { QueryString = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'" };
                var tableNames = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getTableNamesQuery.QueryString).ConfigureAwait(false);

                Boolean tableExists = false;
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if (tableName.Equals(tableNames[i][0]))
                        tableExists = true;
                }
                if (!tableExists)
                    return false;
                else
                    return true;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
