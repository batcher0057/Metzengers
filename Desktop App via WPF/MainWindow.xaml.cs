using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System;
using System.Windows;
using System.Windows.Input;
namespace Metz_N_enger_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// j'ai utilisé le nuget materialDesignTheme
    /// http://materialdesigninxaml.net
    /// https://youtu.be/hu7QG8OEOuk
    public partial class MainWindow : Window
    {
        //propriétés
        public MetzengerContext Bdd { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        //constructeur
        public MainWindow()
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


        //vérifier les identifiants saisis par l'utilisateur
        private void logginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Password))
            {
                return;
            }
            
            if (ToolBox.IfUserExistInDb(Bdd, ToolBox.HashString(txtUserName.Text), ToolBox.HashString(txtPassword.Password)))
            {
                Window ownedWindow = new SoftWare(ToolBox.CreateUserForDTO(Bdd, ToolBox.HashString(txtUserName.Text), ToolBox.HashString(txtPassword.Password)), Bdd);
                ownedWindow.Owner = this;
                ownedWindow.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Vos identifiants ne sont pas valides, veuillez contacter votre administrateur");
                txtUserName.Text = "";
                txtPassword.Password = "";
            }
        }

        //créer une fenêtre de création de compte
        private void signBtn_Click(object sender, RoutedEventArgs e)
        {
            Window ownedWindow = new RegisterWidows();
            ownedWindow.Owner = this;
            ownedWindow.Show();
            Hide();
        }

        private void forgottenPassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
