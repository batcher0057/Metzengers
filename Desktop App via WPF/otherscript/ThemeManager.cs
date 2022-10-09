using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metz_N_enger_WPF.otherscript
{
    public static class ThemeManager
    {
        //détecter le thème actuel et basculer sur l'autre thème
        public static void SwitchTheme(ITheme iTheme)
        {
            if (iTheme.GetBaseTheme() == BaseTheme.Dark)
            {
                iTheme.SetBaseTheme(Theme.Light);
            }
            else
            {
                iTheme.SetBaseTheme(Theme.Dark);
            }
        }
    }
}
