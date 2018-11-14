using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared
{
    public class VerifyTableName
    {
        public static void Verify(String tableName)
        {
            Synchronize(tableName).Wait();
        }

        public static async Task Synchronize(String tableName)
        {
            Boolean isException = false;
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                DatabaseManager.GetConnection().Close();
            }
            finally
            {

            }
        }
    }
}
