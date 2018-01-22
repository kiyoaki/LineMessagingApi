using System;
using System.Threading.Tasks;

namespace LineMessaging
{
    public partial class LineMessagingClient
    {
        private const string MessageReplyApiPath = "/v2/bot/message/reply";

        public async Task ReplyMessage(LineReplyMessage replyMessage)
        {
            if (replyMessage == null)
            {
                throw new ArgumentNullException(nameof(replyMessage));
            }

            if (string.IsNullOrEmpty(replyMessage.ReplyToken))
            {
                throw new ArgumentException($"{nameof(replyMessage.ReplyToken)} is null or empty.");
            }

            if (replyMessage.Messages == null || replyMessage.Messages.Length == 0 || replyMessage.Messages.Length > 5)
            {
                throw new ArgumentException($"{nameof(replyMessage.Messages)} is required and max length is 5.");
            }

            await Post(MessageReplyApiPath, replyMessage);
        }
    }
}
