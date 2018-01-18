using System.Runtime.Serialization;

namespace LINE
{
    public class ImageMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Image;

        [DataMember(Name = "originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [DataMember(Name = "previewImageUrl")]
        public string PreviewImageUrl { get; set; }
    }
}
