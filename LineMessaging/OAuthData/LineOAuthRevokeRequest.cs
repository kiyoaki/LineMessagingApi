using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineOAuthRevokeRequest
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
    }
}
