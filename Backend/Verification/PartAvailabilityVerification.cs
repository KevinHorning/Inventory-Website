using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Verification
{
    public class PartAvailabilityVerification
    {
        // return values
        // true = part is available
        // false = part is already in a system
        public static Boolean Verify(int partID)
        {
            var task = Synchronize(partID).Result;
            return task;
        }

        public static async Task<bool> Synchronize(int partID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                Query getSystemPartsIDsQuery = new Query { QueryString = "SELECT partID FROM systemParts" };
                var partIDs = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getSystemPartsIDsQuery.QueryString).ConfigureAwait(false);

                Boolean partIsAvialable = true;
                for (int i = 0; i < partIDs.Length; i++)
                {
                    if (partID.Equals(partIDs[i][0]))
                        partIsAvialable = false;
                }

                return partIsAvialable;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}