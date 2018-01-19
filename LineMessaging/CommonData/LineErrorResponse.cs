using System.Runtime.Serialization;

namespace LINE.CommonData
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
    }
}
