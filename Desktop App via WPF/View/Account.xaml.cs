using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.Models.DTO;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Metz_N_enger_WPF.View
{
    public partial class Account : Window
    {
        #region propriétés
        public UserDTOAccountPageBase MyUser { get; set; }

        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MetzengerContext Bdd { get; set; }
        #endregion

        //constructeur
        public Account(UserDtoAccountPage myUser, MetzengerContext myBdd)
        {
            InitializeComponent();
            MyUser = myUser;
            Bdd = myBdd;
            DataContext = this;
            statuscbx.ItemsSource = Enum.GetValues(typeof(administration));
            promotion.ItemsSource = Enum.GetValues(typeof(promotions));
            Dtbinding(MyUser);
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

        public void ModifierClick(object sender, RoutedEventArgs e)
        {
            WriteOn();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {   
            Change();
            Bdd.SaveChanges();
            MessageBox.Show(MyUser.IdPromotion.ToString());
        }
        public void Dtbinding(UserDTOAccountPageBase myUser)
        {
            pseudotbx.Text = myUser.Pseudo;
            //emailtbx.Text = myUser.Email;
            //passwordtbx.Password = myUser.Password;
            nomtbx.Text = myUser.Nom;
            teltbx.Text = myUser.Telephone;
            prenomtbx.Text = myUser.Prenom;
            //promotion.SelectedIndex = myUser.IdPromotion.Value;
            statuscbx.SelectedIndex = AccountManager.StatusDtBinding( myUser.StatutAdministratif);
        }
        public void WriteOn()
        {
            pseudotbx.IsReadOnly = false;
            
            passwordtbx.IsEnabled = true;
            nomtbx.IsReadOnly = false;
            teltbx.IsReadOnly = false;
            prenomtbx.IsReadOnly = false;
            statuscbx.IsEnabled = true;
            promotion.IsEnabled = true;
        }
        public void Change()
        {
            UserAccountBase account = Bdd.UserAccounts.Where(u => u.AccountId == MyUser.IdUtilisateur).SingleOrDefault();
            
            account.Phone = teltbx.Text;
            account.Nickname = pseudotbx.Text;
            account.FirstName = prenomtbx.Text;
            account.LastName = nomtbx.Text;
            account.ClassId = promotion.SelectedIndex;
            account.AdministrativeStatus = statuscbx.SelectedValue.ToString();
            
        }

        public void ExitClick(object sender, RoutedEventArgs e)
        {
            
            Window ownedWindow = new SoftWare(ToolBox.CreateUserForDTO(Bdd, MyUser.Pseudo, MyUser.Password), Bdd);
            ownedWindow.Owner = this;
            ownedWindow.Show();
            Hide();
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void emailClick(object sender, RoutedEventArgs e)
        {
            AccountManager.EmailModifier(Bdd,this,MyUser);
        }

        private void passwordtbx_Click(object sender, RoutedEventArgs e)
        {
            AccountManager.PasswordModifier(Bdd, this, MyUser);
        }
    }
}
