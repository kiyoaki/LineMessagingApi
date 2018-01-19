using System.Runtime.Serialization;

namespace LINE
{
    public class LineOAuthRevokeRequest
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
    }
}
