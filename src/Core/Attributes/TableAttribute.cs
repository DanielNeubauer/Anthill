using System;

namespace Anthill.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute :Attribute
    {
        public TableAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
