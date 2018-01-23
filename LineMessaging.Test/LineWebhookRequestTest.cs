using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LineMessaging.Test
{
    public class LineWebhookRequestTest
    {
        private readonly string signature;
        private readonly string requestJson;
        private readonly string channelSecret;

        public LineWebhookRequestTest()
        {
            signature = Environment.GetEnvironmentVariable("LINE_TEST_REQUEST_SIGNATURE");
            requestJson = Environment.GetEnvironmentVariable("LINE_TEST_WEBHOOK_REQUEST_JSON");
            channelSecret = Environment.GetEnvironmentVariable("LINE_TEST_CHANNEL_SECRET");
        }

        [Fact]
        public async Task VerifySuccessTest()
        {
            var req1 = new HttpRequestMessage
            {
                Content = new StringContent(requestJson)
            };
            req1.Headers.Add("X-Line-Signature", signature);
            var webhookRequest = new LineWebhookRequest(channelSecret, req1);

            var valid1 = await webhookRequest.IsValid();
            var json1 = await webhookRequest.GetContentJson();
            var deserialized1 = await webhookRequest.GetContent();

            Assert.True(valid1);
            Assert.Equal(requestJson, json1);

            var e = deserialized1.Events.First();
            Assert.Equal(WebhookRequestEventType.Message, e.Type);
            Assert.Equal(MessageType.Text, e.Message.Type);
            Assert.Equal("てすと", e.Message.Text);
        }

        [Fact]
        public async Task VerifyFailTest()
        {
            var req2 = new HttpRequestMessage
            {
                Content = new StringContent(requestJson)
            };
            req2.Headers.Add("X-Line-Signature", "testtesttest");
            var webhookRequest = new LineWebhookRequest(channelSecret, req2);

            var valid2 = await webhookRequest.IsValid();
            var json2 = await webhookRequest.GetContentJson();
            var deserialized2 = await webhookRequest.GetContent();

            Assert.False(valid2);
            Assert.Equal(requestJson, json2);

            var e = deserialized2.Events.First();
            Assert.Equal(WebhookRequestEventType.Message, e.Type);
            Assert.Equal(MessageType.Text, e.Message.Type);
            Assert.Equal("てすと", e.Message.Text);
        }
    }
}
