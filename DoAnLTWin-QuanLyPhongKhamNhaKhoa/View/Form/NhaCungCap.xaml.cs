using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for NhaCungCap.xaml
    /// </summary>
    public partial class NhaCungCap : Window
    {
        private PhongkhamnhakhoaContext context = new PhongkhamnhakhoaContext();
        private Nhacungcap ncc;
        public NhaCungCap()
        {
            InitializeComponent();
        }
        public NhaCungCap(Nhacungcap NCC)
        {
            InitializeComponent();
            this.ncc = NCC;
            nhanData(NCC);
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();

        }
        public void nhanData(Nhacungcap mcc)
        {
            txbTitle.Text = "Sửa nhà cung cấp";
            txtNameNcc.Text = ncc.TenNcc;
            txtSDT.Text = ncc.Sdt;
            txtDiaChi.Text = ncc.DiaChi;
            txtEmail.Text = ncc.Email;
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
        private bool KiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtNameNcc.Text))
            {
                ShowErrorMessage("Nhập đầy đủ tên nhà cung cấp");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                ShowErrorMessage("Nhập địa chỉ");
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

            return true;
        }

        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            if (KiemTraDayDuThongTin())
            {
                bool isEmailExist = context.Nhacungcaps.Any(ncc => ncc.Email == txtEmail.Text);
                bool isSdtExist = context.Nhacungcaps.Any(ncc => ncc.Sdt == txtSDT.Text);
                if (isEmailExist || isSdtExist)
                {
                    ShowErrorMessage("Email hoặc số điện thoại đã tồn tại!");
                }
                else
                {
                    Nhacungcap newNhaCC = new Nhacungcap
                    {
                        TenNcc = txtNameNcc.Text,
                        Email = txtEmail.Text,
                        Sdt = txtSDT.Text,
                        DiaChi = txtDiaChi.Text,

                    };
                    try
                    {
                        context.Nhacungcaps.Add(newNhaCC);
                        context.SaveChanges();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Không thể thêm nhà cung cấp mới: " + ex.Message);
                    }
                }
            }
        }
        private void click_Sua(object sender, RoutedEventArgs e)
        {

            if (KiemTraDayDuThongTin())
            {
                try
                {
                    var existingNCC = context.Nhacungcaps.FirstOrDefault(nc => nc.MaNcc == ncc.MaNcc);

                    if (existingNCC != null)
                    {
                        existingNCC.TenNcc = txtNameNcc.Text;
                        existingNCC.Email = txtEmail.Text;
                        existingNCC.Sdt = txtSDT.Text;
                        existingNCC.DiaChi = txtDiaChi.Text;
                        context.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        ShowErrorMessage("Nhà cung cấp không tồn tại.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể cập nhật thông tin nhà cung cấp: " + ex.Message);
                }
            }
        }

    }
}
