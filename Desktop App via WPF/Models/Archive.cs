using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger44.Models
{
    public partial class Archive : ArchiveBase
    {
        public Archive(int accountId, int messageId, int bookmarkId) : base(accountId, messageId, bookmarkId)
        {

        }
    }
}
