﻿using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Verification
{
    public class SystemIDverification
    {
        // return values
        // true = systemID does not exist
        // false = systemID does exist
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

                Boolean systemExists = false;
                for (int i = 0; i < systemIDs.Length; i++)
                {
                    if (systemID.Equals(systemIDs[i][0]))
                        systemExists = true;
                }

                return systemExists;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}