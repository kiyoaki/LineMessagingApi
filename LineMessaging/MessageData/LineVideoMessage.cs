using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineVideoMessage : ILineMessage
    {
        [JsonProperty("type")]
        public MessageType Type => MessageType.Video;

        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [JsonProperty("previewImageUrl")]
        public string PreviewImageUrl { get; set; }
    }
}
