using Newtonsoft.Json;
using System.Collections.Generic;

namespace LineMessaging
{
    public class LineReplyMessage
    {
        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }

        [JsonProperty("messages")]
        public IEnumerable<ILineMessage> Messages { get; set; }
    }
}
