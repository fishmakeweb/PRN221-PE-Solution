   M S B A M L   `   `   `  ����\  XAirConditionerShop_DuongVietHoang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AirConditionerShop_DuongVietHoang!AirConditionerShop_DuongVietHoang  5   	   2    ,AirConditionerShop_DuongVietHoang.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:AirConditionerShop_DuongVietHoang     5   	   -   5          � Title$&   AirConditioner Management Window��5   	   $	��500��62   $	��800��6?   $��Arial)�6K   $��14(�6^   ���	#FFD4F7D4 � WindowStartupLocation$ CenterScreen=�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��Airconditioner Management��6   $��24(�64   $
��Bold"�6B   
��� � �$
��Left=�5      $��Center=�6/   $��10q�6J   $��0��6V   �� 5   
   $��1��6   
������� �� CornerRadius$ 5��61   $��10q�6B    �� Padding$ 10q�6N   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $��Feature Function��6   $��5q�63   $��0,0,10,0q�6?   �� 5      -   5         ��Name$ txtSearchFeatureFunction��5      $	��150��6<   $��0,0,10,0q�6H   �� 5       $��Minimum Quantity��6   $��5q�63   $��0,0,10,0q�6?   �� 5!      -   5        $ txtSearchQuantity��5!      $	��150��65   $��0,0,10,0q�6A    � ToolTip$  Enter the minimum quantity��6S   �� 5"      -   5        $��Search��5"      $	��100��6*   $��30,0,0,0q�66   6H   5#      5$      �� 5%   
   $��AirConditional list��6   $��2��6.   $
��Bold"�6<   
��� � �$��14(�6a   6q   � 5&   
   $��3��6    � ColumnDefinitions 5'      �� 5(      $��* �6#   �� 5)      $
��Auto �6#   .+�5+      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 AirConditionerDataGrid��5+      $��0��67   
   AutoGenerateColumns$
 False��6G   $��3��6c   $��18(�6p   $��Stretch=�5,      $��Stretch=�65   $��10q�6Q   $   HorizontalScrollBarVisibility$
 Auto=�5-         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ AirConditionerId��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 35 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *AirConditionerId+6h     50      $ AirConditionerName��6)   $	 120 6l    6E   �� *AirConditionerName+6l     51      $ Warranty��6)   $	 150 6X    6;   �� *
Warranty+6X     52      $ SoundPressureLevel��6)   $	 150 6l    6E   �� *SoundPressureLevel+6l     53      $ FeatureFunction��6)   $ 90 6f    6B   �� *FeatureFunction+6f     54      $ Quantity��6)   $ 60 6X    6;   �� *
Quantity+6X     55      $ DollarPrice��6)   $ 80 6^    6>   �� *DollarPrice+6^     56      $ SupplierName��6)   $ 70 6i    6?   �� *Supplier.SupplierName+6i   58      �� 59      $��1��6   $ Vertical=�6)   $	��Top=�6@   $��10q�6X   .+�5:      �� -   5         ��Name$ 	CreateBtn��5:      $��Create AirConditioner��6,   $	��150��6L   $��0,0,0,10q�6X   $
��10,5q�6j   
�������6�   �� 5;      -   5        $ 	UpdateBtn��5;      $��Update AirConditioner��6,   $	��150��6L   $��0,0,0,10q�6X   $
��10,5q�6j   
�������6�   �� 5<      -   5        $ 	DeleteBtn��5<      $��Delete AirConditioner��6,   $	��150��6L   $��0,0,0,10q�6X   $
��10,5q�6j   
�������6�   �� 5=      -	   5        $ QuitBtn��5=      $
��Quit��6*   $	��120��69   $
��10,5q�6E   
�������6j   5>      5?      5A      5B      