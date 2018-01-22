using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineMembers
    {
        [DataMember(Name = "memberIds")]
        public string[] MemberIds { get; set; }

        [DataMember(Name = "next")]
        public string Next { get; set; }
    }
}
