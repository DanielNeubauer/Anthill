using Anthill.Engine.Services.QueryBuilder;
using Xunit;

namespace Anthill.Core.Test
{
    public class SqlQueryBuilderTests
    {
        [Fact]
        public void TestSelectSingleWhere()
        {
            var queryBuilder = new SqlQueryBuilder() as ISelectQueryBuilder;

            var query = queryBuilder
                .Select("Id", "Name", "InUse")
                .From("User")
                .Where("Name = 'hamster'")
                .ToQuery();

            Assert.Equal("SELECT Id, Name, InUse FROM User WHERE Name = 'hamster'", query);
        }

        [Fact]
        public void TestSelectMultipleWhere()
        {
            var queryBuilder = new SqlQueryBuilder() as ISelectQueryBuilder;

            var query = queryBuilder
                .Select("Id", "Name", "InUse")
                .From("User")
                .Where("Name = 'hamster'")
                .Where("Id = 1")
                .ToQuery();

            Assert.Equal("SELECT Id, Name, InUse FROM User WHERE Name = 'hamster' AND Id = 1", query);
        }

        [Fact]
        public void TestSelectMultipleWhereParams()
        {
            var queryBuilder = new SqlQueryBuilder() as ISelectQueryBuilder;

            var query = queryBuilder
                .Select("Id", "Name", "InUse")
                .From("User")
                .Where("Name = 'hamster'", "Id = 1")
                .ToQuery();

            Assert.Equal("SELECT Id, Name, InUse FROM User WHERE Name = 'hamster' AND Id = 1", query);
        }

        [Fact]
        public void TestFullInsert()
        {
            var queryBuilder = new SqlQueryBuilder() as IInsertStatementBuilder;

            var query = queryBuilder
                .InsertInto("User")
                .Values(new[]{
                    new System.Tuple<string, object>("Name","hamster"),
                    new System.Tuple<string, object>("InUse",true),
                })
                .ToQuery();

            Assert.Equal("INSERT INTO User (Name, InUse) VALUES ('hamster', true)", query);
        }

        [Fact]
        public void TestInsertMultipleValues()
        {
            var queryBuilder = new SqlQueryBuilder() as IInsertStatementBuilder;

            var query = queryBuilder
                .InsertInto("User")
                .Value("Name","hamster")
                .Value("InUse",true)
                .ToQuery();

            Assert.Equal("INSERT INTO User (Name, InUse) VALUES ('hamster', true)", query);
        }

        [Fact]
        public void TestInsert()
        {
            var queryBuilder = new SqlQueryBuilder() as IInsertStatementBuilder;

            var query = queryBuilder
                .InsertInto("User")
                .Values("hamster",true)
                .ToQuery();

            Assert.Equal("INSERT INTO User VALUES ('hamster', true)", query);
        }

        [Fact]
        public void TestUpdate()
        {
            var queryBuilder = new SqlQueryBuilder() as IUpdateStatementBuilder;

            var query = queryBuilder
                .Update("User")
                .Set(new[]{
                    new System.Tuple<string, object>("Name","hamster1"),
                    new System.Tuple<string, object>("InUse",true),
                })
                .Where("Name = 'hamster'")
                .ToQuery();

            Assert.Equal("UPDATE User SET Name='hamster1', InUse=true WHERE Name = 'hamster'", query);
        }

        [Fact]
        public void TestUpdateMultipleSet()
        {
            var queryBuilder = new SqlQueryBuilder() as IUpdateStatementBuilder;

            var query = queryBuilder
                .Update("User")
                .Set("Name","hamster1")
                .Set("InUse",true)
                .Where("Name = 'hamster'")
                .ToQuery();

            Assert.Equal("UPDATE User SET Name='hamster1', InUse=true WHERE Name = 'hamster'", query);
        }
    }
}
