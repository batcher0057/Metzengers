   M S B A M L   `   `   `  ????K  GMetz_N_enger_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Metz_N_enger_WPFMetz_N_enger_WPF  5   	   #    Metz_N_enger_WPF.View.Account   5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Metz_N_enger_WPF     5   	     ? Title$  Acount??5	   	   $	??700??6   $	??540??6%      MaterialDesignBody#???   5
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
Creat_Exit??5#   !   $ Close Application??65   $??Exit Application??5$   !   5%   !   5&      5'      ?? 5(      $	??108??6   $??/View/logo-mns.png??6%   $??Uniform=?6A   $	??428??6S   $??50q?6_   ? 5)      $	??480??6   $	??401??6(   .+?5*      ?? $
??Wrap=?6!   $??Pseudo :??65   $??37??6E   $	??238??6Q   $??30(?6]   ?? 5+      -   5         ??Name$ 	pseudotbx??5+       ?? 
IsReadOnly$
 True??61    ?? TextWrapping$
 Wrap=?6C   $?? ??6W   $??37??6_   $	??242??6k   $ Arrow??6w   ?? 5,      $
??Wrap=?6    $??Nom :??64   $??37??6A   $	??238??6M   $??30(?6Y   ?? 5-      -   5        $ nomtbx??5-      $
 True??6.   $	??240??6@   ?? 5.      $??	Prénom :??6!   $	??240??61   $??30(?6=   ?? 5/      -   5        $ 	prenomtbx??5/   0   $
 True??6   $	??238??6C   ?? 50      $
??Wrap=?6    $??Telephone :??64   $??37??6G   $	??233??6S   $??30(?6_   ?? 51      -   5        $ teltbx??51      $
 True??6.   $	??240??6@   ?? 52      $
??Wrap=?6    $??Email : ??64   $??37??6D   $	??233??6P   $??30(?6\   ?? 53      -   5        $ emailtbx??53      $??Modifier email??6/   $	??240??6H   6T   ?? 54      $
??Wrap=?6    $??
Password: ??64   $??37??6F   $	??233??6R   $??30(?6^   ?? 55      -	   5        $ passwordtbx??55      $	??241??65   $ Arrow??6A   $??Modifier Mot de passe??6P   6p   ?? 56      $??30(?6    $??Promotion :??6.   $	??228??6A   ?? 57      -
   5         ??Name$ 	promotion??57   1   ${?False??6   $	??250??6D   ?? 58      $??Status :??6    $??30(?60   $	??228??6>   ?? 59      -   5        $ 	statuscbx??59   =   ${?False??6   $	??250??61   6=   ?? 5:      -   5        $??Enregistrer??5:      $	??219??63   $??5 0 10 5q?6Q   ?? 5;      -   5        $??Modifier??5;      $	??240??60   $??0 0 0 5q?6R   ?? 5<      -   5        $
??Exit??5<      $	??220??6,   $??5 0 10 0q?6J   ?? 5=      -   5        $??Delete??5=      $	??238??6B   5>      5?      5@      5A      5B      