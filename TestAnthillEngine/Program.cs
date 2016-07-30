using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Anthill.Engine.Attributes;
using Anthill.Engine.Services.Attributes;
using TestAnthillEngine.Tables;

namespace TestAnthillEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new AttributeHelper();
            helper.GetColumnAttributes(typeof(TestTable1).GetProperties());
            var attr = helper.GetDataBaseAttribute(typeof(MyDatabase));
            if (attr[0].GetType() == typeof(Database))
                Console.WriteLine("Yeeah it is an database."); 
            else 
                Console.WriteLine("Oh maaaan! :(");
            Console.ReadKey();
        }
    }
}
