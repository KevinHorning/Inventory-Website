using Backend.Verification;
using CTG.Database;
using CTG.Database.MSSQL;
using System;
using System.Collections.Generic;

namespace Backend.Parts
{
    public class AddToSystem
    {
        // return values
        // 0 = success
        // 1 = partID does not exist
        // 2 = systemID does not exist
        public static int Add(int systemID, int partID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                if (!SystemIDverification.Verify(systemID) && !PartIDverification.Verify(partID))
                {
                    var systemIDpair = new KeyValuePair<System.String, object>("systemID", systemID);
                    var partIDpair = new KeyValuePair<System.String, object>("partID", partID);
                    var values = new[] { systemIDpair, partIDpair};

                    MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                    Query insertQuery = QBuilder.BuildInsertQuery("systemParts", values);
                    DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
                }
                else if (PartIDverification.Verify(partID))
                {
                    return 1;
                }
                else if (SystemIDverification.Verify(systemID))
                {
                    return 2;
                }

                return 0;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
