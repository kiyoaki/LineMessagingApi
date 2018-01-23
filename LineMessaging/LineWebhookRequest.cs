using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LineMessaging
{
    public class LineWebhookRequest
    {
        private readonly byte[] secret;
        private readonly HttpRequestMessage request;
        private string contentJson;
        private LineWebhook content;

        public LineWebhookRequest(string channelSecret, HttpRequestMessage request)
        {
            if (string.IsNullOrEmpty(channelSecret))
            {
                throw new ArgumentException($"{nameof(channelSecret)} is null or empty.");
            }

            secret = Encoding.UTF8.GetBytes(channelSecret);
            this.request = request;
        }

        public async Task<bool> IsValid()
        {
            if (!request.Headers.TryGetValues("X-Line-Signature", out IEnumerable<string> headers))
            {
                return false;
            }

            var signature = headers.FirstOrDefault();
            if (signature == null)
            {
                return false;
            }

            contentJson = await request.Content.ReadAsStringAsync();
            var body = await request.Content.ReadAsByteArrayAsync();

            using (var hmacsha256 = new HMACSHA256(secret))
            {
                if (signature != Convert.ToBase64String(hmacsha256.ComputeHash(body)))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<string> GetContentJson()
        {
            if (contentJson != null)
            {
                return contentJson;
            }

            contentJson = await request.Content.ReadAsStringAsync();
            return contentJson;
        }

        public async Task<LineWebhook> GetContent()
        {
            if (content != null)
            {
                return content;
            }

            contentJson = await GetContentJson();
            if (contentJson == null)
            {
                return null;
            }

            content = JsonConvert.DeserializeObject<LineWebhook>(contentJson);
            return content;
        }
    }
}
