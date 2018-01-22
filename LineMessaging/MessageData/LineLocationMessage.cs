using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineLocationMessage : LineMessageObjectBase
    {
        [DataMember(Name = "type")]
        public override MessageType Type => MessageType.Location;

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
