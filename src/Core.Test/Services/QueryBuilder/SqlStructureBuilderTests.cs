using Xunit;

namespace Anthill.Engine.Services.QueryBuilder.Tests
{
    public class SqlStructureBuilderTests
    {
        [Fact()]
        public void SqlStructureBuilderTest()
        {
            var builder = new SqlStructureBuilder() as ICreateStatementBuilder;

            var result = builder
                .CreateTable("User")
                .Column("Id", "INT")
                .Column("Name", "VARCHAR", 40)
                .PrimaryKey("Id")
                .ToQuery();
            Assert.Equal("CREATE TABLE User(Id INT, Name VARCHAR(40), PRIMARY KEY (Id));", result);
        }
    }
}