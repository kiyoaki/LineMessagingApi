using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace LineMessaging
{
    public class LineWebhookHandler
    {
        private readonly byte[] secret;

        public LineWebhookHandler(string channelSecret)
        {
            if (string.IsNullOrEmpty(channelSecret))
            {
                throw new ArgumentException($"{nameof(channelSecret)} is null or empty.");
            }

            secret = Encoding.UTF8.GetBytes(channelSecret);
        }

        public async Task<(bool valid, LineWebhookRequest request)> VerifyAndDeserialize(HttpRequestMessage req)
        {
            var (valid, json) = await Verify(req);
            if (valid)
            {
                return (true, JsonSerializer.Deserialize<LineWebhookRequest>(json));
            }

            return (false, null);
        }

        public async Task<(bool valid, string json)> Verify(HttpRequestMessage req)
        {
            if (!req.Headers.TryGetValues("X-Line-Signature", out IEnumerable<string> headers))
            {
                return (false, null);
            }

            var signature = headers.FirstOrDefault();
            if (signature == null)
            {
                return (false, null);
            }

            var content = await req.Content.ReadAsStringAsync();
            var body = await req.Content.ReadAsByteArrayAsync();

            using (var hmacsha256 = new HMACSHA256(secret))
            {
                if (signature != Convert.ToBase64String(hmacsha256.ComputeHash(body)))
                {
                    return (false, null);
                }
            }

            return (true, content);
        }
    }
}
