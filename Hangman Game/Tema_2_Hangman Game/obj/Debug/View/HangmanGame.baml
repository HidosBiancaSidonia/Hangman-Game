   M S B A M L   `   `   `  ����N  JTema_2_Hangman Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Tema_2_Hangman_Game.ViewModelTema_2_Hangman_Game.ViewModel  5   	   C&clr-namespace:Tema_2_Hangman_Game.ViewTema_2_Hangman_Game.View  5   	   *    $Tema_2_Hangman_Game.View.HangmanGame   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Tema_2_Hangman_Game.ViewModel     5   	   8views&clr-namespace:Tema_2_Hangman_Game.View     5   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ Hangman Game��5
   	   $��469.718��6   $��703.603��6/    � WindowStartupLocation$ CenterScreen=�6?    � Icon$ hangman.png��6d    � 	Resources 5      1  +Tema_2_Hangman_Game.ViewModel.GameViewModel 
  GameVM  All_categories �� DataType*   $Tema_2_Hangman_Game.View.HangmanGame-   'Tema_2_Hangman_Game.View.All_categories  Cars#   Tema_2_Hangman_Game.View.Cars 
 Movies%   Tema_2_Hangman_Game.View.Movies 
 States%   Tema_2_Hangman_Game.View.States��%  &	        &	      &	 E     &	 w     &	 �       5   
   6   �� 5   
   "  6.   .R�5        5      �� 5   
   "  6$   .R�5        5      �� 5   
   "  6&   .R�5        5      �� 5   
   "  6&   .R�5        5      5      .��5      � 
������� � DataContext 6!   ��  �� Source# [  .+�5   
   o� -   5        $
��menu��5      $
��Left=�6   $��22��66   $	��Top=�6B   $	��697��6Z   $��0,0,-0.333,0q�6f   .@�5      m� $
��File��6   $��	Bodoni MT)�6%   $��16(�6<   ���#493B5C.@�5      m� $��New Game��6   $��	Bodoni MT)�6/   $��14(�6F   ���#493B5C$
��Bold"�6i    m� Command 6{   �� 	 �� Path$	 NewGameCommand�m� 5      $��	Open Game��6   $��	Bodoni MT)�6.   $��14(�6E   ���#493B5C$
��Bold"�6h    6z   �� $	 OpenSaveCommand�m� 5      $��	Save Game��6   $��	Bodoni MT)�6/   $��14(�6F   ���#493B5C$
��Bold"�6i    6{   �� $	 SaveCommand�m� 5       $��
Statistics��6   $��	Bodoni MT)�60   $��14(�6G   ���#493B5C$
��Bold"�6j    6|   �� $	 StatisticiCommand��� 5!      m� 5"      -   5        $��_Exit��5"      $��	Bodoni MT)�6+   $��14(�6B   $
��Bold"�6P   6b   5#      m� 5$      $��_Categories��6   $��	Bodoni MT)�6,   $��16(�6C   ���#493B5C.@�5%      m� -   5        $	��all��5%      $��_All categories��6&   $��	Bodoni MT)�6@   $��14(�6W   $
��Bold"�6e   
 m� CommandParameter$
 1��6�    6w   �� $	 CategoriesCommand�6�   m� 5&      -   5        $	��car��5&      $��_Cars��6&   $��	Bodoni MT)�66   $��14(�6M   $
��Bold"�6[   $
 2��6�    6n   �� $	 CategoriesCommand�6�   m� 5'      -   5        $��movies��5'      $��_Movies��6)   $��	Bodoni MT)�6:   $��14(�6Q   $
��Bold"�6_   $
 3��6�    6q   �� $	 CategoriesCommand�6�   m� 5(      -   5        $��states��5(      $��_States��6)   $��	Bodoni MT)�6;   $��14(�6R   $
��Bold"�6`   $
 4��6�    6s   �� $	 CategoriesCommand�6�   5)      m� 5*      $��_Help��6   $��	Bodoni MT)�6&   $��16(�6=   ���#493B5C.@�5+      m� -   5        $��About��5+      $��	Bodoni MT)�6+   $��14(�6B   $
��Bold"�6P   6b   5,      5-      �� 5.   
   $��
timer2.png��6   $
��Left=�6%   $��60��6@   $��268,366,0,0q�6L   $	��Top=�6a   $	��171��6y   �� 5/   
   $��g.gif��6   $
��Left=�6   $��37��6:   $��386,379,0,0q�6F   $	��Top=�6[   $��33��6s    J� RenderTransformOrigin$ 2.121,0&�6~   � 51   
   -   5        $��	GameFrame��51      $	��320��6    $��0,63,-0.333,77.667q�6-   $ 0.504,0.464&�6I   52      �� 53   
   -	   5        $��	labelTime��53      $��0 : 30��6!   $
��Left=�62   $��292,379,0,0q�6M   $	��Top=�6b   $��78��6z   $
��Bold"�6�   $��Perpetua Titling MT)�6�   $��43��6�   $��18(�6�   �� 54   
   -
   5        $��start��54      $��
Start time��6   $
��Left=�63   $��
96,387,0,0q�6N   $	��Top=�6b   $��75��6z   $ 0.483,0.554&�6�   ���	#FF17CFE1���	#FF8E2EEF6�   �� 55   
   -   5        $
��stop��55      $��	Stop time��6   $
��Left=�61   $��537,387,0,0q�6L   $	��Top=�6a   $��75��6y   $ 0.483,0.554&�6�   ���	#FF17CFE1���	#FF8E2EEF6�   �� 56   
   -   5        $��player��56      $
��Left=�6   $��
447,33,0,0q�69   $	��Top=�6M   $	��121��6e   $��Lucida Bright)�6q   $��16(�6�   $
��Bold"�6�   �� 57   
   $��Player name:��6   $
��Left=�6'   $��
332,34,0,0q�6B   $	��Top=�6V   $	��121��6n   $��Lucida Bright)�6z   $��16(�6�   $
��Bold"�6�   ���	#FF8E2EEF6�   �� 58   
   -   5        $
��icon��58      $
��Left=�6   $��83��67   $��
550,33,0,0q�6C   $	��Top=�6W   $��94��6o   �� 5:   
   -   5        $��status��5:      $
��Left=�6   $��421,329,0,0q�6:   $	��Top=�6O   $	��266��6g   $��Arial Black)�6s   $��16(�6�   $��53��6�   ���	#FFCB53A46�   � 5;   
   -   5        $
��grid��5;   F   ���	#FF6913BE$
��Left=�6i   $	��124��6�   $��268,187,0,0q�6�   $	��Top=�6�   $	��394��6�   $y�Hidden=�6�    6   �� # [  .+�5<      �� -   5        $��OK��5<      ���	#FF17CFE1���	#FF8E2EEF$
��Left=�6Q   $��
153,86,0,0q�6l   $	��Top=�6�   $��86��6�   $��33��6�   $
��Bold"�6�   $��14(�6�   ��6�   �� $	 CheckCommand�6�   �� 5=      -   5        $	��lbl��5=      $
��Left=�6   $��	55,10,0,0q�6:   $	��Top=�6M   $ -1.404,-0.256&�6e   $	��306��6�   $��76��6�   $
��Bold"�6�   $��Times New Roman)�6�   $��18(�6�   5?      5A      5B      