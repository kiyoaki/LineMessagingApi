using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineAudioMessage : ILineMessage
    {
        [JsonProperty("type")]
        public MessageType Type => MessageType.Audio;

        [JsonProperty("originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }
    }
}
