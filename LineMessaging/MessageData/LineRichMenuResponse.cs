using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineRichMenuResponse : LineRichMenu
    {
        [JsonProperty("richMenuId")]
        public string RichMenuId { get; set; }
    }
}
