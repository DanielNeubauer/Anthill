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

        public SqlQueryBuilder Select(params string[] parameters)
        {
            stringBuilder.Append("SELECT ");
            stringBuilder.Append(string.Join(",", parameters));
            return this;
        }

        public SqlQueryBuilder From(string tableName)
        {
            stringBuilder.Append(" FROM {tableName}");
            return this;
        }

        public SqlQueryBuilder Where(string[] whereClauses)
        {
            stringBuilder.Append(" WHERE ");
            stringBuilder.Append(string.Join(" AND ", whereClauses));
            return this;
        }

        public SqlQueryBuilder OrderBy(params string[] fields)
        {
            stringBuilder.Append(" ORDER BY ");
            stringBuilder.Append(string.Join(",", fields));
            return this;
        }

        public string ToQuery()
        {
            return stringBuilder.ToString();
        }
    }
}
