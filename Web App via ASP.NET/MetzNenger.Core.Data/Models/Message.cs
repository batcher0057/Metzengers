using MetzNenger.Core.Data.Models.DTO.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class Message : MessageBase
    {
        public Message(string? body, int accountId, int? channelId) : base(body, accountId, channelId)
        {
        }
    }
}
