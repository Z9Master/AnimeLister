   M S B A M L   `   `   `  ����F  BAnimeLister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AnimeListerAnimeLister  5   	       AnimeLister.AddAnime   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AnimeLister     5   	     � Title$  	Add anime��5   	   $	��270��6   $	��650��6(    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J    � WindowStyle$
 None=�6o   .��5	      � ���	#FF2C2C2C � RowDefinitions 5
   
   �� 5      $��20 �6   6*   �� 5      6   .+�5   
   � $��1��6   ���	#FF363636 � ColumnDefinitions 5      �� 5      6%   �� 5      $��7* �6$   61   .+�5      � $��0��6    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%�   '��       �� 5      
LabelStyle��" ��60   .�5      ��  � ��$	 Century Gothic)�67   6P   �� 5       � ��$	 15(�65   6B   �� 5       � ��
	 �����6G   5      5       5      �� 5      6&   �� 5      6&   �� 5      6&   �� 5      6&   �� 5       6&   �� 5!      $��3* �6$   62   �� 5"      6&   .+�5$      � $��0��6   .+�5%      �� .��6   Name6"   5&      � 5'      $��1��6   .+�5(      �� .��6   Year6"   5)      � 5*      $��2��6   .+�5+      �� .��6   Genre6#   5,      � 5-      $��3��6   .+�5.      �� .��6   Saw6!   5/      � 50      $��4��6   .+�51      �� .��6   	Picture6%   52      � 53      $��5��6   .+�54      �� .��6   Note6"   55      56      � 57      $��1��6    58      ��%  '��       �� 59      TextBoxStyle��" ��62   .�5:      ��  � ��$	 Century Gothic)�67   6P   �� 5;       � ��$	 15(�65   6B   �� 5<       � ��	 �	#FF3636366K   �� 5=       � ��
	 �����6G   �� 5>       � ��	 �	#FF5B5B5B6L   5?      5@       5A      �� 5B      6&   �� 5C      6&   �� 5D      6&   �� 5E      6&   �� 5F      6&   �� 5G      $��3* �6$   62   �� 5H      6&   .+�5J      � $��0��6   $��Center=�6$   $
��Left=�6?   .+�5K      �� -   5        
 ��Name$
 TBl_AnimeName��5K      $	��548��65   6C   5L      � 5M      $��1��6   $��Center=�6$   $
��Left=�6?   .+�5N      �� -   5        $
 TBl_AnimeYear��5N      $	��548��65   6C   5O      � 5P      $��2��6   $��Center=�6$   $
��Left=�6?   .+�5Q      �� -   5        $
 TBl_AnimeGenre��5Q      $	��548��66   6D   5R      � 5S      $��3��6   $��Center=�6$   .+�5T      �� -   5         ��Name$ ChB_AnimeSaw��5T      67   5U      � 5V      $��4��6   $��Center=�6$   $
��Left=�6?    5W      �� 5X      6-   �� 5Y      6-   .+�5[      � $��0��6   .+�5\      �� -   5        ���	#FF363636���	#FF5B5B5B$��Century Gothic)�5\   i   $��15(�6�   $	��100��6�   
�������.��6�   Browse6�   5]      � 5^      $��1��6   .+�5_      �� -   5        $��Lb_PictureUrl��5_       $��Century Gothic)�65   $��15(�6Q   
�������.��6r   Url6w   5`      5a      � 5b      $��5��6   $
��Left=�6$   $��Center=�6?   .+�5c      �� -   5        $
 TBl_AnimeText��5c       �� TextWrapping$
 Wrap=�65   $	��548��6I   $��65��6U   6c   5d      � 5e      $��6��6    5f      �� 5g      $��4* �6+   68   �� 5h      6-   �� 5i      6-   .+�5k      � $��1��6   $	��Top=�6+   $��Right=�6C   .+�5l      �� -   5        ���	#FF363636���	#FF5B5B5B
�������$��Century Gothic)�5l   |   $��15(�6�   $��80��6�   .��6�   Cancel6�   5m      � 5n      $��2��6   $	��Top=�6+   $��Center=�6C   .+�5o      �� -	   5        ���	#FF363636���	#FF5B5B5B
�������$��Century Gothic)�5o   z   $��15(�6�   $��80��6�   .��6�   Save6�   5p      5q      5r      5s      5t      5u      