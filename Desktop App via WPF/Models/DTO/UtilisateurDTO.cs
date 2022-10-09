using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metz_N_enger_WPF.Models.DTO
{
    public class UtilisateurDTO
    {
        //propriétés
        public int Id { get; set; }
        public string  Nom { get; set; }
        public string Prenom { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsValidated { get; set; }

        //constructeur
        public UtilisateurDTO(int id, string nom, string prenom, bool isAdmin, bool isValidated)
        {
            Id = id;
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
            Prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            IsAdmin = isAdmin;
            IsValidated = isValidated;
        }
    }
}
