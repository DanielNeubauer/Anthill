using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{

    public interface IWhere : IToQuery
    {
        IOrderBy OrderBy(params string[] fields);
    }
}
