using System.Runtime.Serialization;

namespace LineMessaging
{
    public abstract class LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public abstract MessageType Type { get; }
    }
}
