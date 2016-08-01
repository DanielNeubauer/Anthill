using Xunit;
using Anthill.Engine.Services.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Core.Test.Models;

namespace Anthill.Engine.Services.QueryBuilder.Tests
{
    public class ModelQueryBuilderTests
    {
        [Fact()]
        public void SelectTest()
        {
            var queryBuilder = new ModelQueryBuilder<User>();

            var result = queryBuilder.Select(u => u.Id, u => u.Name, u => u.InUse).ToQuery();

            Assert.Equal("SELECT Id, Name, Used FROM User", result);
        }

        [Fact()]
        public void SelectWhereBoolTrue()
        {
            var queryBuilder = new ModelQueryBuilder<User>();

            var result = queryBuilder.Select(u => u.Id, u => u.Name, u => u.InUse).Where(u => u.InUse == true).ToQuery();

            Assert.Equal("SELECT Id, Name, Used FROM User WHERE Used = 1", result);
        }

        [Fact()]
        public void SelectWhereGreaterThan()
        {
            var queryBuilder = new ModelQueryBuilder<User>();

            var result = queryBuilder.Select(u => u.Id, u => u.Name, u => u.InUse)
                .Where(u => u.Id >= 0)
                .Where(u => u.Id != 0)
                .Where(u => u.Id <= 0)
                .Where(u => u.Id > 0)
                .Where(u => u.Id < 0)
                .ToQuery();

            Assert.Equal("SELECT Id, Name, Used FROM User WHERE Id >= 0 AND Id <> 0 AND Id <= 0 AND Id > 0 AND Id < 0", result);
        }
    }
}