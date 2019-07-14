using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace XYFramework.BusinessLogic
{
    public class HttpHelper
    {
        public static async Task<string> CreateTokenAsync()
        {
            string url = @"https://developer.api.autodesk.com/authentication/v1/authenticate";
            var nvc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", "HBHmLL2vNGFECjeytJwfkP5qPiGr9x8K"),
                new KeyValuePair<string, string>("client_secret", "oDqR3A8YpuvGjAgO"),
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("scope", "data:read")
            };
            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(nvc) };
            var res = await client.SendAsync(req);
            var a = res.Content.ReadAsStringAsync();
            return JObject.Parse(a.Result)["access_token"].ToString();
        }
    }
}
