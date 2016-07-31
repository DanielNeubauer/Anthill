using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IWhere : IToQuery
    {
        IWhere Where(params string[] whereClauses);
        IOrderBy OrderBy(params string[] fields);
    }
}
