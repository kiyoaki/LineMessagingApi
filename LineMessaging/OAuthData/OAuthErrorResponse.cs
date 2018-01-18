using System.Runtime.Serialization;

namespace LINE
{
    public class OAuthErrorResponse
    {
        [DataMember(Name = "error")]
        public string Error { get; set; }

        [DataMember(Name = "error_description")]
        public string Description { get; set; }
    }
}
