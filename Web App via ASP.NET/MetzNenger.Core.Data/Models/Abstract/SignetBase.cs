using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models.Abstract
{
    public class SignetBase
    {
        public SignetBase(int idSignet, ICollection<Archive> archives)
        {
            IdSignet = idSignet;
            Archives = archives ?? throw new ArgumentNullException(nameof(archives));
        }
        public SignetBase()
        {
            Archives = new HashSet<Archive>();
        }
        public int IdSignet { get; set; }

        public virtual ICollection<Archive> Archives { get; set; }
    }
}