using Metz_N_enger_WPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Metz_N_enger_WPF.Models.DTO;

namespace Metz_N_enger_WPF.otherscript
{
    public static  class HAL9000
    {
        public static void WelcomeMessage (TextBlock myTextB, UserDTOAccountPageBase myUser, ObservableCollection<string> myUserNicknameList)
        {
            myTextB.Text = $"Hello {myUser.Prenom},I am Completely operational, and all my circuits are functioning perfectly. You have {myUserNicknameList.Count} account to validate";
        }
        public static void ErrorHalMessage(string myUser)
        {
            MessageBox.Show($"I'm sorry {myUser},I'm affraid I can't do that ");
        }
        public static void ConfirmHallMessage(string myUser)
        { 
            MessageBox.Show($"Are you sure {myUser}, you are making the right decision?" );
        }
        public static void JeopardyMessage(string myUser)
        {
            MessageBox.Show($"This Decision {myUser}, is too important for me to allow you to jeopardize it.");
        }
    }
}
