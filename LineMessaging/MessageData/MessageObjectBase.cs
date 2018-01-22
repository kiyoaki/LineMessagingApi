using Newtonsoft.Json;

namespace LineMessaging
{
    public abstract class LineMessageObjectBase
    {
        [JsonProperty("type")]
        public abstract MessageType Type { get; }
    }
}
