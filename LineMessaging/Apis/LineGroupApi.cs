using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineMessaging
{
    public partial class LineMessagingClient
    {
        private const string GroupMemberApiPath = "/v2/bot/group/{0}/member/{1}";
        private const string GroupMembersApiPath = "/v2/bot/group/{0}/members/ids";
        private const string LeaveGroupApiPath = "/v2/bot/group/{0}/leave";

        public async Task<LineProfile> GetGroupMember(string groupId, string userId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException($"{nameof(groupId)} is null or empty.");
            }

            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException($"{nameof(userId)} is null or empty.");
            }

            return await Get<LineProfile>(string.Format(GroupMemberApiPath, groupId, userId));
        }

        public async Task<LineMembers> GetGroupMembers(string groupId, string start = null)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException($"{nameof(groupId)} is null or empty.");
            }

            var query = new Dictionary<string, object>();
            if (start != null)
            {
                query["start"] = start;
            }

            return await Get<LineMembers>(string.Format(GroupMembersApiPath, groupId), query);
        }

        public async Task LeaveGroup(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException($"{nameof(groupId)} is null or empty.");
            }

            await Post(string.Format(LeaveGroupApiPath, groupId));
        }
    }
}
