using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace LineMessaging
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "file")]
        File,

        [EnumMember(Value = "location")]
        Location,

        [EnumMember(Value = "sticker")]
        Sticker,

        [EnumMember(Value = "imagemap")]
        Imagemap,

        [EnumMember(Value = "template")]
        Template
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TemplateType
    {
        [EnumMember(Value = "buttons")]
        Buttons,

        [EnumMember(Value = "confirm")]
        Confirm,

        [EnumMember(Value = "carousel")]
        Carousel,

        [EnumMember(Value = "image_carousel")]
        ImageCarousel,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionType
    {
        [EnumMember(Value = "postback")]
        Postback,

        [EnumMember(Value = "message")]
        Message,

        [EnumMember(Value = "uri")]
        Uri,

        [EnumMember(Value = "datetimepicker")]
        Datetimepicker
    }
}
