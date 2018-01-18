using System.Runtime.Serialization;

namespace LINE
{
    public class WebhookRequestMessageSource
    {
        [DataMember(Name = "type")]
        public WebhookRequestMessageSourceType Type { get; set; }

        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "groupId")]
        public string GroupId { get; set; }

        [DataMember(Name = "roomId")]
        public string RoomId { get; set; }
    }
}
