using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineTextMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Text;

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
