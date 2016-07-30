using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Table :Attribute
    {
        public string Name { get; set; }

        private string _connectionString;

    }
}
