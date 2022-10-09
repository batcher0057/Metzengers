using Metz_N_enger_WPF.Models.DTO;
using MetzNenger44.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Metz_N_enger_WPF.otherscript
{
    public static class MessagesManager
    {
        
        //envoyer un message
        public static void SendAMessage(string body, int idChannel, UtilisateurDTO utilisateurDTO, MetzengerContext Bdd, List<Consult> allReadyRead)
        {
            if (SizeBody(body) == true)
            {
                Message message = new Message(body, utilisateurDTO.Id, idChannel);
                messagesRead(allReadyRead, message, Bdd);
                Bdd.SaveChanges();
            }
            else
            {
                MessageBox.Show("Please enter a text of less than one thousand characters");
                body = "";
            }
            
        }
        
        //effacer un message
        public static void DeleteMessage(MetzengerContext bdd, Channel chan)
        {
            List<Message> messages = bdd.Messages.Where(m => m.ChannelId == chan.ChannelId).ToList();

            foreach (Message m in messages)
            {
                chan.Messages.Remove(m);
                bdd.SaveChanges();
            }
        }

        //notification message 
        public static void UHaveAMessage(TextBlock txtBlock, List<Consult> notRead, Button button)
        {
            if (notRead.Where(nr => nr.ReadingDate == null).Any())
            {
                txtBlock.Visibility = Visibility.Visible;
                button.IsEnabled = true;
            }
            else
            {
                txtBlock.Visibility = Visibility.Collapsed;
                button.IsEnabled = false;
            }
        }
        
        //retourner une liste contenant tous les messages non lus du canal sélectionné
        public static List<Message> ReadAMessageChan(List<Consult> toRead, MetzengerContext Bdd)
        {
            List<Message> messages = new List<Message>();

            foreach (Consult c in toRead)
            {
                Message message = Bdd.Messages.Where(m => m.MessageId == c.MessageId).Single();
                c.ReadingDate = DateTime.Now;
                messages.Add(message);
            }

            return messages;
        }

        //horodater nos messages propres pour éviter des notifications superflues
        public static void messagesRead(List<Consult> messages, Message message, MetzengerContext Bdd)
        {
            foreach (Consult c in messages)
            {
                if (c.MessageId == message.MessageId && c.ReadingDate == null)
                {
                    c.ReadingDate = DateTime.Now;
                    Bdd.SaveChanges();
                }
            }
        }


        public static void MessagesReadClick(List<Consult> notRead, MetzengerContext Bdd, TextBox chan)
        {
            //foreach (Consult c in notRead)
            //{
            //    ChannelDTO temp = Bdd.Messages.Where(m => m.MessageId == c.MessageId).Select(x => new ChannelDTO
            //    {
            //        IdChannel = x.Channel.ChannelId,
            //        LibelleChannel = x.Channel.ChannelName,
            //        IdUtilisateurs = x.Channel.Accounts,
            //        Messages = x.Channel.Messages
            //    }).FirstOrDefault();

            //    c.ReadingDate = DateTime.Now;
            //    Bdd.SaveChanges();

            //    chan.Text += $"{c.Message.Channel.ChannelName}: {c.Message.Body}\n";
            //}
        }
        public static void SendPersonnalMessages(TextBox message, string receiver, UtilisateurDTO sender, MetzengerContext bdd)
        {
            UserAccount uDTOReceiver = bdd.UserAccounts.Where(u => u.Nickname == receiver).SingleOrDefault();
            if (SizeBody(message.Text) == true)
            {
                Channel newChannel = new Channel($"{sender.Prenom}_X_{uDTOReceiver.Nickname}");
                bdd.Channels.Add(newChannel);
                bdd.SaveChanges();

                Message newMessage = new Message(message.Text, uDTOReceiver.AccountId, newChannel.ChannelId);
                bdd.Messages.Add(newMessage);
                bdd.SaveChanges();

                bdd.Consults.Add(new Consult(uDTOReceiver.AccountId, newMessage.MessageId));
                bdd.SaveChanges();
            }
            else
            {
                MessageBox.Show("Please enter a text of less than one thousand characters");
                message.Text = "";
            }
        }
        /// <summary>
        /// verifie si le corp tu texte à une taille en dessous de 1000 renvois un bool
        /// </summary>
        /// <param name="corps"></param>
        /// <returns></returns>
        public static bool SizeBody(string corps)
        {
            
            if (corps.Count() > 1000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
