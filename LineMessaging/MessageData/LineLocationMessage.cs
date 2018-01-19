using System.Runtime.Serialization;

namespace LINE
{
    public class LineLocationMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Location;

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
    }
}
