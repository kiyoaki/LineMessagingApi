using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineStickerMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Sticker;

        [DataMember(Name = "packageId")]
        public string PackageId { get; set; }

        [DataMember(Name = "stickerId")]
        public string StickerId { get; set; }
    }
}
