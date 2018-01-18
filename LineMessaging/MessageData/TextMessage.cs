using System.Runtime.Serialization;

namespace LINE
{
    public class TextMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Text;

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
