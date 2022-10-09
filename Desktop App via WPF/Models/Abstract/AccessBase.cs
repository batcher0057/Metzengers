using MetzNenger44.Models;
using System;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class AccessBase
    {
        public AccessBase(int accountId, int channelId, DateTime? firstConnection)
        {
            AccountId = accountId;
            ChannelId = channelId;
            FirstConnection = firstConnection;
        }

        public int AccountId { get; set; }
        public int ChannelId { get; set; }
        public DateTime? FirstConnection { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Channel Channel { get; set; } = null!;
    }
}