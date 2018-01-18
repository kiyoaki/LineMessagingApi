using System.Runtime.Serialization;

namespace LINE
{
    public class WebhookRequestPostback
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }

        [DataMember(Name = "params")]
        public WebhookRequestPostbackParams Params { get; set; }
    }
}
