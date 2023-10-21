using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form
{
    /// <summary>
    /// Interaction logic for XuatHoaDon.xaml
    /// </summary>
    public partial class XuatHoaDon : Window
    {
        private DaphongkhamnhakhoaContext context = new DaphongkhamnhakhoaContext();
        private List<PhieuKhamDieuTriView> viewList;
        public XuatHoaDon()
        {
            InitializeComponent();
        }
        public XuatHoaDon(string tenbn,string tennv, decimal? tongtien,string trangthai,string nddt,DateTime? ngaylap, ObservableCollection<PhieuKhamDieuTriView> viewlist)
        {
            InitializeComponent();
            viewList = viewlist.ToList();

            if (tenbn != null && tennv != null && tongtien != null && trangthai != null && nddt != null && ngaylap != null && viewlist != null)
            {
                txtTenBenhNhan.Text = tenbn;
                txbNhanVien.Text = tennv;
                txtNgayLapHD.Text = ngaylap.ToString();
                txtNDDT.Text = nddt;
                txtTrangThai.Text = trangthai;
                txtTongTien.Text = tongtien.ToString();
                lvDichVuSD.ItemsSource = viewlist;
            }
            else
            {
                MessageBox.Show("Dữ liệu truyền không hợp lệ!");
            }

        }
        private void click_InHoaDon(object sender, RoutedEventArgs e)
        {
            try
            {
                btnInHoaDon.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "In Hóa đơn");
                    MessageBox.Show("in thành công","thông báo",MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("in lỗi", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                btnInHoaDon.Visibility = Visibility.Visible;
            }
        }
    }
}
