   M S B A M L   `   `   `  ����N  JTema_2_Hangman Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Tema_2_Hangman_Game.ViewModelTema_2_Hangman_Game.ViewModel  5   	   (    "Tema_2_Hangman_Game.View.LogInView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Tema_2_Hangman_Game.ViewModel     5   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ 	LogInView��5
   	   $��469.718��6   $��703.603��6,    � WindowStartupLocation$ CenterScreen=�6<    � Icon$ hangman.png��6a    � 	Resources 5      1  +Tema_2_Hangman_Game.ViewModel.UserViewModel   UserViewModel��%   &	          5   
   6   5      .��5      � 
������� � DataContext 6!   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $	��390 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$
 Logo��5      $��0��6   $��75,0,43,281q�6+   ��5      �� 5      	 �� 	UriSource$	 logo.png?�6   5      �� 5   
   -   5        
 ��Name$
 UserList��5   .   $��44,103,366.667,10q�6   $��0��6A   
����������	#FFC200FF��6y   �� *Users+ �� UpdateSourceTrigger$ PropertyChanged=� �� View 5      �� 5      .P�5      �� $
��Name��6%    �� DisplayMemberBinding 63   �� *Name+5       5"      �� 5$   
   $
��Left=�6   $��439,158,0,0q�6/   $
��Wrap=�6D   $=��7**WELCOME!** To start the game, please select a player!��6X   $	��Top=�6�   ���	#FF6311AA �� TextAlignment$ Center=�6�   $��Monotype Corsiva)�6�   $��24(�6�   $	��180��6	  $��99��6  ���	#FF93EBEE6!  �� 5&   
   $��Stretch=�6v   $
��Fill=�6�   $��409,103,42.667,64q�6�   ��6   ��  �� ElementName$ UserList�� �� Path$ SelectedItem.Icon�$ PropertyChanged=�5(      �� 5+   
   -   5        $��1��5+      $��44,12,562.667,9.667q�6   $��Consolas)�6;   $
��Bold"�6Q   ���#493B5C$��New User��6z    J� RenderTransformOrigin$ 	0.5,0.505&�6�   ��6�   �� $ NewUser���6�   �� $ UserList��$ SelectedItem.Name�6  �� 5,   
   $��1��6   $��224,12,382.667,9.667q�6   $��Consolas)�6<   $
��Bold"�6R   ���#493B5C$��Delete User��6y   ��6�   �� $ DeleteCommand���6�   �� $ UserList��$ SelectedItem.Name��� 5-   
   $��1��6   $��391,12,215.667,9.667q�6   $��Consolas)�6<   $
��Bold"�6R   ���#493B5C$
��Play��6�   ��6y   �� $ PlayCommand���6�   �� $ UserList��$ SelectedItem.Name�6�   �� 5.   
   -   5        $��1��5.      $��564,12,42.667,9.667q�6   $��Consolas)�6;   ���#493B5C$
��Bold"�6w   ���	#FFDDDDDD$
��Exit��6�   50      51      