using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineRichMenu
    {
        [JsonProperty("size")]
        public LineSizeObject Size { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("charBarText")]
        public string CharBarText { get; set; }

        [JsonProperty("areas")]
        public BoundsObject[] Areas { get; set; }

        public class BoundsObject
        {
            [JsonProperty("bounds")]
            public LineAreaBounds Bounds { get; set; }

            [JsonProperty("action")]
            public ILineAction Action { get; set; }
        }
    }
}
