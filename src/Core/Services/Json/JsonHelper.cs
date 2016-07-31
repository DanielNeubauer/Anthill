using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthill.Core.Services.Configuration;
using Newtonsoft.Json;

namespace Anthill.Core.Services.Json
{
    class JsonHelper
    {
        public string SerializeLanguage(ConfigurationModel objToJson)
        {
            var jsonText = JsonConvert.SerializeObject(objToJson);
            return jsonText;
        }


        public void WriteJson(string jsonText, string path)
        {
            var writer = new StreamWriter(path);
            writer.Write(jsonText);
            writer.Close();
        }
        public string ReadJson(string path)
        {
            var reader = new StreamReader(path);

            var text = reader.ReadToEnd();
            reader.Close();
            return text;
        }

        public ConfigurationModel DeSerializeConfiguration(string json)
        {
            return JsonConvert.DeserializeObject<ConfigurationModel>(json);
        }

    }
}
