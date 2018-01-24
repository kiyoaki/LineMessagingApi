using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LineMessaging
{
    public class LineMulticastMessage
    {
        [JsonProperty("to")]
        public IEnumerable<string> To { get; set; }

        [JsonProperty("messages")]
        public IEnumerable<ILineMessage> Messages { get; set; }
    }
}
