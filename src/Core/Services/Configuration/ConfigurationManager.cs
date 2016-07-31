using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Core.Services.Json;

namespace Anthill.Core.Services.Configuration
{
    public class ConfigurationManager
    {
        private JsonHelper _jsonHelper = new JsonHelper();
        public ConfigurationModel GetConfiguration(string path)
        {
            var jsonText = _jsonHelper.ReadJson(path);
            return _jsonHelper.DeSerializeConfiguration(jsonText);
        }
    }
}
