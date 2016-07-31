using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Core.Models
{
    public class TableModel
    {
        public DatabaseModel Database;
        public List<ColumnModel> Columns;
        public string Name;
    }
}
