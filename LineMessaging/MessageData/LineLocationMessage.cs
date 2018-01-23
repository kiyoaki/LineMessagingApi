using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineLocationMessage : ILineMessage
    {
        [JsonProperty("type")]
        public MessageType Type => MessageType.Location;

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
