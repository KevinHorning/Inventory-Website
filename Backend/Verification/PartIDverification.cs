using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Verification
{
    class PartIDverification
    {
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
                Query getpartIDsQuery = new Query { QueryString = "SELECT partID FROM parts" };
                var partIDs = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getpartIDsQuery.QueryString).ConfigureAwait(false);

                Boolean tableExists = false;
                for (int i = 0; i < partIDs.Length; i++)
                {
                    if (partID.Equals(partIDs[i][0]))
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
