using MetzNenger44.Models;
using System;
using System.Collections.Generic;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class MeetingBase
    {
        public MeetingBase(DateTime meetingDate)
        {
            MeetingDate = meetingDate;
        }

        public int MeetingId { get; set; }
        public DateTime MeetingDate { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
    }
}