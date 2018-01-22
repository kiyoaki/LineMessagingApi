using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineImageMessage : LineMessageObjectBase
    {
        [JsonProperty("type")]
        public override MessageType Type => MessageType.Image;

        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [JsonProperty("previewImageUrl")]
        public string PreviewImageUrl { get; set; }
    }
}
