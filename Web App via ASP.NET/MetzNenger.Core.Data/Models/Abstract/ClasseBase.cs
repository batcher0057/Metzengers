using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models.Abstract
{
    public abstract class ClasseBase
    {
        public ClasseBase(string libellePromotion)
        {
            LibellePromotion = libellePromotion ?? throw new ArgumentNullException(nameof(libellePromotion));

        }

        public int IdPromotion { get; set; }
        public string LibellePromotion { get; set; } = null!;

        public virtual ICollection<UserAccount> Utilisateurs { get; set; }
    }
}