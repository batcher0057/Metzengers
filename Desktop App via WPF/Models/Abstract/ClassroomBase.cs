using MetzNenger44.Models;
using System.Collections.Generic;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class ClassroomBase
    {
        public ClassroomBase(string className)
        {
            ClassName = className;
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}