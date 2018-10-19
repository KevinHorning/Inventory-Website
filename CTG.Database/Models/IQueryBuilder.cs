using System.Collections.Generic;
using CTG.Database.MySQL;

namespace CTG.Database.Models
{
    public interface IQueryBuilder
    {
        Query BuildQuery(string table, string[] columns, Filter[] filters = null, KeyValuePair<string, bool>[] sorting = null);
        Query BuildInsertQuery(string table, KeyValuePair<string, object>[] values, bool returnId = false);
        Query BuildUpdateQuery(string table, KeyValuePair<string, object>[] values, Filter[] filters, bool includeVoidedRows = false);
        Query BuildCountQuery(string table, Filter[] filters = null, bool includeVoidedRows = false);
        Query BuildDeleteQuery(string table, Filter[] filters, bool includeVoidedRows = false);
    }
}