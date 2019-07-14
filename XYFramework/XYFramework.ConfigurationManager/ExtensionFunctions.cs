using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace XYFramework.Configuration
{
    public static class ExtensionFunctions
    {
        public static List<string> ToList(this JToken jToken)
        {
            return jToken.ToObject<List<string>>();
        }
    }
}
