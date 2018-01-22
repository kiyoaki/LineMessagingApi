using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineImageMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Image;

        [DataMember(Name = "originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [DataMember(Name = "previewImageUrl")]
        public string PreviewImageUrl { get; set; }
    }
}
