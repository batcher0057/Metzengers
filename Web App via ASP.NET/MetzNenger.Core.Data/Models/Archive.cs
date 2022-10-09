using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class Archive
    {
        public int AccountId { get; set; }
        public int MessageId { get; set; }
        public int BookmarkId { get; set; }

        public virtual UserAccount Account { get; set; } = null!;
        public virtual Bookmark Bookmark { get; set; } = null!;
        public virtual Message Message { get; set; } = null!;
    }
}
