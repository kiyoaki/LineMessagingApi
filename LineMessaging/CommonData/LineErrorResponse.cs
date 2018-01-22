using System.Linq;
using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineErrorResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("details")]
        public DetailObject[] Details { get; set; }

        public class DetailObject
        {
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("property")]
            public string Property { get; set; }
        }

        public override string ToString()
        {
            if (Details != null && Details.Any())
            {
                var details = string.Join(", ", Details.Select(x => $"Property {x.Property} {x.Message}"));
                return $"{Message}. details: {details}";
            }

            return Message;
        }
    }
}
