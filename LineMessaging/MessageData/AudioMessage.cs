using System.Runtime.Serialization;

namespace LINE
{
    public class AudioMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Audio;

        [DataMember(Name = "originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [DataMember(Name = "duration")]
        public long Duration { get; set; }
    }
}
