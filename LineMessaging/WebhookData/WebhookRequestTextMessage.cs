using System.Runtime.Serialization;

namespace LINE
{
    public class WebhookRequestTextMessage : WebhookRequestMessagebase
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

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
}
