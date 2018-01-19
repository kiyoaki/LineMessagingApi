using System.Linq;
using System.Runtime.Serialization;

namespace LINE
{
    public class LineErrorResponse
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "details")]
        public DetailObject[] Details { get; set; }

        public class DetailObject
        {
            [DataMember(Name = "message")]
            public string Message { get; set; }

            [DataMember(Name = "property")]
            public string Property { get; set; }
        }

        public override string ToString()
        {
            var details = string.Join(", ", Details.Select(x => $"Property {x.Property} {x.Message}"));
            return $"{Message}. details: {details}";
        }
    }
}
