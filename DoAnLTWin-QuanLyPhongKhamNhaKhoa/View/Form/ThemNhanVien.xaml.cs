using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for ThemNhanVien.xaml
    /// </summary>
    public partial class ThemNhanVien : Window
    {
        private DaphongkhamnhakhoaContext context = new DaphongkhamnhakhoaContext();
        List<Chucvu> chucVuList = new List<Chucvu>();
        private Nhanvien newEmployee = new Nhanvien();
        private NhanVienView dTO;
        public ThemNhanVien()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            LoadGioiTinhComboBox();
        }
        public ThemNhanVien(NhanVienView nhanvien)
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            LoadGioiTinhComboBox();
            this.dTO = nhanvien;
            nhanData(dTO);
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
        private void LoadDataIntoComboBox()
        {
            var chucVuQuery = from cv in context.Chucvus where cv.TenCv != "admin" select cv;
            foreach (var cv in chucVuQuery)
            {
                chucVuList.Add(cv);
            }
            cbChucVu.ItemsSource = chucVuList;
            cbChucVu.DisplayMemberPath = "TenCv";
            cbChucVu.SelectedValuePath = "MaCv";
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

        private int GetMaCvFromComboBox()
        {
            int selectedMaCv = (int)cbChucVu.SelectedValue;
            if (selectedMaCv != null)
            {
                return selectedMaCv;
            }
            return -1;
        }
        private void Click_ThemNV(object sender, RoutedEventArgs e)
        {
            string? selectedGender = cbGioiTinh.SelectionBoxItem as string;
            DateTime? selectedNgaySinh = dtNTNS.SelectedDate;

            if (KiemTraDayDuThongTin())
            {
                int selectedMaCv = GetMaCvFromComboBox();

                if (selectedMaCv != -1)
                {
                    bool isEmailExist = context.Nhanviens.Any(nv => nv.Email == txtEmail.Text);
                    bool isSdtExist = context.Nhanviens.Any(nv => nv.Sdt == txtSDT.Text);
                    if (isEmailExist || isSdtExist)
                    {
                        ShowErrorMessage("Email hoặc số điện thoại đã tồn tại!");
                    }
                    else
                    {
                        Nhanvien newEmployee = new Nhanvien
                        {
                            TenNv = txtName.Text,
                            NgaySinh = selectedNgaySinh ?? DateTime.MinValue,
                            Gt = selectedGender,
                            DiaChi = txtDiaChi.Text,
                            Email = txtEmail.Text,
                            Sdt = txtSDT.Text,
                            MaCv = selectedMaCv
                        };
                        try
                        {
                            context.Nhanviens.Add(newEmployee);
                            context.SaveChanges();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            ShowErrorMessage("Không thể thêm nhân viên mới: " + ex.Message);
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Chọn một chức vụ.");
                }
            }

        }
        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();

        }

        public void nhanData(NhanVienView nv)
        {
            txbTitle.Text = "Sửa nhân viên";
            txtName.Text = nv.TenNv;
            txtDiaChi.Text = nv.DiaChi;
            txtSDT.Text = nv.Sdt;
            txtEmail.Text = nv.Email;
            cbGioiTinh.Text = nv.Gt;
            cbChucVu.Text = nv.TenCv;

            bool isAdmin = IsAdmin(cbChucVu.Text);

            cbChucVu.IsEnabled = !isAdmin;
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
                int selectedMaCv = GetMaCvFromComboBox();

                if (selectedMaCv != -1)
                {
                    try
                    {
                        var existingEmployee = context.Nhanviens.FirstOrDefault(nv => nv.MaNv == dTO.MaNv);

                        if (existingEmployee != null)
                        {

                            existingEmployee.TenNv = txtName.Text;
                            existingEmployee.NgaySinh = selectedNgaySinh ?? DateTime.MinValue;
                            existingEmployee.Gt = selectedGender;
                            existingEmployee.DiaChi = txtDiaChi.Text;
                            existingEmployee.Email = txtEmail.Text;
                            existingEmployee.Sdt = txtSDT.Text;
                            existingEmployee.MaCv = selectedMaCv;

                            context.SaveChanges();
                            this.Close();
                        }
                        else
                        {
                            ShowErrorMessage("Nhân viên không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Không thể cập nhật thông tin nhân viên: " + ex.Message);
                    }
                }
                else
                {
                    ShowErrorMessage("Chọn một chức vụ.");
                }
            }
        }

    }
}
