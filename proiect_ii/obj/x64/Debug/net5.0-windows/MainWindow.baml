   M S B A M L   `   `   `  ����E  Aproiect_ii, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:proiect_ii
proiect_ii  5   	       proiect_ii.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:proiect_ii     5   	     � Title$  Game Marketplace��5   	    � Icon$ images/app.ico��5	   	   $	��650��5
   	   $
��1200��6   $	��650��5   	   $
��1200��6   $	��650��5   	   $
��1200��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   ��5      �� 5   
    �� ImageSource$ 
/main4.png��5       j� 
AlignmentX$
 Left=�6&    j� 
AlignmentY$	 Top=�68   5      .��5      � ��5   
   �� 5      $ /main_img.png��6    � ColumnDefinitions 5   
   �� 5      $	��41* �6   �� 5      $��1159* �6   .+�5   
   �� $��password��6      Nanotech#��[  6#   $
��Left=�6J   $��
16,327,0,0q�6e   $	��Top=�6y   $	��200��6�   $��20(�6�   $��1��6�   $��37��6�   �� 5#   
   -   5        $��NEW USER��5#      #��[  6:   $
��Left=�6a   $��
13,477,0,0q�6|   $	��Top=�6�   $��40��6�   $	��278��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $y�Visible=�6�   
���   �$��20(�6  $��Normal"�6-  $��1��6A  
���������6�   Z� 5%      �� 5(   
   -   5        $��loginButton��5(      $��LOGIN��6$   #��[  6F   $
��Left=�6m   $��
13,427,0,0q�6�   $	��Top=�6�   $��40��6�   $	��278��6�   $��20(�6�   
���   �$��Normal"�6  	 � UseLayoutRounding$	 False��6  $��1��62  
���������6�   Z� 6B  �� 5+   
   -   5        $��CONTINUE AS GUEST��5+      #��[  6@   $
��Left=�6g   $��
13,527,0,0q�6�   $	��Top=�6�   $��40��6�   $	��278��6�   $��20(�6�   
���   �$��Normal"�6�   $	 False��6  $��1��6-  
���������6�   Z� 6=  �� 5/   
   -   5        $
��EXIT��5/      $
��Left=�63   $��
13,577,0,0q�6N   $	��Top=�6b   $��40��6z   $	��278��6�   $��20(�6�   
���   �$��Normal"�6�   $	 False��6�   $��1��6�   
���������6�   Z� 6  �� 52   
   -   5        
 ��Name$
 recoverButton��52   7   $y�Hidden=�6   $��RECOVER��6%   $
��Left=�6e   $��305,288,0,0q�6�   $	��Top=�6�   $	��115��6�   $	��100��6�   $��20(�6�   
���   �$��Normal"�6�   $	 False��6  $��1��6,  
���������6�   Z� 6<  �� 54   
   -   5         ��Name$ usernameBox��54      
 � Tag$ Name of customer��6'   #��[  6>   $
��Left=�6f   $��
13,289,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��278��6�   $��40��6�   $��24(�6�   $��Normal"�6�   
���   �$��1��6  $��4,4,4,4q�6  
������� �� SelectionBrush �	#FF3A3A3A �� SelectionTextBrush
 �����6g  G� 56   
   -   5         G�Name$ passwordBox��56      #��[  6+   $
��Left=�6R   $��
13,362,0,0q�6m   $	��Top=�6�   $	��278��6�   $��40��6�   $��24(�6�   
�������$��1��6�   
���   � G� SelectionBrush �	#FF3A3A3A$��4,4,4,4q�6  �� 57   
   $��username��6   #��[  6#   $
��Left=�6J   $��
16,253,0,0q�6e   $	��Top=�6y   $	��200��6�   $��20(�6�   $��1��6�   $��37��6�   � 5:   
   -   5         �Name$ Notification��5:      $��1��6%   $��Right=�65   $	��Top=�6Q   $��0, 75, -485, 0q�6i   .+�5;      �� $��82��6   
���   �$	��481��63   
���   � J� Opacity$	 0.5Q�6L   �� 5<      $��70��6   
��� ���$��3��68   
��� ���$	 0.5Q�6T   $��-300, 0, 0, 0q�6b   �� 5=      -	   5         ��Name$ NotificationLabel��5=      #��[  6/   $�� ��6V   $
 0.85Q�6a   $��	95,22,0,0q�6p   $��20(�6�   $��Normal"�6�   
��� ���6�   �� 5>      -
   5         ��Name$ NotificationImage��5>      $��50��6/   $��
-390,0,0,0q�6;   $��50��6O   z�5@      T� 5A      -   5        	MovementX�� T� X$ 0Q�5A   8    � Triggers 5C      :� 5D       :� RoutedEvent$' !local:MainWindow.SendNotification��6   .[�5E      �� .��5F      �� -   5        .��5G      U�  �� 
TargetName$ 	MovementX��6<    �� TargetProperty$ X�6^    g� AutoReverse$
 True��6|    g� Duration$ 0:0:3D�6�   .\�5H   "   9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� KeyTime$ 0:0:0.8��67    O� Value$
 -485Q�6I   5I      5J      5K      5L      5N      5O      5P      