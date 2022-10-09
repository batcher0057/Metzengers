using MetzNenger44.Models;
using System;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class ConsultBase
    {
        public ConsultBase(int accountId, int messageId)
        {
            AccountId = accountId;
            MessageId = messageId;
            ReadingDate = DateTime.UtcNow;
        }

        public int AccountId { get; set; }
        public int MessageId { get; set; }
        public DateTime? ReadingDate { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Message Message { get; set; } = null!;
    }
}