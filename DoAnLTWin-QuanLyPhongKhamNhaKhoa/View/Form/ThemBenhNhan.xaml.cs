using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
    
namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form
{
    /// <summary>
    /// Interaction logic for ThemBenhNhan.xaml
    /// </summary>
    public partial class ThemBenhNhan : Window
    {
        private DaphongkhamnhakhoaContext context = new DaphongkhamnhakhoaContext();
        private Benhnhan newBenhnhan = new Benhnhan();
        public ThemBenhNhan()
        {
            InitializeComponent();
            LoadGioiTinhComboBox();
        }
        public ThemBenhNhan(Benhnhan benhNhan)
        {
            InitializeComponent();
            LoadGioiTinhComboBox();
            this.newBenhnhan = benhNhan;
            nhanData(benhNhan);
        }
        public void nhanData(Benhnhan bn)
        {
            txbTitle.Text = "Sửa bệnh nhân";
            txtName.Text = bn.TenBn;
            txtDiaChi.Text = bn.DiaChi;
            txtSDT.Text = bn.Sdt;
            txtEmail.Text = bn.Email;
            cbGioiTinh.Text = bn.GioiTinh;
            dtNTNS.Text=bn.NgaySinh.ToString();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
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
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
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

        private void Click_ThemBN(object sender, RoutedEventArgs e)
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
                    this.Close();
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể bệnh nhân mới: " + ex.Message);
                }
            }
        }



        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();

        }


        private bool IsAdmin(string tenChucVu)
        {

            return tenChucVu.Equals("admin", StringComparison.OrdinalIgnoreCase);
        }

        private void click_Sua(object sender, RoutedEventArgs e)
        {
            string? selectedGender = cbGioiTinh.SelectionBoxItem as string;
            DateTime? selectedNgaySinh = dtNTNS.SelectedDate;

            if (KiemTraDayDuThongTin())
            {
                try
                {
                    var existingBenhnhan = context.Benhnhans.FirstOrDefault(bn => bn.MaBn == newBenhnhan.MaBn);

                    if (existingBenhnhan != null)
                    {

                        existingBenhnhan.TenBn = txtName.Text;
                        existingBenhnhan.NgaySinh = selectedNgaySinh ?? DateTime.MinValue;
                        existingBenhnhan.GioiTinh = selectedGender;
                        existingBenhnhan.DiaChi = txtDiaChi.Text;
                        existingBenhnhan.Email = txtEmail.Text;
                        existingBenhnhan.Sdt = txtSDT.Text;

                        context.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        ShowErrorMessage("Bệnh nhân không tồn tại.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể cập nhật thông tin bệnh nhân: " + ex.Message);
                }
            }
        }
    }

}


