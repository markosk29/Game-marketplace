   M S B A M L   `   `   `  ����E  Aproiect_ii, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:proiect_ii.Panelsproiect_ii.Panels  5   	   %    proiect_ii.Panels.RegisterPanel   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:proiect_ii.Panels     5   	     � Title$  Game Marketplace��5   	    � Icon$ ../images/app.ico��5	   	   $	��650��5
   	   $
��1200��6   $	��650��5   	   $
��1200��6   $	��650��5   	   $
��1200��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   ��5      �� 5   
    �� ImageSource$ /Panels/register1.png��5       j� 
AlignmentX$
 Left=�61    j� 
AlignmentY$	 Top=�6C   5      .��5      �  J� RenderTransformOrigin$ 0.5,0.5&�6   ��5   
   �� 5      $! /Panels/register_panel1.png��6   .+�5   
   �� -   5        $
��Next��5         Nanotech#��[  63   $
��Left=�6Z   $��620,501,0,0q�6u   $	��Top=�6�   $��40��6�   $	��278��6�   $��20(�6�   
���   �$��Normal"�6�    � UseLayoutRounding$ False��6  
���������6�   Z� 6   �� 5   
   -   5        	 ��Name$	 usernameLabel��5      $��	username:��6'   #��[  6;   $
��Left=�6b   $��374,132,0,0q�6}   $	��Top=�6�   $	��200��6�   $��20(�6�   $��37��6�   �� 5   
   -   5        $��usernameTextbox��5      #��[  6)   $��Center=�6P   $��	0,168,0,0q�6m   
 �� TextWrapping$

 Wrap=�6�   $	��Top=�6�   $	��450��6�   $��40��6�   $��24(�6�   $��Normal"�6�   
���   �$��4,4,4,4q�6�   
������� �� SelectionBrush �	#FF3A3A3A �� SelectionTextBrush
 �����6B  �� 5!   
   -   5        $	 passwordLabel��5!      #��[  6'   $��	password:��6N   $
��Left=�6b   $��374,212,0,0q�6}   $	��Top=�6�   $	��200��6�   $��20(�6�   $��37��6�   G� 5"   
   -   5        $��passwordBox��5"      #��[  6)   $��Center=�6P   $��	0,248,0,0q�6m   $	��Top=�6�   $	��450��6�   $��40��6�   $��24(�6�   
�������
���   � G� SelectionBrush �	#FF3A3A3A$��4,4,4,4q�6   �� 5%   
   -   5        $	 confirmPassLabel��5%      #��[  6*   $��confirm password:��6Q   $
��Left=�6m   $��374,291,0,0q�6�   $	��Top=�6�   $	��200��6�   $��20(�6�   $��37��6�   G� 5&   
   -   5        $��confirmPassBox��5&      #��[  6,   $��Center=�6S   $��	0,328,0,0q�6p   $	��Top=�6�   $	��450��6�   $��40��6�   $��24(�6�   
�������
���   � �	#FF3A3A3A$��4,4,4,4q�6  �� 5)   
   -   5        $	 
emailLabel��5)      $��e-mail:��6$   #��[  66   $
��Left=�6]   $��375,372,0,0q�6x   $	��Top=�6�   $	��200��6�   $��20(�6�   $��37��6�   �� 5*   
   -	   5        $��emailTextbox��5*      #��[  6&   $��Center=�6M   $��	0,408,0,0q�6j   $

 Wrap=�6}   $	��Top=�6�   $	��450��6�   $��40��6�   $��24(�6�   $��Normal"�6�   
���   �$��4,4,4,4q�6�   
������� �	#FF3A3A3A
 ����� �� MaxLines$ 1��6Z  �� 5-   
   -
   5        $	 
errorLabel��5-      $�� ��6$   #��[  6/   $��Center=�6V   $��	0,450,0,0q�6s   $	��Top=�6�   $��25(�6�   
���  ��$	��450��6�   $��Normal"�6�   �� 50   
   -   5        $
��Back��50      #��[  63   $
��Left=�6Z   $��310,501,0,0q�6u   $	��Top=�6�   $��40��6�   $	��278��6�   $��20(�6�   
���   �$��Normal"�6�   $ False��6  
���������6�   Z� 6   � 53   
   -   5         �Name$ Notification��53      $��Right=�6%   $	��Top=�6A   $��0, 545, -485, 0q�6Y   .+�54      �� $��82��6   
���   �$	��481��63   
���   � J� Opacity$	 0.5Q�6L   �� 55      $��70��6   
��� E��$��3��67   
��� E��$	 0.5Q�6R   $��-300, 0, 0, 0q�6`   �� 56      -   5        $	 NotificationLabel��56      #��[  6/   $�� ��6V   $
 0.85Q�6a   $��	95,22,0,0q�6p   $��20(�6�   $��Normal"�6�   
��� E��6�   �� 57      -   5         ��Name$ NotificationImage��57      $��50��6/   $��
-390,0,0,0q�6;   $��50��6O   z�59      T� 5:      -   5        	MovementX�� T� X$ 0Q�5:   8    � Triggers 5<      :� 5=       :� RoutedEvent$* $local:RegisterPanel.SendNotification��6   .[�5>      �� .��5?      �� -   5        .��5@      U�  �� 
TargetName$ 	MovementX��6<    �� TargetProperty$ X�6^    g� AutoReverse$
 True��6|    g� Duration$ 0:0:3D�6�   .\�5A   "   9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� KeyTime$ 0:0:0.8��67    O� Value$
 -483Q�6I   5B      5C      5D      5E      5G      5H      5I      