using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.Models;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace Metz_N_enger_WPF
{
    /// <summary>
    /// Logique d'interaction pour RegisterWidows.xaml
    /// </summary>
    public partial class RegisterWidows : Window
    {
        //propriétés
        public MetzengerContext Bdd { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        //constructeur
        public RegisterWidows()
        {
            InitializeComponent();
            Bdd = new MetzengerContext();
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

        //Ajouter un utilisateur à la base de données
        private void CreateClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ConfirmPassword.Password) || String.IsNullOrEmpty(Password.Password) || String.IsNullOrEmpty(Mail.Text) || String.IsNullOrEmpty(Nom.Text) || String.IsNullOrEmpty(Prenom.Text) || String.IsNullOrEmpty(Pseudo.Text))
            {
                MessageBox.Show("Merci de remplir tous les champs obligatoires");
                return;
            }

            if (ConfirmPassword.Password == Password.Password && ToolBox.StringToTryParse(Tel.Text) == true && ToolBox.IsValidMail(Mail.Text) == true) 
            {
                UserAccount tetu = new UserAccount(ToolBox.HashString(Mail.Text), ToolBox.HashString(Password.Password), Pseudo.Text, "", Nom.Text, Prenom.Text, Tel.Text, null);
                Bdd.UserAccounts.Add(tetu);
                Bdd.SaveChanges();

                AccountManager.AddMainChannels(tetu, Bdd);
                Bdd.SaveChanges();

                MessageBox.Show("Le nouveau compte a bien été créé");

                Window ownedWindow = new MainWindow();
                ownedWindow.Owner = this;
                ownedWindow.Show();
                Hide();
            }
            else
            {
                if (ConfirmPassword.Password != Password.Password)
                {
                    MessageBox.Show("Votre mot de passe n'est pas valide");
                    Password.Password = "";
                    ConfirmPassword.Password = "";
                }
                if (ToolBox.StringToTryParse(Tel.Text) == false)
                {
                    Tel.Text = "";
                }
                if (ToolBox.IsValidMail(Mail.Text) == false)
                {
                    Mail.Text = "";
                }
            }
            
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Window ownedWindow = new MainWindow();
            ownedWindow.Owner = this;
            ownedWindow.Show();
            Hide();
        }
    }
}