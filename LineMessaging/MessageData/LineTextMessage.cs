using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineTextMessage : LineMessageObjectBase
    {
        [JsonProperty("type")]
        public override MessageType Type => MessageType.Text;

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
