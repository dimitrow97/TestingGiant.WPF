   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:TestingGiant.App.Views.EntityCruds.Subject*TestingGiant.App.Views.EntityCruds.Subject  5      @    :TestingGiant.App.Views.EntityCruds.Subject.SubjectsAllView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:TestingGiant.App.Views.EntityCruds.Subject     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��30 �6   �� 5      $��60 �6   �� 5      $��15 �6   �� 5      $��60 �6   �� 5      $��15 �6   �� 5      $��75 �6   �� 5      $��15 �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� $��
Categories��6   $��1��6&   $��9��63   $��Center=�6G   6f   �� 5   
   -   5         ��Name$ 
AddSubject��5      $��2��6%   $��1��62   .��6B   Add6G   �� 5   
   -   5        $ EditSubject��5      $��2��6&   $��3��63   .��6C   Edit6I   �� 5    
   -   5        $ DeleteSubject��5       $��2��6(   $��5��65   .��6E   Delete6M   �� 5!   
   $��Center=�5#      $��Bottom=�5$      $��2��5%      $��7��5&      $��16(�5'      $��Center=�5(      
���  ����5"      ��  �� Path$ Message� �� Mode$ OneWay=�5)      &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ Subjects��5+      $��3��6%   $��9��62      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserSortColumns	 .  
   CanUserReorderColumns
 .     CanUserResizeRows .   �� SelectedItem 5,      �� *SelectedSubject+$ TwoWay=�   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     55      $
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6M    .  63   �� *Title+6Y   57      58      59      