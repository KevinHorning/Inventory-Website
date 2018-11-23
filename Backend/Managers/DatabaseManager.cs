using Backend.Models;
using CTG.Database;
using CTG.Database.MSSQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Managers
{
    public class DatabaseManager
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

        public static void AddEquipment(String name, String location, String notes = null)
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

        public async Task<Equipment[]> GetEquipmentTable()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'equipment'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                var headers = new string[headerTable.Length];
                for (int i = 0; i < headerTable.Length; i++)
                {
                    headers[i] = (string)headerTable[i][0];
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
                return data;
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

        public static async Task<bool> PartIDExists(int partID)
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

        public static void AddPart(System.String name, System.String SKU, string serialNumber, int count)
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

        public async Task<int> AddToSystem(int systemID, int partID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                if (!SystemIDExists(systemID).Result && !PartIDExists(partID).Result)
                {
                    var systemIDpair = new KeyValuePair<System.String, object>("systemID", systemID);
                    var partIDpair = new KeyValuePair<System.String, object>("partID", partID);
                    var values = new[] { systemIDpair, partIDpair };

                    MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                    Query insertQuery = QBuilder.BuildInsertQuery("systemParts", values);
                    DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
                }
                else if (await PartIDExists(partID))
                {
                    return 1;
                }
                else if (await SystemIDExists(systemID))
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

        public async Task<Part[]> GetPartsTable()
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
                var headers = listHeaders.ToArray();

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
                return data;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        #endregion

        #region System

        public static async Task<bool> SystemIDExists(int systemID)
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

        public async Task<bool> AddSystem(String name, String SKU, String serialNumber, int systemTemplateID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {
                if (!await SerialNumberExists(serialNumber))
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

        public async Task<Models.System[]> GetSystemsTable()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Query getHeadersQuery = new Query { QueryString = "SELECT COLUMN_NAME FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'systems'" };
                var headerTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getHeadersQuery.QueryString).ConfigureAwait(false);

                var headers = new string[headerTable.Length];
                for (int i = 0; i < headerTable.Length; i++)
                {
                    headers[i] = (string)headerTable[i][0];
                }
                headers[headers.Length - 1] = "serializable";

                Query getDataQuery = new Query { QueryString = "SELECT * FROM systems" };
                var dataTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getDataQuery.QueryString).ConfigureAwait(false);

                Models.System[] data = new Models.System[dataTable.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new Models.System
                    {
                        itemID = (int)dataTable[i][0],
                        name = (string)dataTable[i][1],
                        SKU = (string)dataTable[i][2],
                        serialNumber = (string)dataTable[i][3],
                        systemTempateID = (int)dataTable[i][4],
                    };
                }
                return data;
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        #endregion

        #region LogIn

        private readonly static ArrayList userNames = new ArrayList();
        private static bool comboExists;

        public async Task<bool> Authenticate(string userName, string hashPass)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query query = QBuilder.BuildQuery("users", new[] { "userName", "hashString" });
                object[][] table = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), query.QueryString).ConfigureAwait(false);

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][0].Equals(userName) && table[i][1].Equals(hashPass))
                    {
                        return true;
                    }
                }
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
            return false;
        }

        //TODO: character restrictions
        public static void EnterInfo(string userName, string hashedString)
        {
            var databaseManager = Shared.DBconnection.GetManager();

            try
            {
                var UN = new KeyValuePair<string, object>("userName", userName);
                var HS = new KeyValuePair<String, Object>("hashString", hashedString);
                var values = new[] { UN, HS };
                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query query = QBuilder.BuildInsertQuery("users", values);
                databaseManager.ExecuteNonQueryAsync(databaseManager.GetConnection(), query.QueryString, query.Parameters).Wait();
            }
            finally
            {
                databaseManager.GetConnection().Close();
            }
        }

        public static bool NotDuplicate(string userName)
        {
            var databaseManager = Shared.DBconnection.GetManager();
            try
            {
                getUserNames().Wait();
                for (int i = 0; i < userNames.Count; i++)
                {
                    if (userName.Equals(userNames[i]))
                    {
                        return true;
                    }
                }
            }
            finally
            {
                databaseManager.GetConnection().Close();
            }
            return false;
        }

        public static async Task getUserNames()
        {
            var databaseManager = Shared.DBconnection.GetManager();
            var table = await databaseManager.ExecuteTableAsync(databaseManager.GetConnection(), "SELECT * from users").ConfigureAwait(false);
            for (int i = 0; i < table.Length; i++)
            {
                userNames.Add(table[i][0]);
            }
        }

        #endregion
    }
}
