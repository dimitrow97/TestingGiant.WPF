   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:TestingGiant.App.Views.Authentication%TestingGiant.App.Views.Authentication  5      A%clr-namespace:TestingGiant.App.HelperTestingGiant.App.Helper  5      5    /TestingGiant.App.Views.Authentication.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:TestingGiant.App.Views.Authentication     5      4ff%clr-namespace:TestingGiant.App.Helper     5      $��16(�5      $	��400��5	   	   $	��400��6   .��5
      �   � ColumnDefinitions  5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5    
   �� $��Login��5!      $��1��5"      $��Center=�5#      $��1��5$      6   �� 5&   
   $	��100��5'      $��2��5(      $��1��5)      5*      �� 5,   
   $��	Username:��5-      $	��100��5.      $��3��5/      $��1��50      51      �� 52   
   -   5         ��Name$ Username��59      $	��100��56      $��4��57      $��1��58      ��53      ��  �� Path$ Username� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�59   !   �� 5;   
   $��	Password:��5<      $	��100��5=      $��0 20 0 0q�5>      $��5��5?      $��1��5@      5A      G� 5B   
   -   5         G�Name$ Password��5L      2   ,TestingGiant.App.Helper.PasswordBoxAssistant   BindPassword . $	��100��5I      $��6��5J      $��1��5K         BoundPassword 5D      �� $ Password�	 �� Mode$	 TwoWay=�$ PropertyChanged=� . 
 �� ValidatesOnExceptions
 . 5L   !   �� 5N   
   $��Center=�5P      $��Bottom=�5Q      $��7��5R      $��1��5S      $��10q�5T      ��5O      �� $ Message�$	 OneWay=���5U      �� $ MessageColor�$ PropertyChanged=��� 5V   
   -   5         ��Name$ AttemptLogin��5W      $��8��5X      $��1��5Y      {�5Z      �� $ EnableLoginButton�$ PropertyChanged=�.��6_   Login6f   �� 5[   
   $	��100��5\      $��9��5]      $��1��5^      5_      �� 5`   
   -   5        $ Register��5a      $��10��5b      $��1��5c      $��Register��5d      6"   5e      5f      