using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LINE
{
    public partial class LineMessagingClient
    {
        private const string RoomMemberApiPath = "/v2/bot/room/{roomId}/member/{userId}";
        private const string RoomMembersApiPath = "/v2/bot/room/{roomId}/members/ids";
        private const string LeaveRoomApiPath = "/v2/bot/room/{roomId}/leave";

        public async Task<LineProfile> GetRoomMember(string roomId, string userId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                throw new ArgumentException($"{nameof(roomId)} is null or empty.");
            }

            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException($"{nameof(userId)} is null or empty.");
            }

            return await Get<LineProfile>(string.Format(RoomMemberApiPath, roomId, userId));
        }

        public async Task<LineMembers> GetRoomMembers(string roomId, string start = null)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                throw new ArgumentException($"{nameof(roomId)} is null or empty.");
            }

            var query = new Dictionary<string, object>();
            if (start != null)
            {
                query["start"] = start;
            }

            return await Get<LineMembers>(string.Format(RoomMembersApiPath, roomId), query);
        }

        public async Task LeaveRoom(string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                throw new ArgumentException($"{nameof(roomId)} is null or empty.");
            }

            await Post(string.Format(LeaveRoomApiPath, roomId));
        }
    }
}
