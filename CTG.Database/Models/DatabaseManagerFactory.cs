using CTG.Database.MySQL;
using System;

namespace CTG.Database
{
    public static class DatabaseManagerFactory
    {
        public enum ManagerType
        {
            MySQL
        }

        public static IDatabaseManager Create(ManagerType managerType, string connectionString)
        {
            switch (managerType)
            {
                case ManagerType.MySQL:
                    return new MySqlDatabaseManager(connectionString);
                default:
                    throw new ArgumentOutOfRangeException(nameof(managerType), managerType, null);
            }
        }
    }
}
