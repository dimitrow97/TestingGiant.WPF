   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:TestingGiant.App.Views.EntityCruds.Exam'TestingGiant.App.Views.EntityCruds.Exam  5      ;    5TestingGiant.App.Views.EntityCruds.Exam.ExamGroupView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:TestingGiant.App.Views.EntityCruds.Exam     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��30 �6   �� 5      $	��200 �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� $��1��6A   $��9��6N   $��Center=�6b   ��6   ��  �� Path$ 	Exam.Name� �� Mode$ OneWay=�6�   �� 5   
   -   5         ��Name$ GoBack��5      $��1��6!   $��1��6.   .��6>   Back6D   �� 5   
   -   5        $ RemoveFromGroup��5      $��2��6*   $��1��67   .��6G   Remove from group6Z   �� 5    
   $��Member of Groups:��6   $��Bottom=�6-   $��2��6H   $��9��6U   $��Center=�6i   6�   �� 5"   
   $��Center=�5$      $��Bottom=�5%      $��2��5&      $��7��5'      $��16(�5(      $��Center=�5)      
���  ����5#      �� $ Message�$ OneWay=�5*      &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ MemberOfGroups��5,      $��3��6+   $��9��68      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserSortColumns	 .  
   CanUserReorderColumns
 .     CanUserResizeRows .   �� SelectedItem 5-      �� *SelectedMemberGroup+$ TwoWay=�   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     56      $ 
Group Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6R    .  69   �� *Name+6^   58      �� 5:   
   -   5        $ 
AddToGroup��5:      $��5��6%   $��1��62   .��6B   Add to group6P   �� 5;   
   $��Not a Member of Groups:��6   $��Bottom=�63   $��5��6N   $��9��6[   $��Center=�6o   6�   �� 5=   
   $��Center=�5?      $��Bottom=�5@      $��5��5A      $��7��5B      $��16(�5C      $��Center=�5D      
���  ����5>      �� $ Message�$ OneWay=�5E        5G   
   -   5        $ NotMemberOfGroups��5G      $��6��6.   $��9��6;    .   .   .  	 .  
 .   .   5H      �� *SelectedNotMemberGroup+$ TwoWay=� 5O        5P      $ Id��6%    .  61   �� *Id+6H     5Q      $ 
Group Name��6%   $	 200 6R    .  69   �� *Name+6^   5S      5T      5U      