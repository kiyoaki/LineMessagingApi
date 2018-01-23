using Newtonsoft.Json;

namespace LineMessaging
{
    public interface ILineMessage
    {
        MessageType Type { get; }
    }
}
