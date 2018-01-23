using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineStickerMessage : ILineMessage
    {
        [JsonProperty("type")]
        public MessageType Type => MessageType.Sticker;

        [JsonProperty("packageId")]
        public string PackageId { get; set; }

        [JsonProperty("stickerId")]
        public string StickerId { get; set; }
    }
}
