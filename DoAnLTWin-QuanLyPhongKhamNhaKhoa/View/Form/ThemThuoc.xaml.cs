using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for ThemThuoc.xaml
    /// </summary>
    public partial class ThemThuoc : Window
    {
        private PhongkhamnhakhoaContext context = new PhongkhamnhakhoaContext();
        List<Nhacungcap> NhaCCList = new List<Nhacungcap>();
        List<Dangthuoc> DangThuocList = new List<Dangthuoc>();
        private Thuoc newThuoc;
        private bool isChangingDate = false;
        private Nhacungcap newncc;
        private ThuocView dTO;
        public ThemThuoc()
        {
            InitializeComponent();
            LoadDataIntoComboBoxNcc();
            LoadDangThuocComboBox();
        }

        public ThemThuoc(ThuocView themthuoc)
        {
            InitializeComponent();
            LoadDataIntoComboBoxNcc();
            LoadDangThuocComboBox();
            this.dTO = themthuoc;
            nhanData(dTO);
        }
        public void nhanData(ThuocView th)
        {
            txbTitle.Text = "Sửa thuốc";
            txbThuoc.Text = th.TenThuoc;
            txtMoTa.Text = th.Mota;
            cbDT.Text = th.TenDt;
            cbNCC.Text = th.TenNcc;
            txtGia.Text = th.Gia.ToString();


        }
        private void LoadDangThuocComboBox()
        {
            var thuoc = from dt in context.Dangthuocs select dt;
            foreach (var dt in thuoc)
            {
                DangThuocList.Add(dt);
            }
            cbDT.ItemsSource = DangThuocList;
            cbDT.DisplayMemberPath = "TenDt";
            cbDT.SelectedValuePath = "MaDt";

        }
        private int GetMaDtFromComboBox()
        {
            int selectedMaDt = (int)cbDT.SelectedValue;
            if (selectedMaDt != null)
            {
                return selectedMaDt;
            }
            return -1;
        }
        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();

        }
        private bool KiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txbThuoc.Text))
            {
                ShowErrorMessage("Nhập đầy đủ tên thuốc!");
                return false;
            }

            if (string.IsNullOrEmpty(txtMoTa.Text))
            {
                ShowErrorMessage("Nhập đầy đủ mô tả!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                ShowErrorMessage("Nhập đầy đủ giá bán!");
                return false;
            }

            return true;
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private void LoadDataIntoComboBoxNcc()
        {
            var thuoc = from ncc in context.Nhacungcaps select ncc;
            foreach (var ncc in thuoc)
            {
                NhaCCList.Add(ncc);
            }
            cbNCC.ItemsSource = NhaCCList;
            cbNCC.DisplayMemberPath = "TenNcc";
            cbNCC.SelectedValuePath = "MaNcc";
        }
        private int GetMaNccFromComboBox()
        {
            int selectedMaNcc = (int)cbNCC.SelectedValue;
            if (selectedMaNcc != null)
            {
                return selectedMaNcc;
            }
            return -1;
        }
        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            DateTime? selectedHSH = dtNN.SelectedDate;
            if (KiemTraDayDuThongTin())
            {
                int selectedMaNcc = GetMaNccFromComboBox();
                int selectedMaDt = GetMaDtFromComboBox();
                if (selectedMaNcc != -1 || selectedMaDt != 1)
                {
                    string input1 = txtGia.Text;
                    int output1;
                    bool success = int.TryParse(input1, out output1);

                    if (!success)
                    {
                        ShowErrorMessage("Nhập sai giá ");
                    }
                    else
                        try
                        {
                            Thuoc newThuoc = new Thuoc
                            {
                                TenThuoc = txbThuoc.Text,
                                Mota = txtMoTa.Text,
                                Hsd = selectedHSH ?? DateTime.MinValue,
                                Gia = output1,
                                Mancc = selectedMaNcc,
                                MaDt = selectedMaDt,
                            };

                            context.Thuocs.Add(newThuoc);
                            context.SaveChanges();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            ShowErrorMessage("Không thể thêm thuốc: " + ex.Message);
                        }

                }
            }
            else
            {
                ShowErrorMessage("Chọn nhà cung cấp.");
            }




        }

        private void click_Sua(object sender, RoutedEventArgs e)
        {

            if (KiemTraDayDuThongTin())
            {
                string input1 = txtGia.Text;
                int output1;
                bool success = int.TryParse(input1, out output1);
                if (!success)
                {
                    ShowErrorMessage("Nhập sai giá ");
                    return;
                }
                DateTime? selectedHSH = dtNN.SelectedDate;
                int selectedMaNcc = GetMaNccFromComboBox();
                int selectedMaDt = GetMaDtFromComboBox();
                if (selectedMaNcc != -1 || selectedMaDt != 1)
                {
                    try
                    {
                        var existingThuoc = context.Thuocs.FirstOrDefault(th => th.MaThuoc == dTO.MaThuoc);

                        if (existingThuoc != null)
                        {
                            existingThuoc.TenThuoc = txbThuoc.Text;
                            existingThuoc.Mota = txtMoTa.Text;
                            existingThuoc.Hsd = selectedHSH ?? DateTime.MinValue;
                            existingThuoc.Gia = output1;
                            existingThuoc.Mancc = selectedMaNcc;
                            existingThuoc.MaDt = selectedMaDt;

                            context.SaveChanges();
                            this.Close();
                        }
                        else
                        {
                            ShowErrorMessage("Thuốc không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Không thể cập nhật thông tin thuốc: " + ex.Message);
                    }
                }
                else
                {
                    ShowErrorMessage("Chọn một nhà cung cấp.");
                }

            }

        }

        private void dtNN_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isChangingDate)
            {
                isChangingDate = true;

                DatePicker datePicker = (DatePicker)sender;

                if (datePicker.SelectedDate.HasValue && datePicker.SelectedDate < DateTime.Now)
                {
                    datePicker.SelectedDate = DateTime.Now;
                }

                isChangingDate = false;
            }
        }
    }
}
