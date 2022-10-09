using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class AttachedFile
    {
        public int FileId { get; set; }
        public string? FileName { get; set; }
        public string FileType { get; set; } = null!;
        public string FileHash { get; set; } = null!;
        public int MessageId { get; set; }

        public virtual Message Message { get; set; } = null!;
    }
}
