   M S B A M L   `   `   `  ????K  GMetz_N_enger_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Metz_N_enger_WPFMetz_N_enger_WPF  5   	       Metz_N_enger_WPF.SoftWare   5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Metz_N_enger_WPF     5   	     ? Title$  Acount??5	   	   $	??700??6   $	??540??6%      MaterialDesignBody#???   5
   	    ? AllowsTransparency$
 True??6]    ? WindowStyle$
 None=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	   ??5
   G   Z? .??5      ? .+?5   
   #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 15Q?6     MaterialDesignPaper#???  67   $??25q?6j   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=?5      6Q   )  #MaterialDesignThemes.Wpf.DialogHost  5   
   -   5          Name$ CrtHost??5   $      CloseOnClickAway$
 True??5   $   .??5      ?? .+?5      '  !MaterialDesignThemes.Wpf.PopupBox  $??Right=?6*   $??	0 30 30 0q?5   *      PlacementMode$ BottomAndAlignLeftEdges=?5   *   	   	StaysOpen$	 False??5   *   $??25??5   *   
   PopupContent.
 5      ?? .+?5      ?? $??	16 10 0 6q?6%    ?? Orientation$ 
Horizontal=?68   $??Center=?5   !   .+?5      ?? $??Center=?6(   $??	Dark Mode??6C   d? 5      -   5         d?Name$ CreatToggle??5   '    ? Cursor$
 Hand??5   +    ? ToolTip$ Enable Dark Mode??69   $??12 0 8 0q?6T    d? 	IsChecked 5   <   ?? *IsDarkTheme+6^   5      ?? 5       $ Having trouble Loggin In???6!   $??0 8 0 0q?5!   !   $??Account??5"   !   ?? 5#      -   5         ??Name$ 
Creat_Exit??5#   !   $ Close Application??65   $??Exit Application??5$   !   5%   !   5&      5'      ? 5(      $	??381??6   $	??450??6+   $??Center=?68   .+?5)      ?? -   5         ??Name$ chanList??5)   B    ?? DisplayMemberPath$ LibelleChannel??6   $y?Visible=?6T   $??Center=?6i   $	??300??6?   $	??144??6?   $??20q?6?   $??Center=?6?   5;      ?? 5<      -   5         ??Name$
 chan??5<      $??1q?6,    ?? 
IsReadOnly$
 True??6@    ?? TextWrapping$
 Wrap=?6R   $?? ??6f   $	??310??6n   $	??294??6{   ?? 5=      -   5        $ 
txtBoxSend??5=      $??
60 20 0 20q?63   $ WrapWithOverflow=?6G   $??Ecrivez votre message??6g   $	??207??6?   $ Arrow??6?    ?? 	MaxLength$
 1000??6?    ?? MaxLines$ 5??6?   $??41??6?   ?? 5>      -   5        $??Envoyer??5>      $??28??6/   $	??170??6;   6G   5?      ?? 5@      $	??484??6   $	??239??6)   $ Vertical=?66   $??Stretch=?6M   $??Stretch=?6k   .+?5A      ?? $
??Left=?6   $	??157??6:   $	??222??6H   $??20q?6T   $
??Left=?6a   .@?5B      ?? -   5        $??Gestion Administrateur??5B   !   $	??197??6V   ?? 5C      -	   5        $??Envoyer un message privé??5C   !   $	??197??6a   ?? 5D      -
   5        $??Déconnexion??5D   !   $	??197??6K   5E      ?? 5G      -   5         ??Name$ 
welcomeBox??5G   0   $??20(?6!   $
??Wrap=?6D   $?? ??6X   $	??480??6`   $??30??6l   ?? 5H      -   5        $ haveAMessages??5H   /   ${?False??6   
?????? $??28??6_   $	??191??6k   $??0q?6w   .??5I      ?? -   5        $ MyFadingText??5I   :   $y?Visible=?6%   $	??159??6P   $??22??6\   $??15(?6h   $
??Bold"?6v   
??? ??? ? Triggers 5J      :? 5K   "    :? RoutedEvent$ FrameworkElement.Loaded??6/   .[?5L   &   ?? .??5M   *   ?? .??5N   .   W?  ?? 
TargetName$ MyFadingText??6>    ?? TargetProperty$ (UIElement.Opacity)?6c    W? From 1.06?   	 W? To 0.06?    g? Duration$ 0:0:5D?6?     g? AutoReverse$
  True??6?   ! g? RepeatBehavior$! Forever??6?   5O   +   5P   '   5Q   #   ?? 5R   3   $?Vous avez un Message.??67   6W   5S      ?? 5T      $??/logo-mns.png??6   $??23??63   $	??482??6?   5U      5V      5W      5X      5Y      