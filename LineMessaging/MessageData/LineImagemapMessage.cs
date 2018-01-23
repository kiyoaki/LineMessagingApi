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
        public IAction[] Actions { get; set; }

        public interface IAction
        {
            [JsonProperty("type")]
            ActionType Type { get; }

            [JsonProperty("area")]
            LineAreaBounds Area { get; set; }
        }

        public class LinkActionObject : IAction
        {
            [JsonProperty("type")]
            public ActionType Type => ActionType.Uri;

            [JsonProperty("linkUri")]
            public string LinkUri { get; set; }

            [JsonProperty("area")]
            public LineAreaBounds Area { get; set; }
        }

        public class MessageActionObject : IAction
        {
            [JsonProperty("type")]
            public ActionType Type => ActionType.Message;

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("area")]
            public LineAreaBounds Area { get; set; }
        }
    }
}
