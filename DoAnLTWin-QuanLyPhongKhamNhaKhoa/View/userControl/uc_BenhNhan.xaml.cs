using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_BenhNhan.xaml
    /// </summary>
    public partial class uc_BenhNhan : UserControl
    {
        private DaphongkhamnhakhoaContext context = new DaphongkhamnhakhoaContext();
        private uc_hoadon hd;
        private getEmployeeName sharedData;

        public uc_BenhNhan()
        {
            InitializeComponent();
            hd = new uc_hoadon();
            LoadGioiTinhComboBox();
        }
        private void LoadGioiTinhComboBox()
        {
            List<string> gioiTinhList = new List<string>
            {
                "NAM",
                "NỮ",
                "KHÁC"
            };

            cbGioiTinh.ItemsSource = gioiTinhList;
            cbGioiTinh.SelectedValuePath = "GioiTinh";

        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private bool KiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowErrorMessage("Nhập đầy đủ họ tên!");
                return false;
            }

            if (!IsValidPhoneNumber(txtSDT.Text))
            {
                ShowErrorMessage("Nhập số điện thoại đúng định dạng số!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowErrorMessage("Nhập đầy đủ email!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                ShowErrorMessage("Nhập đầy đủ địa chỉ!");
                return false;
            }

            return true;
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 10)
            {
                return false;
            }

            if (!long.TryParse(phoneNumber, out _))
            {
                return false;
            }
            return true;
        }
        public void SetSharedData(getEmployeeName data)
        {
            sharedData = data;
        }
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            string? selectedGender = cbGioiTinh.SelectionBoxItem as string;
            DateTime? selectedNgaySinh = dtNTNS.SelectedDate;

            bool isEmailExist = context.Benhnhans.Any(nv => nv.Email == txtEmail.Text);
            bool isSdtExist = context.Benhnhans.Any(nv => nv.Sdt == txtSDT.Text);
            if (isEmailExist || isSdtExist)
            {
                ShowErrorMessage("Email hoặc số điện thoại đã tồn tại!");
            }
            else
            {
                Benhnhan newBenhnha = new Benhnhan
                {
                    TenBn = txtName.Text,
                    NgaySinh = selectedNgaySinh ?? DateTime.MinValue,
                    GioiTinh = selectedGender,
                    DiaChi = txtDiaChi.Text,
                    Email = txtEmail.Text,
                    Sdt = txtSDT.Text,
                };
                try
                {
                    context.Benhnhans.Add(newBenhnha);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể bệnh nhân mới: " + ex.Message);
                }
                ContentControl mainControl = this.Parent as ContentControl;
                if (mainControl != null)
                {
                    uc_hoadon userControl2 = new uc_hoadon();
                    userControl2.SetPatientName(txtName.Text);
                    userControl2.SetSharedData(sharedData);
                    mainControl.Content = userControl2;
                }
            }
        }
    }
}