using System;
using System.Threading.Tasks;

namespace LINE
{
    public partial class LineMessagingClient
    {
        private const string MessageContentApiPath = "/v2/bot/message/{0}/content";

        public async Task GetMessageContent(string messageId)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                throw new ArgumentException($"{nameof(messageId)} is null or empty.");
            }

            await GetAsByteArray(string.Format(MessageContentApiPath, messageId));
        }
    }
}
