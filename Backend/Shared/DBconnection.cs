using CTG.Database.Models;
using System.Data.SqlClient;

namespace Backend.Shared
{
    class DBconnection
    {      
        public static IDatabaseManager GetManager()
        {
            var cb = new SqlConnectionStringBuilder
            {
                DataSource = "atlas-dev-server.database.windows.net",
                UserID = "kevinH",
                Password = "Kevin#321",
                InitialCatalog = "atlas"
            };
            var manager = DatabaseFactory.Create(DatabaseFactory.ManagerType.MSSQL, cb.ConnectionString);
            return manager;
        }  
    }
}
