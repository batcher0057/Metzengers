using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger44.Models
{
    public partial class AttachedFile : AttachedFileBase
    {
        public AttachedFile(string? fileName, string fileType, string fileHash) : base(fileName, fileType, fileHash)
        {

        }
    }
}
