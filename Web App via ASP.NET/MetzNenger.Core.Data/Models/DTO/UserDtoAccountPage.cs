using MetzNenger.Core.Data.Models.Abstract;

namespace MetzNenger.Core.Data.Models.DTO
{
    public class UserDtoAccountPage : UserDTOAccountPageBase
    {
        public UserDtoAccountPage(int idUtilisateur, string email, string password, string? pseudo, string statutAdministratif, string nom, string prenom, string? telephone, bool validationCompte, int? idPromotion) : base(idUtilisateur, email, password, pseudo, statutAdministratif, nom, prenom, telephone, validationCompte, idPromotion)
        {
        }
    }
}
