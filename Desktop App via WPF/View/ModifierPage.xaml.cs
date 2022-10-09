using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.Models;
using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour ModifierPage.xaml
    /// </summary>
    public partial class ModifierPage : Window
    {
        public UserAccount MyUser { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MetzengerContext Bdd { get; set; }
        public ModifierPage(MetzengerContext bdd, UserDTOAccountPageBase myUser)
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

        private void modifieremail_Click(object sender, RoutedEventArgs e)
        {
            string oldmailH = ToolBox.HashString(oldMail.Text);
            if (Bdd.UserAccounts.Where(u => u.Email == oldmailH).Any())
            {
                if (newMail.Text== newMailconfirm.Text)
                {
                    MyUser.Email = ToolBox.HashString(newMailconfirm.Text);
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
