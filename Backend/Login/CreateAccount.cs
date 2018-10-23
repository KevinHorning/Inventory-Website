using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CTG.Database;
using CTG.Database.Models;
using CTG.Database.MSSQL;

namespace Backend.Login
{
    class CreateAccount
    {
        private static Boolean userNameExixts = false;
        private readonly static ArrayList userNames = new ArrayList();

        //TODO: character restrictions
        public static void EnterInfo(string userName, string hashedString)
        {
            var DatabaseManager = Shared.Connection.GetManager();

            var UN = new KeyValuePair<string, object>("userName", userName);
            var HS = new KeyValuePair<String, Object>("hashString", hashedString);
            var values = new[] { UN, HS };
            MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
            Query query = QBuilder.BuildInsertQuery("users", values);
            DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), query.QueryString, query.Parameters).Wait();
            DatabaseManager.GetConnection().Close();
        }

        public static Boolean NotDuplicate(string userName)
        {
            var DatabaseManager = Shared.Connection.GetManager();

            getUserNames(DatabaseManager).Wait();
            for (int i = 0; i < userNames.Count; i++)
            {
                if (userName.Equals(userNames[i]))
                {
                    userNameExixts = true;
                    break;
                }
            }
            DatabaseManager.GetConnection().Close();
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
    }
}