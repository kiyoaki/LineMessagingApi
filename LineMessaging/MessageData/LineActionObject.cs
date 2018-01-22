using System.Runtime.Serialization;

namespace LineMessaging
{
    public abstract class LineActionObjectBase
    {
        [DataMember(Name = "type")]
        public abstract ActionType Type { get; }
    }

    public class PostbackAction : LineActionObjectBase
    {
        [DataMember(Name = "type")]
        public override ActionType Type => ActionType.Postback;
    }

    public class MessageAction : LineActionObjectBase
    {
        [DataMember(Name = "type")]
        public override ActionType Type => ActionType.Message;
    }

    public class UriAction : LineActionObjectBase
    {
        [DataMember(Name = "type")]
        public override ActionType Type => ActionType.Uri;
    }

    public class DatetimepickerAction : LineActionObjectBase
    {
        [DataMember(Name = "type")]
        public override ActionType Type => ActionType.Datetimepicker;
    }
}
