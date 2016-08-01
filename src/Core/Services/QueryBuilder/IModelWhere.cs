using System;
using System.Linq.Expressions;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IModelWhere<TModel> : IModelOrderBy<TModel>, IToQuery
    {
        IModelWhere<TModel> Where(Expression<Func<TModel, bool>> predicate);
        IModelOrderBy<TModel> OrderBy(params Expression<Func<TModel, object>>[] columns);
    }
}