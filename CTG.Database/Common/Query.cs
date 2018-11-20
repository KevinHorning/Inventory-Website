using CTG.Database.Models;

namespace CTG.Database
{
    public class Query
    {
        public string QueryString { get; set; }
        public SqlParameter[] Parameters { get; set; }
    }
}