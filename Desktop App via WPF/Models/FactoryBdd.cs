using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.Models.DTO;
using Metz_N_enger_WPF.View;
using MetzNenger44.Models;
using System;

namespace Metz_N_enger_WPF.Models
{
    public static class FactoryBdd
    {
        public static UserAccountBase CreateUser(string mail, string password, string pseudo, string status, string nom, string prenom, string tel)
        {
            return new UserAccount(mail, password, pseudo, status, nom, prenom, tel, null);
        }

        public static Consult CreateRead(int accountId, int idMessage)
        {
            Consult c = new Consult(accountId, idMessage);
            c.ReadingDate = DateTime.Now;

            return c;
        }

        public static AccountPageAdmin CreateAccountAdminPAge(MetzengerContext bdd, string MyUser, int id)
        {
            return new AccountPageAdmin(ToolBox.CreateUserForDTOAccountPage(bdd, MyUser, id), bdd);
        }

        public static Account CreateAccountPage(MetzengerContext Bdd, string Prenom, int ID)
        {
            return new Account(ToolBox.CreateUserForDTOAccountPage(Bdd, Prenom, ID), Bdd);
        }

        public static SendPersonnalMessage CreateWindowPersonnalMessage(MetzengerContext Bdd, UtilisateurDTO MyUser)
        {
            return new SendPersonnalMessage(Bdd, MyUser);
        }

        public static MainWindow CreateMainWindow()
        {
            return new MainWindow();
        }
    }
}
