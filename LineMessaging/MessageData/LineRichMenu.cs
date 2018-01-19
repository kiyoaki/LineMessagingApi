using System.Runtime.Serialization;

namespace LINE
{
    public class LineRichMenu
    {
        [DataMember(Name = "size")]
        public LineSizeObject Size { get; set; }

        [DataMember(Name = "selected")]
        public bool Selected { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "charBarText")]
        public string CharBarText { get; set; }

        [DataMember(Name = "areas")]
        public BoundsObject[] Areas { get; set; }

        public class BoundsObject
        {
            [DataMember(Name = "bounds")]
            public LineAreaBoundsObject Bounds { get; set; }

            [DataMember(Name = "action")]
            public LineActionObjectBase Action { get; set; }
        }
    }
}
