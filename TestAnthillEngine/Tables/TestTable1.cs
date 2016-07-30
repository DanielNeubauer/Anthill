using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Engine.Attributes;

namespace TestAnthillEngine.Tables
{
    [Table(Name ="TestTable")]
    public class TestTable1
    {
        [Column(PrimaryKey = true, AutoIncrement = true, Datatype = "INTEGER",  Name = "Id")]
        public int Id { get; set; }
        [Column( Datatype = "NVARCHAR", Length = 250, Name = "Name")]
        public string Name { get; set; }
        [Column(Datatype = "BOOLEAN", Length = 250, Name = "Used")]
        public bool InUse { get; set; }
    }
}
