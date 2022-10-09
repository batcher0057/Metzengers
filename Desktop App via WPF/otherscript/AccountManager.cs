using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.View;
using MetzNenger44.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Metz_N_enger_WPF.otherscript
{
    public abstract class AccountManager
    {
        

        //retourner une liste contenant les utilisateurs non validés
        public static List<UserAccount> AccountToValidate(MetzengerContext Bdd)
        {
            List<UserAccount> myUsers = Bdd.UserAccounts.Where(u => u.IsValidated == false).ToList();

            return myUsers;
        }

        //retourner une collection contenant les utilisateurs non validés
        public static ObservableCollection<string> AccountToValidateString(MetzengerContext Bdd)
        {
            ObservableCollection<string> notValidatedUsers = new ObservableCollection<string>();
            List<UserAccount> myUsers = Bdd.UserAccounts.Where(u => u.IsValidated == false).ToList();

            foreach (UserAccount u in myUsers)
            {
                notValidatedUsers.Add(u.Nickname);
            }
            return notValidatedUsers;
        }
        
        //retourner l'index correspondant au status de l'utilisateur
        public static int StatusDtBinding(string status)
        {
            switch (status)
            {
                case "Student":
                    return 1;
                case "Management":
                    return 2;
                case "Speaker":
                    return 3;
                case "Other":
                    return 4;
                default:
                    return 0;
            }
        }

        //retourner une collection contenant les utilisateurs validés
        public static ObservableCollection<string> MyUsersList(MetzengerContext Bdd)
        {
            ObservableCollection<string> myUserList = new ObservableCollection<string>();

            foreach (UserAccount u in UserValidate(Bdd))
            {
                myUserList.Add(u.Nickname);
            }
            return myUserList;
        }

        //retourner une liste contenant les utilisateurs validés
        public static List<UserAccount> UserValidate(MetzengerContext Bdd)
        {
            List<UserAccount> validatedUsers = Bdd.UserAccounts.Where(u => u.IsValidated == true).ToList();
            MessageBox.Show(validatedUsers.Count.ToString());
            return validatedUsers;
        }

        //afficher la page de modification de l'email 
        public static void EmailModifier(MetzengerContext Bdd, Window mypage, UserDTOAccountPageBase MyUser)
        {
            Window ownedWindow = new ModifierPage(Bdd,MyUser);
            ownedWindow.Owner = mypage;
            ownedWindow.Show();
        }

        //afficher la page de modification du mot de passe
        public static void PasswordModifier(MetzengerContext Bdd, Window mypage, UserDTOAccountPageBase MyUser)
        {
            Window ownedWindow = new ModifierPassword(Bdd, MyUser);
            ownedWindow.Owner = mypage;
            ownedWindow.Show();
        }

        //attribuer les canaux généraux à un utilisateur
        public static void AddMainChannels(UserAccount user, MetzengerContext Bdd)
        {
            List<Channel> mainChannels = Bdd.Channels.Where(c => ChannelManager.channels.Contains(c.ChannelName)).ToList();
            
            foreach (Channel chan in mainChannels)
            {
                Access permission = new Access(user.AccountId, chan.ChannelId, DateTime.Now);
                Bdd.Add(permission);
                Bdd.SaveChanges();
            }
        }
    }
}
