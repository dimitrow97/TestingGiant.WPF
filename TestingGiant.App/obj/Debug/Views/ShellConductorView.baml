   M S B A M L   `   `   `  ����K  GTestingGiant.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TestingGiant.App.ViewsTestingGiant.App.Views  5   	   /    )TestingGiant.App.Views.ShellConductorView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TestingGiant.App.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	ShellView��5	   	   $	��800��6   $
��1200��6(    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � WindowStyle$
 None=�6q    � 	Resources 5
         ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType	 �Name
 ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle�� 5   
   %�  &	        '�� D    �� 5      " n�6)   .�5      ��  � �� 5      �� 5      " n�6*   .R�5      � $
	 Grid��6#   .+�5   "   �� $��Stretch=�6,   $��Stretch=�6J   $
��Auto��6f   $
��Auto��6s   
������ 6�   �� 5   "   $
 
Rectangle1��6)   $ 10��6=   $��Stretch=�6O   $��Stretch=�6m   $
��Auto��6�   $
��Auto��6�   #��z��6�   5       5      P� 5   "    �@�Tag$ 
Horizontal��69   . �5   &   �� $ 
Rectangle1��6-    � ��$
 Auto��6V   �� 5   &   $ 
Rectangle1��6-    � ��$ 7��6W   5   #   5      5      5      �� 5       " ��6/   .�5!      ��  �@��IsFlicksEnabled .  6;   �� 5"       � ��
 �����6/   �� 5#       � ��
 �����6/   �� 5$       � ��$ 10��6*   �� 5%       � �� 5&      �� 5'      " ��6*   .R�5(      � $	 GridRoot��6#   $��19��65   ��6@   Z� .+�5)   "   ]� $ 
PART_Track��6(   $��0��6<   ��. |�.   5*   &   n� 5+   *   $ Thumb��60   #��z��6?   #���   6i    5-   &   �� 5.   *   $ PageUp��67   $��ScrollBar.PageDownCommand��6G   $ 0Q�6k   |�.  6w    50   &   �� 51   *   $ PageDown��67   $��ScrollBar.PageUpCommand��6I   $ 0Q�6k   |�.  6w   53   #   54       56      P� 57   "   $ Thumb��6*    �@J�IsMouseOver . . �58   &   �� # �  6-   $ Thumb��6Y    � ��6l   59   #   P� 5:   "   $ Thumb��6*    �@n�
IsDragging . . �5;   &   �� # �  6-   $ Thumb��6Q    � ��6d   5<   #   P� 5>   "    � {� .  . �5?   &   �� $ Thumb��6-    � y�$ 	Collapsed=�6V   5@   #   P� 5A   "    �@��Orientation$ 
Horizontal=�6A   . �5B   &   �� $ GridRoot��6-    �@�LayoutTransform 5C   *   �� 5D   .   $	 -90Q�6>   5F   '   �� 5G   &   $ 
PART_Track��6-    �@�LayoutTransform 5H   *   �� 5I   .   $	 -90Q�6>   5K   '   �� 5L   &    � ��$
 Auto��6>   �� 5M   &    � ��$ 12��6?   �� 5N   &   $ Thumb��6-    �@�Tag$ 
Horizontal��6O   �� 5O   &   $ PageDown��6-    � ��$ ScrollBar.PageLeftCommand��6V   �� 5P   &   $ PageUp��6-    � ��$  ScrollBar.PageRightCommand��6T   5Q   #   5S      5U      5V      5W      .��5Y      �  � ColumnDefinitions 5Z   
   �� 5[      $	��200 �6   �� 5\      $��* �6    � RowDefinitions 5^   
   �� 5_      $��30 �6   �� 5`      $��* �6   .+�5c   
   � $��1��6   $��1��6   ���	#FFCFCFCF.+�5d      �� .��5e      �  5f      �� 5g      $��* �6(   �� 5h      $��* �6(   �� 5i      $��* �6(    5k      �� 5l      $��1* �6+   �� 5m      $��1* �6+   �� 5n      $��1* �6+   .+�5q      � $��0��6   $��3��6(   $��3��69   $��Center=�6M   $	��940��6j   $	��700��6v   .+�5r      � 
�������$��15 0 0 0q�62    J� OpacityMask 5s      !� 5t   "    !� Visual 6.   ��  �� ElementName$ BorderG1��.+�5v      �� -   5        $
 BorderG1��5v   %   $ 5��67   
