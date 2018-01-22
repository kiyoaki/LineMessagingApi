using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace LineMessaging
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OAuthGrantType
    {
        [EnumMember(Value = "client_credentials")]
        ClientCredentials
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OAuthTokenType
    {
        [EnumMember(Value = "Bearer")]
        Bearer
    }
}