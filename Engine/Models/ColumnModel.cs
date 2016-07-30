using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Models
{
    public class ColumnModel
    {
        public TableModel Table;
        public string Name;
        public string Datatype;
        public int length;
        public bool AutoIncrement;
        public bool PrimaryKey;
    }
}
