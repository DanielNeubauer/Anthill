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

        [Fact]
        public void TestFullInsert()
        {
            var queryBuilder = new SqlQueryBuilder();

            var query = queryBuilder
                .InsertInto("User")
                .Values(new[]{
                    new System.Tuple<string, object>("Name","hamster"),
                    new System.Tuple<string, object>("InUse",true),
                })
                .ToQuery();

            Assert.Equal("INSERT INTO User (Name, InUse) VALUES (hamster, True)", query);
        }
    }
}
