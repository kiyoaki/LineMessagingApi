using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LineMessaging
{
    public partial class LineMessagingClient
    {
        private const string LineMessagePushApiPath = "/v2/bot/message/push";
        private const string LineMessageMulticastApiPath = "/v2/bot/message/multicast";

        public async Task PushMessage(LinePushMessage pushMessage)
        {
            if (pushMessage == null)
            {
                throw new ArgumentNullException(nameof(pushMessage));
            }

            if (string.IsNullOrEmpty(pushMessage.To))
            {
                throw new ArgumentException($"{nameof(pushMessage.To)} is null or empty.");
            }

            if (pushMessage.Messages == null)
            {
                throw new ArgumentException($"{nameof(pushMessage.Messages)} is required and max length is 5.");
            }

            var messageCount = pushMessage.Messages.Count();
            if (messageCount == 0 || messageCount > 5)
            {
                throw new ArgumentException($"{nameof(pushMessage.Messages)} is required and max length is 5.");
            }

            await Post(LineMessagePushApiPath, pushMessage);
        }

        public async Task PushMessage(string to, ILineMessage message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            await Post(LineMessagePushApiPath, new LinePushMessage
            {
                To = to,
                Messages = new List<ILineMessage> { message }
            });
        }

        public async Task PushMessage(string to, IEnumerable<ILineMessage> messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
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

            await Post(LineMessagePushApiPath, new LinePushMessage
            {
                To = to,
                Messages = messages
            });
        }

        public async Task PushMessage(string to, string message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"{nameof(message)} is null or empty.");
            }

            await Post(LineMessagePushApiPath, new LinePushMessage
            {
                To = to,
                Messages = new List<ILineMessage> { new LineTextMessage { Text = message } }
            });
        }

        public async Task PushMessage(string to, params string[] messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            if (messages.Length == 0 || messages.Length > 5)
            {
                throw new ArgumentException($"{nameof(messages)} is required and max length is 5.");
            }

            await Post(LineMessagePushApiPath, new LinePushMessage
            {
                To = to,
                Messages = messages.Select(x => (ILineMessage)new LineTextMessage { Text = x }).ToList()
            });
        }

        public async Task MulticastMessage(LineMulticastMessage multicastMessage)
        {
            if (multicastMessage == null)
            {
                throw new ArgumentNullException(nameof(multicastMessage));
            }

            if (multicastMessage.To == null)
            {
                throw new ArgumentException($"{nameof(multicastMessage.To)} is required and max length is 150.");
            }

            var toCount = multicastMessage.To.Count();
            if (toCount == 0 || toCount > 150)
            {
                throw new ArgumentException($"{nameof(multicastMessage.To)} is required and max length is 150.");
            }

            if (multicastMessage.Messages == null)
            {
                throw new ArgumentException($"{nameof(multicastMessage.Messages)} is required and max length is 5.");
            }

            var messageCount = multicastMessage.Messages.Count();
            if (messageCount == 0 || messageCount > 5)
            {
                throw new ArgumentException($"{nameof(multicastMessage.Messages)} is required and max length is 5.");
            }

            await Post(LineMessageMulticastApiPath, multicastMessage);
        }

        public async Task MulticastMessage(IEnumerable<string> to, ILineMessage message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var toCount = to.Count();
            if (toCount == 0 || toCount > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            await Post(LineMessageMulticastApiPath, new LineMulticastMessage
            {
                To = to,
                Messages = new List<ILineMessage> { message }
            });
        }

        public async Task MulticastMessage(IEnumerable<string> to, IEnumerable<ILineMessage> messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            var toCount = to.Count();
            if (toCount == 0 || toCount > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            var messageCount = messages.Count();
            if (messageCount == 0 || messageCount > 5)
            {
                throw new ArgumentException($"{nameof(messages)} is required and max length is 5.");
            }

            await Post(LineMessageMulticastApiPath, new LineMulticastMessage
            {
                To = to,
                Messages = messages
            });
        }

        public async Task MulticastMessage(IEnumerable<string> to, string message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"{nameof(message)} is null or empty.");
            }

            var toCount = to.Count();
            if (toCount == 0 || toCount > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            await Post(LineMessageMulticastApiPath, new LineMulticastMessage
            {
                To = to,
                Messages = new List<ILineMessage> { new LineTextMessage { Text = message } }
            });
        }

        public async Task MulticastMessage(IEnumerable<string> to, params string[] messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            var toCount = to.Count();
            if (toCount == 0 || toCount > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            var messageCount = messages.Count();
            if (messageCount == 0 || messageCount > 5)
            {
                throw new ArgumentException($"{nameof(messages)} is required and max length is 5.");
            }

            await Post(LineMessageMulticastApiPath, new LineMulticastMessage
            {
                To = to,
                Messages = messages.Select(x => (ILineMessage)new LineTextMessage { Text = x }).ToList()
            });
        }
    }
}
