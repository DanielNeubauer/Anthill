using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services
{
    public class SqlQueryBuilder
    {
        public SqlQueryBuilder()
        {

        }

        private StringBuilder stringBuilder = new StringBuilder();

        public SqlQueryBuilder InsertInto(string tableName)
        {
            stringBuilder.Append("INSERT INTO {tableName} ");
            return this;
        }

        public SqlQueryBuilder Values(params Tuple<string,object>[] clauses)
        {
            var columns = new List<String>();
            var values = new List<object>();
            foreach (var clause in clauses)
            {
                columns.Add(clause.Item1);
                values.Add(clause.Item2);
            }
            stringBuilder.AppendFormat("({0})", string.Join(", ",columns));
            Values(values.ToArray());
            return this;
        }

        public SqlQueryBuilder Values(params object[] values)
        {
            stringBuilder.Append(" VALUES ");
            stringBuilder.AppendFormat("({0})", string.Join(", ", values));
            return this;
        }

        public SqlQueryBuilder Select(params string[] parameters)
        {
            stringBuilder.Append("SELECT ");
            stringBuilder.Append(string.Join(", ", parameters));
            return this;
        }

        public SqlQueryBuilder From(string tableName)
        {
            stringBuilder.Append($" FROM {tableName}");
            return this;
        }

        public SqlQueryBuilder Where(params string[] whereClauses)
        {
            stringBuilder.Append(" WHERE ");
            stringBuilder.Append(string.Join(" AND ", whereClauses));
            return this;
        }

        public SqlQueryBuilder OrderBy(params string[] fields)
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
    }
}
