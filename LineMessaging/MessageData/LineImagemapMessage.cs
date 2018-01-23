using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineImagemapMessage : ILineMessage
    {
        [JsonProperty("type")]
        public MessageType Type => MessageType.Imagemap;

        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("altText")]
        public string AltText { get; set; }

        [JsonProperty("baseSize")]
        public LineSizeObject BaseSize { get; set; }

        [JsonProperty("actions")]
        public ActionObjectBase[] Actions { get; set; }

        public abstract class ActionObjectBase
        {
            [JsonProperty("type")]
            public abstract ActionType Type { get; }

            [JsonProperty("area")]
            public LineAreaBoundsObject Area { get; set; }
        }

        public class LinkActionObject : ActionObjectBase
        {
            [JsonProperty("type")]
            public override ActionType Type => ActionType.Uri;

            [JsonProperty("linkUri")]
            public string LinkUri { get; set; }
        }

        public class MessageActionObject : ActionObjectBase
        {
            [JsonProperty("type")]
            public override ActionType Type => ActionType.Message;

            [JsonProperty("text")]
            public string Text { get; set; }
        }
    }
}
