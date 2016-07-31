using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anthill.Engine.Services.QueryBuilder
{
    public class SqlQueryBuilder : ISelectQueryBuilder, IInsertStatementBuilder, IUpdateStatementBuilder, ISelect, IFrom, IWhere, IInsertInto, IValues, IUpdate, ISet
    {
        public SqlQueryBuilder()
        {

        }

        private StringBuilder stringBuilder = new StringBuilder();

        private IEnumerable<string> CorrectValues(object[] values)
        {
            return values.Select((input, output) => CorrectValue(input));
        }

        private string CorrectValue(object value)
        {
            if (value.GetType() == typeof(string))
            {
                return $"'{value}'";
            }
            if (value.GetType() == typeof(bool))
            {
                return value.ToString().ToLowerInvariant();
            }
            return value.ToString();
        }

        public IInsertInto InsertInto(string tableName)
        {
            stringBuilder.Append($"INSERT INTO {tableName} ");
            return this;
        }

        public IValues Values(params Tuple<string, object>[] clauses)
        {
            var columns = new List<String>();
            var values = new List<object>();
            foreach (var clause in clauses)
            {
                columns.Add(clause.Item1);
                values.Add(clause.Item2);
            }
            stringBuilder.AppendFormat("({0})", string.Join(", ", columns));
            Values(values.ToArray());
            return this;
        }

        public IValues Values(params object[] values)
        {
            stringBuilder.Append(" VALUES ");
            var correctValues = CorrectValues(values);
            stringBuilder.AppendFormat("({0})", string.Join(", ", correctValues));
            return this;
        }

        public ISelect Select(params string[] parameters)
        {
            stringBuilder.Append("SELECT ");
            stringBuilder.Append(string.Join(", ", parameters));
            return this;
        }

        public IFrom From(string tableName)
        {
            stringBuilder.Append($" FROM {tableName}");
            return this;
        }

        public IWhere Where(params string[] whereClauses)
        {
            stringBuilder.Append(" WHERE ");
            stringBuilder.Append(string.Join(" AND ", whereClauses));
            return this;
        }

        public IOrderBy OrderBy(params string[] fields)
        {
            stringBuilder.Append(" ORDER BY ");
            stringBuilder.Append(string.Join(", ", fields));
            return this;
        }

        public SqlQueryBuilder Clear()
        {
            stringBuilder.Clear();
            return this;
        }

        public string ToQuery()
        {
            return stringBuilder.ToString();
        }

        public IUpdate Update(string tableName)
        {
            stringBuilder.Append($"UPDATE {tableName} ");
            return this;
        }

        public ISet Set(params Tuple<string, object>[] clauses)
        {
            stringBuilder.Append("SET ");
            var values = clauses.Select((input, output) => $"{input.Item1}={CorrectValue(input.Item2)}");
            stringBuilder.Append(string.Join(", ", values));
            return this;
        }
    }
}
