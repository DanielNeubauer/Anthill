using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Engine.Attributes;
using TestAnthillEngine.Tables;

namespace TestAnthillEngine
{
    [Database(DatabaseType = Anthill.Engine.Enum.DatabaseType.Microsoft, ConnectionString = "TestConnectionString", Name ="MyDatabase")]
    public class MyDatabase
    {
        public TestTable1 table1 { get; set; }
    }
}
