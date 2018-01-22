using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineOAuthAccessTokenRequest
    {
        [DataMember(Name = "grant_type")]
        public OAuthGrantType GrantType { get; set; } = OAuthGrantType.ClientCredentials;

        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }
    }
}
