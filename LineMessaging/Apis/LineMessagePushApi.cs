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

            if (pushMessage.Messages == null || pushMessage.Messages.Count == 0 || pushMessage.Messages.Count > 5)
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

        public async Task PushMessage(string to, IList<ILineMessage> messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            if (messages.Count == 0 || messages.Count > 5)
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

        public async Task PushMessage(string to, IList<string> messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            if (messages.Count == 0 || messages.Count > 5)
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

            if (multicastMessage.To == null || multicastMessage.To.Count == 0 || multicastMessage.To.Count > 150)
            {
                throw new ArgumentException($"{nameof(multicastMessage.To)} is required and max length is 150.");
            }

            if (multicastMessage.Messages == null || multicastMessage.Messages.Count == 0 || multicastMessage.Messages.Count > 5)
            {
                throw new ArgumentException($"{nameof(multicastMessage.Messages)} is required and max length is 5.");
            }

            await Post(LineMessageMulticastApiPath, multicastMessage);
        }

        public async Task MulticastMessage(IList<string> to, ILineMessage message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (to.Count == 0 || to.Count > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            await Post(LineMessageMulticastApiPath, new LineMulticastMessage
            {
                To = to,
                Messages = new List<ILineMessage> { message }
            });
        }

        public async Task MulticastMessage(IList<string> to, IList<ILineMessage> messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            if (to.Count == 0 || to.Count > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            if (messages.Count == 0 || messages.Count > 5)
            {
                throw new ArgumentException($"{nameof(messages)} is required and max length is 5.");
            }

            await Post(LineMessageMulticastApiPath, new LineMulticastMessage
            {
                To = to,
                Messages = messages
            });
        }

        public async Task MulticastMessage(IList<string> to, string message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"{nameof(message)} is null or empty.");
            }

            if (to.Count == 0 || to.Count > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            await Post(LineMessageMulticastApiPath, new LineMulticastMessage
            {
                To = to,
                Messages = new List<ILineMessage> { new LineTextMessage { Text = message } }
            });
        }

        public async Task MulticastMessage(IList<string> to, IList<string> messages)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            if (to.Count == 0 || to.Count > 150)
            {
                throw new ArgumentException($"{nameof(to)} is required and max length is 150.");
            }

            if (messages.Count == 0 || messages.Count > 5)
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
