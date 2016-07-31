using Anthill.Engine.Services;
using Xunit;

namespace Anthill.Core.Test
{
    public class SqlQueryBuilderTests
    {
        [Fact]
        public void TestFullSelect()
        {
            var queryBuilder = new SqlQueryBuilder();

            var query = queryBuilder
                .Select("Id", "Name", "InUse")
                .From("User")
                .Where("Name = 'hamster'")
                .ToQuery();

            Assert.Equal("SELECT Id, Name, InUse FROM User WHERE Name = 'hamster'", query);
        }
    }
}
