using System.Runtime.Serialization;

namespace LineMessaging
{
    public class LineRichMenuResponse : LineRichMenu
    {
        [DataMember(Name = "richMenuId")]
        public string RichMenuId { get; set; }
    }
}
