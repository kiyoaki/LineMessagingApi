using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LineMessaging
{
    public class LineOAuthClient
    {
        private static readonly MediaTypeHeaderValue MediaType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
        private const string OAuthAccessTokenApiPath = "/v2/oauth/accessToken";
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = LineConstants.BaseUri,
            Timeout = TimeSpan.FromSeconds(10)
        };

        private readonly string channelId;
        private readonly string channelSecret;

        public LineOAuthClient(string channelId, string channelSecret)
        {
            if (string.IsNullOrEmpty(channelId))
            {
                throw new ArgumentException($"{nameof(channelId)} is null or empty.");
            }
            if (string.IsNullOrEmpty(channelSecret))
            {
                throw new ArgumentException($"{nameof(channelSecret)} is null or empty.");
            }

            this.channelId = channelId;
            this.channelSecret = channelSecret;
        }

        public async Task<LineOAuthAccessTokenResponse> GetAccessToken()
        {
            var body = new LineOAuthAccessTokenRequest
            {
                ClientId = channelId,
                ClientSecret = channelSecret
            };

            using (var message = new HttpRequestMessage(HttpMethod.Post, OAuthAccessTokenApiPath))
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(body));
                message.Content.Headers.ContentType = MediaType;
                try
                {
                    var response = await HttpClient.SendAsync(message);
                    var responseJson = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = JsonConvert.DeserializeObject<LineOAuthErrorResponse>(responseJson);
                        if (error != null)
                        {
                            throw new LineMessagingException(OAuthAccessTokenApiPath, error);
                        }
                        throw new LineMessagingException(OAuthAccessTokenApiPath,
                            $"Error has occurred. Response StatusCode:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
                    }

                    return JsonConvert.DeserializeObject<LineOAuthAccessTokenResponse>(responseJson);
                }
                catch (TaskCanceledException)
                {
                    throw new LineMessagingException(OAuthAccessTokenApiPath, "Request Timeout");
                }
            }
        }
    }
}
