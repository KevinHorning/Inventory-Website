using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CTG.Database.Models;
using MySql.Data.MySqlClient;
using IDatabaseManager = CTG.Database.Models.IDatabaseManager;

namespace CTG.Database.MySQL
{
    internal class MySqlDatabaseManager : IDatabaseManager
    {
        private readonly string _connectionString;

        public MySqlDatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IConnectionWrapper GetConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return new MySqlConnectionWrapper(connection);
        }

        public async Task<int> ExecuteScalarAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null)
        {
            var mysqlConnection = (MySqlConnectionWrapper)connection;
            
            var command = GetCommand(mysqlConnection.GetConnection(), query, parameters);
            var result = await command.ExecuteScalarAsync().ConfigureAwait(false);
            if (result != DBNull.Value)
                return int.Parse(result.ToString());
            return 0;
        }

        public async Task<int> ExecuteScalarAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            var mysqlConnection = (MySqlConnectionWrapper)connection;

            try
            {
                return await ExecuteScalarAsync(connection, query, parameters).ConfigureAwait(false);
            }
            finally
            {
                mysqlConnection.GetConnection().Close();
            }
        }

        public async Task<object[][]> ExecuteTableAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null)
        {
            var mysqlConnection = (MySqlConnectionWrapper)connection;

            var command = GetCommand(mysqlConnection.GetConnection(), query, parameters);
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
            var mysqlConnection = (MySqlConnectionWrapper)connection;

            var command = GetCommand(mysqlConnection.GetConnection(), query, parameters);
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        public async Task ExecuteNonQueryAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            var mysqlConnection = (MySqlConnectionWrapper)connection;

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

        private MySqlCommand GetCommand(MySqlConnection connection, string query, SqlParameter[] parameters = null)
        {
            var command = new MySqlCommand(query, connection);
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
