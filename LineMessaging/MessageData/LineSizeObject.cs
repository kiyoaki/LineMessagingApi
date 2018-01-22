using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineSizeObject
    {
        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }
    }
}
