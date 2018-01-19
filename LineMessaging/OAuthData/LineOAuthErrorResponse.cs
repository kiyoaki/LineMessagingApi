using System.Runtime.Serialization;

namespace LINE
{
    public class LineOAuthErrorResponse
    {
        [DataMember(Name = "error")]
        public string Error { get; set; }

        [DataMember(Name = "error_description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Error}. description: {Description}.";
        }
    }
}
