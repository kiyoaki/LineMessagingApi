using System.Runtime.Serialization;

namespace LINE
{
    public class LineSizeObject
    {
        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }
    }
}
