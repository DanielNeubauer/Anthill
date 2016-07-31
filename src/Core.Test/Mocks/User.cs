using Anthill.Core.Attributes;

namespace Anthill.Core.Test.Models
{
    [Table("User")]
    public class User
    {
        [Column("Id",PrimaryKey = true, AutoIncrement = true, Datatype = "INTEGER")]
        public int Id { get; set; }
        [Column("Name", Datatype = "NVARCHAR", Length = 250)]
        public string Name { get; set; }
        [Column("Used", Datatype = "BOOLEAN")]
        public bool InUse { get; set; }
    }

}
