   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:kursachkursach  5   	       kursach.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:kursach     5   	   -   5          � Title$  Note--��5	   	   $	��450��6   $	��500��6%    � 
ResizeMode$ NoResize=�61    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ 
Reses.xaml?�6%   %    5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��8* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��7* �6#   �� 5      $
��1.5* �6#   �� 5      $
��1.5* �6#   .+�5      �� $��noteminusminus.png��6   $��0��60   $��3��6@   $
��Fill=�6T   5      � 5   
   $��1��6    5      �� 5       $��8* �6#   �� 5!      $��2* �6#   .+�5#      &   System.Windows.Controls.DataGrid     dgrd#��[  6      CanUserAddRows$ False��5$   <      CanUserDeleteRows$ False��5%      	   AutoGenerateColumns$	 False��61   
   
IsReadOnly$

 True��6M   ��5#   5   �� *Docs+ �� SelectedItem 5$      �� *SelectedDoc+   Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Title+  5(      $ Date modified��6)   $ 3* 6@    6K   �� *DateModified+5*      �� 5+      $��1��6   .+�5,      �� $
��Edit��6     But#��[ 6(   ��6E   �� *OpenCommand+�� 5-      $	��Add��6   #��[ 6'   ��6D   �� *
AddCommand+�� 5.      $��Delete��6   #��[ 6*   ��6G   �� *DeleteCommand+5/      50      51      52      