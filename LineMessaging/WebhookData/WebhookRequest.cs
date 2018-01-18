using System.Runtime.Serialization;

namespace LINE
{
    public class WebhookRequest
    {
        [DataMember(Name = "events")]
        public WebhookRequestEvent[] Events { get; set; }
    }
}
