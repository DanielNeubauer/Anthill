using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface ISelectQueryBuilder
    {
        ISelect Select(params string[] parameters);
    }
}
