using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LineMessaging
{
    public partial class LineMessagingClient
    {
        private const string RichMenuApiPath = "/v2/bot/richmenu/{0}";
        private const string RichMenusApiPath = "/v2/bot/richmenu";
        private const string UsersRichMenuApiPath = "/v2/bot/user/{0}/richmenu";
        private const string LinkUsersRichMenuApiPath = "/v2/bot/user/{0}/richmenu/{1}";
        private const string RichMenuContentApiPath = "/v2/bot/richmenu/{0}/content";

        public async Task<LineProfile> GetRichMenu(string richMenuId)
        {
            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException($"{nameof(richMenuId)} is null or empty.");
            }

            return await Get<LineProfile>(string.Format(RichMenuApiPath, richMenuId));
        }

        public async Task<string> CreateRichMenu(LineRichMenu richMenu)
        {
            if (richMenu == null)
            {
                throw new ArgumentNullException(nameof(richMenu));
            }

            var response = await Post<RichMenuIdResponse>(RichMenusApiPath, richMenu);
            return response?.RichMenuId;
        }

        public async Task DeleteRichMenu(string richMenuId)
        {
            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException($"{nameof(richMenuId)} is null or empty.");
            }

            await Delete(string.Format(RichMenuApiPath, richMenuId));
        }

        public async Task<string> GetUsersRichMenuId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException($"{nameof(userId)} is null or empty.");
            }

            var response = await Get<RichMenuIdResponse>(string.Format(UsersRichMenuApiPath, userId));
            return response?.RichMenuId;
        }

        public async Task LinkUsersRichMenu(string userId, string richMenuId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException($"{nameof(userId)} is null or empty.");
            }

            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException($"{nameof(richMenuId)} is null or empty.");
            }

            await Post(string.Format(LinkUsersRichMenuApiPath, userId, richMenuId));
        }

        public async Task UnlinkUsersRichMenu(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException($"{nameof(userId)} is null or empty.");
            }

            await Delete(string.Format(UsersRichMenuApiPath, userId));
        }

        public async Task<byte[]> GetRichMenuContent(string richMenuId)
        {
            if (string.IsNullOrEmpty(richMenuId))
            {
                throw new ArgumentException($"{nameof(richMenuId)} is null or empty.");
            }

            return await GetAsByteArray(string.Format(RichMenuContentApiPath, richMenuId));
        }

        internal class RichMenuIdResponse
        {
            [DataMember(Name = "richMenuId")]
            internal string RichMenuId { get; set; }
        }
    }
}
