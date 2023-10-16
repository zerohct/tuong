using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for login_Form.xaml
    /// </summary>
    public partial class login_Form : Window
    {
        public bool isLoaded = false;
        public login_Form()
        {
            InitializeComponent(); 


        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txt_userName.Text;
            //string password1 = txtb_password.Text; 
            string password = txt_password.Password; 
            

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {                
                using (var context = new PhongkhamnhakhoaContext())
                {
                    var user = context.Taikhoans.FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);
                    if (user == null)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                        return;

                    }
                    int? chucVu = context.Nhanviens.FirstOrDefault(nv => nv.MaNv == user.MaNv).MaCv;
                    if (chucVu == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        //MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                        MessageBox.Show("Đăng nhập thành công!");
                        EMainWindow mainWindow = new EMainWindow();
                        mainWindow.MaNvFromForm1 = user.MaNv;
                        mainWindow.hienThiTen();
                        mainWindow.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
            }
        }

        public bool IsDarkTheme{get; set;}
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void themeToggle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if(IsDarkTheme = theme.GetBaseTheme()== BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            
            if (checkBox.IsChecked == true)
            {
                txtb_password.Text = txt_password.Password;
                txtb_password.Visibility = Visibility.Visible;
                txt_password.Visibility = Visibility.Hidden;
            }
            else
            {
                txt_password.Password = txtb_password.Text;
                txtb_password.Visibility = Visibility.Hidden;
                txt_password.Visibility = Visibility.Visible;
            }
        }

        private void txtb_password_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_password.Password = txtb_password.Text;
        }
    }
}
