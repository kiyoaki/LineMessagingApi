using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LinePushMessage
    {
        [DataMember(Name = "to")]
        public string To { get; set; }

        [DataMember(Name = "messages")]
        public LineMessageObjectBase[] Messages { get; set; }
    }
}
