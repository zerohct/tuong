using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for Create_Account.xaml
    /// </summary>
    public partial class Create_Account : Window
    {
        private DaphongkhamnhakhoaContext context;
        private Taikhoan tk;
        List<Nhanvien> nvlist = new List<Nhanvien>();
        public Create_Account()
        {
            InitializeComponent();
            
            context = new DaphongkhamnhakhoaContext();
            LoadDataIntoComboBox();
        }

        private void MinimizeButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
           
            this.WindowState = WindowState.Minimized;
            e.Handled = true; 
        }

        private void LoadDataIntoComboBox()
        {

            var nhanvienquerry = from cv in context.Nhanviens select cv;
            foreach (var cv in nhanvienquerry)
            {
                nvlist.Add(cv);
            }
            cbnhanvien.ItemsSource = nvlist;
            cbnhanvien.DisplayMemberPath = "TenNv";
            cbnhanvien.SelectedValuePath = "MaNv";
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            this.Close();
        }


        private void btnCancer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            int? employeeId = cbnhanvien.SelectedValue as int?;
            if (employeeId == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên.");
            }
            else if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tên đăng nhập và mật khẩu.");
            }
            else
            {
                
                bool isUsernameExist = context.Taikhoans.Any(a => a.TenDangNhap == username);

                if (isUsernameExist)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.");
                }
                else
                {
                    Taikhoan newAccount = new Taikhoan
                    {
                        TenDangNhap = username,
                        MatKhau = password,
                        MaNv = employeeId
                    };
                    context.Taikhoans.Add(newAccount);
                    context.SaveChanges();
                    MessageBox.Show("Tài khoản đã được thêm thành công.");
                }
                txtPass.Clear();
                txtUser.Clear();
            }
        }
    }
}
