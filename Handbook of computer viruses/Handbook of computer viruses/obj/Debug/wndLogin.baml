   M S B A M L   `   `   `  ����W  SHandbook of computer viruses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Handbook_of_computer_virusesHandbook_of_computer_viruses  5   	   +    %Handbook_of_computer_viruses.wndLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Handbook_of_computer_viruses     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Вхід��5	   	   $	��500��6   $	��400��6#    � 
ResizeMode$ NoResize=�6/   .��5
      � ���	#FF0D0E2E.+�5   
   �� -   5         ��Name$ brdMainInLogin��5      ���#1E1E4E �� CornerRadius$ 50��5      $��15q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6#      Color$ White��63      ShadowDepth$ 0Q�6A   6S   ._�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      �� 5      $	��100 �6$   �� 5      $��50 �6$   	 � ColumnDefinitions	 5      �� 5      $��50 �6'   �� 5      .+�5      �� -   5        
 ��Name$
 lblLogin��5      $��0��5      $��2��5       $��Вхід��5!      $��Center=�5"      $��Center=�5#      $��25(�5$      $
��Bold"�5%      
��� � �5&      �� 5(      $��1��6   $��1��5)   !   $��
10,40,60,0q�5*   !   .+�5+      �� -   5         ��Name$ txtLogin��5+      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логін��5,       %  !MaterialDesignFloatingHintTextBox#��[  5-      
�������$��25(�5/      G� 50      -   5         G�Name$ psbPassword��50   "   $ Пароль��51   "    ) %MaterialDesignFloatingHintPasswordBox#��[ 52   "   
�������$��25(�54   "   55      �� 57      $��1��6   $��0��58      .+�59      �� -   5         ��Name$ imgLogin��59      $
��Fill=�5:       $��50��5;       $��50��5<       
 �� Top$ 60��5=       $��5,0,0,0q�5>       �� 5?      -   5        $ imgPassword��5?      $
��Fill=�5@       $��50��5A       $��50��5B       $	 134��5C       5D      � 5F      $��2��6   $��2��5G      .+�5H      �� -   5        $ brdLogin��5H      $	��200��5I   !   $��50��5J   !   $��0,0,0,30q�5K   !    � Cursor$
 Hand��5L   !   
��� � �$ 30��5N   !   ._�5R      �� $��Center=�6    $��Center=�5S   $   $��Увійти��5T   $   $��22(�5U   $   $
��Bold"�5V   $    5W        5X      -   5        brdLoginEffectsMist��$ 20Q�5Y   /   $
 Lime��5Z   /   $ 0Q�5[   /   5\      5_      5`      � 5b      $��3��6   $��2��5c      .+�5d      �� -	   5         ��Name$ tbSignUp��5d       
�������$��Center=�5f       �� 5g      -
   5         ��Name$ rnSignUp��5g   "   $��16(�5h   "   .�60   Немає аккаунта?5j       B� 5k      -   5         B�Name$ 	unlSignUp��5k   (   
����  �$��16(�5m   (    � Cursor$
 Hand��5n   (   .�5o   G    Зареєструватись5q      5r      5s      5t      5u      5v      5w      