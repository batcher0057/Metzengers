using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger44.Models
{
    public partial class Invite : InviteBase
    {
        public Invite(int accountId, int meetingId, string? meetingTitle) : base(accountId, meetingId, meetingTitle)
        {

        }
    }
}
