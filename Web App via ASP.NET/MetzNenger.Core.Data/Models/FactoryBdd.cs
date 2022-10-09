using MetzNenger.Core.Data.Models.Abstract;

namespace MetzNenger.Core.Data.Models
{
    public static class FactoryBdd
    {
        public static UtilisateurBase CreateUser(string mail, string password, string pseudo, string nom, string prenom, string tel)
        {
            return new UserAccount(mail, password, pseudo, nom, prenom, tel, "");
        }
        public static Consult CreateRead(int accountId, int idMessage)
        {
            Consult c = new Consult(accountId, idMessage);
            c.ReadingDate = DateTime.Now;
            return c;
        }
        //public static AccountPageAdmin CreateAccountAdminPAge(MetzengerContext bdd,string MyUser, int id)
        //{
        //    return new AccountPageAdmin(ToolBox.CreateUserForDTOAccountPage(bdd, MyUser, id), bdd);
        //}
        //public static Account CreateAccountPage(MetzengerContext Bdd,string Prenom,int ID)
        //{
        //    return new Account(ToolBox.CreateUserForDTOAccountPage(Bdd, Prenom, ID), Bdd);
        //}
        //public static SendPersonnalMessage CreateWindowPersonnalMessage(MetzengerContext Bdd,UtilisateurDTO MyUser)
        //{ 
        //    return new SendPersonnalMessage(Bdd, MyUser);
        //}
        //public static MainWindow CreateMainWindow()
        //{
        //    return new MainWindow();
        //}

    }
}
