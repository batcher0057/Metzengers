using MetzNenger44.Models;
using System;
using System.Collections.Generic;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public class UserAccountBase
    {
        public UserAccountBase()
        {
            Accesses = new HashSet<Access>();
            Archives = new HashSet<Archive>();
            Consults = new HashSet<Consult>();
            Invites = new HashSet<Invite>();
            Messages = new HashSet<Message>();
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
        public bool? IsDeleted { get; set; }
        public int? ClassId { get; set; }

        public virtual Classroom? Class { get; set; }
        public virtual ICollection<Access> Accesses { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Consult> Consults { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public UserAccountBase(string email, string password, string? nickname, string administrativeStatus, string lastName, string firstName, string? phone, int? classId)
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
            IsDeleted = false;
            ClassId = classId;
        }
    }
}