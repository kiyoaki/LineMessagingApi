using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineTemplateMessage : ILineMessage
    {
        [JsonProperty("type")]
        public MessageType Type => MessageType.Template;

        [JsonProperty("altText")]
        public string AltText { get; set; }

        [JsonProperty("template")]
        public TemplateObject Template { get; set; }

        public class TemplateObject
        {
        }

        public class ButtonObject : TemplateObject
        {
            [JsonProperty("type")]
            public TemplateType Type => TemplateType.Buttons;

            [JsonProperty("thumbnailImageUrl")]
            public string ThumbnailImageUrl { get; set; }

            [JsonProperty("imageAspectRatio")]
            public string ImageAspectRatio { get; set; }

            [JsonProperty("imageSize")]
            public string ImageSize { get; set; }

            [JsonProperty("imageBackgroundColor")]
            public string ImageBackgroundColor { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("actions")]
            public ILineAction[] Actions { get; set; }
        }
    }
}
