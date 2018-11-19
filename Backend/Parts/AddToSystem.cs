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
        // 1 = systemID does not exist
        // 2 = partID does not exist
        public static int Add(int systemID, int partID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                if (SystemIDverification.Verify(systemID) && PartIDverification.Verify(partID))
                {
                    var systemIDpair = new KeyValuePair<String, object>("systemID", systemID);
                    var partIDpair = new KeyValuePair<String, object>("partID", partID);
                    var values = new[] { systemIDpair, partIDpair};

                    MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                    Query insertQuery = QBuilder.BuildInsertQuery("systemParts", values);
                    DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
                }
                else if (PartIDverification.Verify(systemID))
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
