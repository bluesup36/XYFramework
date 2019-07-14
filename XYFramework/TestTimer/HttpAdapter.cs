using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestTimer
{
    public class HttpAdapter
    {
        public string Post(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent cx = new System.Net.Http.StringContent("");
                return client.PostAsync(url, cx).Result.ToString();
            }
        }
    }
}
