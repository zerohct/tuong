using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_qlphieuluong.xaml
    /// </summary>
    public partial class uc_hoadon : UserControl
    {
        private DaphongkhamnhakhoaContext context;
        private int currentMaPdt;
        private ObservableCollection<PhieuKhamDieuTriView> chiTietHoaDonList = new ObservableCollection<PhieuKhamDieuTriView>();
        private ObservableCollection<string> name; 
        private string selectedName;
        public uc_hoadon()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            loadten();
            
        }
        public void SetEmployeeName(string name)
        {
            txbNameNv.Text = name;
        }


        private void loadten()
        {
            name = new ObservableCollection<string>(context.Benhnhans.Select(nv => nv.TenBn));
            txtBenhNhan.TextChanged += txtBenhNhan_TextChanged;
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
            DateTime? selectedNgayLap = dtNTNS.SelectedDate;
            using (var dbContext = new DaphongkhamnhakhoaContext())
            {
                if (chiTietHoaDonList.Any())
                {
                    Phieudieutri pdt = new Phieudieutri();
                    pdt.Ngaylap = selectedNgayLap;
                    pdt.Tongtien = Convert.ToDecimal(txtTongTien.Text);
                    string tenBenhNhan = txtBenhNhan.Text;
                    var benhNhan = dbContext.Benhnhans.FirstOrDefault(bn => bn.TenBn == tenBenhNhan);
                    if (benhNhan != null)
                    {
                        pdt.MaBn = benhNhan.MaBn;
                    }
                    string tenNhanVien = txbNameNv.Text;
                    var nhanVien = dbContext.Nhanviens.FirstOrDefault(nv => nv.TenNv == tenNhanVien);
                    if (nhanVien != null)
                    {
                        pdt.MaNv = nhanVien.MaNv;
                    }
                    pdt.Nddt = txtnddt.Text;
                    pdt.TrangThai = cbTrangThai.Text;
                    dbContext.Phieudieutris.Add(pdt);
                    dbContext.SaveChanges();
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
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                printDocument.PrinterSettings.PrinterName = printDialog.PrintQueue.FullName;
                printDocument.Print();
            }
            printDocument.Dispose();
            
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font titleFont = new Font("Arial", 16, System.Drawing.FontStyle.Bold);
            Font tableHeaderFont = new Font("Arial", 14, System.Drawing.FontStyle.Bold);
            Font itemFont = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            float z = (e.PageBounds.Width - (int)graphics.MeasureString("HÓA ĐƠN", titleFont).Width) / 2;
            float x = 100;
            float y = 100;
            decimal totalCost = 0;

            string title = "HÓA ĐƠN";
            float titleX = (e.PageBounds.Width - graphics.MeasureString(title, titleFont).Width) / 2;
            float titleY = 100;
            graphics.DrawString(title, titleFont, brush, titleX, titleY);
            
            string imagePath = "D:\\ca-master\\DoAnLTWin-QuanLyPhongKhamNhaKhoa\\image\\Logo\\logo.png";

            if (System.IO.File.Exists(imagePath))
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath))
                {
                    float imageWidth = 80;
                    float imageHeight = 80;

                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(100, 100, imageWidth, imageHeight);

                    Region originalClip = graphics.Clip;
                    graphics.Clip = new Region(path);

                    graphics.DrawImage(image, 100, 100, imageWidth, imageHeight);

                    graphics.Clip = originalClip;

                    path.Dispose();
                }
            }
            else
            {
                Console.WriteLine("Tệp hình ảnh không tồn tại.");
            }
            float patientX = 150;
            float employeeX = e.PageBounds.Width - 450; 
            float namesY = titleY + 50; 
            string patientName = "Tên bệnh nhân: " + txtBenhNhan.Text;
            string employeeName = "Tên nhân viên: " + txbNameNv.Text;
            graphics.DrawString(patientName, itemFont, brush, patientX, namesY);
            graphics.DrawString(employeeName, itemFont, brush, employeeX, namesY);
            namesY += 50;
            DateTime? selectedNgayLap = dtNTNS.SelectedDate;
            if (selectedNgayLap != null)
            {
                string ngayLapString = "Ngày lập: " + selectedNgayLap.Value.ToShortDateString();
                graphics.DrawString(ngayLapString, itemFont,brush, patientX, namesY);
            }
            string trangThaiString = "Trạng thái: " + cbTrangThai.Text;
            graphics.DrawString(trangThaiString, itemFont, brush, employeeX, namesY);
            namesY += 50;
            string nddt = "Nội Dung điều trị : " + txtnddt.Text;
            graphics.DrawString(nddt, itemFont, brush, patientX, namesY);

            float col1X = 150;
            float col2X = 200;
            float col3X = 350;
            float col4X = 500;
            float tableY = namesY + 50;

            Pen pen = new Pen(Brushes.Black, 2);
            tableY += 25;
            graphics.DrawLine(pen, col1X, tableY, col4X + 100, tableY);

            graphics.DrawString("STT", tableHeaderFont, brush, col1X, tableY);
            graphics.DrawString("Dịch Vụ", tableHeaderFont, brush, col2X, tableY);
            graphics.DrawString("Số Lượng", tableHeaderFont, brush, col3X, tableY);
            graphics.DrawString("Thành Tiền", tableHeaderFont, brush, col4X, tableY);

            
            Pen pen1 = new Pen(Brushes.Black, 2);
            tableY += 25;
            graphics.DrawLine(pen1, col1X, tableY, col4X+100, tableY) ;
            int stt = 1;
            tableY += 40;
            foreach (var item in chiTietHoaDonList)
            {
                graphics.DrawString(stt.ToString(), itemFont, brush, col1X, tableY);
                graphics.DrawString(item.TenDv, itemFont, brush, col2X, tableY);
                graphics.DrawString(item.Sl.ToString(), itemFont, brush, col3X, tableY);
                graphics.DrawString(item.TongTien.ToString(), itemFont, brush, col4X, tableY);
                totalCost += item.TongTien;
                tableY += 40;
                stt++;
            }
            Pen pen2 = new Pen(Brushes.Black, 2);
            tableY += 20;
            graphics.DrawLine(pen2, col1X, tableY, col4X + 100, tableY);

            string totalCostString = "Tổng tiền hóa đơn: " + totalCost.ToString();
            graphics.DrawString(totalCostString, itemFont, brush, col3X, tableY + 40);


           
        }

        private void txtBenhNhan_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtBenhNhan.Text.ToLower();

            List<string> filteredNames = name
                .Where(n => n.ToLower().Contains(searchText))
                .ToList();

            suggestionListBox.ItemsSource = filteredNames;

            if (filteredNames.Count > 0)
            {
                suggestionPopup.IsOpen = true;
            }
            else
            {
                suggestionPopup.IsOpen = false;
            }
        }
        private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            suggestionPopup.IsOpen = false;
        }
        private void searchTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                suggestionPopup.IsOpen = false;
            }
        }
        private void suggestionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suggestionListBox.SelectedItem != null)
            {
                selectedName = suggestionListBox.SelectedItem.ToString();
                txtBenhNhan.Text = selectedName;
                suggestionPopup.IsOpen = false;
            }
        }

    }
}
