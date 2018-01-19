using System.Runtime.Serialization;

namespace LINE
{
    public class LineImagemapMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Imagemap;

        [DataMember(Name = "baseUrl")]
        public string BaseUrl { get; set; }

        [DataMember(Name = "altText")]
        public string AltText { get; set; }

        [DataMember(Name = "baseSize")]
        public BaseSizeObject BaseSize { get; set; }

        [DataMember(Name = "actions")]
        public ActionObject[] Actions { get; set; }

        public class BaseSizeObject
        {
            [DataMember(Name = "width")]
            public int Width { get; set; }

            [DataMember(Name = "height")]
            public int Height { get; set; }
        }

        public class ActionObject
        {
            [DataMember(Name = "type")]
            public ImagemapActionType Type { get; set; }

            [DataMember(Name = "linkUri")]
            public string LinkUri { get; set; }

            [DataMember(Name = "text")]
            public string Text { get; set; }

            [DataMember(Name = "area")]
            public AreaObject Area { get; set; }

            public class AreaObject
            {
                [DataMember(Name = "x")]
                public int X { get; set; }

                [DataMember(Name = "y")]
                public int Y { get; set; }

                [DataMember(Name = "width")]
                public int Width { get; set; }

                [DataMember(Name = "height")]
                public int Height { get; set; }
            }
        }
    }
}
