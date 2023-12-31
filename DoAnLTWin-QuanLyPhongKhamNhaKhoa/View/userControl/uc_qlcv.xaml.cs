﻿using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model.export;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_qlcv.xaml
    /// </summary>
    public partial class uc_qlcv : UserControl
    {
        private DaphongkhamnhakhoaContext context;
        private ExportToExcel excel;
        public uc_qlcv()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadChucVus();
        }
        public void LoadChucVus()
        {
            var cv = context.ViewChucVus.ToList();
            DataGridXaml.ItemsSource = cv;

        }
        public void ReloadData()
        {
            LoadChucVus();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemChucVu cv = new ThemChucVu();
            cv.Closed += (s, args) =>
            {
                ReloadData();
            };
            cv.Show();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridXaml.SelectedItem as ViewChucVu;
            if (row == null) return;
            ThemChucVu cv = new ThemChucVu(row);
            cv.Closed += (s, args) =>
            {
                LoadChucVus();
            };
            cv.Show();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var selectedChucVu = DataGridXaml.SelectedItem as ViewChucVu;
            if (selectedChucVu != null)
            {
                try
                {
                    int maChucVu = selectedChucVu.MaCv;
                    var luongToDelete = context.Luongs.Where(l => l.MaCv == maChucVu).ToList();
                    foreach (var luong in luongToDelete)
                    {
                        context.Luongs.Remove(luong);
                    }
                    var chucVuToDelete = context.Chucvus.FirstOrDefault(cv => cv.MaCv == maChucVu);
                    if (chucVuToDelete != null)
                    {
                        context.Chucvus.Remove(chucVuToDelete);
                        context.SaveChanges();
                        LoadChucVus();
                    }
                    else
                    {
                        ShowErrorMessage("Không thể tìm thấy chức vụ để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể xóa Chức vụ và lương: " + ex.Message);
                }
            }
            else
            {
                ShowErrorMessage("Chọn một Chức vụ để xóa.");
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            excel = new ExportToExcel();
            excel.ExportToExcelpost(DataGridXaml);
        }
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {


            string searchKeyword = textBoxSearch.Text.ToLower();
            ICollectionView view = CollectionViewSource.GetDefaultView(DataGridXaml.ItemsSource);
            if (view != null)
            {
                view.Filter = item =>
                {

                    var employeeView = (ViewChucVu)item;
                    return employeeView.Tencv.ToLower().Contains(searchKeyword);
                };
            }
        }
    }
}
