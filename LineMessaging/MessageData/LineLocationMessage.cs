using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineLocationMessage : LineMessageObjectBase
    {
        [JsonProperty("type")]
        public override MessageType Type => MessageType.Location;

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
