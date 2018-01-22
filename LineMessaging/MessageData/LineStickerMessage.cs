using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineStickerMessage : LineMessageObjectBase
    {
        [JsonProperty("type")]
        public override MessageType Type => MessageType.Sticker;

        [JsonProperty("packageId")]
        public string PackageId { get; set; }

        [JsonProperty("stickerId")]
        public string StickerId { get; set; }
    }
}
