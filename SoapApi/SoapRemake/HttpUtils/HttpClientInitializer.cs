using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SoapRemake.HttpUtils
{
    public static class HttpClientInitializer
    {
        public static HttpClient HttpClient { get; set; }

        public static HttpClient GetHttpClient(string baseAddress, string mediaType)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(baseAddress);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            return HttpClient;
        }
    }
}