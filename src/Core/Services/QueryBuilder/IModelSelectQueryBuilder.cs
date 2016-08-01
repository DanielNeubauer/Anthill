using System;
using System.Linq.Expressions;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IModelSelectQueryBuilder<TModel>
    {
        IModelSelect<TModel> Select(params Expression<Func<TModel, object>>[] columns);
    }
}