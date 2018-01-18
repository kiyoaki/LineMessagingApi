using System.Runtime.Serialization;

namespace LINE
{
    public class WebhookRequestPostbackParams
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "time")]
        public string Time { get; set; }

        [DataMember(Name = "datetime")]
        public string Datetime { get; set; }
    }
}
