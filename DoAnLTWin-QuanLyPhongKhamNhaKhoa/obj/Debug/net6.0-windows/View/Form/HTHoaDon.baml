   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      $  DoAnLTWin-QuanLyPhongKhamNhaKhoa9   3DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form.HTHoaDon   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0sys&clr-namespace:System;assembly=mscorlib  5      
�������  � WindowStartupLocation$  CenterScreen=�5   ,    � Title$ DisplayHoaDon��5	      $	��650��6   $
��1000��6+   .��5
      � $��Center=�6   $��Center=�6(   .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $��* �6$   �� 5      $	��100 �6$   .+�5      � $��0��6   .+�5      �� $��Chi Tiết Hóa Đơn��6       textfont#��[  68   5      � 5      $��1��6    � ColumnDefinitions 5      �� 5      $	��400 �6+   �� 5      $	��100 �6+   �� 5      $	��400 �6+   .+�5      �� $��0��6!   .+�5      � $��30��6   $	��213��6+   $	��Top=�67   $
��Left=�6O   $��	40 35 0 0q�6j   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�66   $��25��6E   $��25��6Q   $��Center=�6\   �� 5      -   5         ��Name$ 	txbNameNv��5   '   $��30 0 0 0q�6:   $��0q�6L    �� 
IsReadOnly$
 True��6X   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Nhập thông tin nhân viên��5   '    % !MaterialDesignFloatingHintTextBox#��[ 5    '   5!      � 5"      $��30��6   $	��213��6+   $	��Top=�67   $
��Left=�6O   $��	40 40 0 0q�6j   .+�5#        $ CalendarRange=�66   $��25��6K   $��25��6W   $��Center=�6b   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ dtNTNS��5$   )   $��30,0,0,2q�69   $��0q�6K   $ Ngày lập ��5%   *    ( $MaterialDesignFloatingHintDatePicker#��[ 5&   *   
	 �� Now
   SelectedDate#
 Z	 6h   $��Bottom=�5'   )   5*      � 5,      $��25��6   $	��213��6+   $	��Top=�67   $
��Left=�6O   $��
40 40 0 20q�6j   .+�5-        $ People=�66   $��25��6D   $��25��6P   $��Center=�6[   �� 5.      -   5        $ txtBenhNhan��5.   '   $��30 0 0 0q�6<   $��0q�6N   $
 True��6Z   $$ Nhập thông tin bệnh nhân��5/   '   #��[ 50   '   52      53      � 54      $	��200��6   $��6��6)   $��Center=�63   ���#9A8A8A$��1��6c   �� 56      $��2��6!   .+�57      � $��30��6   $	��213��6+   $	��Top=�67   $
��Left=�6O   $��	40 35 0 0q�6j   .+�58        $ Dollar=�66   $��25��6D   $��25��6P   $��Center=�6[   �� 59      -   5        $ txtTongTien��59   '   $��30 0 0 0q�6<   $��0q�6N   $ tổng tiền��5:      $
 True��6?   #��[ 5;      5<      � 5=      $��30��6   $	��213��6+   $	��Top=�67   $
��Left=�6O   $��	40 40 0 0q�6j   .+�5>        $ 
ListStatus=�66   $��25��6H   $��25��6T   $��Center=�6_   �� 5?      -   5         ��Name$ cbTrangThai��5?   '   $��Right=�6<   $��Bottom=�6X   $��30 0 0 0q�6s    " MaterialDesignOutlinedComboBox#��[ 5@       �� 
IsReadOnly$
 True��6J   $ Trạng thái��5A      $��25��5B      $��5q�6   $	��180��6*   .@�5C   "   �� $��Đã Thanh Toán��6/   �� 5D   "   $��Chưa Thanh Toán��6/   �� 5E   "   $��Hủy��6/   5F      5G      � 5H      $��30��6   $	��213��6'   $	��Top=�63   $
��Left=�6K   $��	40 35 0 0q�6f   .+�5I        $	 Pen=�62   $��25��6=   $��25��6I   $��Center=�6T   �� 5J      -   5        $ txtnddt��5J   #   $��30 0 0 0q�64   $��0q�6F   $
 True��6S   $% Nhập nội dung điều trị��5K   %   #��[ 5L   %   5M      5N      5P      � 5R      $��2��6    5S      �� 5T      $
��801* �6+   �� 5U      $	��79* �6+   .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridHoaDon��5W      $
��Left=�5X   &   $��15,0,0,0q�6A   $	��Top=�6S      SelectionMode$ Extended=�5Y   %   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6>      SelectionUnit$ FullRow=�5Z   %   $	��900��6=   $	��250��6I      CanUserReorderColumns$ False��5[   %      AutoGenerateColumns$ False��5\   %      
IsReadOnly$
 True��6A   $��2 0 2 2q�5]   %   
���   �$   HorizontalScrollBarVisibility$
 Auto=�5^      "   VerticalScrollBarVisibility$
 Auto=�6&      GridLinesVisibility$	 All=�5_   %   $��2��6?      Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5c      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã dịch vụ��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *MaDv+  5d      $ Tên dịch vụ��61   $	 120 6F    6R   �� *TenDv+  5e      $ Đơn vị tính��61   $	 100 6F    6R   �� *Dvt+  5f      $ Số Lượng��61   $ 70 6C    6N   �� *Sl+  5g      $ Khuyến mại��61   $	 100 6E    6Q   �� *	Khuyenmai+  5h      $ Gía dịch vụ��61   $	 165 6F    6R   �� *Giadv+  5i      $ Thời gian bảo hành��61   $	 115 6M    6Y   �� *Tgbh+  5j      $ Tổng tiền��61   $	 155 6D    6P   �� *
TongTien+5l      5m      � 5n      $��3��6   .+�5o      �� -   5         ��Name$ btnThoat��5o   h   $��Thoát��6     	AppButton#��[ 6)   $��Right=�6L   6z   5p      5q      5s      5t      