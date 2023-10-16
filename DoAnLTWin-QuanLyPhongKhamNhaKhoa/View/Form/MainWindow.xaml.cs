using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using System.Linq;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng không?", "Xác nhận thoát", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; 
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }


        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            login_Form loginWindow = new login_Form();
            loginWindow.Show();
            this.Close();
                

        }
        private void EmployeetButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeExpander.IsExpanded = !EmployeeExpander.IsExpanded;
        }
        private void EmployeeInfor_Click(object sender, RoutedEventArgs e)
        {
            uc_qlnv1 nhanVien = new uc_qlnv1();
            contentControl.Content = nhanVien;
        }
        private void ChucVu_Click(object sender, RoutedEventArgs e)
        {
            uc_qlcv cv = new uc_qlcv();
            contentControl.Content = cv;
        }

        private void DeviceButton_Click(object sender, RoutedEventArgs e)
        {
            deviceExpander.IsExpanded = !deviceExpander.IsExpanded;
        }
        private void SupplierButton_Click(object sender, RoutedEventArgs e)
        {
            SupplierExpander.IsExpanded = !SupplierExpander.IsExpanded;
        }
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            CheckExpander.IsExpanded = !CheckExpander.IsExpanded;
        }

        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            About_us_form about_Us = new About_us_form();
            about_Us.ShowDialog();
            
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Create_Account ca = new Create_Account();
            ca.ShowDialog();

        }
        private void Helpme_Click(object sender, RoutedEventArgs e)
        {
            //Code to show the create account page
        }

        private void btnThuoc_Click(object sender, RoutedEventArgs e)
        {
            uc_Thuoc thuoc = new uc_Thuoc();
            contentControl.Content = thuoc;
        }

        private void btnNCC_Click(object sender, RoutedEventArgs e)
        {
            uc_ThemNCC NCC = new uc_ThemNCC();
            contentControl.Content = NCC;
        }

        private void btnThietBi_Click(object sender, RoutedEventArgs e)
        {
            uc_ThietBi tb = new uc_ThietBi();
            contentControl.Content = tb;
        }

        private void btnBenhNhan_Click(object sender, RoutedEventArgs e)
        {
            uc_qlbn bn = new uc_qlbn();
            contentControl.Content = bn;
        }

        private void btnDichVu_Click(object sender, RoutedEventArgs e)
        {
            uc_dichvu dv = new uc_dichvu();
            contentControl.Content = dv;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uc_hoadon hd = new uc_hoadon();
            contentControl.Content = hd;
        }
    }
}
