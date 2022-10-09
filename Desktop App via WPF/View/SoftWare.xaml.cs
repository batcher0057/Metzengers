using MaterialDesignThemes.Wpf;
using Metz_N_enger_WPF.Models;
using Metz_N_enger_WPF.Models.DTO;
using Metz_N_enger_WPF.otherscript;
using MetzNenger44.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Metz_N_enger_WPF
{
    /// <summary>
    /// Logique d'interaction pour SoftWare.xaml
    /// </summary>
    public partial class SoftWare : Window
    {
        //propriétés
        public UtilisateurDTO MyUser { get; set; }

        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MetzengerContext Bdd { get; set; }
        public ObservableCollection<ChannelDTO> MyChannels { get; set; }
        public List<Consult> notRead { get; set; }
        public List<Message> read { get; set; }

        //constructeur
        public SoftWare(UtilisateurDTO myUser, MetzengerContext myBdd)
        {
            InitializeComponent();
            MyUser = myUser;
            DataContext = this;
            welcomeBox.Text = $"Bonjour : {MyUser.Prenom}";
            Bdd = myBdd;

            MyChannels = ChannelManager.Mychannel(this.Bdd, MyUser);
            chanList.ItemsSource = MyChannels;

            notRead = Bdd.Consults.Where(er => er.ReadingDate == null && er.AccountId==MyUser.Id).ToList();
            read = new List<Message>();
            MessagesManager.UHaveAMessage(MyFadingText,notRead,haveAMessages);
            //MessageBox.Show(notRead.Count.ToString());
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
        

        //Envoyer un message
        private void SendClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ChannelDTO chanchoice = (ChannelDTO)chanList.SelectedItem;
                ChannelDTO chantext = MyChannels.Where(c => c.LibelleChannel == chanchoice.LibelleChannel).Single();
                Message read = new Message($"{MyUser.Prenom}: {txtBoxSend.Text}", MyUser.Id, chantext.IdChannel);

                MessagesManager.messagesRead(notRead,read,Bdd);
                //Bdd.Messages.Add(new Message($"{MyUser.Prenom}: {txtBoxSend.Text}", MyUser.Id, chantext.IdChannel));
                Bdd.Messages.Add(read);
                Bdd.SaveChanges();

                Bdd.Consults.Add(FactoryBdd.CreateRead(MyUser.Id, read.MessageId));
                Bdd.SaveChanges();

                chan.Text += $"\n{MyUser.Prenom}: {txtBoxSend.Text}";
                txtBoxSend.Text = "Enter your Message: ";
            }
            catch (NullReferenceException)
            {
                HAL9000.ErrorHalMessage(MyUser.Prenom);
            }
        }

        //Sélectionner un canal et affiche son contenu
        private void chanList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            chan.Text = "";
            ChannelDTO chanchoice = (ChannelDTO)chanList.SelectedItem;
            List<Message> chantext = Bdd.Messages.Where(m => m.ChannelId == chanchoice.IdChannel).ToList();

            foreach (Message m in chantext)
            {
                chan.Text += $"\n{m.Body}";
                foreach (Consult item in notRead)
                {
                    if (item.ReadingDate == null)
                    {
                        item.ReadingDate = DateTime.Now;
                        Bdd.SaveChanges();
                    }
                }
            }
        }

        private void HaveAMessages_Click(object sender, RoutedEventArgs e)
        {
            MessagesManager.MessagesReadClick(notRead, Bdd, chan);
            MessagesManager.UHaveAMessage(MyFadingText, notRead,haveAMessages);
        }

        private void LogOutClick(object sender, RoutedEventArgs e)
        {
            WindowsManager.CreateWindows(FactoryBdd.CreateMainWindow(), this);
        }

        private void AcountClick(object sender, RoutedEventArgs e)
        {
            if (MyUser.IsAdmin == true)
            {
                WindowsManager.CreateWindows(FactoryBdd.CreateAccountAdminPAge(Bdd, MyUser.Prenom, MyUser.Id), this);
            }
            else
            {
                WindowsManager.CreateWindows(FactoryBdd.CreateAccountPage(Bdd, MyUser.Prenom, MyUser.Id), this);
            }

        }

        private void SendPersonalMessages(object sender, RoutedEventArgs e)
        {
            WindowsManager.CreateWindowsPersonnalMessages(FactoryBdd.CreateWindowPersonnalMessage(Bdd, MyUser), this);
        }

        //public static void UHaveAMessageTimmer(object source, ElapsedEventArgs e)
        //{
        //    if (notRead.Where(nr => nr.ReadingDate == null).Any())
        //    {
        //        MyFadingText.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        MyFadingText.Visibility = Visibility.Collapsed;
        //    }
        //}

    }
}