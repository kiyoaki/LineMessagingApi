using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LineMessaging
{
    public partial class LineMessagingClient
    {
        private static readonly MediaTypeHeaderValue MediaTypeJson = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
        private static readonly MediaTypeHeaderValue MediaTypeJpeg = MediaTypeHeaderValue.Parse("image/jpeg");
        private static readonly MediaTypeHeaderValue MediaTypePng = MediaTypeHeaderValue.Parse("image/png");
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = LineConstants.BaseUri,
            Timeout = TimeSpan.FromSeconds(10)
        };
        private static readonly HttpClient HttpDataClient = new HttpClient
        {
            BaseAddress = LineConstants.BaseDataUri,
            Timeout = TimeSpan.FromSeconds(10)
        };

        private readonly AuthenticationHeaderValue accessTokenHeaderValue;

        public LineMessagingClient(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentException($"{nameof(accessToken)} is null or empty.");
            }

            accessTokenHeaderValue = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        private async Task<T> Get<T>(string path, Dictionary<string, object> query = null)
        {
            return await SendRequest<T>(HttpMethod.Get, path, query);
        }

        private async Task<T> Post<T>(string path, object body)
        {
            return await SendRequest<T>(HttpMethod.Post, path, null, body);
        }

        private async Task Post(string path, object body = null)
        {
            await SendRequest(HttpMethod.Post, path, null, body);
        }

        private async Task PostJpeg(string path, byte[] image)
        {
            await PostImage(path, "jpeg", image);
        }

        private async Task PostPng(string path, byte[] image)
        {
            await PostImage(path, "png", image);
        }

        private async Task Delete(string path)
        {
            await SendRequest(HttpMethod.Delete, path);
        }

        private async Task<byte[]> GetAsByteArray(string path)
        {
            using (var message = new HttpRequestMessage(HttpMethod.Get, path))
            {
                message.Headers.Authorization = accessTokenHeaderValue;
                HttpResponseMessage response;
                try
                {
                    response = await HttpDataClient.SendAsync(message);
                }
                catch (TaskCanceledException)
                {
                    throw new LineMessagingException(path, "Request Timeout");
                }

                await CheckStatusCode(path, response);
                return await response.Content.ReadAsByteArrayAsync();
            }
        }

        private async Task<T> SendRequest<T>(HttpMethod method, string path,
            Dictionary<string, object> query = null, object body = null)
        {
            var responseJson = await SendRequest(method, path, query, body);
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        private async Task PostImage(string path, string imageFormat, byte[] image)
        {
            using (var message = new HttpRequestMessage(HttpMethod.Post, path))
            {
                message.Content = new ByteArrayContent(image);
                switch (imageFormat)
                {
                    case "jpeg":
                        message.Content.Headers.ContentType = MediaTypeJpeg;
                        break;

                    case "png":
                        message.Content.Headers.ContentType = MediaTypePng;
                        break;

                    default:
                        throw new LineMessagingException(path, $"{imageFormat} is not supported.");
                }
                message.Headers.Authorization = accessTokenHeaderValue;

                HttpResponseMessage response;
                try
                {
                    response = await HttpClient.SendAsync(message);
                }
                catch (TaskCanceledException)
                {
                    throw new LineMessagingException(path, "Request Timeout");
                }
            }
        }

        private async Task<string> SendRequest(HttpMethod method, string path,
            Dictionary<string, object> query = null, object body = null)
        {
            string queryString = null;
            if (query != null)
            {
                queryString = query.ToQueryString();
            }

            using (var message = new HttpRequestMessage(method, path + queryString))
            {
                if (body != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(body));
                    message.Content.Headers.ContentType = MediaTypeJson;
                }
                message.Headers.Authorization = accessTokenHeaderValue;

                HttpResponseMessage response;
                try
                {
                    response = await HttpClient.SendAsync(message);
                }
                catch (TaskCanceledException)
                {
                    throw new LineMessagingException(path, "Request Timeout");
                }

                await CheckStatusCode(path, response);
                return await response.Content.ReadAsStringAsync();
            }
        }

        private static async Task CheckStatusCode(string path, HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<LineErrorResponse>(responseJson);
                if (error != null)
                {
                    throw new LineMessagingException(path, error);
                }
                throw new LineMessagingException(path,
                    $"Error has occurred. Response StatusCode:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
            }
        }
    }
}
