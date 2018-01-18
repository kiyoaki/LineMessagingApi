using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINE
{
    public class Webhook
    {
        private const string SignatureHeaderKey = "X-Line-Signature";

        private readonly byte[] secret;

        public Webhook(string channelSecret)
        {
            if (string.IsNullOrEmpty(channelSecret))
            {
                throw new ArgumentException($"{nameof(channelSecret)} is null or empty.");
            }

            secret = Encoding.UTF8.GetBytes(channelSecret);
        }

        public async Task<(bool valid, string json)> Verify(HttpRequestMessage req)
        {
            IEnumerable<string> headers;
            if (!req.Headers.TryGetValues("X-Line-Signature", out headers))
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
