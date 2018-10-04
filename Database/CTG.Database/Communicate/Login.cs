using System;
using System.Threading.Tasks;
using CTG.Database.MySQL;

namespace CTG.Database.Communication
{

    public class Login
    {
        static Boolean exists = false;
        public static Boolean Authenticate(string userName, string hashPass)
        {
            Synchronize(userName, hashPass).Wait();
            return exists;
        }

        public static async Task Synchronize(string userName, string hashPass)
        {
            MySqlDatabaseManager manager = new MySqlDatabaseManager("server=localhost;database=atlas;uid=kevin;password=kevin");
            manager.GetConnection();

            Query Q = QueryBuilder.BuildQuery("users", new[] { "userName", "hashString" });
            using (var rdr = await manager.ExecuteReaderAsync(manager.GetConnection(), Q.QueryString))
            {
                while (rdr.Read())
                {
                    if ((string)rdr[0] == userName && (string)rdr[1] == hashPass)
                    {
                        exists = true;
                    }
                }
            }
            manager.GetConnection().Close();
        }
    }
}
