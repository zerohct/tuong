using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private getEmployeeName sharedData;
        public uc_hoadon()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            loadten();

        }
        public void SetSharedData(getEmployeeName data)
        {
            sharedData = data;
            txbNameNv.Text = sharedData.EmployeeName;
        }
        public void SetPatientName(string Name)
        {
            txtBenhNhan.Text = Name;
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
                    XuatHoaDon hoaDon = new XuatHoaDon(tenBenhNhan, tenNhanVien, pdt.Tongtien, pdt.TrangThai, pdt.Nddt, pdt.Ngaylap, chiTietHoaDonList);
                    hoaDon.ShowDialog();

                }
            }

            /*PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            

            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
               
                printDocument.PrinterSettings.PrinterName = printDialog.PrintQueue.FullName;
                printDocument.Print();
            }
            printDocument.Dispose();*/

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
