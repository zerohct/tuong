using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Drawing.Printing;


namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_qlphieuluong.xaml
    /// </summary>
    public partial class uc_hoadon : UserControl
    {
        private PhongkhamnhakhoaContext context;
        private int currentMaPdt;
        private ObservableCollection<PhieuKhamDieuTriView> chiTietHoaDonList = new ObservableCollection<PhieuKhamDieuTriView>();

        public uc_hoadon()
        {
            InitializeComponent();
            context = new PhongkhamnhakhoaContext();
            LoadHoaDon();
        }
        public void LoadHoaDon()
        {
            /*currentMaPdt = maPdt;*/

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


        private void UpdateTotalAmount()
        {
            decimal tongTien = chiTietHoaDonList.Sum(item => item.TongTien);
            txtTongTien.Text = tongTien.ToString();
        }
        private void btnThem_Click_1(object sender, RoutedEventArgs e)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.Closed += (s, args) =>
            {
                if (cthd.DialogResult == true)
                {
                    PhieuKhamDieuTriView chiTietHoaDonData = cthd.GetPhieuKhamDieuTri();
                    chiTietHoaDonList.Add(chiTietHoaDonData);

                    DataGridHoaDon.ItemsSource = chiTietHoaDonList;

                    UpdateTotalAmount();
                }
            };
            cthd.ShowDialog();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridHoaDon.SelectedItem != null)
            {
                PhieuKhamDieuTriView selectedRow = (PhieuKhamDieuTriView)DataGridHoaDon.SelectedItem;
                chiTietHoaDonList.Remove(selectedRow);
                DataGridHoaDon.ItemsSource = null;
                DataGridHoaDon.ItemsSource = chiTietHoaDonList;
                UpdateTotalAmount();
            }
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new PhongkhamnhakhoaContext())
            {
                if (chiTietHoaDonList.Any())
                {
                    Phieudieutri pdt = new Phieudieutri();

                    dbContext.Phieudieutris.Add(pdt);
                    foreach (var cthd in chiTietHoaDonList)
                    {
                        Ctpkdt ctpkdt = new Ctpkdt();

                        ctpkdt.MaPdt = pdt.MaPdt;
                        ctpkdt.MaDv = cthd.MaDv;
                        ctpkdt.Sl = cthd.Sl;
                        ctpkdt.Dongia = cthd.Giadv;
                        dbContext.Ctpkdts.Add(ctpkdt);
                    }

                    dbContext.SaveChanges();
                }
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridHoaDon.SelectedItem != null)
            {
                PhieuKhamDieuTriView selectedRow = (PhieuKhamDieuTriView)DataGridHoaDon.SelectedItem;

                ChiTietHoaDon chiTietHoaDonForm = new ChiTietHoaDon();
                chiTietHoaDonForm.LoadData(selectedRow);
                chiTietHoaDonForm.Closed += (s, args) =>
                {
                    if (chiTietHoaDonForm.DialogResult == true)
                    {
                        PhieuKhamDieuTriView editedData = chiTietHoaDonForm.GetPhieuKhamDieuTri();
                        int index = chiTietHoaDonList.IndexOf(selectedRow);
                        chiTietHoaDonList[index] = editedData;
                        UpdateTotalAmount();
                    }
                };
                chiTietHoaDonForm.ShowDialog();
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

                printDocument.Print();
            }
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            float x = 100;
            float y = 100;

 
            foreach (var item in chiTietHoaDonList)
            {
                string line = $"Dịch vụ: {item.TenDv}, Số lượng: {item.Sl}, Giá: {item.Giadv}, Tổng tiền: {item.TongTien}";
                graphics.DrawString(line, font, brush, x, y);
                y += 30; 
            }
        }
    }
}
