using System.Runtime.Serialization;

namespace LINE
{
    public class LineMulticastMessage
    {
        [DataMember(Name = "to")]
        public string[] To { get; set; }

        [DataMember(Name = "messages")]
        public LineMessageObjectBase[] Messages { get; set; }
    }
}
