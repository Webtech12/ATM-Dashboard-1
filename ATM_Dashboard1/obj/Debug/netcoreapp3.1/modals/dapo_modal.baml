   M S B A M L   `   `   `  ����I  EATM_Dashboard1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ATM_Dashboard1.modalsATM_Dashboard1.modals  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   &     ATM_Dashboard1.modals.dapo_modal   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   /local#clr-namespace:ATM_Dashboard1.modals  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	     � 
ResizeMode$  CanMinimize=�5
   	   $��Segoe UI Emoji)�6"    � Title$ 
dapo_modal��5   	   $	��750��6   $	��600��6)   .��5      � .+�5   
   �� $��D-APO��6   $��25(�6!   $��Center=�6/   $��Champagne & Limousines)�6L   $	��Top=�6t   ���#8877a9$��28��5   *   $��83��66    J� RenderTransformOrigin$ 0.433,0.599&�6A   $��0,12,0,0q�6e   � 5   
    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $
��0.5* �6#   �� 5      $
��0.5* �6#   .+�5      � $��0��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5       �� $��Center=�6   $��15,-10,15,0q�68   .+�5!      �� -   5        $��	txinitial��5!      $
��0,10q�6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Inital��6=    %  !MaterialDesignFloatingHintTextBox#��[  5"      $��Champagne & Limousines)�6Y   $��16(�6�   5#      5$      � 5&      $��0��6   $��1��6    $	��Top=�60   $��0,48,0,0q�6H   $��65��6Z   .+�5'      �� $	��Top=�6   $��
15,27,15,0q�65   .+�5(      (  "System.Windows.Controls.DatePicker  -   5        $��txtdate��5(   !   $
 Date��61     MaterialDesignDatePicker#��[ 6W   $��Champagne & Limousines)�6�   5)      5*      � 5,      $��1��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5-      �� $��Center=�6   $��15,-10,15,0q�68   .+�5.      )  #MaterialDesignThemes.Wpf.TimePicker  -   5          Name$ txttime��5.   0   6C   5/      50      � 52      $��1��6   $��1��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�53      �� $��Center=�6   $��15,-30,15,0q�68   .+�54      �� 	On Behalf6+   �� 55      -   5         ��Name$ Onbehalf��55      .@�56      ��  �� 
IsSelected$
 True��6'   .��69   Select6A   57      58      59      � 5;      $��2��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5<      �� $��Center=�6   $��15,-30,15,0q�68   .+�5=      �� 	Subject6)   �� 5>      -   5        $ subject��5>      .@�5?      �� $
 True��6'   .��69   Select6A   5@      5A      5B      � 5D      $��2��6   $��1��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5E      �� $��Center=�6   $��15,-30,15,0q�68   .+�5F      �� Description6-   �� 5G      -   5        $	 des��5G      .@�5H      �� $
 True��6'   .��69   
Restricted6E   �� 5I      .��6(   Active60   �� 5J      .��6'   
Not Active63   5K      5L      5M      � 5O      $��3��6   $��0��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5P      �� $��Center=�6   $��15,-10,15,0q�68   .+�5Q      �� -   5        	 ��Name$
	 roci��5Q      $
��0,10q�6,   $
 ROSI��6:   $��0��6`   #��[  5R      $��Champagne & Limousines)�6Y   $��16(�6�   5S      5T      � 5V      $��3��6   $��1��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5W      �� $��Center=�6   $��15,-30,15,0q�68   .+�5X      �� Status6(   �� 5Y      -   5        $ status��5Y      .@�5Z      �� .��6'   Open6-   �� 5[      $
 True��6'   .��69   Close6@   �� 5\      .��6'   	Follow-Up62   5]      5^      5_      � 5a      $��4��6   $��0��6    $	��Top=�60   $��0,46,0,0q�6H   $��65��6Z   $��2��6f   .+�5b      �� $��Center=�6   $��15,-10,15,0q�68   .+�5c      �� -	   5        
 ��Name$	
 arr��5c      .��6,   	ARR KPI65   �� 5d      -
   5        $	
 dep��5d      .��6,   	DEP KPI65   �� 5e      -   5        $

 dans��5e      .��6-   Dans Internal6<   5f      5g      � 5i      $��4��6   $��1��6    $	��Top=�60   $��0,50,0,0q�6H   $��65��6Z   .+�5j      �� $��Center=�6   $��15,-10,15,0q�68   .+�5k      �� -   5        $	 
close_time��5k      $
��0,10q�62   $ 
Close time��6@   #��[  5l      $��Champagne & Limousines)�6Y   $��16(�6�   ��5k   l   �� 
 �� Now �� Source# Z  �� Mode$ OneWay=� �� StringFormat$ yyyy-MM-dd HH:mm ��5l   �   5m      5n      5o      �� 5r   
   -   5        $	��150��5r      $��Center=�60   $��Bottom=�6M   $��0,0,0,20q�6h   $��Submit��6z   ���	#FF45B6AF���	#FF45B6AF6�   5t      5u      