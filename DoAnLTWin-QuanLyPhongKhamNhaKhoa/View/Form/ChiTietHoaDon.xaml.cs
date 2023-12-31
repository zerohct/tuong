﻿using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form
{
    /// <summary>
    /// Interaction logic for ChiTietHoaDon.xaml
    /// </summary>
    public partial class ChiTietHoaDon : Window
    {
        private DaphongkhamnhakhoaContext context;
        private List<Dichvu> dichVuList = new List<Dichvu>();
        private List<PhieuKhamDieuTriView> phieuKhamDieuTri = new List<PhieuKhamDieuTriView>();


        public ChiTietHoaDon()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadDataIntoComboBox();
            txtMaDv.IsReadOnly = true;
            txtDvt.IsReadOnly = true;
            txtGiaDv.IsReadOnly = true;
            txtTgbh.IsReadOnly = true;
            txtKhuyenMai.IsReadOnly = true;
        }

        private void LoadDataIntoComboBox()
        {
            var dichVuQuery = from dv in context.Dichvus select dv;
            foreach (var dv in dichVuQuery)
            {
                dichVuList.Add(dv);
            }

            cbTenDv.ItemsSource = dichVuList;
            cbTenDv.DisplayMemberPath = "TenDv";
            cbTenDv.SelectedValuePath = "MaDv";
        }

        public PhieuKhamDieuTriView GetPhieuKhamDieuTri()
        {
            PhieuKhamDieuTriView cthdData = new PhieuKhamDieuTriView();

            cthdData.MaDv = int.Parse(txtMaDv.Text);
            cthdData.TenDv = (cbTenDv.SelectedItem as Dichvu)?.TenDv;
            cthdData.Dvt = txtDvt.Text;
            cthdData.Giadv = decimal.Parse(txtGiaDv.Text);
            cthdData.Sl = int.Parse(txtSl.Text);
            cthdData.TongTien = (cthdData.Sl * cthdData.Giadv);
            if (!string.IsNullOrEmpty(txtTgbh.Text) && double.TryParse(txtTgbh.Text, out double tgbhValue))
            {
                cthdData.Tgbh = tgbhValue;
            }
            else
            {
                cthdData.Tgbh = 0;
            }
            

            return cthdData;
        }

        private void Click_Them(object sender, RoutedEventArgs e)
        {
            if (IsValidInput())
            {

                DialogResult = true;
                this.Close();

            }
        }
        private void click_Sua(object sender, RoutedEventArgs e)
        {
            if (IsValidInput())
            {

                DialogResult = true;
                this.Close();

            }
        }

        private bool IsValidInput()
        {
            if (cbTenDv.SelectedItem == null || string.IsNullOrWhiteSpace(txtSl.Text) )
            {
                ShowErrorMessage("Vui lòng điền đầy đủ thông tin chi tiết hóa đơn.");
                return false;
            }

            int soLuong;
            if (!int.TryParse(txtSl.Text, out soLuong) || soLuong <= 0)
            {
                ShowErrorMessage("Số lượng phải là một số nguyên dương.");
                return false;
            }


            return true;
        }



        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void click_Huy(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void LoadData(PhieuKhamDieuTriView data)
        {
            txbTitle.Text = "Sửa Thông Tin";
           cbTenDv.Text= data.TenDv;
           txtSl.Text=data.Sl.ToString();

        }
        private void cbTenDv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTenDv.SelectedItem != null)
            {
                Dichvu selectedDichVu = (Dichvu)cbTenDv.SelectedItem;
                txtMaDv.Text = selectedDichVu.MaDv.ToString();
                txtDvt.Text = selectedDichVu.Dvt;
                txtGiaDv.Text = selectedDichVu.Giadv.ToString();
                txtTgbh.Text = selectedDichVu.Tgbh.ToString();
                txtKhuyenMai.Text=selectedDichVu.Khuyenmai.ToString();
            }
        }
    }

}
