   M S B A M L   `   `   `  ����D  @sub_neteo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:sub_neteo	sub_neteo  5   	       sub_neteo.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:sub_neteo     5   	     � Title$  
MainWindow��5   	   $	��700��6   $
��1000��6)    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowState$ Normal=�6      PrimaryBackgroundColor#���   5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   6-   �� 5      $	��900 �6   6-   .+�5   
   	� -   5         	�Name$ bt_icono��5      $��0��6(     MenuRadioButtonLogo#���  68     logo
 � Tag# �  6f   $	��Top=�5      $��0,50,0,0q�60   6T   �� 5   
     PrimaryColor2#���  6   $��1��6>    �� CornerRadius$ 20��6N   $��
0,20,20,20q�6`   $	��880��6t   ._�5      �  5      �� 5      $	��200 �6'   65   �� 5      $��* �6'   63   .+�5      ��   SecundaryBackgroundColor#���  6   $ 	20,0,0,20��6Q   $��0��6j   ._�5      � 	 � RowDefinitions	 5      �� 5      $	��200 �6,   6;   �� 5       $	��100 �6,   6;   �� 5!      $	��100 �6,   6;   �� 5"      $	��100 �6,   6;   �� 5#      $��* �6,   69   .+�5&      �� $��Right=�6$   $��0,30,5,0q�6@   $��50(�6R   #���   6`   $��Noto Sans SemiBold)�5'   $   $��0��6D   SUB6V   	� 5)      -   5        $ 	bt_Perfil��5)   &   $��1��69   $��Programador��6F     MenuRadioButtonStyle#���  6\     perfil_complete# �  6�   
 � Cursor$

 Hand��5*   &   6P   	� 5,      -   5        $ bt_Home��5,   &   $��2��67   $
��Home��6D   #���  6S     home# �  6�   $

 Hand��5-   '    d� 	IsChecked$
 TrueY�65   6[   	� 5.      -   5        $ bt_tabla��5.   &   $��3��68   $��Tabla��6E   #���  6U    	 notes# �  6�   $

 Hand��5/   '   6K   50      51       � 53      -   5          �Name$ PagesNavigation��53      $��1��61     � NavigationUIVisibility$ Hidden=�6A   6c   55      56      57      58      