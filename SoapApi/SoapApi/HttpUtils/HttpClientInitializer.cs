using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.UI;

namespace SoapApi.HttpUtils
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