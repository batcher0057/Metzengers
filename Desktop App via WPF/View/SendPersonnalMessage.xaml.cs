using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.Models;
using Metz_N_enger_WPF.Models.DTO;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metz_N_enger_WPF.View
{
    /// <summary>
    /// Logique d'interaction pour SendPersonnalMessage.xaml
    /// </summary>
    public partial class SendPersonnalMessage : Window
    {
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MetzengerContext Bdd { get; set; }
        public UtilisateurDTO MyUser { get; set; }
        public ObservableCollection<string> MyUsersList { get; set; }
        public SendPersonnalMessage(MetzengerContext bdd, UtilisateurDTO myUser)
        {
            InitializeComponent();
            Bdd = bdd;
            MyUser = myUser;
            MyUsersList = AccountManager.MyUsersList(Bdd);
            userChoice.ItemsSource = MyUsersList;
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
            this.Hide();
        }

        //déplacer la fenêtre de l'application par glisser-déposer
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();

        }

        private void sendPersonnalMessage_Click(object sender, RoutedEventArgs e)
        {
            MessagesManager.SendPersonnalMessages(sendPersonnalMessageTextBox,userChoice.SelectedItem.ToString(),MyUser,Bdd);
        }

       
    }
}
