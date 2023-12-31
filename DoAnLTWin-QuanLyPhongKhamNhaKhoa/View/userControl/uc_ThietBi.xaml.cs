﻿using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
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
    /// Interaction logic for uc_ThietBi.xaml
    /// </summary>
    public partial class uc_ThietBi : UserControl
    {
        private DaphongkhamnhakhoaContext context;
        private ExportToExcel excel;
        public uc_ThietBi()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadThietBi();
        }

        public void LoadThietBi()
        {
            var query = from tb in context.Thietbis
                        join ncc in context.Nhacungcaps
                        on tb.Mancc equals ncc.MaNcc
                        select new ThietBiView
                        {
                            MaTb=tb.MaTb,
                            TenTb=tb.TenTb,
                            Sl=tb.Sl,
                            Tinhtrang =tb.Tinhtrang,
                            TenNcc=ncc.TenNcc,
                        };
            dataGridThietBi.ItemsSource = query.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemThietBi tb = new ThemThietBi();
            tb.Closed += (s, args) =>
            {
                LoadThietBi();
            };
            tb.Show();
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }


        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = dataGridThietBi.SelectedItem as ThietBiView;
            if (selectedEmployee != null)
            {
                try
                {
                    var thietbiDelete = context.Thietbis.FirstOrDefault(tb => tb.MaTb == selectedEmployee.MaTb);

                    if (thietbiDelete != null)
                    {
                        context.Thietbis.Remove(thietbiDelete);
                        context.SaveChanges();
                        LoadThietBi();
                    }
                    else
                    {
                        ShowErrorMessage("Không thể tìm thấy thiết bị để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể xóa thiết bị: " + ex.Message);
                }
            }
            else
            {
                ShowErrorMessage("Chọn một thiết bị để xóa.");
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var row = dataGridThietBi.SelectedItem as ThietBiView;
            if (row == null) return;
            ThemThietBi thietbi = new ThemThietBi(row);
            thietbi.Closed += (s, args) =>
            {
                LoadThietBi();
            };
            thietbi.Show();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            excel = new ExportToExcel();
            excel.ExportToExcelpost(dataGridThietBi);
        }
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {


            string searchKeyword = textBoxSearch.Text.ToLower();
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGridThietBi.ItemsSource);
            if (view != null)
            {
                view.Filter = item =>
                {

                    var employeeView = (ThietBiView)item;
                    return employeeView.TenTb.ToLower().Contains(searchKeyword);
                };
            }
        }
    }
}

