using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model.export;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_Thuoc.xaml
    /// </summary>
    public partial class uc_Thuoc : UserControl
    {
        private DaphongkhamnhakhoaContext context;
        private ExportToExcel excel;
        public uc_Thuoc()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadThuoc();
        }
        public void LoadThuoc()
        {
            var query = from thuoc in context.Thuocs
                        join ncc in context.Nhacungcaps
                        on thuoc.Mancc equals ncc.MaNcc
                        join dt in context.Dangthuocs
                        on thuoc.MaDt equals dt.MaDt
                        select new ThuocView
                        {
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc =thuoc.TenThuoc,
                            Mota=thuoc.Mota,
                            Gia=thuoc.Gia,
                            TenDt=dt.TenDt,
                            TenNcc=ncc.TenNcc,
                            Hsd=thuoc.Hsd
            
                        };
            DataGridThuoc.ItemsSource = query.ToList();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemThuoc thuoc = new ThemThuoc();
            thuoc.Closed += (s, args) =>
            {
                LoadThuoc();
            };
            thuoc.Show();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridThuoc.SelectedItem as ThuocView;
            if (row == null) return;
            ThemThuoc thuoc = new ThemThuoc(row);
            thuoc.Closed += (s, args) =>
            {
                LoadThuoc();
            };
            thuoc.Show();
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var selectedThuoc = DataGridThuoc.SelectedItem as ThuocView;
            if (selectedThuoc != null)
            {
                try
                {
                    var thuocDelete = context.Thuocs.FirstOrDefault(thuoc => thuoc.MaThuoc == selectedThuoc.MaThuoc);

                    if (thuocDelete != null)
                    {
                        context.Thuocs.Remove(thuocDelete);
                        context.SaveChanges();
                        LoadThuoc();
                    }
                    else
                    {
                        ShowErrorMessage("Không thể tìm thấy thuốc  để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể xóa thuốc: " + ex.Message);
                }
            }
            else
            {
                ShowErrorMessage("Chọn một thuốc để xóa.");
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            excel = new ExportToExcel();
            excel.ExportToExcelpost(DataGridThuoc);
        }
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {


            string searchKeyword = textBoxSearch.Text.ToLower();
            ICollectionView view = CollectionViewSource.GetDefaultView(DataGridThuoc.ItemsSource);
            if (view != null)
            {
                view.Filter = item =>
                {

                    var employeeView = (ThuocView)item;
                    return employeeView.TenThuoc.ToLower().Contains(searchKeyword);
                };
            }
        }
    }
}
