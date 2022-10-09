using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.Models.DTO;
using MetzNenger44.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Metz_N_enger_WPF
{
    public static class ToolBox
    {

        //créer l'empreinte SHA256 d'une chaine de caractères
        public static string HashString(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            string salt = "lintelligenceartificielleestlecontrairedelabetisenaturelle";

            System.Text.StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(text + salt));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        //valider la saisie du numéro de téléphone
        public static bool StringToTryParse(string sttp)
        {
            if (String.IsNullOrEmpty(sttp))
            {
                return true;
            }

            if (!int.TryParse(sttp, out int check))
            {
                MessageBox.Show("Vous devez entrer un téléphone valide");
                return false;
            }
            else
            {
                return true;
            }
        }

        //valider la saisie de l'adresse email
        public static bool IsValidMail(string emailaddress)
        {
            if (String.IsNullOrEmpty(emailaddress))
            {
                return false;
            }

            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Vous devez entrer un email valide");
                return false;
            }
        }

        //créer une nouvelle page
        public static void createpage(Window initWindows, Window currentWindow)
        {
            initWindows.Owner = initWindows;
            initWindows.Show();
            currentWindow.Hide(); //sert à cacher la fenetre
        }

        //vérifier si l'utilisateur existe déjà
        public static bool IfUserExistInDb(MetzengerContext bdd, string user, string password)
        {
            bool existingUser = bdd.UserAccounts.Where(u => u.Email == user && u.Password == password).Any();

            return existingUser;
        }

        //créer un conteneur avec les propriétés de l'utilisateur
        public static UtilisateurDTO CreateUserForDTO(MetzengerContext bdd, string user, string password)
        {
            UserAccountBase userDto = bdd.UserAccounts.Where(u => (u.Email == user && u.Password == password )
                   ||( u.Nickname == user && u.Password == password)).SingleOrDefault();
            
            UtilisateurDTO finalUserDTO = new UtilisateurDTO(userDto.AccountId, userDto.LastName, userDto.FirstName, userDto.IsAdmin,userDto.IsValidated);

            return finalUserDTO;
        }

        //créer un conteneur avec les propriétés de l'utilisateur
        public static UserDtoAccountPage CreateUserForDTOAccountPage(MetzengerContext bdd, string user, int idUtilisateur)
        {
            UserAccountBase userDto = bdd.UserAccounts.Where(u => u.FirstName == user && u.AccountId == idUtilisateur).Single();

            UserDtoAccountPage finalUserDTO = new UserDtoAccountPage(userDto.AccountId,userDto.Email,userDto.Password,userDto.Nickname,
               userDto.AdministrativeStatus, userDto.LastName, userDto.FirstName,userDto.Phone,userDto.IsValidated,userDto.ClassId);

            return finalUserDTO;
        }

        //créer un nouvel utilisateur
        public static UserAccountBase ReturnUser(UtilisateurDTO utilisateurDTO, MetzengerContext Bdd)
        {
            UserAccountBase utilisateur = Bdd.UserAccounts.Where(u => u.AccountId == utilisateurDTO.Id).Single();

            return utilisateur;
        }
    }
}

