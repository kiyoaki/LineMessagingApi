using System.Runtime.Serialization;

namespace LINE
{
    public class TemplateMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Template;

        [DataMember(Name = "altText")]
        public string AltText { get; set; }

        [DataMember(Name = "template")]
        public TemplateMessageContent Template { get; set; }
    }

    public class TemplateMessageContent
    {
    }

    public class TemplateMessageButtons : TemplateMessageContent
    {
        [DataMember(Name = "type")]
        public TemplateType Type => TemplateType.Buttons;

        [DataMember(Name = "thumbnailImageUrl")]
        public string ThumbnailImageUrl { get; set; }

        [DataMember(Name = "imageAspectRatio")]
        public string ImageAspectRatio { get; set; }

        [DataMember(Name = "imageSize")]
        public string ImageSize { get; set; }

        [DataMember(Name = "imageBackgroundColor")]
        public string ImageBackgroundColor { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "actions")]
        public TemplateMessageAction[] Actions { get; set; }
    }

    public class TemplateMessageAction
    {
    }

    public class PostbackAction : TemplateMessageAction
    {
        [DataMember(Name = "type")]
        public PostbackActionType Type => PostbackActionType.Postback;
    }

    public class MessageAction
    {
        [DataMember(Name = "type")]
        public PostbackActionType Type => PostbackActionType.Message;
    }

    public class UriAction
    {
        [DataMember(Name = "type")]
        public PostbackActionType Type => PostbackActionType.Uri;
    }

    public class DatetimepickerAction
    {
        [DataMember(Name = "type")]
        public PostbackActionType Type => PostbackActionType.Datetimepicker;
    }
}
