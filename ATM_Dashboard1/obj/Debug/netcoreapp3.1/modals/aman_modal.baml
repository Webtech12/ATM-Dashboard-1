   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   I EATM_Dashboard1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ATM_Dashboard1ATM_Dashboard1 5   	      ATM_Dashboard1.aman_modal   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   (localclr-namespace:ATM_Dashboard1  5   	     � 
ResizeMode$  CanMinimize=�5
   	   $��Segoe UI Emoji)�6"    � Title$ 
aman_modal��5   	   $	��750��6   $	��600��6)   .��5      � .+�5   
   �� $
��AMAN��6   $��25(�6    $��Center=�6.   $��Champagne & Limousines)�6K   $	��Top=�6s   ���#8877a9$��28��5   *   $��83��66    J� RenderTransformOrigin$ 0.433,0.599&�6A   $��0,12,0,0q�6e   � 5   
    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $
��0.5* �6#   �� 5      $
��0.5* �6#   .+�5       � $��0��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5!      �� $��Center=�6   $��15,-10,15,0q�68   .+�5"      �� -   5        $��	txinitial��5"      $
��0,10q�6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Inital��6=    %  !MaterialDesignFloatingHintTextBox#��[  5#      $��Champagne & Limousines)�6Y   $��16(�6�   5$      5%      � 5'      $��0��6   $��1��6    $	��Top=�60   $��0,48,0,0q�6H   $��65��6Z   .+�5(      �� $	��Top=�6   $��
15,27,15,0q�65   .+�5)      (  "System.Windows.Controls.DatePicker  -   5        $��txtdate��5)   !   $
 Date��61     MaterialDesignDatePicker#��[ 6W   $��Champagne & Limousines)�6�   5*      5+      � 5-      $��1��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5.      �� $��Center=�6   $��15,-10,15,0q�68   .+�5/      )  #MaterialDesignThemes.Wpf.TimePicker  -   5          Name$ txttime��5/   0   6C   50      51      � 53      $��1��6   $��1��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�54      �� $��Center=�6   $��15,-30,15,0q�68   .+�55      �� 	On Behalf6+   �� 56      -   5         ��Name$ Onbehalf��56      .@�57      ��  �� 
IsSelected$
 True��6'   .��69   Select6A   58      59      5:      � 5=      $��2��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5>      �� $��Center=�6   $��15,-30,15,0q�68   .+�5?      �� 	Subject6)   �� 5@      -   5        $ subject��5@      .@�5A      �� $
 True��6'   .��69   Select6A   5B      5C      5D      � 5F      $��2��6   $��1��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5G      �� $��Center=�6   $��15,-30,15,0q�68   .+�5H      �� Rate6&   �� 5I      -   5        $
 rate��5I      .@�5J      �� $
 True��6'   .��69   556=   5K      5L      5M      � 5O      $��3��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5P      �� $��Center=�6   $��15,-30,15,0q�68   .+�5Q      �� Status6(   �� 5R      -   5        $ status��5R      .@�5S      �� .��6'   Open6-   �� 5T      $
 True��6'   .��69   Close6@   �� 5U      .��6'   	Follow-Up62   5V      5W      5X      � 5Z      $��3��6   $��1��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5[      �� $	��Top=�6   $��15,-26,15,0q�65   .+�5\      �� -   5        	 ��Name$		 des��5\      
 �� AcceptsReturn$

 True��6+   " �� VerticalScrollBarVisibility$ Visible=�6@    �� TextWrapping$
 Wrap=�6f   $
��0,10q�6z   $ Description��5]      #��[  6I   $��Champagne & Limousines)�5^      $��16(�6D   5_      5`      � 5b      $��4��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5c      �� $��Center=�6   $��15,-10,15,0q�68   .+�5d      �� -	   5        $
	 roci��5d      $
��0,10q�6,   $
 ROSI��6:   $��0��6`   #��[  5e      $��Champagne & Limousines)�6Y   $��16(�6�   5f      5g      � 5i      $��5��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5j      �� $��Center=�6   $��15,-10,15,0q�68   .+�5k      �� -
   5        $	 
close_time��5k      $
��0,10q�62   $ 
Close time��6@   #��[  5l      $��Champagne & Limousines)�6Y   $��16(�6�   ��5k   l   �� 
 �� Now �� Source# Z  �� Mode$ OneWay=� �� StringFormat$ yyyy-MM-dd HH:mm ��5l   �   5m      5n      � 5p      $��4��6   $��1��6    $	��Top=�60   $��0,46,0,0q�6H   $��65��6Z   $��2��6f   .+�5q      �� $��Center=�6   $��15,-10,15,0q�68   .+�5r      �� -   5         ��Name$	 arr��5r      .��6,   	ARR KPI65   �� 5s      -   5        $	 dep��5s      .��6,   	DEP KPI65   �� 5t      -   5        $
 dans��5t      .��6-   Dans Internal6<   5u      5v      5x      �� 5z   
   -   5        $	��150��5z      $��Center=�61   $��Bottom=�6N   $��0,0,0,20q�6i   $��Submit��6{   ���	#FF45B6AF���	#FF45B6AF6�   5|      5      