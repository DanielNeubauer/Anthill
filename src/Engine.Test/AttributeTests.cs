using System;
using System.Linq;
using Xunit;
using Anthill.Engine.Test.Mocks;
using Anthill.Engine.Attributes;
using System.Reflection;

namespace Anthill.Engine.Test
{
    public class AttributeTests
    {
        [Theory]
        [InlineData(typeof(User),"User")]
        public void TestTableAttributeName(Type type, string value)
        {
            var tableAttribute = type.GetCustomAttribute<Table>();
            Assert.NotNull(tableAttribute);
            Assert.Equal(value, tableAttribute.Name);
        }

        [Fact]
        public void TestTableAttributeNameEmpty()
        {
            var tableAttribute = typeof(FailUser).GetCustomAttribute<Table>();
            Assert.NotNull(tableAttribute);
            Assert.Equal("", tableAttribute.Name);
        }

        [Theory]
        [InlineData(typeof(User), "Id","Id")]
        [InlineData(typeof(User), "Name", "Name")]
        [InlineData(typeof(User), "InUse", "Used")]
        public void TestColumnAttributeName(Type type, string propertyName, string value)
        {
            var property = type.GetProperty(propertyName);
            Assert.NotNull(property);
            var columnAttribute = property.GetCustomAttribute<Column>();
            Assert.Equal(value, columnAttribute.Name);
        }

        [Fact]
        public void TestColumnAttributeNameEmptyInId()
        {
            var property = typeof(FailUser).GetProperties().First(prop => prop.Name == "Id");
            Assert.NotNull(property);
            var columnAttribute = property.GetCustomAttribute<Column>();
            Assert.Equal("", columnAttribute.Name);
        }
    }
}
