   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:TestingGiant.App.Views.EntityCruds.Subject*TestingGiant.App.Views.EntityCruds.Subject  5      ?    9TestingGiant.App.Views.EntityCruds.Subject.SubjectAddView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:TestingGiant.App.Views.EntityCruds.Subject     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��Create Subject Form��5       $��1��5!      $��Center=�5"      $��7��5#      6#   �� 5%   
   $	��100��5&      $��2��5'      $��7��5(      5)      �� 5+   
   $��Subject title:��5,      $	��100��5-      $��3��5.      $��2��5/      $��3��50      51      �� 52   
   -   5         ��Name$
 Name��5:      $	��100��56      $��4��57      $��2��58      $��3��59      ��53      ��  �� Path$
 Name� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�5:      �� 5<   
   $��Center=�5>      $��Bottom=�5?      $��5��5@      $��5��5A      $��10q�5B      
���  ����5=      �� $ Message� �� Mode$ OneWay=�5C      �� 5D   
   -   5         ��Name$ AttemptCreate��5E      $��6��5F      $��2��5G      {�5H      �� $ EnableAddButton�$ PropertyChanged=�.��6]   Create Subject6m   �� 5I   
   -   5        $ GoBack��5J      $��6��5K      $��4��5L      .��6   Cancel6%   5M      5N      