using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CTG.Database.Models;
using CTG.Database.MSSQL;

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
            MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
            Query query = QBuilder.BuildInsertQuery("users", values);
            manager.ExecuteNonQueryAsync(manager.GetConnection(), query.QueryString, query.Parameters).Wait();
            manager.getConnection.close();
        }

        public static Boolean notDuplicate(string username)
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

            getUserNames(manager).Wait();
            for (int i = 0; i < userNames.Count; i++)
            {
                if (username.Equals(userNames[i]))
                    userNameExixts = true;
            }

            manager.getConnection.close();
            return userNameExixts;
        }

        public static async Task getUserNames(IDatabaseManager manager)
        {
            var table = await manager.ExecuteTableAsync(manager.GetConnection(), "SELECT * from users");
            for (int i = 0; i < table.Length; i++)
            {
                userNames.Add(table[i][0]);
            }
        }
    }
}