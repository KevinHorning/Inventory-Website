using CTG.Database;
using System;
using System.Threading.Tasks;

namespace Backend.Shared
{
    class Deletion
    {
        public static void Delete(string table, int ID)
        {
            Synchronize(table, ID).Wait();
        }

        public static async Task Synchronize(string table, int ID)
        {
            Boolean isException = false;
            var DatabaseManager = Shared.DBconnection.GetManager();
            
            Query sizeQuery = new Query { QueryString = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'" };
            var tableNames = await DatabaseManager.ExecuteTableAsync(DatabaseManager.GetConnection(), sizeQuery.QueryString).ConfigureAwait(false);

            Query namesQuery = new Query { QueryString = "SELECT COUNT(*) FROM " + table };
            var tableSize = await DatabaseManager.ExecuteScalarAsync(DatabaseManager.GetConnection(), namesQuery.QueryString, namesQuery.Parameters).ConfigureAwait(false);

            try
            {
                Boolean tableExists = false;
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if (table.Equals(tableNames[i][0]))
                        tableExists = true;
                }
                if (!tableExists)
                    throw new CustomException("Table " + table + " does not exist.");                

                if (ID >= (int)tableSize || ID < 0)
                    throw new CustomException("ID is out of range.");
            }
            catch (CustomException ex)
            {
                isException = true;
                Console.WriteLine(ex.Message);
                //todo exeption handling
            }
            finally
            {
                if (!isException)
                {
                    string tableIDattribute = table.Substring(0, table.Length - 1);
                    Query deleteQuery = new Query { QueryString = "DELETE FROM " + table + " WHERE " + tableIDattribute + " = " + ID};
                    DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), deleteQuery.QueryString, deleteQuery.Parameters).Wait();
                    DatabaseManager.GetConnection().Close();
                }
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
