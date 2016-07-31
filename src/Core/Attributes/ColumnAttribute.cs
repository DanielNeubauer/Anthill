using System;

namespace Anthill.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public bool AutoIncrement { get; set; }
        public bool PrimaryKey { get; set; }
        public string Datatype { get; set; }
        public int Length { get; set; }
    }
}
