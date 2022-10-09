using MetzNenger.Core.Data.Models.Abstract;

namespace MetzNenger.Core.Data.Models
{
    public class UserAccount : UtilisateurBase
    {
        public UserAccount()
        {
        }

        public UserAccount(string email, string password, string? nickname, string administrativeStatus, string lastName, string firstName, string? phone) : base(email, password, nickname, administrativeStatus, lastName, firstName, phone)
        {

        }
        
    }
}
