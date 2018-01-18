using System.Runtime.Serialization;

namespace LINE
{
    public class OAuthRevokeRequest
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
    }
}
