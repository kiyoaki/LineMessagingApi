using System;
using System.Threading.Tasks;
using Xunit;

namespace LineMessaging.Test
{
    public class LineOAuthClientTest
    {
        private readonly LineOAuthClient apiClient;

        public LineOAuthClientTest()
        {
            var channelId = Environment.GetEnvironmentVariable("LINE_TEST_CHANNEL_ID");
            var channelSecret = Environment.GetEnvironmentVariable("LINE_TEST_CHANNEL_SECRET");
            apiClient = new LineOAuthClient(channelId, channelSecret);
        }

        [Fact]
        public async Task GetAndRevokeAccessTokenTest()
        {
            var token = await apiClient.GetAccessToken();
            Assert.NotNull(token);

            await apiClient.RevokeAccessToken(token.AccessToken);
        }
    }
}
