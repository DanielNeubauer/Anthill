using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Engine.Enum;

namespace Anthill.Engine.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Database : Attribute
    {
        public DatabaseType DatabaseType { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
