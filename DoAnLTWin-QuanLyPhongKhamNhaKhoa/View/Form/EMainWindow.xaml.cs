using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl;
using System;
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
        private uc_hoadon hd = new uc_hoadon();
        private uc_BenhNhan bn = new uc_BenhNhan();
        private getEmployeeName sharedData;
        public EMainWindow()
        {
            InitializeComponent();
            Home trangchu = new Home();
            contentControl.Content = trangchu;
        }
        public void SetSharedData(getEmployeeName data)
        {
            sharedData = data;
        }
        /* public void SetEmployeeName(string name)
         {
             bn.SetEmployeeName(name);
            *//* hd.SetEmployeeName(name);*//*
         }*/
        public int? MaNvFromForm1 { get; set; }
        public void hienThiTen()
        {
            using (var context = new DaphongkhamnhakhoaContext())
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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            }
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
        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            hd.SetSharedData(sharedData);
            contentControl.Content = hd;
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Home trangchu = new Home();
            contentControl.Content = trangchu;
        }
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            string pdfPath = "D:/ca-master/DoAnLTWin-QuanLyPhongKhamNhaKhoa/HDSH.pdf";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnBN_Click(object sender, RoutedEventArgs e)
        {
            bn.SetSharedData(sharedData);
            contentControl.Content = bn;
        }

        private void btnhd_Click(object sender, RoutedEventArgs e)
        {
            uc_HTHoaDon uc = new uc_HTHoaDon();
            contentControl.Content = uc;
        }
    }
}
