using CTG.Database.MySQL;
using System;
using System.Threading.Tasks;

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

            Query query = QueryBuilder.BuildQuery("users", new[] { "userName", "hashString" });
            using (var reader = await manager.ExecuteReaderAsync(manager.GetConnection(), query.QueryString))
            {
                while (reader.Read())
                {
                    exists = ((string)reader[0] == userName && (string)reader[1] == hashPass);
                }
            }
            manager.GetConnection().Close();
        }
    }
}
