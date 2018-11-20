using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CTG.Database.Models;
using Oracle.ManagedDataAccess.Client;
using IDatabaseManager = CTG.Database.Models.IDatabaseManager;

namespace CTG.Database.Oracle
{
    public class OracleDatabaseManager : IDatabaseManager
    {
        private readonly string _connectionString;

        public OracleDatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IConnectionWrapper GetConnection()
        {
            var connection = new OracleConnection(_connectionString);
            connection.Open();
            return new OracleConnectionWrapper(connection);
        }

        public async Task<int> ExecuteScalarAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null)
        {
            var connectionWrapper = (OracleConnectionWrapper)connection;

            var command = GetCommand(connectionWrapper.GetConnection(), query, parameters);
            var result = await command.ExecuteScalarAsync().ConfigureAwait(false);
            if (result != DBNull.Value)
                return int.Parse(result.ToString());
            return 0;
        }

        public async Task<int> ExecuteScalarAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            var connectionWrapper = (OracleConnectionWrapper)connection;

            try
            {
                return await ExecuteScalarAsync(connection, query, parameters).ConfigureAwait(false);
            }
            finally
            {
                connectionWrapper.GetConnection().Close();
            }
        }

        public async Task<object[][]> ExecuteTableAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null)
        {
            var connectionWrapper = (OracleConnectionWrapper)connection;

            var command = GetCommand(connectionWrapper.GetConnection(), query, parameters);
            var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
            var schemaTable = reader.GetSchemaTable();

            var result = new List<object[]>();
            while (reader.Read())
            {
                var row = new List<object>();
                for (var i = 0; i < schemaTable.Rows.Count; i++)
                {
                    row.Add(reader.GetValue(i));
                }
                result.Add(row.ToArray());
            }

            return result.ToArray();
        }

        public async Task<object[][]> ExecuteTableAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            return await ExecuteTableAsync(connection, query, parameters).ConfigureAwait(false);
        }

        public async Task ExecuteNonQueryAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null)
        {
            var mysqlConnection = (OracleConnectionWrapper)connection;

            var command = GetCommand(mysqlConnection.GetConnection(), query, parameters);
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        public async Task ExecuteNonQueryAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            var mysqlConnection = (OracleConnectionWrapper)connection;

            try
            {
                await ExecuteNonQueryAsync(connection, query, parameters).ConfigureAwait(false);
            }
            finally
            {
                mysqlConnection.GetConnection().Close();
            }
        }

        #region helpers

        private OracleCommand GetCommand(OracleConnection connection, string query, SqlParameter[] parameters = null)
        {
            var command = new OracleCommand(query, connection);
            command.CommandTimeout = 15 * 60;
            command.Prepare();

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    var p = command.CreateParameter();
                    p.ParameterName = parameter.Name;
                    p.Value = parameter.Value;
                    p.DbType = parameter.Type;
                    command.Parameters.Add(p);
                }
            }

            return command;
        }

        #endregion
    }
}
