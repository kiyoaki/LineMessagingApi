using System;
using System.Runtime.Serialization;

namespace LINE
{
    public class WebhookRequestEvent
    {
        [DataMember(Name = "type")]
        public WebhookRequestEventType Type { get; set; }

        [DataMember(Name = "timestamp")]
        public long UnixTimestamp { get; set; }

        [IgnoreDataMember]
        public DateTime Timestamp
        {
            get { return UnixTimestamp.FromUnixTime(); }
        }

        [DataMember(Name = "replyToken")]
        public string ReplyToken { get; set; }

        [DataMember(Name = "source")]
        public WebhookRequestMessageSource Source { get; set; }

        [DataMember(Name = "message")]
        public WebhookRequestTextMessage Message { get; set; }

        [DataMember(Name = "postback")]
        public WebhookRequestPostback Postback { get; set; }

        [DataMember(Name = "beacon")]
        public WebhookRequestBeacon Beacon { get; set; }
    }
}
