using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metz_N_enger_WPF.Models.DTO
{
    public class UserDtoAccountPage : UserDTOAccountPageBase
    {
        public UserDtoAccountPage(int idUtilisateur, string email, string password, string? pseudo, string statutAdministratif, string nom, string prenom, string? telephone, bool validationCompte, int? idPromotion) : base(idUtilisateur, email, password, pseudo, statutAdministratif, nom, prenom, telephone, validationCompte, idPromotion)
        {
        }
    }
}
