using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models.DTO.Abstract
{
    public abstract class MessageBase
    {

        public MessageBase()
        {
            Archives = new HashSet<Archive>();
            AttachedFiles = new HashSet<AttachedFile>();
            Consults = new HashSet<Consult>();
        }

        public int MessageId { get; set; }
        public DateTime Timestamping { get; set; }
        public string? Body { get; set; }
        public bool? IsFavorite { get; set; }
        public int AccountId { get; set; }
        public int? ChannelId { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Channel? Channel { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
        public virtual ICollection<Consult> Consults { get; set; }

        protected MessageBase(string? body, int accountId, int? channelId)
        {
            Body = body;
            AccountId = accountId;
            ChannelId = channelId;
            Timestamping = DateTime.Now;
            IsFavorite = false;
        }
    }
}