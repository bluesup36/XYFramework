using System;
using Newtonsoft.Json.Linq;
using System.IO;

namespace XYFramework.Configuration
{
    public class Manager
    {
        static string settingsFilePath;
        static Manager manager = new Manager();
        public static Manager Load(string path)
        {
            settingsFilePath = path;
            return manager;
        }

        public JToken this[string key]
        {
            get
            {
                try
                {
                    var json = File.ReadAllText(settingsFilePath);
                    JObject obj = JObject.Parse(json);
                    return obj[key];
                }
                catch (IOException)
                {
                    throw new IOException("Cannot load config file");
                }
                catch (Exception)
                {
                    throw new Exception("Cannot parse config file, invalid json");
                }
            }
        }
    }
}
