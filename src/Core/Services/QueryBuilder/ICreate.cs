using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface ICreate
    {
        IColumn Column(string columnName, string type, int length = 0);
    }
}
