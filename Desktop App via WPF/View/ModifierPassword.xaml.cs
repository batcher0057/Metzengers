using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Metz_N_enger_WPF.View
{
    /// <summary>
    /// Logique d'interaction pour ModifierPage.xaml
    /// </summary>
    public partial class ModifierPassword : Window
    {
        public UserAccount MyUser { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MetzengerContext Bdd { get; set; }
        public ModifierPassword(MetzengerContext bdd, UserDTOAccountPageBase myUser)
        {
            InitializeComponent();
            Bdd = bdd;
            MyUser= bdd.UserAccounts.Where(u=>u.AccountId==myUser.IdUtilisateur).SingleOrDefault();
        }
        //basculer entre les 2 thèmes
        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            ThemeManager.SwitchTheme(theme);
            paletteHelper.SetTheme(theme);
        }

        //quitter l'application
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //déplacer la fenêtre de l'application par glisser-déposer
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void ModifierPassword_Click(object sender, RoutedEventArgs e)
        {
            string email = ToolBox.HashString(emailtxt.Text);
            if (Bdd.UserAccounts.Where(u => u.Email == email).Any())
            {
                if (newpassword.Password== newpasswordConfirm.Password)
                {
                    MyUser.Password = ToolBox.HashString(newpasswordConfirm.Password);
                    Bdd.SaveChanges();
                }
                else
                {
                    MessageBox.Show("voir avec la chaudiere pour un message ");
                }
            }
            else
            {
                MessageBox.Show("voir avec la chaudiere pour un message mais un autre ");
            }
        }
    }
}
