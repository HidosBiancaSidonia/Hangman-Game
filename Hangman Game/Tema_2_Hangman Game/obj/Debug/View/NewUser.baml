   M S B A M L   `   `   `  ����N  JTema_2_Hangman Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Tema_2_Hangman_Game.ViewModelTema_2_Hangman_Game.ViewModel  5   	   &     Tema_2_Hangman_Game.View.NewUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Tema_2_Hangman_Game.ViewModel     5   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ NewUser��5	   	   $��469.718��6   $��703.603��6*    � WindowStartupLocation$ CenterScreen=�6:    � Icon$ hangman.png��6_    � 	Resources 5      1  +Tema_2_Hangman_Game.ViewModel.UserViewModel   	NewUserVM��%   &	          5   
   6   5      .��5      � 
������� � DataContext 6!   ��  �� Source# [  .+�5   
   �� $��0,41,19,247q�6   $'��!Add your name and select an icon:��6)   $��20(�6R   $��Verdana)�6`   $
��Bold"�6u    �� TextAlignment$ Center=�6�   �� 5   
   -   5        $��	NameBlock��5   :   $��193,106,109,308q�6   $��Name:��6-   $��Verdana)�6K   $
��Bold"�6`   �� 5   
   -   5        $��NameBox��5   *   $��250,93,208,308q�6   $��Sylfaen)�69   $
��Bold"�6N   $��16(�6`    �� TextAlignment$ Center=�6�   ���	#FFC200FF	 �� TextDecorations	 6n   Z� ��6�   �� *NameN+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5   
   -   5        $��
ImageBlock��5   :   $��20,170,603,247q�6   $��Image:��6,   $��Verdana)�6L   $
��Bold"�6a   �� 5   
   $
��Left=�6   $��100,156,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_1.jpg��6�   ��6�   ��  �� Path$ ImageCommand�.��5      �� $��player_img_1.jpg��6   5      �� 5   
   $
��Left=�6   $��250,156,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_2.jpg��6�   ��6�   �� $ ImageCommand�.��5      �� $��player_img_2.jpg��6   5      �� 5   
   $
��Left=�6   $��550,156,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_4.jpg��6�   ��6�   �� $ ImageCommand�.��5      �� $��player_img_4.jpg��6   5      �� 5   
   $
��Left=�6   $��400,156,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_3.jpg��6�   ��6�   �� $ ImageCommand�.��5       �� $��player_img_3.jpg��6   5!      �� 5"   
   $
��Left=�6   $��100,280,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_5.jpg��6�   ��6�   �� $ ImageCommand�.��5#      �� $��player_img_5.jpg��6   5$      �� 5%   
   $
��Left=�6   $��250,280,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_6.jpg��6�   ��6�   �� $ ImageCommand�.��5&      �� $��player_img_6.jpg��6   5'      �� 5(   
   $
��Left=�6   $��400,280,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_7.jpg��6�   ��6�   �� $ ImageCommand�.��5)      �� $��player_img_7.jpg��6   5*      �� 5+   
   $
��Left=�6   $��550,280,0,0q�6-   $	��Top=�6B   $	��100��6Z   $	��100��6f   ���	#FFC200FF$��player_img_8.jpg��6�   ��6�   �� $ ImageCommand�.��5,      �� $��player_img_8.jpg��6   5-      �� 5/   
   $��174,407,424,7q�6   $��Consolas)�6(   $
��Bold"�6>   $
��Save��6Q   ���#493B5C��6v   �� *SaveCommand+�� 50   
   -   5        $��475,407,123,7q�50      $��Consolas)�6(   $
��Bold"�6>   $
��Back��6Q   ���#493B5C J� RenderTransformOrigin$ 0.993,0.367&�6�   52      53      