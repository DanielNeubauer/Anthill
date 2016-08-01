using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public interface IColumn : IToQuery
    {
        IColumn Column(string columnName, string type, int length = 0);
        IPrimaryKey PrimaryKey(params string[] columnNames);
    }
}
