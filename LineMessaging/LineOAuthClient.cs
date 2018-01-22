using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Utf8Json;

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
                byte[] bodyBytes = null;
                bodyBytes = JsonSerializer.Serialize(body);
                message.Content = new ByteArrayContent(bodyBytes);
                message.Content.Headers.ContentType = MediaType;

                try
                {
                    var response = await HttpClient.SendAsync(message);
                    var responseJson = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = JsonSerializer.Deserialize<LineOAuthErrorResponse>(responseJson);
                        if (error != null)
                        {
                            throw new LineMessagingException(OAuthAccessTokenApiPath, error);
                        }
                        throw new LineMessagingException(OAuthAccessTokenApiPath,
                            $"Error has occurred. Response StatusCode:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
                    }

                    return JsonSerializer.Deserialize<LineOAuthAccessTokenResponse>(responseJson);
                }
                catch (TaskCanceledException)
                {
                    throw new LineMessagingException(OAuthAccessTokenApiPath, "Request Timeout");
                }
            }
        }
    }
}
