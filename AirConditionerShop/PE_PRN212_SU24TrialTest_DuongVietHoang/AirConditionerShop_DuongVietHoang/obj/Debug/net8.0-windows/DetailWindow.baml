   M S B A M L   `   `   `  ����\  XAirConditionerShop_DuongVietHoang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AirConditionerShop_DuongVietHoang!AirConditionerShop_DuongVietHoang  5   	   4    .AirConditionerShop_DuongVietHoang.DetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:AirConditionerShop_DuongVietHoang     5   	   -   5          � Title$  Detail Window��5      $	��500��6'   $	��800��64   ���	#FFD4F7D4 � WindowStartupLocation$ CenterScreen=�6W   .��5
      � $��Center=�6   $��Center=�6(    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��140 �6   .+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 10q�66   $	��500��6C   $
��Auto��6O   ._�5      �� .+�5      �� -   5         ��Name$ DetailTittle��5      $$��Create | Update AirConditioner��6.   $��24(�6W   $
��Bold"�6e   
����  �$��Center=�6�   $��0,0,0,20q�6�   �� 5       �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�66   .+�5      �� $��ID��6   $��14(�6)   $
��Bold"�67   $��Center=�6I   $	��120��6d   �� 5      -   5         ��Name$ txtAirConditionerId��5      $��25��6;   $	��0,5q�6G   $��Center=�6T   $	��350��6o   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5      �� $
��Name��6   $��14(�6+   $
��Bold"�69   $��Center=�6K   $	��120��6f   �� 5      -   5        $ txtAirConditionerName��5      $��25��6=   $	��0,5q�6I   $��Center=�6V   $	��350��6q   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5      �� $��Warranty��6   $��14(�6/   $
��Bold"�6=   $��Center=�6O   $	��120��6j   �� 5      -   5        $ txtWarranty��5      $��25��63   $	��0,5q�6?   $��Center=�6L   $	��350��6g   5      �� 5!      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5"      �� $��SP Level��6   $��14(�6/   $
��Bold"�6=   $��Center=�6O   $	��120��6j   �� 5#      -   5        $ txtSoundPressureLevel��5#      $��25��6=   $	��0,5q�6I   $��Center=�6V   $	��350��6q   5$      �� 5&      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5'      �� $��Feature Function��6   $��14(�67   $
��Bold"�6E   $��Center=�6W   $	��120��6r   �� 5(      -   5        $ txtFeatureFunction��5(      $��25��6:   $	��0,5q�6F   $��Center=�6S   $	��350��6n   5)      �� 5+      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5,      �� $��DollarPrice��6   $��14(�62   $
��Bold"�6@   $��Center=�6R   $	��120��6m   �� 5-      -   5        $ txtDollarPrice��5-      $��25��66   $	��0,5q�6B   $��Center=�6O   $	��150��6j   �� 5.      $��Quantity��6   $��14(�6/   $
��Bold"�6=   $��Center=�6O   $��80��6j   $��20,0,0,0q�6u   �� 5/      -	   5        $ txtQuantity��5/      $��25��63   $	��0,5q�6?   $��Center=�6L   $	��100��6g   50      �� 52      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�53      �� $��SupplierCompany��6   $��14(�66   $
��Bold"�6D   $��Center=�6V   $	��120��6q   �� 54      -
   5         ��Name$ selectSupplierCompany��54      $��25��6>   $	��0,5q�6J   $��Center=�6W   $	��350��6r   55      56      57      �� 58   
   $��1��6   $	��Top=�6%   $
��0,20q�6=   .+�59      �� -   5        	 ��Name$	 SaveBtn��59      $
��Save��6&   $	��120��65   $��0,0,0,10q�6A   $	��0,5q�6S   6a   �� 5:      -   5        $	 CloseBtn��5:      $��Close��6'   $	��120��67   $	��0,5q�6C   6Q   5;      5<      5=      