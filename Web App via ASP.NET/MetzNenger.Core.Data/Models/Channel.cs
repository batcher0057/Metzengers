using MetzNenger.Core.Data.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class Channel : ChannelBase
    {
        public Channel()
        {
        }

        public Channel(string channelName) : base(channelName)
        {
        }

    }
}
