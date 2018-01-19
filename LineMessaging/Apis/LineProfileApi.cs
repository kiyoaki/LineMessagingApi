using System;
using System.Threading.Tasks;

namespace LINE
{
    public partial class LineMessagingClient
    {
        private const string ProfileApiPath = "/v2/bot/profile/{0}";

        public async Task<LineProfile> GetProfile(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException($"{nameof(userId)} is null or empty.");
            }

            return await Get<LineProfile>(string.Format(ProfileApiPath, userId));
        }
    }
}
