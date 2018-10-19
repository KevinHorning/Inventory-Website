using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CTG.Database.Models;

namespace CTG.Database.Oracle
{
    public class OracleQueryBuilder: IQueryBuilder
    {
        public Query BuildQuery(string table, string[] columns, Filter[] filters = null, KeyValuePair<string, bool>[] sorting = null)
        {
            var result = new Query();

            var queryString = $"SELECT {string.Join(",", columns)} FROM {table}";
            var paramList = new List<SqlParameter>();
            queryString = BuildWhereClause(filters, result, queryString, paramList);

            if (sorting != null)
            {
                queryString += " ORDER BY";
                foreach (var item in sorting)
                {
                    var orderString = item.Value ? "ASC" : "DESC";
                    queryString += $" {item.Key} {orderString}, ";
                }
                queryString = queryString.Substring(0, queryString.Length - 2);//strip off trailing comma
            }

            result.QueryString = queryString;
            return result;
        }

        public Query BuildInsertQuery(string table, KeyValuePair<string, object>[] values, bool returnId = false)
        {
            var result = new Query();

            var queryString = $"INSERT INTO {table}({string.Join(",", values.Select(x => x.Key))})";
            queryString += " VALUES (";

            var paramList = new List<SqlParameter>();

            foreach (var value in values)
            {
                var id = Guid.NewGuid().ToString().Replace("-", "");
                var parameterName = $"@{id}";
                queryString += $"{parameterName},";

                var cleanedValue = value.Value;
                if (value.Value is DateTime)
                {
                    cleanedValue = ((DateTime)cleanedValue).ToString("yyyy-MM-dd HH:mm:ss");
                }

                paramList.Add(new SqlParameter
                {
                    Name = parameterName,
                    Value = cleanedValue,
                    Type = GetDatabaseType(value.Value)
                });
            }

            queryString = queryString.Substring(0, queryString.Length - 1);//strip off trailing comma
            queryString += ")";

            if (returnId)
            {
                queryString += ";SELECT LAST_INSERT_ID();";
            }

            result.Parameters = paramList.ToArray();
            result.QueryString = queryString;
            return result;
        }
        
        public Query BuildUpdateQuery(string table, KeyValuePair<string, object>[] values, Filter[] filters, bool includeVoidedRows = false)
        {
            var result = new Query();

            var queryString = $"UPDATE {table}";
            queryString += " SET ";

            var paramList = new List<SqlParameter>();

            foreach (var value in values)
            {
                var id = Guid.NewGuid().ToString().Replace("-", "");
                var parameterName = $"@{id}";
                queryString += $"{value.Key} = {parameterName},";

                var filterValue = value.Value.ToString();
                if (value.Value is string)
                    filterValue = $"{value.Value}";

                if (value.Value is DateTime)
                    filterValue = $"{value.Value:yyyy-MM-dd hh:mm:ss}";

                paramList.Add(new SqlParameter
                {
                    Name = parameterName,
                    Value = filterValue,
                    Type = GetDatabaseType(value.Value)
                });
            }
            queryString = queryString.Substring(0, queryString.Length - 1);//strip off trailing comma
            queryString = BuildWhereClause(filters, result, queryString, paramList);

            result.Parameters = paramList.ToArray();
            result.QueryString = queryString;
            return result;
        }

        public Query BuildCountQuery(string table, Filter[] filters = null, bool includeVoidedRows = false)
        {
            var result = new Query();

            var paramList = new List<SqlParameter>();

            var queryString = $"SELECT COUNT(*) FROM {table}";
            queryString = BuildWhereClause(filters, result, queryString, paramList);

            result.QueryString = queryString;
            result.Parameters = paramList.ToArray();
            return result;
        }

        public Query BuildDeleteQuery(string table, Filter[] filters, bool includeVoidedRows = false)
        {
            var result = new Query();

            var queryString = $"DELETE FROM {table}";

            var paramList = new List<SqlParameter>();
            queryString = BuildWhereClause(filters, result, queryString, paramList);

            result.Parameters = paramList.ToArray();
            result.QueryString = queryString;
            return result;
        }

        private DbType GetDatabaseType(object value)
        {
            if (value is bool)
            {
                return DbType.Boolean;
            }

            if (value is string)
            {
                return DbType.String;
            }

            if (value is int)
            {
                return DbType.Int32;
            }

            if (value is short)
            {
                return DbType.Int16;
            }

            if (value is double)
            {
                return DbType.Double;
            }

            if (value is DateTime)
            {
                return DbType.DateTime2;
            }

            return DbType.Binary;
        }

        private string BuildWhereClause(Filter[] filters, Query result, string queryString, List<SqlParameter> paramList)
        {
            if (filters == null || filters.Length == 0)
            {
                return queryString;
            }

            queryString += " WHERE ";

            foreach (var filter in filters)
            {
                if (filter.Operator.ToLower().Contains("in"))
                {
                    queryString += $"{filter.Column} {filter.Operator} ({filter.Value}) AND ";
                }
                else if (filter.Operator.ToLower().Equals("is"))
                {
                    queryString += $"{filter.Column} IS {filter.Value} AND ";
                }
                else
                {
                    var id = Guid.NewGuid().ToString().Replace("-", "");
                    var parameterName = $"@{id}";
                    queryString += $"{filter.Column} {filter.Operator} {parameterName} AND ";

                    var filterValue = filter.Value.ToString();
                    if (filter.Value is string)
                        filterValue = $"{filter.Value}";

                    if (filter.Value is DateTime)
                        filterValue = $"{filter.Value:yyyy-MM-dd hh:mm:ss}";

                    paramList.Add(new SqlParameter
                    {
                        Name = parameterName,
                        Value = filterValue,
                        Type = GetDatabaseType(filter.Value)
                    });
                }
            }
            queryString = queryString.Substring(0, queryString.Length - 4);//strip off trailing AND

            result.Parameters = paramList.ToArray();

            return queryString;
        }
    }
}
