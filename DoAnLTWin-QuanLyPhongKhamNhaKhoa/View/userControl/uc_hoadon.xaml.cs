using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_qlphieuluong.xaml
    /// </summary>
    public partial class uc_hoadon : UserControl
    {
        private PhongkhamnhakhoaContext  context;
        private int currentMaPdt;
        public uc_hoadon()
        {
            InitializeComponent();
            context = new PhongkhamnhakhoaContext();
            LoadHoaDon(2);
        }
        public uc_hoadon(int maPdt)
        {
            InitializeComponent();
            context = new PhongkhamnhakhoaContext();
            currentMaPdt = maPdt;
            LoadHoaDon(currentMaPdt);
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void LoadHoaDon(int maPdt)
        {
            currentMaPdt = maPdt;

            var query = from dv in context.Dichvus
                        join c in context.Ctpkdts
                        on dv.MaDv equals c.MaDv
                        join pdt in context.Phieudieutris
                        on c.MaPdt equals pdt.MaPdt
                        where pdt.MaPdt == currentMaPdt 
                        select new PhieuKhamDieuTriView
                        {
                            MaPdt = pdt.MaPdt,
                            MaDv = dv.MaDv,
                            TenDv = dv.TenDv,
                            Dvt = dv.Dvt,
                            Sl = c.Sl,
                            Khuyenmai = dv.Khuyenmai,
                            Giadv = dv.Giadv,
                            Tgbh = dv.Tgbh,
                            TongTien = c.Sl * dv.Giadv,
                        };
            DataGridHoaDon.ItemsSource = query.ToList();
        }

        private void txtSDT_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, RoutedEventArgs e)
        {
            ChiTietHoaDon nv = new ChiTietHoaDon();
            nv.Closed += (s, args) =>
            {
                LoadHoaDon(currentMaPdt);
            };
            nv.Show();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
