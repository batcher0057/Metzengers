using Metz_N_enger_WPF.Models.Abstract;
using Metz_N_enger_WPF.Models.DTO;
using MetzNenger44.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Metz_N_enger_WPF.otherscript
{
    public static class ChannelManager
    {
        public static string[] channels = new[] { "Accueil", "General", "Flash-info", "Helpdesk-technique", "Info-Covid-19", "MNS-Family" };

        //ajouter un nouveau canal
        public static void CreateChannel(MetzengerContext bdd, string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return;
            }

            if (!bdd.Channels.Where(c => c.ChannelName == name).Any())
            {
                bdd.Channels.Add(new Channel(name));
                bdd.SaveChanges();
                MessageBox.Show($"Le canal #{name}# a bien été ajouté !");
            }
            else
            {
                MessageBox.Show($"Ajout impossible !!! Le canal #{name}# existe déjà !");
            }
            
        }
        
        //supprimer un canal existant
        public static void DeleteChannel(MetzengerContext bdd, string name, UserDTOAccountPageBase myuser)
        {
            if (String.IsNullOrEmpty(name))
            {
                return;
            }

            try
            {
                List<Channel> channels = bdd.Channels.Where(c => c.ChannelName == name).ToList();

                foreach (Channel c in channels)
                {
                    MessagesManager.DeleteMessage(bdd, c);

                    bdd.Channels.Remove(c);
                    bdd.SaveChanges();
                    MessageBox.Show($"Le canal #{name}# a bien été supprimé !");
                }
            }

            catch (Exception e)
            {
                MessageBox.Show($"I'm sorry {myuser.Prenom},I'm affraid I can't do that ");
                MessageBox.Show(e.Message);
            }
        }

        //retourner tous les canaux
        public static ObservableCollection<string> OBCChannelString(MetzengerContext Bdd)
        {
            ObservableCollection<string> allChannels = new ObservableCollection<string>();
            
            foreach (Channel u in Bdd.Channels)
            {
                allChannels.Add(u.ChannelName);
            }

            return allChannels;
        }

        //
        //public static string ChannelChoice(MetzengerContext Bdd, List<Consult> notRead, TextBox mychan)
        //{
        //    Channel canal = new Channel();
        //    string toReturn = "";

        //    foreach (Message m in MessagesManager.ReadAMessageChan(notRead,Bdd))
        //    {
        //        canal = Bdd.Channels.Where(c => c.ChannelId == m.ChannelId).Single();
        //        canal.Messages.Add(m);
        //        toReturn += canal.Messages.ToString() + "\n";
        //    }

        //    return toReturn ;
        //}
        

        //retourner un DTO contenant uniquement les noms des canaux
        public static ObservableCollection<ChannelDTO> Mychannel(MetzengerContext Bdd, UtilisateurDTO user)
        {
            ObservableCollection<ChannelDTO> myListChan = new ObservableCollection<ChannelDTO>();
            List<Access> myAccessList = Bdd.Accesses.Where(a => a.AccountId == user.Id).ToList();
  
            foreach (Channel chan in Bdd.Channels)
            {
                foreach (Access a in myAccessList)
                {
                    if (a.ChannelId == chan.ChannelId)
                    {
                        myListChan.Add(new ChannelDTO(chan.ChannelId, chan.ChannelName, chan.Messages));
                        break;
                    }
                }
            }

            return myListChan;
        }
    
    

        //public static ObservableCollection<ChannelDTO> Mychannel(MetzengerContext Bdd)
        //{
        //    ObservableCollection<ChannelDTO> myListChan = new ObservableCollection<ChannelDTO>();

        //    foreach (Channel chan in Bdd.Channels)
        //    {
        //        myListChan.Add(new ChannelDTO(chan.ChannelId, chan.ChannelName, chan.Messages));
        //    }

        //    return myListChan;
        //}
    }
}
