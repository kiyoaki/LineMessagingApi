using Newtonsoft.Json;

namespace LineMessaging
{
    public class LineOAuthErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Error}. description: {Description}.";
        }
    }
}
