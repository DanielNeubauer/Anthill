using System;
using System.Collections.Generic;
using System.Reflection;

namespace Anthill.Engine.Extensions
{
    public static class AttributeExtensions
    {
        public static IEnumerable<TCustomAttribute> GetCostumAttributes<TCustomAttribute>(this Type type) where TCustomAttribute: Attribute
        {
            var propertyList = new List<TCustomAttribute>();
            foreach(var propertyInfo in type.GetProperties())
            {
                var customAttribute = propertyInfo.GetCustomAttribute<TCustomAttribute>(true);
                if(customAttribute != null)
                {
                    propertyList.Add(customAttribute);
                }
            }
            return propertyList;
        }

        public static TCustomAttribute GetCustomAttribute<TCustomAttribute>(this MemberInfo m) where TCustomAttribute: Attribute
        {
            return m.GetCustomAttribute<TCustomAttribute>(true);
        }
    }
}
