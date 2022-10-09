using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models.Abstract
{
    public  class UtilisateurBase
    {

        public UtilisateurBase()
        {
            Archives = new HashSet<Archive>();
            Consults = new HashSet<Consult>();
            Messages = new HashSet<Message>();
            Channels = new HashSet<Channel>();
        }

        public int AccountId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Nickname { get; set; }
        public string AdministrativeStatus { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Phone { get; set; }
        public bool IsValidated { get; set; }
        public bool IsAdmin { get; set; }
        //public bool is_invited { get; set; }
        public int? ClassId { get; set; }
        

        public virtual Classroom? Class { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Consult> Consults { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }

        protected UtilisateurBase( string email, string password, string? nickname, string administrativeStatus, string lastName, string firstName, string? phone)
        {

            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Nickname = nickname;
            AdministrativeStatus = administrativeStatus ?? throw new ArgumentNullException(nameof(administrativeStatus));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Phone = phone;
            IsValidated = false;
            IsAdmin = false;
            //is_invited = false;

        }
        //public UtilisateurBase()
        //{

        //}
    }
}