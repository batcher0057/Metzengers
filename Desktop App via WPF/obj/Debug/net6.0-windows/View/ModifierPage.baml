   M S B A M L   `   `   `  ????K  GMetz_N_enger_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Metz_N_enger_WPFMetz_N_enger_WPF  5   	   (    "Metz_N_enger_WPF.View.ModifierPage   5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Metz_N_enger_WPF     5   	     ? Title$  Acount??5	   	   $	??240??6   $	??700??6%      MaterialDesignBody#???   5
   	    ? AllowsTransparency$
 True??6]    ? WindowStyle$
 None=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	   ??5
   G   Z? .??5      ? .+?5   
   #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 15Q?6     MaterialDesignPaper#???  67   $??25q?6j   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=?5      6Q   )  #MaterialDesignThemes.Wpf.DialogHost  5   
   -   5          Name$ CrtHost??5   $      CloseOnClickAway$
 True??5   $   .??5      ?? .+?5      '  !MaterialDesignThemes.Wpf.PopupBox  $??Right=?6*   $??	0 30 30 0q?5   *      PlacementMode$ BottomAndAlignLeftEdges=?5   *   	   	StaysOpen$	 False??5   *   $??25??5   *   
   PopupContent.
 5      ?? .+?5      ?? $??	16 10 0 6q?6%    ?? Orientation$ 
Horizontal=?68   $??Center=?5   !   .+?5      ?? $??Center=?6(   $??	Dark Mode??6C   d? 5      -   5         d?Name$ CreatToggle??5   '    ? Cursor$
 Hand??5   +    ? ToolTip$ Enable Dark Mode??69   $??12 0 8 0q?6T    d? 	IsChecked 5   <   ?? *IsDarkTheme+6^   5      ?? 5      $ Having trouble Loggin In???6!   $??0 8 0 0q?5    !   $??Acount??5!   !   ?? 5"      -   5         ??Name$ 
Creat_Exit??5"   !   $ Close Application??65   $??Exit Application??5#   !   5$   !   5%      5&      ?? 5'      $??	20 0 20 0q?6   $
??Left=?60   $	??675??6K   .+?5(      ?? $??51??6!   ?? 5)      -   5         ??Name$ oldMail??5)      $??31??6/   $??10  5 q?6;   $	??231??6K   $??Center=?6W   $?? ??6t   
???   ?$??1q?6?   ?? 5*      -   5        $ newMail??5*      $??28??6/   $
??10 5q?6;   $	??231??6I   $??Center=?6U   $?? ??6r   
???   ?$??1q?6?   ?? 5+      -   5        $ newMailconfirm??5+      $??29??66   $	??231??6B   $
??10 5q?6N   $??Center=?6\   $?? ??6y   
???   ?$??1q?6?   ?? 5,      -   5        $ modifieremail??5,   <   $??Modifier??6   $	??219??60   6S   5-      5.      5/      50      51      