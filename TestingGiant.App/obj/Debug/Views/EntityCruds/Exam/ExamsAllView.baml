   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:TestingGiant.App.Views.EntityCruds.Exam'TestingGiant.App.Views.EntityCruds.Exam  5      :    4TestingGiant.App.Views.EntityCruds.Exam.ExamsAllView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:TestingGiant.App.Views.EntityCruds.Exam     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��30 �6   �� 5      $��60 �6   �� 5      $��15 �6   �� 5      $��60 �6   �� 5      $��15 �6   �� 5      $��75 �6   �� 5      $��15 �6   �� 5      $��85 �6   �� 5      $��15 �6   �� 5      $	��100 �6   �� 5      $��15 �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5!   
   �� $��Exams��6   $��1��6!   $��9��6.   $��Center=�6B   6a   �� 5"   
   -   5         ��Name$ AddExam��5"      $��2��6"   $��1��6/   .��6?   Add6D   �� 5#   
   -   5        $ EditExam��5#      $��2��6#   $��3��60   .��6@   Edit6F   �� 5$   
   -   5        $ 
DeleteExam��5$      $��2��6%   $��5��62   .��6B   Delete6J   �� 5%   
   -   5        $ AddRemoveGroups��5%      $��2��6*   $��7��67   .��6G   Groups6O   �� 5&   
   -   5        $ AddRemoveQuestions��5&      $��2��6-   $��9��6:   .��6J   	Questions6U   �� 5'   
   $��Center=�5)      $��Bottom=�5*      $��2��5+      $��11��5,      $��16(�5-      $��Center=�5.      
���  ����5(      ��  �� Path$ Message� �� Mode$ OneWay=�5/      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ Exams��51      $��3��6"   $��13��6/      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserSortColumns	 .  
   CanUserReorderColumns
 .     CanUserResizeRows .   �� SelectedItem 52      �� *SelectedExam+$ TwoWay=�   Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5;      $
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6L    .  63   �� *Name+6X     5<      $ Exam Key��6%   $	 150 6S    .  67   �� *	ExamKey+6_     5=      $ Exam Password��6%   $	 150 6]    .  6<   �� *ExamPassword+6i     5>      $ Time limit(min)��6%   $	 120 6h    .  6>   �� *TimeToFinishInMinutes+6t     5?      $ 	Exam Type��6%   $	 150 6U    .  68   �� *
ExamType+6a     5@      $ 	Max Score��6%   $	 120 6Y    .  68   �� *MaximumScore+6e   5B      5C      5D      