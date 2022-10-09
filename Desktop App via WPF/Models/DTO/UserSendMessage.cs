using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metz_N_enger_WPF.Models.DTO
{
    public class UserSendMessage
    {
        public int Id { get; set; }
        //public bool IsValidate { get; set; }
        public string  Pseudo { get; set; }

        public UserSendMessage(int id, string pseudo)
        {
            Id = id;
            Pseudo = pseudo ?? throw new ArgumentNullException(nameof(pseudo));
        }
    }
}
