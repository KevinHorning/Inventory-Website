using Oracle.ManagedDataAccess.Client;

namespace CTG.Database.Oracle
{
    public class OracleConnectionWrapper : IConnectionWrapper
    {
        private readonly OracleConnection _connection;

        public OracleConnectionWrapper(OracleConnection connection)
        {
            _connection = connection;
        }

        public OracleConnection GetConnection()
        {
            return _connection;
        }

        public void Close()
        {
            _connection?.Close();
        }
    }
}
