using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metz_N_enger_WPF.Models.Abstract
{
    public abstract class UserDTOAccountPageBase
    {
        public int IdUtilisateur { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Pseudo { get; set; }
        public string StatutAdministratif { get; set; } = null!;
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string? Telephone { get; set; }
        public bool ValidationCompte { get; set; }
        public int? IdPromotion { get; set; } 

        public UserDTOAccountPageBase(int idUtilisateur, string email, string password, string? pseudo, string statutAdministratif, string nom, string prenom, string? telephone, bool validationCompte, int? idPromotion)
        {
            IdUtilisateur = idUtilisateur;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Pseudo = pseudo;
            StatutAdministratif = statutAdministratif ?? throw new ArgumentNullException(nameof(statutAdministratif));
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
            Prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            Telephone = telephone;
            ValidationCompte = validationCompte;
            IdPromotion = idPromotion;
        }
    }
}
