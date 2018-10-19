using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CTG.Database.Communicate
{
    class CreateAccount
    {  
        static Boolean userNameExixts = false;
        static ArrayList userNames = new ArrayList();

        public void EnterInfo(string username, string password)
        {
            var cb = new SqlConnectionStringBuilder
            {
                DataSource = "atlas-dev-server.database.windows.net",
                UserID = "kevinH",
                Password = "Kevin#321",
                InitialCatalog = "atlas"
            };

            var manager = DatabaseFactory.Create(DatabaseFactory.ManagerType.MSSQL, cb.ConnectionString);
            manager.GetConnection();

            var UN = new KeyValuePair<string, object>("userName", username);
            var HS = new KeyValuePair<String, Object>("hashString", password);
            var values = new[] { UN, HS };
            Query query = QueryBuilder.BuildInsertQuery("users", values);
            manager.ExecuteNonQueryAsync(manager.GetConnection(), query.QueryString, query.Parameters).Wait();
        }

        public static Boolean notDuplicate(string username)
        {
            MySqlDatabaseManager manager = new MySqlDatabaseManager("server=localhost;database=atlas;uid=kevin;password=kevin");
            manager.GetConnection();

            getUserNames(manager).Wait();
            for (int i = 0; i < userNames.Count; i++)
            {
                if (username.Equals(userNames[i]))
                    userNameExixts = true;
            }

            return userNameExixts;
        }

        public static async Task getUserNames(MySqlDatabaseManager manager)
        {
            using (var reader = await manager.ExecuteReaderAsync(manager.GetConnection(), "SELECT * from users"))
            {
                while (reader.Read())
                {
                    userNames.Add(reader[0]);
                }
            }
        }
    }
}