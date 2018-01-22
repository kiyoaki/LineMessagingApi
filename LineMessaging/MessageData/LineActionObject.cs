using Newtonsoft.Json;

namespace LineMessaging
{
    public abstract class LineActionObjectBase
    {
        [JsonProperty("type")]
        public abstract ActionType Type { get; }
    }

    public class PostbackAction : LineActionObjectBase
    {
        [JsonProperty("type")]
        public override ActionType Type => ActionType.Postback;
    }

    public class MessageAction : LineActionObjectBase
    {
        [JsonProperty("type")]
        public override ActionType Type => ActionType.Message;
    }

    public class UriAction : LineActionObjectBase
    {
        [JsonProperty("type")]
        public override ActionType Type => ActionType.Uri;
    }

    public class DatetimepickerAction : LineActionObjectBase
    {
        [JsonProperty("type")]
        public override ActionType Type => ActionType.Datetimepicker;
    }
}
