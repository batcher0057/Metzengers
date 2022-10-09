using MetzNenger.Core.Data.Models.Abstract;

namespace MetzNenger.Core.Data.Models
{
    public partial class Access : AccessBase
    {
        public Access(int accountId, int channelId) : base(accountId, channelId)
        {
        }
    }
}
