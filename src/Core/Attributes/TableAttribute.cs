using System;

namespace Anthill.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute()
        {

        }
        public TableAttribute(string name):this()
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
