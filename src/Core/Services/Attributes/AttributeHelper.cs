using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Anthill.Core.Attributes;

namespace Anthill.Engine.Services.Attributes
{
    public class AttributeHelper
    {
        public ColumnAttribute GetColumnAttribute(PropertyInfo propertyInfo)
        {
            return (ColumnAttribute)propertyInfo.GetCustomAttribute
                (typeof(ColumnAttribute), false);
        }

        public List<ColumnAttribute> GetColumnAttributes(PropertyInfo[] propertyInfos)
        {
            var columnList = new List<ColumnAttribute>();
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
