using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Verification
{
    public class SerialNumberVerification
    {
        public static Boolean Verify(String serialNumber)
        {
            var task = Synchronize(serialNumber).Result;
            return task;
        }

        // return values
        // true = serialNumber is not in use
        // false = serialNumber is already in use 
        public static async Task<bool> Synchronize(String serialNumber)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                Query getSerialNumbersQuery = new Query { QueryString = "SELECT serialNumber FROM systems" };
                var serialNumbers = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getSerialNumbersQuery.QueryString).ConfigureAwait(false);

                Boolean serialNumberIsUsed = false;
                for (int i = 0; i < serialNumbers.Length; i++)
                {
                    if (serialNumber.Equals(serialNumbers[i][0]))
                        serialNumberIsUsed = true;
                }
                if (serialNumberIsUsed)
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
