using CTG.Database.MySQL;
using System;
using System.Threading.Tasks;

namespace CTG.Database.Communication
{

    public class Login
    {
        public static bool Authenticate(string userName, string hashPass)
        {
            return Synchronize(userName, hashPass).Result;
        }

        public static async Task<bool> Synchronize(string userName, string hashPass)
        {
            MySqlDatabaseManager manager = new MySqlDatabaseManager("server=localhost;database=atlas;uid=kevin;password=kevin");
            manager.GetConnection();

            var exists = false;
            var query = QueryBuilder.BuildQuery("users", new[] { "userName", "hashString" });
            using (var reader = await manager.ExecuteReaderAsync(manager.GetConnection(), query.QueryString))
            {
                while (reader.Read())
                {
                    exists = (((string)reader[0]).Equals(userName) && ((string)reader[1]).Equals(hashPass));
                }
            }
            manager.GetConnection().Close();
            return exists;
        }
    }
}
