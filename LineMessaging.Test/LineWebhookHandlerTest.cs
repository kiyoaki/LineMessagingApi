using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LineMessaging.Test
{
    public class LineWebhookHandlerTest
    {
        private readonly string signature;
        private readonly string requestJson;
        private readonly LineWebhookHandler webhookHandler;

        public LineWebhookHandlerTest()
        {
            signature = Environment.GetEnvironmentVariable("LINE_TEST_REQUEST_SIGNATURE");
            requestJson = Environment.GetEnvironmentVariable("LINE_TEST_WEBHOOK_REQUEST_JSON");
            var channelSecret = Environment.GetEnvironmentVariable("LINE_TEST_CHANNEL_SECRET");
            webhookHandler = new LineWebhookHandler(channelSecret);
        }

        [Fact]
        public async Task VerifyTest()
        {
            var req1 = new HttpRequestMessage
            {
                Content = new StringContent(requestJson)
            };
            req1.Headers.Add("X-Line-Signature", signature);
            var (valid1, json1) = await webhookHandler.Verify(req1);
            Assert.True(valid1);
            Assert.Equal(requestJson, json1);

            var req2 = new HttpRequestMessage
            {
                Content = new StringContent(requestJson)
            };
            req2.Headers.Add("X-Line-Signature", "testtesttest");
            var (valid2, json2) = await webhookHandler.Verify(req2);
            Assert.False(valid2);
            Assert.Null(json2);
        }

        [Fact]
        public async Task VerifyAndDeserializeTest()
        {
            var req1 = new HttpRequestMessage
            {
                Content = new StringContent(requestJson)
            };
            req1.Headers.Add("X-Line-Signature", signature);
            var (valid1, request1) = await webhookHandler.VerifyAndDeserialize(req1);
            Assert.True(valid1);

            var e = request1.Events.First();
            Assert.Equal(WebhookRequestEventType.Message, e.Type);
            Assert.Equal(MessageType.Text, e.Message.Type);
            Assert.Equal("てすと", e.Message.Text);

            var req2 = new HttpRequestMessage
            {
                Content = new StringContent(requestJson)
            };
            req2.Headers.Add("X-Line-Signature", "testtesttest");
            var (valid2, json2) = await webhookHandler.VerifyAndDeserialize(req2);
            Assert.False(valid2);
            Assert.Null(json2);
        }
    }
}
