using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class Classroom
    {
        public Classroom()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
