using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models.Abstract
{
    public class ChannelBase
    {

        public int ChannelId { get; set; }
        public string ChannelName { get; set; } = null!;

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<UserAccount> Accounts { get; set; }

        public ChannelBase(string channelName)
        {
            ChannelName = channelName ?? throw new ArgumentNullException(nameof(channelName));
        }
        public ChannelBase()
        {

        }
    }
}