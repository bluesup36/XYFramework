using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XYFramework.HttpRequest
{
    public class HttpProvider
    {
        private static HttpClient Client = new HttpClient();
        public static async Task Get(string url)
        {
            Console.WriteLine("Starting connections");
            var data = await Client.GetByteArrayAsync(url);
            var ret = Encoding.UTF8.GetString(data);
            Console.WriteLine(ret);
            Console.WriteLine("Connections done");
            Console.ReadLine();
        }

        public static async Task Post(string url, string content)
        {
            Console.WriteLine("Starting connections");
            Uri uri = new Uri(url);
            HttpContent httpContent = new StringContent(content);
            var result = await Client.PostAsync(uri, httpContent);
            Console.WriteLine(result.StatusCode);
            Console.WriteLine("Connections done");
            Console.ReadLine();
        }
    }
}
