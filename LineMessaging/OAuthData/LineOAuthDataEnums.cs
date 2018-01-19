using System.Runtime.Serialization;

namespace LINE
{
    public enum OAuthGrantType
    {
        [EnumMember(Value = "client_credentials")]
        ClientCredentials
    }

    public enum OAuthTokenType
    {
        [EnumMember(Value = "Bearer")]
        Bearer
    }
}