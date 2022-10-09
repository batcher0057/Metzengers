using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger44.Models
{
    public partial class Access : AccessBase
    {
        public Access(int accountId, int channelId, DateTime? firstConnection) : base(accountId, channelId, firstConnection)
        {
        }
    }
}
