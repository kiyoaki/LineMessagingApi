using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineImageMessage : ILineMessage
    {
        [JsonProperty("type")]
        public MessageType Type => MessageType.Image;

        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [JsonProperty("previewImageUrl")]
        public string PreviewImageUrl { get; set; }
    }
}
