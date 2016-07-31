using System;
using System.Linq;
using Anthill.Core.Services.Configuration;
using Xunit;

namespace Anthill.Core.Test.Services.Configuration
{
    public class TestConfigurationManager
    {
        [Theory]
        [InlineData(@"C:\Users\Admin\Documents\Anthill\src\Core\ContentFiles\config.json")]
        public void TestGetConfiguration(string path)
        {
            var configuratinManager = new ConfigurationManager();
            var config = configuratinManager.GetConfiguration(path);
            Assert.NotNull(config);
            Assert.NotNull(config.ConnectionString);
        }
    }
}
