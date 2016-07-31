using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IValues : IToQuery
    {
        IValues Value(object value);
        IValues Value(string column, object value);
    }
}
