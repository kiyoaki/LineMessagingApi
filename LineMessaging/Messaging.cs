using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LINE
{
    public class Messaging
    {
        private static readonly MediaTypeHeaderValue MediaType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = LineConstants.BaseUri,
            Timeout = TimeSpan.FromSeconds(10)
        };

        private readonly string _apiKey;
        private readonly byte[] _apiSecret;

        public Messaging(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = Encoding.UTF8.GetBytes(apiSecret);
        }
    }
}
