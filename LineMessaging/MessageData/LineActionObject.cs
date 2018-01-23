using Newtonsoft.Json;

namespace LineMessaging
{
    public interface ILineAction
    {
        [JsonProperty("type")]
        ActionType Type { get; }
    }

    public class PostbackAction : ILineAction
    {
        [JsonProperty("type")]
        public ActionType Type => ActionType.Postback;
    }

    public class MessageAction : ILineAction
    {
        [JsonProperty("type")]
        public ActionType Type => ActionType.Message;
    }

    public class UriAction : ILineAction
    {
        [JsonProperty("type")]
        public ActionType Type => ActionType.Uri;
    }

    public class DatetimepickerAction : ILineAction
    {
        [JsonProperty("type")]
        public ActionType Type => ActionType.Datetimepicker;
    }
}
