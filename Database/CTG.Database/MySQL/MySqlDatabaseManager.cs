using System;
using System.Data.Common;
using System.IO;
using System.Threading.Tasks;
using CTG.Database.Models;
using MySql.Data.MySqlClient;

namespace CTG.Database.MySQL
{

    internal class MySqlDatabaseManager : IDatabaseManager
    {
        private readonly string _connectionString;

        public MySqlDatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public async Task<DbDataReader> ExecuteRawAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null)
        {
            var command = GetCommand(connection, query, parameters);
            var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
            return reader;
        }

        public async Task<DbDataReader> ExecuteRawAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            return await ExecuteRawAsync(connection, query, parameters);
        }

        public async Task<int> ExecuteScalarAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null)
        {
            var command = GetCommand(connection, query, parameters);
            var result = await command.ExecuteScalarAsync().ConfigureAwait(false);
            return (int?)result ?? 0;
        }

        public async Task<int> ExecuteScalarAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            try
            {
                return await ExecuteScalarAsync(connection, query, parameters).ConfigureAwait(false);
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<DbDataReader> ExecuteReaderAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null)
        {
            var command = GetCommand(connection, query, parameters);
            var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
            return reader;
        }

        public async Task<DbDataReader> ExecuteReaderAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            return await ExecuteReaderAsync(connection, query, parameters).ConfigureAwait(false);
        }

        public async Task ExecuteNonQueryAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null)
        {
            var command = GetCommand(connection, query, parameters);
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        public async Task ExecuteNonQueryAsync(string query, SqlParameter[] parameters = null)
        {
            var connection = GetConnection();
            try
            {
                await ExecuteNonQueryAsync(connection, query, parameters).ConfigureAwait(false);
            }
            finally
            {
                connection.Close();
            }
        }

        #region helpers

        private MySqlCommand GetCommand(MySqlConnection mySqlConnection, string query, SqlParameter[] parameters = null)
        {
            var command = new MySqlCommand(query, mySqlConnection);
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
