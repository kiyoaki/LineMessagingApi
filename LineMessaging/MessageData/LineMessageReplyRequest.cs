using System.Runtime.Serialization;

namespace LINE
{
    public class LineMessageReplyRequest
    {
        [DataMember(Name = "replyToken")]
        public string replyToken { get; set; }

        [DataMember(Name = "messages")]
        public string messages { get; set; }
    }
}
