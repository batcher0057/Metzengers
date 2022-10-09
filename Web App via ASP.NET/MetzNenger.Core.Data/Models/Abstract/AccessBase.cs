using MetzNenger.Core.Data.Models;
using System;

namespace MetzNenger.Core.Data.Models.Abstract
{
    public abstract class AccessBase
    {
        public int AccountId { get; set; }
        public int ChannelId { get; set; }
        public DateTime? FirstConnection { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Channel Channel { get; set; } = null!;

        protected AccessBase(int accountId, int channelId)
        {
            AccountId = accountId;
            ChannelId = channelId;
        }
    }
}