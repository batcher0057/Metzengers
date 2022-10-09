using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger44.Models
{
    public partial class UserAccount : UserAccountBase
    {
        public UserAccount(string email, string password, string? nickname, string administrativeStatus, string lastName, string firstName, string? phone, int? classId) : base(email, password, nickname, administrativeStatus, lastName, firstName, phone, classId)
        {

        }
    }
}
