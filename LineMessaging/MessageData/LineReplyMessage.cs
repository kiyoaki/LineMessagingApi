using System.Runtime.Serialization;

namespace LINE
{
    public class LineReplyMessage
    {
        [DataMember(Name = "replyToken")]
        public string ReplyToken { get; set; }

        [DataMember(Name = "messages")]
        public LineMessageObjectBase[] Messages { get; set; }
    }
}
