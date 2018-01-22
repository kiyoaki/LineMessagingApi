using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineOAuthAccessTokenRequest
    {
        [JsonProperty("grant_type")]
        public OAuthGrantType GrantType { get; set; } = OAuthGrantType.ClientCredentials;

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}
