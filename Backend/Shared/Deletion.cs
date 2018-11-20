﻿using Backend.Parts;
using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Shared
{
    class Deletion
    {
        public static void Delete(string tableName, int ID)
        {
            Synchronize(tableName, ID).Wait();
        }

        public static async Task Synchronize(string tableName, int ID)
        {
            Boolean isException = false;
            var DatabaseManager = Shared.DBconnection.GetManager();

            try
            {   
                //TODO change to verification method
                Query getTableNamesQuery = new Query { QueryString = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'" };
                var tableNames = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getTableNamesQuery.QueryString).ConfigureAwait(false);

                Query getPrimaryKeyQuery = new Query { QueryString = "SELECT * FROM atlas.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'" };
                var partsTable = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getPrimaryKeyQuery.QueryString).ConfigureAwait(false);
                string tablePrimaryKeyName = (string)partsTable[0][3];

                Query getTableIDsQuery = new Query { QueryString = "SELECT " + tablePrimaryKeyName + " FROM " + tableName};
                var tablePrimaryIDs = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), getTableIDsQuery.QueryString).ConfigureAwait(false);

                Boolean tableExists = false;
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if (tableName.Equals(tableNames[i][0]))
                        tableExists = true;
                }
                if (!tableExists)
                {
                    isException = true;
                    throw new CustomException("Table " + tableName + " does not exist.");
                }

                var tableData = PartsTable.GetPartsTable().Data ;
                Boolean IDexists = false;
                for (int j = 0; j < tableData.Length; j++)
                {
                    if (ID.Equals(tablePrimaryIDs[j][0]))
                        IDexists = true;
                }
                if (!IDexists)
                    throw new CustomException("ID does not exist");

                if (!isException)
                {
                    Query deleteQuery = new Query { QueryString = "DELETE FROM " + tableName + " WHERE " + tablePrimaryKeyName + " = " + ID };
                    DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), deleteQuery.QueryString, deleteQuery.Parameters).Wait();
                }
            }
            catch (CustomException ex)
            {
                isException = true;
                Console.WriteLine(ex.Message);
                //todo exeption handling
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        class CustomException : Exception
        {
            public CustomException(string message)
            {
            }
        }
    }
}
