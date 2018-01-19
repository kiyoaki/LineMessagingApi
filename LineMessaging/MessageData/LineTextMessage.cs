using System.Runtime.Serialization;

namespace LINE
{
    public class LineTextMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Text;

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
