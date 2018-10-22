using System;
using System.Data.SqlClient;
using CTG.Database.Models;
using Backend.Login;

namespace Backend.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
                Console.WriteLine("Connection Successful");
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
            }

            Console.ReadKey();
        }
    }
}