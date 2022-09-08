using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpUtils
{
    public static class HttpClientInitializer
    {
        public static HttpClient HttpClient { get; set; }

        public static HttpClient GetClient(string baseAddress, string mediaType)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(baseAddress);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            return HttpClient;
        }
    }
}
