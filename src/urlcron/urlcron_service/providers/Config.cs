using System;
using System.IO;
using System.Web.Script.Serialization;

namespace urlcron.service.providers
{
    public class Config
    {
        class ConfigDto {
            public string JobSource { get; set; }
        }


        private readonly ConfigDto data;
        
        public Config() : this("urlcron.config") {}
        public Config(string configfilename) {
            if (!File.Exists(configfilename)) throw new InvalidOperationException($"Missing config file: {configfilename}!");

            var jsonData = File.ReadAllText(configfilename);
            
            var json = new JavaScriptSerializer();
            this.data = json.Deserialize<ConfigDto>(jsonData);
        }

        
        public Uri JobSource => new Uri(this.data.JobSource);
    }
}