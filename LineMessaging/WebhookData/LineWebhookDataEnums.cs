using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace LineMessaging
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebhookRequestEventType
    {
        [EnumMember(Value = "message")]
        Message,

        [EnumMember(Value = "follow")]
        Follow,

        [EnumMember(Value = "unfollow")]
        Unfollow,

        [EnumMember(Value = "join")]
        Join,

        [EnumMember(Value = "leave")]
        Leave,

        [EnumMember(Value = "postback")]
        Postback,

        [EnumMember(Value = "beacon")]
        Beacon
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebhookRequestSourceType
    {
        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "group")]
        Group,

        [EnumMember(Value = "room")]
        Room
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebhookRequestBeaconType
    {
        [EnumMember(Value = "enter")]
        Enter,

        [EnumMember(Value = "leave")]
        Leave,

        [EnumMember(Value = "banner")]
        Banner
    }
}
