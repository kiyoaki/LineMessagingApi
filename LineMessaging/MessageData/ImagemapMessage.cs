using System.Runtime.Serialization;

namespace LINE
{
    public class ImagemapMessage
    {
        [DataMember(Name = "type")]
        public MessageType Type => MessageType.Imagemap;

        [DataMember(Name = "baseUrl")]
        public string BaseUrl { get; set; }

        [DataMember(Name = "altText")]
        public string AltText { get; set; }

        [DataMember(Name = "baseSize")]
        public ImagemapMessageBaseSize BaseSize { get; set; }

        [DataMember(Name = "actions")]
        public ImagemapMessageAction[] Actions { get; set; }
    }

    public class ImagemapMessageBaseSize
    {
        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }
    }

    public class ImagemapMessageAction
    {
        [DataMember(Name = "type")]
        public ImagemapActionType Type { get; set; }

        [DataMember(Name = "linkUri")]
        public string LinkUri { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "area")]
        public ImagemapMessageActionArea Area { get; set; }
    }

    public class ImagemapMessageActionArea
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
