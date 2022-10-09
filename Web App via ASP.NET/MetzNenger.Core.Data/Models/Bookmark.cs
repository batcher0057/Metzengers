using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class Bookmark
    {
        public Bookmark()
        {
            Archives = new HashSet<Archive>();
        }

        public int BookmarkId { get; set; }

        public virtual ICollection<Archive> Archives { get; set; }
    }
}
