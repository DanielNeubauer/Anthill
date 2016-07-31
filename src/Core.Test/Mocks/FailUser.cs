
using Anthill.Core.Attributes;

namespace Anthill.Engine.Test.Mocks
{
    [Table]
    public class FailUser
    {
        [Column("", PrimaryKey = true, AutoIncrement = true, Datatype = "INTEGER")]
        public int Id { get; set; }
    }
}
