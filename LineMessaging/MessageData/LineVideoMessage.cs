using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineVideoMessage : LineMessageObjectBase
    {
        [JsonProperty("type")]
        public override MessageType Type => MessageType.Video;

        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [JsonProperty("previewImageUrl")]
        public string PreviewImageUrl { get; set; }
    }
}
