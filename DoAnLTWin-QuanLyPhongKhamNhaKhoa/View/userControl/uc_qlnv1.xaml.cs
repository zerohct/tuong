using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1.export;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_qlnv1.xaml
    /// </summary>

    public partial class uc_qlnv1 : UserControl
    {
        private PhongkhamnhakhoaContext context;
        private ExportToExcel excel;
        public uc_qlnv1()
        {
            InitializeComponent();
            context = new PhongkhamnhakhoaContext();
            LoadEmployees();
        }
        public void LoadEmployees()
        {
            var query = from nv in context.Nhanviens
                        join cv in context.Chucvus
                        on nv.MaCv equals cv.MaCv
                        select new NhanVienView
                        {
                            MaNv = nv.MaNv,
                            TenNv = nv.TenNv,
                            NgaySinh = nv.NgaySinh,
                            Gt = nv.Gt,
                            DiaChi = nv.DiaChi,
                            Email = nv.Email,
                            Sdt = nv.Sdt,
                            TenCv = cv.TenCv
                        };
            DataGridXaml.ItemsSource = query.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemNhanVien nv = new ThemNhanVien();
            nv.Closed += (s, args) =>
            {
                LoadEmployees();
            };
            nv.Show();

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        { 
            var row = DataGridXaml.SelectedItem as NhanVienView;
            if (row == null) return;
            ThemNhanVien nhanVien = new ThemNhanVien(row);
            nhanVien.Closed += (s, args) =>
            {
                LoadEmployees();
            };
            nhanVien.Show();
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = DataGridXaml.SelectedItem as NhanVienView;
            if (selectedEmployee != null)
            {
                try
                {   
                    var employeeToDelete = context.Nhanviens.FirstOrDefault(nv => nv.MaNv == selectedEmployee.MaNv);

                    if (employeeToDelete != null)
                    {
                        context.Nhanviens.Remove(employeeToDelete);
                        context.SaveChanges();
                        LoadEmployees();
                    }
                    else
                    {
                        ShowErrorMessage("Không thể tìm thấy nhân viên để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể xóa nhân viên: " + ex.Message);
                }
            }
            else
            {
                ShowErrorMessage("Chọn một nhân viên để xóa.");
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            excel=new ExportToExcel();
            excel.ExportToExcelpost(DataGridXaml);

        }
    }
}
