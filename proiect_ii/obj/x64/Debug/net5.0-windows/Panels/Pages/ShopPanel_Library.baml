   M S B A M L   `   `   `  ����E  Aproiect_ii, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:proiect_ii.Panels.Pagesproiect_ii.Panels.Pages  5      /    )proiect_ii.Panels.Pages.ShopPanel_Library   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:proiect_ii.Panels.Pages     5        N� Title$  ShopPanel_Library��5	      .��5      � -   5        $��libraryPage��5      .+�5   
   �� -   5        $��libraryTitle��5      $��
YOUR GAMES��6$      Nanotech#��[  69    J� Opacity$ 1Q�5      $��Center=�6   
�������$��0,-2,0,0q�6M   $	��Top=�6_   $��45(�6w   $��70��6�   �� 5   
   -   5        $��
firstRowBg��5      $��Center=�6&   $	 0.4Q�6C   $	��250��6Q   $��10000��6^   $��0,50,0,0q�6l   
���   �
���   �$	��Top=�5   $    �� Stretch$
 Fill=�6<   �� 5   
   -   5        $��secondRowBg��5      $��Center=�6'   $	 0.4Q�6D   $	��250��6R   $��10000��6_   $��	0,350,0,0q�6m   
���   �
���   �$	��Top=�5   $   $
 Fill=�6<   �� 5   
   -   5        $��leftButtonBg��5      $��Center=�6(   $	 0.4Q�6E   $��50��6S   $	��100��6_   $��-200,300,0,0q�6k   
���   �
���   �$	��Top=�5   $   $
 Fill=�6<   �� 5   
   -   5        $��rightButtonBg��5      $��Center=�6)   $	 0.4Q�6F   $��50��6T   $	��100��6`   $��200,300,0,0q�6l   
���   �
���   �$	��Top=�5   $   $
 Fill=�6<   �� 5   
   -   5        $��libraryEmptyMessage��5      $"��It's a bit lonely in here :(��6+   #��[  6R   $ 1Q�5      $��Center=�6   
�������$��	0,125,0,0q�6M   $	��Top=�6`   $��45(�6x   $��70��6�   �� 5   
   -   5        $��libraryEmptyMessage2��5      $@��:Feel free to visit our store and expand your collection :)��6,   #��[  6q   $ 1Q�5      $��Center=�6   
�������$��	0,430,0,0q�6M   $	��Top=�6`   $��45(�6x   $��70��6�   �� 5!   
   -	   5        $��
leftButton��5!      $!��../../images/left-arrow.png��6B   $
��Fill=�6h    �� BitmapScalingMode$
 Fant=�5"      $��center=�6;   $��75��6X   $��-200,285,0,0q�6d   $	��Top=�6z   $��75��6�   �� 5$   
   -
   5        $��rightButton��5$      $"��../../images/right-arrow.png��6?   $
��Fill=�6f   $
 Fant=�5%      $��center=�6;   $��75��6X   $��200,285,0,0q�6d   $	��Top=�6y   $��75��6�   � 5'   
   -   5        $��gameInfoGrid��5'      $	��Top=�6#   $
��Left=�6;   $��-800, 0, 0, 0q�6V    K� ZIndex$ 10��6m   .+�5(      �� -   5        $��
gameInfoBg��5(      $
 0.95Q�6*   $	��750��69   $	��750��6F   $��0,0,0,0q�6R   
���   �
���   �$
 Fill=�5)   (   �� 5+      -   5        $��gameInfoImg��5+      $&�� ../../images/default_gamepic.png��6'   $
��Fill=�6R   $
 Fant=�5,      $	��400��6<   $��
0,-200,0,0q�6I   $	��400��6]   �� 5.      -   5        $��gameInfoTitle��5.      $��
GAME TITLE��6)   #��[  6>   $ 1Q�5/      $��Center=�6    
�������$��	0,500,0,0q�6Q   $	��Top=�6d   $��37(�6|   $��70��6�   �� 51      -   5        $��gameInfoPlay��51      $
��PLAY��6)   #��[  68   $��	0,530,0,0q�6_   $��50��52      $	��250��6"   $��20(�6.   
��� E��$��Normal"�6j    � UseLayoutRounding$ False��6~   
���������6S   Z� 6�   �� 54      -   5        $��gameInfoClose��54      $!��../../images/left-arrow.png��6)   $
��Fill=�6d   $
 Fant=�55      $��Right=�6;   $	��100��6W   $��0,0,10,0q�6d   $��Center=�6v   $	��100��6�   z�57      T� 58      -   5        	MovementX�� T� X$ 0Q�58   8    � Triggers 5:      :� 5;       :� RoutedEvent$* $local:ShopPanel_Library.OpenGameInfo��6   .[�5<      �� .��5=      �� .��5>      U� 	 �� 
TargetName$	 	MovementX��6<   
 �� TargetProperty$
 X�6^    g� Duration$ 0:0:4D�6|   .\�5?   "   9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� KeyTime$ 0:0:0.3��67    O� Value$	 750Q�6I   5@      5A      5B      5C      :� 5D      $+ %local:ShopPanel_Library.CloseGameInfo��6   .[�5E      �� .��5F      �� .��5G      U� $	 	MovementX��6<   $
 X�6^   $ 0:0:4D�6|   .\�5H   "     $ 0:0:0.3��67   $ 0Q�6I   5I      5J      5K      5L      5N      5O      5P      