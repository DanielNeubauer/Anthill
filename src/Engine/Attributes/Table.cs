using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Table :Attribute
    {
        public Table(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
