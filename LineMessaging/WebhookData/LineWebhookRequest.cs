using System;
using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineWebhookRequest
    {
        [DataMember(Name = "events")]
        public Event[] Events { get; set; }

        public class Event
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
            public SourceObject Source { get; set; }

            [DataMember(Name = "message")]
            public MessageObject Message { get; set; }

            [DataMember(Name = "postback")]
            public PostbackObject Postback { get; set; }

            [DataMember(Name = "beacon")]
            public BeaconObject Beacon { get; set; }

            public class SourceObject
            {
                [DataMember(Name = "type")]
                public WebhookRequestSourceType Type { get; set; }

                [DataMember(Name = "userId")]
                public string UserId { get; set; }

                [DataMember(Name = "groupId")]
                public string GroupId { get; set; }

                [DataMember(Name = "roomId")]
                public string RoomId { get; set; }
            }

            public abstract class MessageObject
            {
                [DataMember(Name = "id")]
                public long Id { get; set; }

                [DataMember(Name = "type")]
                public abstract MessageType Type { get; set; }

                [DataMember(Name = "text")]
                public string Text { get; set; }

                [DataMember(Name = "fileName")]
                public string FileName { get; set; }

                [DataMember(Name = "fileSize")]
                public long? FileSize { get; set; }

                [DataMember(Name = "title")]
                public string Title { get; set; }

                [DataMember(Name = "address")]
                public string Address { get; set; }

                [DataMember(Name = "latitude")]
                public double? Latitude { get; set; }

                [DataMember(Name = "longitude")]
                public double? Longitude { get; set; }

                [DataMember(Name = "packageId")]
                public string PackageId { get; set; }

                [DataMember(Name = "stickerId")]
                public string StickerId { get; set; }
            }

            public class PostbackObject
            {
                [DataMember(Name = "data")]
                public string Data { get; set; }

                [DataMember(Name = "params")]
                public PostbackParams Params { get; set; }

                public class PostbackParams
                {
                    [DataMember(Name = "date")]
                    public string Date { get; set; }

                    [DataMember(Name = "time")]
                    public string Time { get; set; }

                    [DataMember(Name = "datetime")]
                    public string Datetime { get; set; }
                }
            }

            public class BeaconObject
            {
                [DataMember(Name = "hwid")]
                public string HardwareId { get; set; }

                [DataMember(Name = "type")]
                public WebhookRequestBeaconType Type { get; set; }

                [DataMember(Name = "dm")]
                public string DeviceMessage { get; set; }
            }
        }
    }
}
