namespace Backend.Parts
{
    public class Part
    {
        public int itemID { get; set; }
        public string name { get; set; }
        public string SKU { get; set; }
        public string serialNumber { get; set; }
        public int count { get; set; }
        public string itemType = "part";
        public bool serializable { get; set; }

        public static async Task<bool> IsAvaliable(int partID)
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

        public static async Task<bool> IDExists(int partID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                Query getpartIDsQuery = new Query { QueryString = "SELECT partID FROM parts" };
                var partIDs = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getpartIDsQuery.QueryString).ConfigureAwait(false);

                Boolean partIDexists = false;
                for (int i = 0; i < partIDs.Length; i++)
                {
                    if (partID.Equals(partIDs[i][0]))
                        partIDexists = true;
                }

                return partIDexists;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        public static async Task<bool> SerialNumberExists(String serialNumber)
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

        public static async Task AddPart(System.String name, System.String SKU, string serialNumber, int count)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                //TODO check for name and serialNumber duplication
                var namePair = new KeyValuePair<string, object>("name", name);
                var SKUpair = new KeyValuePair<System.String, object>("SKU", SKU);
                var serialNumberPair = new KeyValuePair<System.String, object>("serialNumber", serialNumber);
                var countPair = new KeyValuePair<System.String, object>("count", count);
                var values = new[] { namePair, SKUpair, serialNumberPair, countPair };

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query insertQuery = QBuilder.BuildInsertQuery("parts", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        public static int AddToSystem(int systemID, int partID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                if (!SystemIDverification.Verify(systemID) && !PartIDverification.Verify(partID))
                {
                    var systemIDpair = new KeyValuePair<System.String, object>("systemID", systemID);
                    var partIDpair = new KeyValuePair<System.String, object>("partID", partID);
                    var values = new[] { systemIDpair, partIDpair };

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
