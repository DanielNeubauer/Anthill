using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Engine.Services.Json;

namespace Anthill.Engine.Services.Configuration
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
