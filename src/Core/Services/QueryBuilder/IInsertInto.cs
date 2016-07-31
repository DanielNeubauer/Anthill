using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IInsertInto
    {
        IValues Values(params Tuple<string, object>[] clauses);
        IValues Values(params object[] values);
        IValues Value(string column, object value);
        IValues Value(object value);
    }
}
