using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.Models;
using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Metz_N_enger_WPF.View
{
    
    public partial class AccountPageAdmin : Window
    {
        //propriétés
        public UserDTOAccountPageBase MyUser { get; set; }

        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MetzengerContext Bdd { get; set; }
        
        public ObservableCollection<string> MyUserNicknameList { get; set; }
        public ObservableCollection<string> MyChannellist { get; set; }

        //constructeur
        public AccountPageAdmin(UserDTOAccountPageBase myUser, MetzengerContext myBdd)
        {
            InitializeComponent();
            MyUser = myUser;
            DataContext = this;
            Bdd = myBdd;
            Combotextmethode();
            ComboTextChanString();
            //HAL9000.WelcomeMessage(welcomebox, MyUser, MyUserNicknameList);
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

        private void CreateChanClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(createChan.Text))
            {
                MessageBox.Show($"I'm sorry {MyUser.Prenom},I'm affraid I can't do that ");
            }
            else
            {
                ChannelManager.CreateChannel(Bdd, createChan.Text);
                Bdd.SaveChanges();
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Window ownedWindow = new SoftWare(ToolBox.CreateUserForDTO(Bdd, MyUser.Pseudo, MyUser.Password), Bdd);
            ownedWindow.Owner = this;
            ownedWindow.Show();
            Hide();
        }

        private void DeleteAccountClick(object sender, RoutedEventArgs e)
        {
            if (cbDelete.ItemsSource==null)
            {
                HAL9000.JeopardyMessage(MyUser.Prenom);
            }
            //TODO: faire une methode qui compare 2 date et si sup. à X jour alors on peut l'effacer.
        }

        private void DeleteChannelClick(object sender, RoutedEventArgs e)
        {
            if (deletchan.SelectedValue == null)
            {
                HAL9000.JeopardyMessage(MyUser.Prenom);
            }
            else
            {
                //sa soulève une erreur quand on essaye de d'effacer le chan quand on on a pas créé de nouveau message alors qu'il y en a deja
                ChannelManager.DeleteChannel(Bdd, deletchan.SelectedValue.ToString(), MyUser);
                Bdd.SaveChanges();
                ComboTextChanString();
            }
        }
        private void AccountTovalidate(object sender, RoutedEventArgs e)
        {
            if (accountToValidate.SelectedValue == null)
            {
                HAL9000.ErrorHalMessage(MyUser.Prenom);
            }
            else
            {
                UserAccount user = Bdd.UserAccounts.Where(u => u.Nickname == accountToValidate.SelectedValue.ToString()).Single();
                user.IsValidated = true;
                Bdd.SaveChanges();
                Combotextmethode();
            }
        }
        public void Combotextmethode()
        {
                MyUserNicknameList = AccountManager.AccountToValidateString(Bdd);
                accountToValidate.ItemsSource = MyUserNicknameList;
        }
        public void ComboTextChanString()
        {
                MyChannellist = ChannelManager.OBCChannelString(Bdd);
                deletchan.ItemsSource = MyChannellist;
        }
    }
}
