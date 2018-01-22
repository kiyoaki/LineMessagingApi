using SixLabors.ImageSharp;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LineMessaging.Test
{
    public class LineMessagingClientTest
    {
        private readonly LineMessagingClient apiClient;

        public LineMessagingClientTest()
        {
            var accessToken = Environment.GetEnvironmentVariable("LINE_ACCESS_TOKEN");
            apiClient = new LineMessagingClient(accessToken);
        }

        [Fact]
        public async Task GetMessageContentTest()
        {
            const string messageId = "7349950403913";
            var bytes = await apiClient.GetMessageContent(messageId);
            Assert.NotNull(bytes);

            var image = Image.Load(bytes);
            Assert.NotNull(image);

        }
    }
}
