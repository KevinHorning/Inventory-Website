using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Managers
{
    class DatabaseManager
    {
        public static async Task<bool> TabelNameExists(String tableName)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                Query getTableNamesQuery = new Query { QueryString = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'" };
                var tableNames = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getTableNamesQuery.QueryString).ConfigureAwait(false);

                Boolean tableExists = false;
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if (tableName.Equals(tableNames[i][0]))
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
        #region Equipment

        public static async Task AddEquipment(String name, String location, String notes = null)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            KeyValuePair<String, object>[] values;

            try
            {
                var namePair = new KeyValuePair<String, object>("name", name);
                var locationPair = new KeyValuePair<String, object>("location", location);
                if (!(notes == null))
                {
                    var notesPair = new KeyValuePair<String, object>("notes", notes);
                    values = new[] { namePair, locationPair, notesPair };
                }
                else
                    values = new[] { namePair, locationPair };

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query insertQuery = QBuilder.BuildInsertQuery("equipment", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        public async Task GetEquipmentTable()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'equipment'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                Headers = new string[headerTable.Length];
                for (int i = 0; i < headerTable.Length; i++)
                {
                    Headers[i] = (string)headerTable[i][0];
                }

                Query getDataQuery = new Query { QueryString = "SELECT * FROM equipment" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                Equipment[] data = new Equipment[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new Equipment
                    {
                        equipmentID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        location = (string)dataTable[i][2],
                    };
                }
                Data = data;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        #endregion

        #region Parts

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

        public async Task GetPartsTable()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'parts'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                //Headers = new string[headerTable.Length];
                var listHeaders = new List<String>();
                for (int i = 0; i < headerTable.Length; i++)
                {
                    listHeaders.Add((string)headerTable[i][0]);
                    //Headers[i] = (string)headerTable[i][0];                   
                }
                listHeaders.Add("serializable");
                Headers = listHeaders.ToArray();

                Query getDataQuery = new Query { QueryString = "SELECT * FROM parts" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                Part[] data = new Part[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {

                    data[i] = new Part
                    {
                        itemID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        SKU = (string)dataTable[i][2],
                        serialNumber = (string)dataTable[i][3],
                        count = (int)dataTable[i][4]
                    };
                    if ((int)dataTable[i][4] > 1)
                        data[i].serializable = false;
                    else
                        data[i].serializable = true;
                }
                Data = data;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        #endregion

        #region System

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

        public async Task Synchronize()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'systems'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                Headers = new string[headerTable.Length];
                for (int i = 0; i < headerTable.Length; i++)
                {
                    Headers[i] = (string)headerTable[i][0];
                }
                Headers[Headers.Length - 1] = "serializable";

                Query getDataQuery = new Query { QueryString = "SELECT * FROM systems" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                System[] data = new System[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new System
                    {
                        itemID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        SKU = (string)dataTable[i][2],
                        serialNumber = (string)dataTable[i][3],
                        systemTempateID = (int)dataTable[i][4],
                    };
                }
                Data = data;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        #endregion

        #region LogIn

        private static Boolean userNameExixts = false;
        private readonly static ArrayList userNames = new ArrayList();
        private static Boolean hashPassExists;
        private static Boolean comboExists;
        private static String message = "";

        public static async Task Authenticate(string userName, string hashPass)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query query = QBuilder.BuildQuery("users", new[] { "userName", "hashString" });
                object[][] table = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), query.QueryString).ConfigureAwait(false);

                if (table.Length == 0)
                    message = "No users in database.";

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][0].Equals(userName) && table[i][1].Equals(hashPass))
                    {
                        comboExists = true;
                        break;
                    }
                    else if (table[i][0].Equals(userName))
                        usernameExists = true;
                    else if (!usernameExists && table[i][1].Equals(hashPass))
                        hashPassExists = true;
                }

                if (comboExists)
                    message = "Account authenticated";
                else if (usernameExists)
                    message = "Password not found";
                else if (hashPassExists)
                    message = "Username not found";
                else
                    message = "Username and password not found";
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        //TODO: character restrictions
        public static void EnterInfo(string userName, string hashedString)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                var UN = new KeyValuePair<string, object>("userName", userName);
                var HS = new KeyValuePair<String, Object>("hashString", hashedString);
                var values = new[] { UN, HS };
                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query query = QBuilder.BuildInsertQuery("users", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), query.QueryString, query.Parameters).Wait();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        public static Boolean NotDuplicate(string userName)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                getUserNames(DatabaseManager).Wait();
                for (int i = 0; i < userNames.Count; i++)
                {
                    if (userName.Equals(userNames[i]))
                    {
                        userNameExixts = true;
                        break;
                    }
                }
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
            return userNameExixts;
        }

        public static async Task getUserNames(IDatabaseManager DatabaseManager)
        {
            var table = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), "SELECT * from users").ConfigureAwait(false);
            for (int i = 0; i < table.Length; i++)
            {
                userNames.Add(table[i][0]);
            }
        }

        #endregion
    }
}
