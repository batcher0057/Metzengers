using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Otherscript
{
    public static class ToolBox
    {
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
//        //valider la saisie de l'utilisateur
//        public static bool StringToTryParse(string sttp)
//        {
//            if (!int.TryParse(sttp, out int check))
//            {
//                MessageBox.Show("You must enter a number");
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }

//        //valider l'adresse email saisie par l'utilisateur
//        public static bool IsValidMail(string emailaddress)
//        {
//            try
//            {
//                MailAddress m = new MailAddress(emailaddress);

//                return true;
//            }
//            catch (FormatException)
//            {
//                MessageBox.Show("You must enter a valid email");
//                return false;
//            }
//        }

//        //créer une nouvelle page
//        public static void createpage(Window initWindows, Window currentWindow)
//        {
//            initWindows.Owner = initWindows;
//            initWindows.Show();
//            currentWindow.Hide(); //sert à cacher la fenetre
//        }

//        //vérifier si l'utilisateur existe déjà
//        public static bool IfUserExistInDb(MetzengerContext bdd, string user, string password)
//        {

//            bool checkUser = bdd.UserAccounts.Where(u => u.Email == user && u.Password == password && u.IsValidated == true
//                   | u.Email == user && u.Password == password && u.IsValidated == true).Any();
//            return checkUser;

//        }

//        //créer un conteneur avec les propriétés de l'utilisateur
//        public static UtilisateurDTO CreateUserForDTO(MetzengerContext bdd, string user, string password)
//        {//TODO mettre les isactive en place
//#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
//            UtilisateurBase userDto = bdd.UserAccounts.Where(u => (u.Email == user && u.Password == password)
//                   || (u.Nickname == user && u.Password == password)).SingleOrDefault();

//#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
//            UtilisateurDTO finalUserDTO = new UtilisateurDTO(userDto.AccountId, userDto.LastName, userDto.FirstName, userDto.IsAdmin, userDto.IsValidated);
//            return finalUserDTO;
//        }
//        public static UserDtoAccountPage CreateUserForDTOAccountPage(MetzengerContext bdd, string user, int idUtilisateur)
//        {
//#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
//            UtilisateurBase userDto = bdd.UserAccounts.Where(u => u.FirstName == user && u.AccountId == idUtilisateur).Single();
//#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
//            UserDtoAccountPage finalUserDTO = new UserDtoAccountPage(userDto.AccountId, userDto.Email, userDto.Password, userDto.Nickname,
//               userDto.AdministrativeStatus, userDto.LastName, userDto.FirstName, userDto.Phone, userDto.IsValidated, userDto.ClassId);
//            return finalUserDTO;
//        }
//        //créer un nouvel utilisateur
//        public static UtilisateurBase ReturnUser(UtilisateurDTO utilisateurDTO, MetzengerContext Bdd)
//        {
//            UtilisateurBase utilisateur = Bdd.UserAccounts.Where(u => u.AccountId == utilisateurDTO.Id).Single();
//            return utilisateur;
//        }


    }

}

