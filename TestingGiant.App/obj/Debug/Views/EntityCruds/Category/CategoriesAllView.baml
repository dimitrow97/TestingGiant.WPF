   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:TestingGiant.App.Views.EntityCruds.Category+TestingGiant.App.Views.EntityCruds.Category  5      C    =TestingGiant.App.Views.EntityCruds.Category.CategoriesAllView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:TestingGiant.App.Views.EntityCruds.Category     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��30 �6   �� 5      $��60 �6   �� 5      $��15 �6   �� 5      $��60 �6   �� 5      $��15 �6   �� 5      $��75 �6   �� 5      $��15 �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� $��
Categories��6   $��1��6&   $��9��63   $��Center=�6G   6f   �� 5   
   -   5         ��Name$ AddCategory��5      $��2��6&   $��1��63   .��6C   Add6H   �� 5   
   -   5        $ EditCategory��5      $��2��6'   $��3��64   .��6D   Edit6J   �� 5    
   -   5        $ DeleteCategory��5       $��2��6)   $��5��66   .��6F   Delete6N   �� 5!   
   $��Center=�5#      $��Bottom=�5$      $��2��5%      $��7��5&      $��16(�5'      $��Center=�5(      
���  ����5"      ��  �� Path$ Message� �� Mode$ OneWay=�5)      &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ 
Categories��5+      $��3��6'   $��9��64      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  	   CanUserSortColumns	 .  
   CanUserReorderColumns
 .     CanUserResizeRows .   �� SelectedItem 5,      �� *SelectedCategory+$ TwoWay=�   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     55      $
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6L    .  63   �� *Name+6X   57      58      59      