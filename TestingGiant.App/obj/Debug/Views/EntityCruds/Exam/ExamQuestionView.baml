   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:TestingGiant.App.Views.EntityCruds.Exam'TestingGiant.App.Views.EntityCruds.Exam  5      >    8TestingGiant.App.Views.EntityCruds.Exam.ExamQuestionView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:TestingGiant.App.Views.EntityCruds.Exam     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��30 �6   �� 5      $	��200 �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� $��1��6A   $��9��6N   $��Center=�6b   ��6   ��  �� Path$ 	Exam.Name� �� Mode$ OneWay=�6�   �� 5   
   -   5         ��Name$ GoBack��5      $��1��6!   $��1��6.   .��6>   Back6D   �� 5   
   -   5        $ RemoveQuestion��5      $��2��6)   $��1��66   .��6F   Remove question6W   �� 5    
   $��Member Questions:��6   $��Bottom=�6-   $��2��6H   $��9��6U   $��Center=�6i   6�   �� 5"   
   $��Center=�5$      $��Bottom=�5%      $��2��5&      $��7��5'      $��16(�5(      $��Center=�5)      
���  ����5#      �� $ Message�$ OneWay=�5*      &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ MemberQuestions��5,      $��3��6,   $��9��69      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserSortColumns	 .  
   CanUserReorderColumns
 .     CanUserResizeRows .   �� SelectedItem 5-      �� *SelectedMemberQuestion+$ TwoWay=�   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     56      $ Title��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6N    .  64   �� *Title+6Z     57      $ Description��6%   $	 200 6Z    .  6:   �� *Description+6f     58      $ QuestionType��6%   $	 120 6\    .  6;   �� *QuestionType+6h     59      $ Points��6%   $	 120 6P    .  65   �� *Points+6\     5:      $ 
Difficulty��6%   $	 120 6X    .  69   �� *
Difficulty+6d   5<      �� 5>   
   -   5        $ AddQuestion��5>      $��5��6&   $��1��63   .��6C   Add question6Q   �� 5?   
   $��Not Member Questions:��6   $��Bottom=�61   $��5��6L   $��9��6Y   $��Center=�6m   6�   �� 5A   
   $��Center=�5C      $��Bottom=�5D      $��5��5E      $��7��5F      $��16(�5G      $��Center=�5H      
���  ����5B      �� $ Message�$ OneWay=�5I        5K   
   -   5        $ NotMemberQuestions��5K      $��6��6/   $��9��6<    .   .   .  	 .  
 .   .   5L      �� *SelectedNotMemberQuestion+$ TwoWay=� 5S        5T      $ Id��6%    .  61   �� *Id+6H     5U      $ Title��6%   $	 200 6N    .  64   �� *Title+6Z     5V      $ Description��6%   $	 200 6Z    .  6:   �� *Description+6f     5W      $ QuestionType��6%   $	 120 6\    .  6;   �� *QuestionType+6h     5X      $ Points��6%   $	 120 6P    .  65   �� *Points+6\     5Y      $ 
Difficulty��6%   $	 120 6X    .  69   �� *
Difficulty+6d   5[      5\      5]      