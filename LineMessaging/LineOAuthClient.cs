using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LineMessaging
{
    public class LineOAuthClient
    {
        private const string OAuthAccessTokenApiPath = "/v2/oauth/accessToken";
        private const string OAuthRevokeTokenApiPath = "/v2/oauth/revoke";
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
            using (var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", channelId },
                { "client_secret", channelSecret }
            }))
            {
                try
                {
                    var response = await HttpClient.PostAsync(OAuthAccessTokenApiPath, content);
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

        public async Task RevokeAccessToken(string accessToken)
        {
            using (var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "access_token", accessToken }
            }))
            {
                try
                {
                    var response = await HttpClient.PostAsync(OAuthRevokeTokenApiPath, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<LineOAuthErrorResponse>(responseJson);
                        if (error != null)
                        {
                            throw new LineMessagingException(OAuthAccessTokenApiPath, error);
                        }
                        throw new LineMessagingException(OAuthAccessTokenApiPath,
                            $"Error has occurred. Response StatusCode:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
                    }
                }
                catch (TaskCanceledException)
                {
                    throw new LineMessagingException(OAuthAccessTokenApiPath, "Request Timeout");
                }
            }
        }
    }
}
