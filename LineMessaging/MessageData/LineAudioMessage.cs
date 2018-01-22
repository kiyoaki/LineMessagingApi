using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineAudioMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Audio;

        [DataMember(Name = "originalContentUrl")]
        public string OriginalContentUrl { get; set; }

        [DataMember(Name = "duration")]
        public long Duration { get; set; }
    }
}
