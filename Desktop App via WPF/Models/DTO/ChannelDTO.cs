using MetzNenger44.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metz_N_enger_WPF.Models.DTO
{
    public class ChannelDTO
    {
        //propriétés
        public int IdChannel { get; set; }
        public string LibelleChannel { get; set; } = null!;

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserAccount> IdUtilisateurs { get; set; }
        
        //constructeur
        public ChannelDTO(int idChannel, string libelleChannel, ICollection<Message> messages)
        {
            IdChannel = idChannel;
            LibelleChannel = libelleChannel;
            Messages = messages;
            
        }

        //constructeur
        public ChannelDTO()
        {

        }
    }
}
