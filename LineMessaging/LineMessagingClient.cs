using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LINE
{
    public class LineMessagingClient
    {
        private static readonly MediaTypeHeaderValue MediaType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = LineConstants.BaseUri,
            Timeout = TimeSpan.FromSeconds(10)
        };

        private readonly string accessToken;

        public LineMessagingClient(string accessToken)
        {
            this.accessToken = accessToken;
        }


    }
}
