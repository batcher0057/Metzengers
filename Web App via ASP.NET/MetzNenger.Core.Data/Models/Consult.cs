using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class Consult
    {
        public int AccountId { get; set; }
        public int MessageId { get; set; }
        public DateTime? ReadingDate { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Message Message { get; set; } = null!;

        public Consult(int accountId, int messageId)
        {
            AccountId = accountId;
            MessageId = messageId;
        }
    }
}
