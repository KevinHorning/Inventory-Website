using MySql.Data.MySqlClient;

namespace CTG.Database.MySQL
{
    public class MySqlConnectionWrapper : IConnectionWrapper
    {
        private readonly MySqlConnection _connection;

        public MySqlConnectionWrapper(MySqlConnection connection)
        {
            _connection = connection;
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        public void Close()
        {
            _connection?.Close();
        }
    }
}
