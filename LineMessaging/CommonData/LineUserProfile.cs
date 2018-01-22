using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineProfile
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "pictureUrl")]
        public string PictureUrl { get; set; }

        [DataMember(Name = "statusMessage")]
        public string StatusMessage { get; set; }
    }
}
