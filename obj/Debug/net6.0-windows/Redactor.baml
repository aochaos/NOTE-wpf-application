   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:kursachkursach  5   	       kursach.Redactor   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:kursach     5   	     � Title$  Redactor��5   	   $	��450��6   $	��500��6'    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ ApplicationCommands.Save��5
      6<    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ 
Reses.xaml?�6%   %    5      .��5      ]� 
��� ���.+�5   
   c� $	��Top=�6   
��� ���.@�5      �� $��ApplicationCommands.Save��6   $
��Save��68      StyleForSave#��[  6G   $��0q�6m   �� 5      d� 5      -   5        $��btnBold��5   @   $ ��EditingCommands.ToggleBold��6   $��B��6O     But2#��[ 6[   d� 5      -   5        $��	btnItalic��5   B   $"��EditingCommands.ToggleItalic��6   $��I��6S   #��[ 6_   d� 5      -   5        $��btnUnderline��5   E   $%��EditingCommands.ToggleUnderline��6   $��U��6Y   #��[ 6e   �� 5      �� 5      -   5        $��cmbFontFamily��5      $	��100��6,     Cbox#��[ 5      �� 5      -   5        $��cmbFontSize��5      $��50��6*    �� 
IsEditable$
 True��65   #��[ 5   I   �� 5      -   5        $��cmbTextColor��5      $��80��6+   #��[ 5       5!      �� 5"   
   -   5        $��	rtbEditor��5"      
�������6U   5#      5$      