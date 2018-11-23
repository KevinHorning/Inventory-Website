using System.Threading.Tasks;

namespace CTG.Database.Models
{
    public interface IDatabaseManager
    {
        IConnectionWrapper GetConnection();

        Task<int> ExecuteScalarAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null);
        Task<int> ExecuteScalarAsync(string query, SqlParameter[] parameters = null);

        Task<object[][]> ExecuteTableAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null);
        Task<object[][]> ExecuteTableAsync(string query, SqlParameter[] parameters = null);

        Task ExecuteNonQueryAsync(IConnectionWrapper connection, string query, SqlParameter[] parameters = null);
        Task ExecuteNonQueryAsync(string query, SqlParameter[] parameters = null);
    }
}