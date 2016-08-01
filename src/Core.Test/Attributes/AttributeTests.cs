using Xunit;
using Anthill.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Core.Test.Models;
using Anthill.Engine.Extensions;
using Anthill.Engine.Test.Mocks;

namespace Anthill.Core.Attributes.Tests
{
    public class AttributeTests
    {
        [Theory]
        [InlineData(typeof(User), "User")]
        public void TestTableAttributeName(Type type, string value)
        {
            var tableAttribute = type.GetCustomAttribute<TableAttribute>();
            Assert.NotNull(tableAttribute);
            Assert.Equal(value, tableAttribute.Name);
        }

        [Fact]
        public void TestTableAttributeNameEmpty()
        {
            var tableAttribute = typeof(FailUser).GetCustomAttribute<TableAttribute>();
            Assert.NotNull(tableAttribute);
            Assert.Null(tableAttribute.Name);
        }

        [Theory]
        [InlineData(typeof(User), "Id", "Id")]
        [InlineData(typeof(User), "Name", "Name")]
        [InlineData(typeof(User), "InUse", "Used")]
        public void TestColumnAttributeName(Type type, string propertyName, string value)
        {
            var property = type.GetProperty(propertyName);
            Assert.NotNull(property);
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            Assert.Equal(value, columnAttribute.Name);
        }

        [Fact]
        public void TestColumnAttributeNameEmptyInId()
        {
            var property = typeof(FailUser).GetProperties().First(prop => prop.Name == "Id");
            Assert.NotNull(property);
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            Assert.Equal("", columnAttribute.Name);
        }
    }
}