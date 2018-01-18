using System;
using System.Runtime.Serialization;

namespace LINE
{
    public class OAuthAccessTokenResponse
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "expires_in")]
        public long UnixtimeExpiresIn { get; set; }

        [IgnoreDataMember]
        public DateTime ExpiresIn
        {
            get { return UnixtimeExpiresIn.FromUnixTime(); }
        }

        [DataMember(Name = "token_type")]
        public OAuthTokenType TokenType { get; set; } = OAuthTokenType.Bearer;
    }
}
