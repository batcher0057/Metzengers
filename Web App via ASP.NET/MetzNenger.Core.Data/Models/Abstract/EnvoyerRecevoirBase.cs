using System;

namespace MetzNenger.Core.Data.Models.Abstract
{
    public abstract class EnvoyerRecevoirBase
    {
        public int AccountId { get; set; }
        public int MessageId { get; set; }
        public DateTime? ReadingDate { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Message Message { get; set; } = null!;

        public EnvoyerRecevoirBase(int idUtilisateur, int idMessage)
        {
            AccountId = idUtilisateur;
            MessageId = idMessage;
        }
    }
}