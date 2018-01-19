using System.Runtime.Serialization;

namespace LINE
{
    public abstract class LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public abstract MessageType Type { get; }
    }
}
