using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form
{
    /// <summary>
    /// Interaction logic for ThemDichVu.xaml
    /// </summary>
    public partial class ThemDichVu : Window
    {
        private PhongkhamnhakhoaContext context = new PhongkhamnhakhoaContext();
        private Dichvu dv;
        public ThemDichVu()
        {
            InitializeComponent();
        }
        public ThemDichVu(Dichvu DV)
        {
            InitializeComponent();
            this.dv = DV;
            nhanData(DV);
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        public void nhanData(Dichvu dv)
        {
            txbTitle.Text = "Sửa dịch vụ";
            txtDichVu.Text = dv.TenDv;
            txtDvt.Text = dv.Dvt;
            txtGiaDv.Text = dv.Giadv.ToString();
            txtKhuyenMai.Text = dv.Khuyenmai.ToString();
            txtTGBH.Text = dv.Tgbh.ToString();
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private bool KiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtDichVu.Text))
            {
                ShowErrorMessage("Nhập đầy đủ tên dịch vụ");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDvt.Text))
            {
                ShowErrorMessage("Nhập đơn vịn tính");
                return false;
            }

            return true;
        }
        private void Click_ThemNV(object sender, RoutedEventArgs e)
        {
            if (KiemTraDayDuThongTin())
            {
                string input = txtGiaDv.Text;
                decimal output;
                bool success = decimal.TryParse(input, out output);
                string input1 = txtKhuyenMai.Text;
                int output1;
                bool success1 = int.TryParse(input1, out output1);
                string input2 = txtTGBH.Text;
                double output2;
                bool success2 = double.TryParse(input2, out output2);
                if (!success)
                {
                    ShowErrorMessage("Nhập sai giá dịch vụ");
                }
                else
                {
                    Dichvu newDichvu = new Dichvu
                    {
                        TenDv = txtDichVu.Text,
                        Dvt = txtDvt.Text,
                        Giadv = output,
                        Khuyenmai = output1,
                        Tgbh = output2

                    };
                    try
                    {
                        context.Dichvus.Add(newDichvu);
                        context.SaveChanges();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Không thể thêm dịch vụ  mới: " + ex.Message);
                    }
                }
            }
        }

        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();

        }
        private void click_Sua(object sender, RoutedEventArgs e)
        {
            if (KiemTraDayDuThongTin())
            {
                try
                {
                    var existingDv = context.Dichvus.FirstOrDefault(dichvu => dichvu.MaDv == dv.MaDv);
                    string input = txtGiaDv.Text;
                    decimal output;
                    bool success = decimal.TryParse(input, out output);
                    string input1 = txtKhuyenMai.Text;
                    int output1;
                    bool success1 = int.TryParse(input1, out output1);
                    string input2 = txtTGBH.Text;
                    double output2;
                    bool success2 = double.TryParse(input2, out output2);
                    if (!success)
                    {
                        ShowErrorMessage("Nhập sai giá dịch vụ");
                    }
                    if (existingDv != null)
                    {
                        existingDv.TenDv = txtDichVu.Text;
                        existingDv.Dvt = txtDvt.Text;
                        existingDv.Giadv = output;
                        existingDv.Khuyenmai = output1;
                        existingDv.Tgbh = output2;
                        context.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        ShowErrorMessage("Dịch vụ không tồn tại.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể cập nhật thông tin nhà dịch vụ: " + ex.Message);
                }
            }
        }
    }
}
