using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for EMainWindow.xaml
    /// </summary>
    public partial class EMainWindow : Window
    {
        public EMainWindow()
        {
            InitializeComponent();
        }
        public int? MaNvFromForm1 { get; set; }
        public void hienThiTen()
        {
            using (var context = new PhongkhamnhakhoaContext())
            {
                int? chucVuId = context.Nhanviens.FirstOrDefault(nv => nv.MaNv == MaNvFromForm1).MaCv;

                if (chucVuId != null)
                {
                    var chucVu = context.Chucvus.FirstOrDefault(cv => cv.MaCv == chucVuId);

                    if (chucVu != null)
                    {
                        chucVutext.Text = "Chức vụ: " + chucVu.TenCv;
                    }
                }
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

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatientExpander.IsExpanded = !PatientExpander.IsExpanded;
        }

        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            About_us_form about_Us = new About_us_form();
            about_Us.ShowDialog();
        }


        private void Helpme_Click(object sender, RoutedEventArgs e)
        {
            //Code to show the create account page
        }

        private void addImageButton_Click(object sender, RoutedEventArgs e)
        {

        }
/*        public int GetNewestMaPdt()
        {
            using (var context = new PhongkhamnhakhoaContext())
            {
                var newestMaPdt = context.Phieudieutris
                    .OrderByDescending(pdt => pdt.MaPdt)
                    .Select(pdt => pdt.MaPdt)
                    .FirstOrDefault();
                if (newestMaPdt != null)
                {
                    return newestMaPdt + 1;
                }
                else
                {
                    return 1;
                }
            }
        }*/
        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            /*currentMaPdt = GetNewestMaPdt();*/
            uc_hoadon hd=new uc_hoadon();
            contentControl.Content = hd;
        }
    }
}
