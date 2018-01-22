using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineImagemapMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Imagemap;

        [DataMember(Name = "baseUrl")]
        public string BaseUrl { get; set; }

        [DataMember(Name = "altText")]
        public string AltText { get; set; }

        [DataMember(Name = "baseSize")]
        public LineSizeObject BaseSize { get; set; }

        [DataMember(Name = "actions")]
        public ActionObjectBase[] Actions { get; set; }

        public abstract class ActionObjectBase
        {
            [DataMember(Name = "type")]
            public abstract ActionType Type { get; }

            [DataMember(Name = "area")]
            public LineAreaBoundsObject Area { get; set; }
        }

        public class LinkActionObject : ActionObjectBase
        {
            [DataMember(Name = "type")]
            public override ActionType Type => ActionType.Uri;

            [DataMember(Name = "linkUri")]
            public string LinkUri { get; set; }
        }

        public class MessageActionObject : ActionObjectBase
        {
            [DataMember(Name = "type")]
            public override ActionType Type => ActionType.Message;

            [DataMember(Name = "text")]
            public string Text { get; set; }
        }
    }
}
