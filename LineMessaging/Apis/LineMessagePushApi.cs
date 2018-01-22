using System;
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

            if (pushMessage.Messages == null || pushMessage.Messages.Length == 0 || pushMessage.Messages.Length > 5)
            {
                throw new ArgumentException($"{nameof(pushMessage.Messages)} is required and max length is 5.");
            }

            await Post(LineMessagePushApiPath, pushMessage);
        }

        public async Task PushMessage(LineMulticastMessage multicastMessage)
        {
            if (multicastMessage == null)
            {
                throw new ArgumentNullException(nameof(multicastMessage));
            }

            if (multicastMessage.To == null || multicastMessage.To.Length == 0 || multicastMessage.To.Length > 150)
            {
                throw new ArgumentException($"{nameof(multicastMessage.To)} is required and max length is 150.");
            }

            if (multicastMessage.Messages == null || multicastMessage.Messages.Length == 0 || multicastMessage.Messages.Length > 5)
            {
                throw new ArgumentException($"{nameof(multicastMessage.Messages)} is required and max length is 5.");
            }

            await Post(LineMessagePushApiPath, multicastMessage);
        }
    }
}
