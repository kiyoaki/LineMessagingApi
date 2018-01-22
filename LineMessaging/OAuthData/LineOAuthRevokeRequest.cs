using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineOAuthRevokeRequest
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
