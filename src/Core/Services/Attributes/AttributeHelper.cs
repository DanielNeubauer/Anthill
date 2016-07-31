using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Anthill.Engine.Attributes;

namespace Anthill.Engine.Services.Attributes
{
    public class AttributeHelper
    {
        public Column GetColumnAttribute(PropertyInfo propertyInfo)
        {
            return (Column)propertyInfo.GetCustomAttribute
                (typeof(Column), false);
        }

        public List<Column> GetColumnAttributes(PropertyInfo[] propertyInfos)
        {
            var columnList = new List<Column>();
            foreach (var propertyInfo in propertyInfos)
            {
                columnList.Add(GetColumnAttribute(propertyInfo));
            }
            return columnList;
        }

        public object[] GetClassAttributes(Type t)
        {
            return Attribute.GetCustomAttributes(t);
        }

    }
}
