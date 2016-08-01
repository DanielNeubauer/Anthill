using Anthill.Core.Attributes;
using Anthill.Core.Test.Models;
using System;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

namespace Anthill.Engine.Services.QueryBuilder.Tests
{
    public class SqlStructureBuilderTests
    {
        [Fact()]
        public void CreateTableTest()
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

        [Fact()]
        public void DropTableTest()
        {
            var builder = new SqlStructureBuilder() as IDropStatementBuilder;
            var result = builder
                .DropTable("User")
                .ToQuery();
            Assert.Equal("DROP TABLE User;", result);
        }
    }
}