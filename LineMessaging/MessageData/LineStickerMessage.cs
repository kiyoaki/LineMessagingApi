using System.Runtime.Serialization;

namespace LINE
{
    public class LineStickerMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Sticker;

        [DataMember(Name = "packageId")]
        public string PackageId { get; set; }

        [DataMember(Name = "stickerId")]
        public string StickerId { get; set; }
    }
}
