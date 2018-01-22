using Newtonsoft.Json;
using System;

namespace LineMessaging
{
    public class LineOAuthAccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long UnixtimeExpiresIn { get; set; }

        [JsonIgnore]
        public DateTime ExpiresIn
        {
            get { return UnixtimeExpiresIn.FromUnixTime(); }
        }

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "Bearer";
    }
}
