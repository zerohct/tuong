using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model.export;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_HTHoaDon.xaml
    /// </summary>
    public partial class uc_HTHoaDon : UserControl
    {
        private DaphongkhamnhakhoaContext context;
        private ExportToExcel excel;

        public uc_HTHoaDon()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadHoaDon();
        }
        public void LoadHoaDon()
        {
            var query = from pkdt in context.Phieudieutris
                        join nv in context.Nhanviens
                        on pkdt.MaNv equals nv.MaNv
                        join bn in context.Benhnhans
                        on pkdt.MaBn equals bn.MaBn
                        select new HoaDonView
                        {
                            MaPdt = pkdt.MaPdt,
                            TenNv = nv.TenNv,
                            Ngaylap = pkdt.Ngaylap,
                            TenBn = bn.TenBn,
                            TrangThai = pkdt.TrangThai,
                            Nddt = pkdt.Nddt,
                            Tongtien = pkdt.Tongtien,



                        };
            dataGridHoaDon.ItemsSource = query.ToList();
        }
        private void btnIn_Click(object sender, RoutedEventArgs e)
        {

            excel = new ExportToExcel();
            excel.ExportToExcelpost(dataGridHoaDon);
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var selected = dataGridHoaDon.SelectedItem as HoaDonView;
            if (selected != null)
            {
                try
                {
                    var cthdDelete = context.Ctpkdts.Where(ct => ct.MaPdt == selected.MaPdt).ToList();
                    foreach (var ctpkdt in cthdDelete)
                    {
                        context.Ctpkdts.Remove(ctpkdt);
                    }
                    context.SaveChanges();
                    var HoaDonDelete = context.Phieudieutris.Where(dv => dv.MaPdt == selected.MaPdt).ToList();
                    if (HoaDonDelete != null && HoaDonDelete.Any())
                    {
                        foreach (var phieudieutri in HoaDonDelete)
                        {
                            context.Phieudieutris.Remove(phieudieutri);
                        }
                        context.SaveChanges();
                        LoadHoaDon();
                    }
                    else
                    {
                        ShowErrorMessage("Không thể tìm thấy hóa đơn để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể xóa hóa đơn: " + ex.Message);
                }
            }
            else
            {
                ShowErrorMessage("Chọn một hóa đơn để xóa.");
            }

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = datePicker.SelectedDate.Value.Date;
                LoadHoaDon(selectedDate);
            }
            else
            {
                LoadHoaDon();
            }
        }
        public void LoadHoaDon(DateTime? selectedDate = null)
        {
            var query = from pkdt in context.Phieudieutris
                        join nv in context.Nhanviens
                        on pkdt.MaNv equals nv.MaNv
                        join bn in context.Benhnhans
                        on pkdt.MaBn equals bn.MaBn
                        select new HoaDonView
                        {
                            MaPdt = pkdt.MaPdt,
                            TenNv = nv.TenNv,
                            Ngaylap = pkdt.Ngaylap,
                            TenBn = bn.TenBn,
                            TrangThai = pkdt.TrangThai,
                            Nddt  = pkdt.Nddt,
                            Tongtien = pkdt.Tongtien,
                        };

            if (selectedDate.HasValue)
            {
                query = query.Where(hd => hd.Ngaylap == selectedDate.Value);
            }

            dataGridHoaDon.ItemsSource = query.ToList();
        }

        private void dataGridHoaDon_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var selectedRow = (HoaDonView)dataGridHoaDon.SelectedItem;
                if (selectedRow != null)
                {
                    //HTHoaDon newForm = new HTHoaDon();
                    HTHoaDon newForm = new HTHoaDon(selectedRow);
                    newForm.ShowDialog();
                }
            }
        }
    }
}

