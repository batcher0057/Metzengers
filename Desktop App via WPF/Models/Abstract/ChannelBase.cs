using MetzNenger44.Models;
using System;
using System.Collections.Generic;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class ChannelBase
    {
        public ChannelBase(string channelName)
        {
            ChannelName = channelName;
        }

        public int ChannelId { get; set; }
        public string ChannelName { get; set; } = null!;

        public virtual ICollection<Access> Accesses { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}