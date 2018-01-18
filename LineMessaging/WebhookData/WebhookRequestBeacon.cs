using System.Runtime.Serialization;

namespace LINE
{
    public class WebhookRequestBeacon
    {
        [DataMember(Name = "hwid")]
        public string HardwareId { get; set; }

        [DataMember(Name = "type")]
        public WebhookRequestBeaconType Type { get; set; }

        [DataMember(Name = "dm")]
        public string DeviceMessage { get; set; }
    }
}
