using System.Runtime.Serialization;

namespace LINE
{
    public class LineRichMenuResponse : LineRichMenu
    {
        [DataMember(Name = "richMenuId")]
        public string RichMenuId { get; set; }
    }
}
