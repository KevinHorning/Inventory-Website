using System.Data;

namespace CTG.Database.Models
{
    public class SqlParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public DbType Type { get; set; } = DbType.String;
    }
}
