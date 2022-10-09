using MetzNenger44.Models;
using System.Collections.Generic;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class BookmarkBase
    {
        public BookmarkBase()
        {

        }

        public int BookmarkId { get; set; }

        public virtual ICollection<Archive> Archives { get; set; }
    }
}