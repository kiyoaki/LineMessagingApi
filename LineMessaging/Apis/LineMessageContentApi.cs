using System;
using System.Threading.Tasks;

namespace LineMessaging
{
    public partial class LineMessagingClient
    {
        private const string MessageContentApiPath = "/v2/bot/message/{0}/content";

        public Task<byte[]> GetMessageContent(string messageId)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                throw new ArgumentException($"{nameof(messageId)} is null or empty.");
            }

            return GetAsByteArray(string.Format(MessageContentApiPath, messageId));
        }
    }
}
