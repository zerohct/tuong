using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for ThemChucVu.xaml
    /// </summary>

    public partial class ThemChucVu : Window
    {
        private PhongkhamnhakhoaContext context = new PhongkhamnhakhoaContext();
        private Chucvu newchucvu;
        private Luong newLuong;
        private ViewChucVu dTO;
        public ThemChucVu()
        {
            InitializeComponent();
        }
        public ThemChucVu(ViewChucVu cv)
        {
            InitializeComponent();
            this.dTO = cv;
            nhanData(dTO);

        }
        public void nhanData(ViewChucVu cv)
        {
            txbTitle.Text = "Sửa chức vụ";
            txtChucvu.Text = cv.Tencv;
            txbMoTa.Text = cv.MoTa;
            txtluong.Text = cv.TienLuong.ToString();
            bool isAdmin = IsAdmin(txtChucvu.Text);
            txtChucvu.IsEnabled = !isAdmin;
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
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private bool KiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtChucvu.Text))
            {
                ShowErrorMessage("Nhập đầy đủ tên chức vụ");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbMoTa.Text))
            {
                ShowErrorMessage("Nhập mô tả chức vụ");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtluong.Text))
            {
                ShowErrorMessage("Nhập lương cửa chức vụ!");
                return false;
            }

            return true;
        }

        private void Click_ThemNV(object sender, RoutedEventArgs e)
        {
            if (KiemTraDayDuThongTin())
            {
                string input = txtluong.Text;
                decimal output;
                bool success = decimal.TryParse(input, out output);
                if (!success)
                {
                    ShowErrorMessage("Nhập sai chuỗi tiền lương");
                }
                else
                {
                    Chucvu newChucvu = new Chucvu
                    {
                        TenCv = txtChucvu.Text,
                        Mota = txbMoTa.Text
                    };

                    try
                    {
                        context.Chucvus.Add(newChucvu);
                        context.SaveChanges();
                        int newMaCv = newChucvu.MaCv;

                        Luong newLuong = new Luong
                        {
                            MaCv = newMaCv,
                            Tienluong = output
                        };

                        context.Luongs.Add(newLuong);
                        context.SaveChanges();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Không thể thêm chức vụ và lương mới: " + ex.Message);
                    }
                }
            }


        }


        private bool IsAdmin(string tenChucVu)
        {

            return tenChucVu.Equals("admin", StringComparison.OrdinalIgnoreCase);
        }
        private void click_Sua(object sender, RoutedEventArgs e)
        {
            if (KiemTraDayDuThongTin())
            {
                string input = txtluong.Text;
                decimal output;
                bool success = decimal.TryParse(input, out output);
                if (!success)
                {
                    ShowErrorMessage("Nhập sai chuỗi tiền lương");
                    return;
                }

                try
                {
                    var existingChucVu = context.Chucvus.FirstOrDefault(cv => cv.MaCv == dTO.MaCv);

                    if (existingChucVu != null)
                    {
                        existingChucVu.TenCv = txtChucvu.Text;
                        existingChucVu.Mota = txbMoTa.Text;
                        var existingLuong = context.Luongs.FirstOrDefault(l => l.MaCv == dTO.MaCv);
                        if (existingLuong != null)
                        {
                            existingLuong.Tienluong = output;
                        }
                    }
                    else
                    {
                        ShowErrorMessage("Chức vụ không tồn tại.");
                        return;
                    }

                    context.SaveChanges();
                    this.Close();
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể cập nhật chức vụ và lương: " + ex.Message);
                }
            }
        }
        internal Chucvu GetChucVu()
        {
            return newchucvu;
        }

        internal Luong GetLuong()
        {
            return newLuong;
        }
    }
}
