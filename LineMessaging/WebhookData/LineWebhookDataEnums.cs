using System.Runtime.Serialization;

namespace LineMessaging
{
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

    public enum WebhookRequestSourceType
    {
        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "group")]
        Group,

        [EnumMember(Value = "room")]
        Room
    }

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
