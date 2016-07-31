using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface ISet: IToQuery
    {
        ISet Set(string column, object value);
        IWhere Where(params string[] whereClauses);
    }
}
