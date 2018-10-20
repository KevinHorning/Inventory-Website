﻿using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CTG.Database;
using CTG.Database.Models;
using CTG.Database.MSSQL;

namespace Backend.Login
{

    public class Login
    {
        static Boolean usernameExists;
        static Boolean hashPassExists;
        static Boolean comboExists;
        static String message = "";

        //TODO: add admin version 
        public static Tuple<Boolean, String> Authenticate(string userName, string hashPass)
        {
            Synchronize(userName, hashPass).Wait();
            return Tuple.Create(comboExists, message);
        }

        public static async Task Synchronize(string userName, string hashPass)
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

            MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
            Query query = QBuilder.BuildQuery("users", new[] { "userName", "hashString" });
            object[][] table = await manager.ExecuteTableAsync(manager.GetConnection(), query.QueryString);

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

            manager.GetConnection().Close();
        }
    }
}