using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineReplyMessage
    {
        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }

        [JsonProperty("messages")]
        public LineMessageObjectBase[] Messages { get; set; }
    }
}
