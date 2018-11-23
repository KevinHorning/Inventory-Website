namespace Backend.Systems
{
    public class System
    {
        public int itemID { get; set; }
        public string name { get; set; }
        public string SKU { get; set; }
        public string serialNumber { get; set; }
        public int systemTempateID { get; set; }

        public int count = 1;
        public string itemType = "system";
        public bool serializable = true;

        public static async Task<bool> IDExists(int systemID)
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

        public static Boolean AddSystem(String name, String SKU, String serialNumber, int systemTemplateID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                if (!SerialNumberVerification.Verify(serialNumber))
                {
                    return false;
                }

                var namePair = new KeyValuePair<String, object>("name", name);
                var SKUpair = new KeyValuePair<String, object>("SKU", SKU);
                var serialNumberPair = new KeyValuePair<String, object>("serialNumber", serialNumber);
                var systemTemplateIDpair = new KeyValuePair<String, object>("systemTemplateID", systemTemplateID);
                var values = new[] { namePair, SKUpair, serialNumberPair, systemTemplateIDpair };

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query insertQuery = QBuilder.BuildInsertQuery("systems", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();

                return true;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
