using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IModelSelect<TModel>: IToQuery, IModelOrderBy<TModel>
    {
        IModelWhere<TModel> Where(Expression<Func<TModel, bool>> predicate);
        IModelOrderBy<TModel> OrderBy(params Expression<Func<TModel, object>>[] columns);
    }
}
