using Anthill.Engine.Attributes;

namespace Anthill.Engine.Test.Mocks
{
    [Table(Name = "User")]
    public class User
    {
        [Column(PrimaryKey = true, AutoIncrement = true, Datatype = "INTEGER", Name = "Id")]
        public int Id { get; set; }
        [Column(Datatype = "NVARCHAR", Length = 250, Name = "Name")]
        public string Name { get; set; }
        [Column(Datatype = "BOOLEAN", Length = 250, Name = "Used")]
        public bool InUse { get; set; }
    }
}