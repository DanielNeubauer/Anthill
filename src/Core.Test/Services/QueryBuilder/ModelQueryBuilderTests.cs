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
    }
}