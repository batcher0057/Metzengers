using MetzNenger44.Models;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class AttachedFileBase
    {
        public AttachedFileBase(string? fileName, string fileType, string fileHash)
        {
            FileName = fileName;
            FileType = fileType;
            FileHash = fileHash;
        }

        public int FileId { get; set; }
        public string? FileName { get; set; }
        public string FileType { get; set; } = null!;
        public string FileHash { get; set; } = null!;
        public int MessageId { get; set; }

        public virtual Message Message { get; set; } = null!;
    }
}