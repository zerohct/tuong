   M S B A M L   `   `   `  ����[  WDoAnLTWin-QuanLyPhongKhamNhaKhoa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl1DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl  5      ?    9DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl.uc_qlbn   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nuc?clr-namespace:DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl     5      
�������.��5	      (� .��5
   
   �   � RowDefinitions  5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $��50 �6    �� 5      $��30 �6    .+�5      � $��0��6   .+�5      �� $��Thông tin Bệnh nhân��6      textfont#��[  67   5      � 5      $��1��6    � ColumnDefinitions 5      �� 5      $��20 �6'   �� 5      $	��160 �6'   �� 5      $	��160 �6'   �� 5      $	��160 �6'   �� 5      $	��160 �6'   �� 5      $	��170 �6'   .+�5      � $��1��6   .+�5      �� -   5         ��Name$ btnThem��5   Y   $��Thêm Bệnh nhân��6     	AppButton#��[ 66   $
��Left=�6�   $��
10,30,0,10q�6�   $	��150��6�   5       � 5!      $��2��6   .+�5"      �� -   5        $ btnSua��5"   X   $��Sửa Bệnh nhân��6   #��[ 65   $��30��6}   $��
10,30,10,0q�6�   $	��Top=�6�   5#      � 5$      $��3��6   .+�5%      �� -   5        $ btnXoa��5%   X   $��Xóa Bệnh nhân��6   #��[ 65   $	��NaN��6h   $��10,30,10,10q�6u   6�   5&      � 5'      $��4��6   .+�5(      �� -   5        $ btnIn��5(   W   $��In Thông Tin��6   #��[ 64   6f   5)      � 5*      $��5��6   .+�5+      �� 
�������
�������$��1q�6J    �� CornerRadius$ 10��6^   $	��160��6p   $��30��6|   $��	0,17,10,0q�6�   ._�5,      � .+�5-      �� -   5        $��textBoxSearch��5-   &   $��Center=�6<   $	��150��6Y   $��20��6e   $��13(�6q   $��Center=�6   
������ $��0q�6�   $��0q�6�   $��0q�6�   �� 5.      $��Search��6(   $��Center=�66   $
��Left=�6Q   $��5,0,0,0q�6l   
���������5/   "   �� 50   &    �� 
TargetType" ��6,    �� Triggers 51   *   �� 52   .    �� Binding 6:   �� *Text+ �� ElementName$ textBoxSearch�� �� Value  6n   .a�53   2   �� 	 �� Property	 � y�
 �� Value$
 Visible=�6O   54   /   .�56   *   �� 	 � y�$
 Hidden=�6G   57   '   59      5:      5;      5<      5=      � 5>      $��2��6    5?      �� 5@      $
��161* �6'   �� 5A      $
��229* �6'   .+�5C      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridBenhNhan��5C      $��Center=�65   $��15,0,0,0q�6R   $��Center=�6d      SelectionMode$ Extended=�6   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�      SelectionUnit$ FullRow=�5D      $	��750��65   $	��300��6A      CanUserReorderColumns$ False��6N   $
��Auto=�5E      $
��Auto=�6M      AutoGenerateColumns$ False��6}      
IsReadOnly$
 True��6�   $��2 0 2 2q�6�   
���   �   GridLinesVisibility$	 All=�6�   $��2��6�      Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Bệnh Nhân��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *MaBn+  5I      $ Tên Bệnh Nhân��6-   $	 120 6D    6P   �� *TenBn+  5J      $ 
Ngày Sinh��6-   $	 100 6@    6L   �� *
NgaySinh+ �� StringFormat$ 
dd/MM/yyyy��  5K      $ Giới Tính��6-   $ 70 6@    6K   �� *
GioiTinh+  5L      $ Địa Chỉ��6-   $	 100 6>    6J   �� *DiaChi+  5M      $ Email��6-   $	 165 6<    6H   �� *Email+  5N      $
 SĐT��6-   $	 115 6:    6F   �� *Sdt+5R      5T      � 5U      $��3��6   $��Right=�6    .+�5V      E   ?DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl.navigationBar  5W      5X      5Y      5Z      