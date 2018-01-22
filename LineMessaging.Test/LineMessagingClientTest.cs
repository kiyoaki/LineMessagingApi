using SixLabors.ImageSharp;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LineMessaging.Test
{
    public class LineMessagingClientTest
    {
        private readonly string userId1;
        private readonly string userId2;
        private readonly string roomId;
        private readonly string groupId;
        private readonly LineMessagingClient apiClient;

        public LineMessagingClientTest()
        {
            userId1 = Environment.GetEnvironmentVariable("LINE_TEST_USER_ID_1");
            userId2 = Environment.GetEnvironmentVariable("LINE_TEST_USER_ID_2");
            roomId = Environment.GetEnvironmentVariable("LINE_TEST_ROOM_ID");
            groupId = Environment.GetEnvironmentVariable("LINE_TEST_GROUP_ID");
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

        [Fact]
        public async Task PushMessageTest()
        {
            var message = new LinePushMessage(userId1, "PushMessageTest");
            await apiClient.PushMessage(message);
        }

        [Fact]
        public async Task PushMessagesTest()
        {
            var message = new LinePushMessage(userId1, new[] { "PushMessagesTest 1", "PushMessagesTest 2" });
            await apiClient.PushMessage(message);
        }

        [Fact]
        public async Task PushLineMulticastMessageTest()
        {
            var message = new LineMulticastMessage(new[] { userId1, userId2 }, "PushLineMulticastMessageTest");
            await apiClient.PushMessage(message);
        }

        [Fact]
        public async Task PushLineMulticastMessagesTest()
        {
            var message = new LineMulticastMessage(new[] { userId1, userId2 },
                new[] { "PushLineMulticastMessagesTest 1", "PushLineMulticastMessagesTest 2" });
            await apiClient.PushMessage(message);
        }

        [Fact]
        public async Task GetProfileTest()
        {
            var profile = await apiClient.GetProfile(userId1);
            Assert.NotNull(profile);
        }

        [Fact]
        public async Task GetRoomMemberTest()
        {
            var profile = await apiClient.GetRoomMember(roomId, userId1);
            Assert.NotNull(profile);
        }

        [Fact]
        public async Task GetGroupMemberTest()
        {
            var profile = await apiClient.GetGroupMember(groupId, userId1);
            Assert.NotNull(profile);
        }
    }
}
