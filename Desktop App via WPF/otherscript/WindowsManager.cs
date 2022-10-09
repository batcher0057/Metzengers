using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Metz_N_enger_WPF.otherscript
{
    public static class WindowsManager
    {
        public static void CreateWindows(Window window, Window currentWidow)
        {
            Window ownedWindow = window;
            ownedWindow.Owner = currentWidow;
            ownedWindow.Show();
            currentWidow.Hide();
        }

        public static void CreateWindowsPersonnalMessages(Window window, Window currentWidow)
        {
            Window ownedWindow = window;
            ownedWindow.Owner = currentWidow;
            ownedWindow.Show();
        }
        
    }
}
