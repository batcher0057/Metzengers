using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger44.Models
{
    public partial class Message : MessageBase
    {
        public Message(string body, int accountId, int? channelId) : base(body, accountId, channelId)
        {

        }
    }
}
