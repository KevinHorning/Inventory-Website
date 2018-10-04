using CTG.Database.MySQL;
using System.Threading.Tasks;

public class Login
{
    public bool Authenticate(string userName, string hashPass)
    {
        return Synchronize(userName, hashPass).Result; 
    }

    public static async Task<bool> Synchronize(string userName, string hashPass)
    {
        var exists = false;
        MySqlDatabaseManager manager = new MySqlDatabaseManager("server=localhost;database=atlas;uid=kevin;password=kevin");
        manager.GetConnection();

        Query Q = QueryBuilder.BuildQuery("users", new[] {"userName", "hashString"});
        using (var reader = await manager.ExecuteReaderAsync(manager.GetConnection(), Q.QueryString))
        {
            while (reader.Read())
            {
                if (((string)reader[0]).Equals(userName) && ((string)reader[1]).Equals(hashPass))
                    exists = true;
            }
        }
        manager.GetConnection().Close();
        return exists;
    }
}
