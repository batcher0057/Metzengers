using MetzNenger44.Models;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class ArchiveBase
    {
        public ArchiveBase(int accountId, int messageId, int bookmarkId)
        {
            AccountId = accountId;
            MessageId = messageId;
            BookmarkId = bookmarkId;
        }

        public int AccountId { get; set; }
        public int MessageId { get; set; }
        public int BookmarkId { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Bookmark Bookmark { get; set; } = null!;
        public virtual Message Message { get; set; } = null!;
    }
}