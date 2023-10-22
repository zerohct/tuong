using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form
{
    /// <summary>
    /// Interaction logic for HTHoaDon.xaml
    /// </summary>
    public partial class HTHoaDon : Window
    {
        private DaphongkhamnhakhoaContext context = new DaphongkhamnhakhoaContext();
        public HTHoaDon()
        {
            InitializeComponent();
        }
        public HTHoaDon(HoaDonView hd)
        {
            InitializeComponent();
            nhanData(hd);
        }
        public void nhanData(HoaDonView th)
        {
            txtBenhNhan.Text = th.TenBn;
            txtTongTien.Text = th.Tongtien.ToString();
            txbNameNv.Text = th.TenNv;
            cbTrangThai.Text = th.TrangThai;
            txtnddt.Text = th.Nddt;
            dtNTNS.Text=th.Ngaylap.ToString();
            var query = from ct in context.Ctpkdts
                        join dv in context.Dichvus
                        on ct.MaDv equals dv.MaDv
                        join pdt in context.Phieudieutris
                        on ct.MaPdt equals pdt.MaPdt
                        where ct.MaPdt.Equals(th.MaPdt)
                        select new PhieuKhamDieuTriView 
                        {
                            MaPdt=th.MaPdt,
                            MaDv=dv.MaDv,
                            TenDv=dv.TenDv,
                            Dvt=dv.Dvt, 
                            Sl=ct.Sl,
                            Khuyenmai=dv.Khuyenmai,
                            Giadv=dv.Giadv,
                            Tgbh=dv.Tgbh,
                            TongTien= dv.Giadv*ct.Sl,
                        };
            DataGridHoaDon.ItemsSource = query.ToList();

        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
