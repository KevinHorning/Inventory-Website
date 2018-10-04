using CTG.Database.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Threading.Tasks;

namespace CTG.Database
{
    public interface IDatabaseManager
    {
        MySqlConnection GetConnection();

        Task<DbDataReader> ExecuteRawAsync(string query, SqlParameter[] parameters = null);
        Task<DbDataReader> ExecuteRawAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null);


        Task<int> ExecuteScalarAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null);
        Task<int> ExecuteScalarAsync(string query, SqlParameter[] parameters = null);

        Task<DbDataReader> ExecuteReaderAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null);
        Task<DbDataReader> ExecuteReaderAsync(string query, SqlParameter[] parameters = null);

        Task ExecuteNonQueryAsync(MySqlConnection connection, string query, SqlParameter[] parameters = null);
        Task ExecuteNonQueryAsync(string query, SqlParameter[] parameters = null);
    }
}