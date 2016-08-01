using Anthill.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Anthill.Engine.Services.QueryBuilder
{
    public class ModelQueryBuilder<TModel> : SqlQueryBuilder
    {
        public ModelQueryBuilder()
        {

        }

        public ModelQueryBuilder<TModel> Where(Expression<Func<TModel, bool>> predicate)
        {
            var body = predicate.Body as BinaryExpression;
            Where($"{GetExpressionValue(body.Left)} {GetOperator(body.NodeType)} {GetExpressionValue(body.Right)}");
            return this;
        }

        public ModelQueryBuilder<TModel> Select(params Expression<Func<TModel, object>>[] columns)
        {
            Select(GetColumns(columns).ToArray()).From(TableName);
            return this;
        }

        private string GetExpressionValue(Expression expression)
        {
            var memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                return (memberExpression.Member as PropertyInfo)?.GetCustomAttribute<ColumnAttribute>()?.Name ?? "";
            }
            var constantExpression = expression as ConstantExpression;
            if (constantExpression != null)
            {
                if (constantExpression.Value.GetType() == typeof(string))
                {
                    return $"'{constantExpression.Value}'";
                }
                if(constantExpression.Value.GetType() == typeof(bool))
                {
                    var value = constantExpression.Value.ToString();
                    return bool.Parse(constantExpression.Value.ToString()) ? "1" : "0";
                }
                return constantExpression.Value.ToString();
            }
            return "";
        }

        private string GetOperator(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.NotEqual:
                    return "<>";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
            }
            return "";
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
