using MetzNenger.Core.Data.Models;

namespace MetzNenger.Web.UI.Models
{
    public class UtilisateurModels : UserAccount
    {
        public UtilisateurModels(string email, string password, string? nickname, string administrativeStatus, string lastName, string firstName, string? phone) : base(email, password, nickname, administrativeStatus, lastName, firstName, phone)
        {
        }
    }
}
