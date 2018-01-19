using System.Runtime.Serialization;

namespace LINE
{
    public class LineTemplateMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Template;

        [DataMember(Name = "altText")]
        public string AltText { get; set; }

        [DataMember(Name = "template")]
        public TemplateObject Template { get; set; }

        public class TemplateObject
        {
        }

        public class ButtonObject : TemplateObject
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
            public ActionObject[] Actions { get; set; }

            public class ActionObject
            {
            }

            public class Postback : ActionObject
            {
                [DataMember(Name = "type")]
                public PostbackActionType Type => PostbackActionType.Postback;
            }

            public class Message
            {
                [DataMember(Name = "type")]
                public PostbackActionType Type => PostbackActionType.Message;
            }

            public class Uri
            {
                [DataMember(Name = "type")]
                public PostbackActionType Type => PostbackActionType.Uri;
            }

            public class Datetimepicker
            {
                [DataMember(Name = "type")]
                public PostbackActionType Type => PostbackActionType.Datetimepicker;
            }
        }
    }
}