�������6H   �� 5w      -   5         ��Name$ 
ActiveItem��5w   -   6C   5x      5y      5z      5{      5|      � 5~   
   $��1��6   ��5      �� 5�       �� EndPoint$ 0.5,1&�6&     �� 
StartPoint$  0.5,0&�67   .��5�      � ! � Color$! 	LightGray��6#   " � Offset$" 1Q�65   � 5�      $! 	#FFE6E6E6��6#   5�       5�      �� 5�      $	��100 �6    �� 5�      $��* �6    # J� Effect# 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�      $   
BlurRadius$$ 20Q�6#   %   Color$% 	#FFDEDEDE��63   &   RenderingBias$& Quality=�6E   '   ShadowDepth$' 1Q�6]   .+�5�      � ���	#FFA46FE4.+�5�      �� $��	DASHBOARD��6   $��Center=�6-   $��Center=�6J   $��WS Simple Gallifreyan)�6e   ���	#FFBC96EA$��16(�6�   5�      �� 5�      $��1��6   .+�5�      �� -   5        ( ��Name$( GoToDashboard��5�      $��10q�60   ���	#FF8522BD���	#FF8522BD.��5�      � $	��150��6   .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon  )   Kind$) ViewDashboard=�62   $��Center=�6G   �� 5�      $��Center=�6$   $��	DASHBOARD��6A   $��Champagne & Limousines)�6R   5�      5�      �� 5�      -   5        $( 	GoToUsers��5�      $��10q�6T   ���	#FF8522BD���	#FF8522BDy�6,   �� * �� Path$* IsUserAdmin�.��5�      � $	��150��6   .+�5�        $) Account=�62   $��Center=�6A   �� 5�      $��Center=�6$   $��USERS��6A   $��Champagne & Limousines)�6N   5�      5�      �� 5�      -   5        $( GoToCategories��5�      $��10q�6Y   ���	#FF8522BD���	#FF8522BDy�61   �� $* IsUserAdmin�.��5�      � $	��150��6   .+�5�        $) Category=�62   $��Center=�6B   �� 5�      $��Center=�6$   $��
CATEGORIES��6A   $��Champagne & Limousines)�6S   5�      5�      �� 5�      -   5        $( 
GoToGroups��5�      $��10q�6U   ���	#FF8522BD���	#FF8522BDy�6-   �� $* IsUserAdmin�.��5�      � $	��150��6   .+�5�        $) Group=�62   $��Center=�6?   �� 5�      $��Center=�6$   $��GROUPS��6A   $��Champagne & Limousines)�6O   5�      5�      �� 5�      -   5        $( GoToSubjects��5�      $��10q�6W   ���	#FF8522BD���	#FF8522BDy�6/   �� $* IsUserAdmin�.��5�      � $	��150��6   .+�5�        $) TextSubject=�62   $��Center=�6E   �� 5�      $��Center=�6$   $��SUBJECTS��6A   $��Champagne & Limousines)�6Q   5�      5�      �� 5�      -   5        $( GoToQuestions��5�      $��10q�6X   ���	#FF8522BD���	#FF8522BDy�60   �� $* IsUserAdmin�.��5�      � $	��150��6   .+�5�        $) QuestionMarkCircle=�62   $��Center=�6L   �� 5�      $��Center=�6$   $��	QUESTIONS��6A   $��Champagne & Limousines)�6R   5�      5�      �� 5�      -	   5        $( 	GoToExams��5�      $��10q�6T   ���	#FF8522BD���	#FF8522BDy�6,   �� $* IsUserAdmin�.��5�      � $	��150��6   .+�5�        $) HexagonMultiple=�62   $��Center=�6I   �� 5�      $��Center=�6$   $��EXAMS��6A   $��Champagne & Limousines)�6N   5�      5�      5�      5�      � 5�   
   -
   5        $	 GridMainHeader��5�      $��2��6'   ���	#FF8522BD.+�5�      �� + �� Orientation$+ 
Horizontal=�6   $��Right=�62   $
��10,0q�6N   .+�5�      ��  0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6   $��25��6_   $��25��6j   
���������6v   Z� ��6�   Z� .��5�        $
) Bell=�6.   5�      �� 5�      #��[ 6   $��25��6_   $��25��6j   
���������6v   Z� ��6�   Z� .��5�        $) Account=�6.   5�      �� 5�      -   5        $( ButtonClose��5�      #��[ 6.   $��25��6t   $��25��6   
���������6�   Z� ��6�   Z� .��5�        $) Power=�6.   5�      5�      5�      5�      5�      