using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LineMessaging
{
    public class LineMulticastMessage
    {
        [JsonProperty("to")]
        public IList<string> To { get; set; }

        [JsonProperty("messages")]
        public IList<ILineMessage> Messages { get; set; }
    }
}
