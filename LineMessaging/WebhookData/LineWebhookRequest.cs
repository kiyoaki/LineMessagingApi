using Newtonsoft.Json;
using System;

namespace LineMessaging
{
    public class LineWebhookContent
    {
        [JsonProperty("events")]
        public Event[] Events { get; set; }

        public class Event
        {
            [JsonProperty("type")]
            public WebhookRequestEventType Type { get; set; }

            [JsonProperty("timestamp")]
            public long UnixTimestamp { get; set; }

            [JsonIgnore]
            public DateTime Timestamp
            {
                get { return UnixTimestamp.FromUnixTime(); }
            }

            [JsonProperty("replyToken")]
            public string ReplyToken { get; set; }

            [JsonProperty("source")]
            public SourceObject Source { get; set; }

            [JsonProperty("message")]
            public MessageObject Message { get; set; }

            [JsonProperty("postback")]
            public PostbackObject Postback { get; set; }

            [JsonProperty("beacon")]
            public BeaconObject Beacon { get; set; }

            public class SourceObject
            {
                [JsonProperty("type")]
                public WebhookRequestSourceType Type { get; set; }

                [JsonProperty("userId")]
                public string UserId { get; set; }

                [JsonProperty("groupId")]
                public string GroupId { get; set; }

                [JsonProperty("roomId")]
                public string RoomId { get; set; }
            }

            public class MessageObject
            {
                [JsonProperty("id")]
                public long Id { get; set; }

                [JsonProperty("type")]
                public MessageType Type { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonProperty("fileName")]
                public string FileName { get; set; }

                [JsonProperty("fileSize")]
                public long? FileSize { get; set; }

                [JsonProperty("title")]
                public string Title { get; set; }

                [JsonProperty("address")]
                public string Address { get; set; }

                [JsonProperty("latitude")]
                public double? Latitude { get; set; }

                [JsonProperty("longitude")]
                public double? Longitude { get; set; }

                [JsonProperty("packageId")]
                public string PackageId { get; set; }

                [JsonProperty("stickerId")]
                public string StickerId { get; set; }
            }

            public class PostbackObject
            {
                [JsonProperty("data")]
                public string Data { get; set; }

                [JsonProperty("params")]
                public PostbackParams Params { get; set; }

                public class PostbackParams
                {
                    [JsonProperty("date")]
                    public string Date { get; set; }

                    [JsonProperty("time")]
                    public string Time { get; set; }

                    [JsonProperty("datetime")]
                    public string Datetime { get; set; }
                }
            }

            public class BeaconObject
            {
                [JsonProperty("hwid")]
                public string HardwareId { get; set; }

                [JsonProperty("type")]
                public WebhookRequestBeaconType Type { get; set; }

                [JsonProperty("dm")]
                public string DeviceMessage { get; set; }
            }
        }
    }
}
