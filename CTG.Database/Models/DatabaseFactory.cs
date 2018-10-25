using System;
using CTG.Database.MSSQL;
using CTG.Database.MySQL;
using CTG.Database.Oracle;

namespace CTG.Database.Models

{
    public static class DatabaseFactory
    {
        public enum ManagerType
        {
            MySQL,
            Oracle,
            MSSQL
        }

        public static IDatabaseManager Create(ManagerType managerType, string connectionString)
        {
            switch (managerType)
            {
                case ManagerType.MySQL:
                    return new MySqlDatabaseManager(connectionString);
                case ManagerType.Oracle:
                    return new OracleDatabaseManager(connectionString);
                case ManagerType.MSSQL:
                    return new MSSQLDatabaseManager(connectionString);
                default:
                    throw new ArgumentOutOfRangeException(nameof(managerType), managerType, null);
            }
        }

        public static IQueryBuilder CreateQueryBuilder(ManagerType managerType)
        {
            switch (managerType)
            {
                case ManagerType.MySQL:
                    return new MySQLQueryBuilder();
                case ManagerType.Oracle:
                    return new OracleQueryBuilder();
                case ManagerType.MSSQL:
                    return new MSSQLQueryBuilder();
                default:
                    throw new ArgumentOutOfRangeException(nameof(managerType), managerType, null);
            }
        }
    }
}
