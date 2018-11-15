using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Verification
{
    class SystemIDverification
    {
        public static Boolean Verify(int systemID)
        {
            var task = Synchronize(systemID).Result;
            return task;
        }

        public static async Task<bool> Synchronize(int systemID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                Query getSystemIDsQuery = new Query { QueryString = "SELECT systemID FROM systems" };
                var systemIDs = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getSystemIDsQuery.QueryString).ConfigureAwait(false);

                Boolean tableExists = false;
                for (int i = 0; i < systemIDs.Length; i++)
                {
                    if (systemID.Equals(systemIDs[i][0]))
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
