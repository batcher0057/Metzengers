using MetzNenger44.Models;
using System;
using System.Collections.Generic;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class MessageBase
    {
        public MessageBase(string body, int accountId, int? channelId)
        {
            Timestamping = DateTime.UtcNow;
            Body = body;
            AccountId = accountId;
            ChannelId = channelId;
        }

        public int MessageId { get; set; }
        public DateTime Timestamping { get; set; }
        public string Body { get; set; }
        public int AccountId { get; set; }
        public int? ChannelId { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Channel? Channel { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
        public virtual ICollection<Consult> Consults { get; set; }
    }
}