using CTG.Database.MySQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Test1
{
    public static void Main()
    {
        //Console.WriteLine(Login.Authenticate("hgdsong", "yyyninf"));
        test().Wait();
        Console.ReadKey();
    }

    public static async Task test()
	{
		MySqlDatabaseManager manager = new MySqlDatabaseManager("server=localhost;database=atlas;uid=kevin;password=kevin");
		manager.GetConnection();

        Query insQuery = insertQuery();
        manager.ExecuteNonQueryAsync(manager.GetConnection(), insQuery.QueryString, insQuery.Parameters).Wait();
		//manager.ExecuteNonQueryAsync(manager.GetConnection(), "DELETE FROM users").Wait();
		using (var rdr = await manager.ExecuteReaderAsync(manager.GetConnection(), "SELECT * from users"))
		{
			while (rdr.Read())
			{
				Console.WriteLine(rdr[0] + " " + rdr[1] + " " + rdr[2]);
			}
		}
		Console.WriteLine("Done.");
	}

    public static Query insertQuery()
    {
        KeyValuePair<String, Object>[] values = { new KeyValuePair<String, Object>("userName", "John Smith"), new KeyValuePair<String, Object>("hashString", "84345354") };
        Query Q = QueryBuilder.BuildInsertQuery("users", values);
        return Q;
    }
}