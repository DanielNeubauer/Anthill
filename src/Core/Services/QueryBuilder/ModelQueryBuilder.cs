using Anthill.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public class ModelQueryBuilder<TModel>
    {
        private SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

        public ModelQueryBuilder()
        {

        }

        public ModelQueryBuilder<TModel> Select(params Expression<Func<TModel, object>>[] columns)
        {
            queryBuilder.Select(GetColumns(columns).ToArray()).From(TableName);
            return this;
        }

        public string ToQuery()
        {
            return queryBuilder.ToQuery();
        }

        private IEnumerable<string> GetColumns<TResult>(Expression<Func<TModel, TResult>>[] columns)
        {
            return columns.Select(column => GetColumnName(column)).Where(column => !string.IsNullOrEmpty(column));
        }

        private string GetColumnName<TResult>(Expression<Func<TModel, TResult>> columnExpression)
        {
            MemberExpression body = columnExpression.Body as MemberExpression;
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)columnExpression.Body;
                body = ubody.Operand as MemberExpression;
            }
            var propertyInfo = body.Member as PropertyInfo;
            return propertyInfo?.GetCustomAttribute<ColumnAttribute>()?.Name ?? "";
        }

        private string TableName { get; } = typeof(TModel).GetCustomAttribute<TableAttribute>().Name;
    }
}
