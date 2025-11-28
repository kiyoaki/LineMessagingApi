using System;
using System.Collections.Generic;
using System.Linq;
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

            if (replyMessage.Messages == null)
            {
                throw new ArgumentException($"{nameof(replyMessage.Messages)} is required and max length is 5.");
            }

            var messageCount = replyMessage.Messages.Count();
            if (messageCount == 0 || messageCount > 5)
            {
                throw new ArgumentException($"{nameof(replyMessage.Messages)} is required and max length is 5.");
            }

            await Post(MessageReplyApiPath, replyMessage);
        }

        public async Task ReplyMessage(string replyToken, IEnumerable<ILineMessage> messages)
        {
            if (string.IsNullOrEmpty(replyToken))
            {
                throw new ArgumentException($"{nameof(replyToken)} is null or empty.");
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            var messageCount = messages.Count();
            if (messageCount == 0 || messageCount > 5)
            {
                throw new ArgumentException($"{nameof(messages)} is required and max length is 5.");
            }

            await Post(MessageReplyApiPath, new LineReplyMessage
            {
                ReplyToken = replyToken,
                Messages = messages
            });
        }

        public async Task ReplyMessage(string replyToken, string message)
        {
            if (string.IsNullOrEmpty(replyToken))
            {
                throw new ArgumentException($"{nameof(replyToken)} is null or empty.");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"{nameof(message)} is null or empty.");
            }

            await Post(MessageReplyApiPath, new LineReplyMessage
            {
                ReplyToken = replyToken,
                Messages = new List<ILineMessage> { new LineTextMessage { Text = message } }
            });
        }

        public async Task ReplyMessage(string replyToken, params string[] messages)
        {
            if (string.IsNullOrEmpty(replyToken))
            {
                throw new ArgumentException($"{nameof(replyToken)} is null or empty.");
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            if (messages.Length == 0 || messages.Length > 5)
            {
                throw new ArgumentException($"{nameof(messages)} is required and max length is 5.");
            }

            await Post(MessageReplyApiPath, new LineReplyMessage
            {
                ReplyToken = replyToken,
                Messages = messages.Select(x => (ILineMessage)new LineTextMessage { Text = x }).ToList()
            });
        }
    }
}
