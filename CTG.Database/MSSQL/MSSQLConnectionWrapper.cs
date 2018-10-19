using System.Data.SqlClient;

namespace CTG.Database.MSSQL
{
    public class MSSQLConnectionWrapper : IConnectionWrapper
    {
        private readonly SqlConnection _connection;

        public MSSQLConnectionWrapper(SqlConnection connection)
        {
            _connection = connection;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void Close()
        {
            _connection?.Close();
        }
    }
}
