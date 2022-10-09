using MetzNenger44.Models;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class InviteBase
    {
        public InviteBase(int accountId, int meetingId, string? meetingTitle)
        {
            AccountId = accountId;
            MeetingId = meetingId;
            MeetingTitle = meetingTitle;
        }

        public int AccountId { get; set; }
        public int MeetingId { get; set; }
        public string? MeetingTitle { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Meeting Meeting { get; set; } = null!;
    }
}