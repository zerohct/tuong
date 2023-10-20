using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for ThemThietBi.xaml
    /// </summary>
    public partial class ThemThietBi : Window
    {
        private DaphongkhamnhakhoaContext context;
        List<Nhacungcap> NhaCCList = new List<Nhacungcap>();
        private Thietbi newtb;
        private Nhacungcap newncc;
        private ThietBiView dTO;
        public ThemThietBi()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadDataIntoComboBox();
        }
        public ThemThietBi(ThietBiView thietbi)
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadDataIntoComboBox();
            this.dTO = thietbi;
            nhanData(dTO);
        }
        public void nhanData(ThietBiView nv)
        {
            txtTitle.Text = "Sửa thiết bị";
            txtThietBi.Text = nv.TenTb;
            txtSL.Text = nv.Sl.ToString();
            txtTinhTrang.Text = nv.Tinhtrang;
            cbTenNCC.Text = nv.TenNcc;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private bool KiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtThietBi.Text))
            {
                ShowErrorMessage("Nhập đầy đủ tên thiết bị!");
                return false;
            }

            if (string.IsNullOrEmpty(txtSL.Text))
            {
                ShowErrorMessage("Nhập số lượng đúng định dạng số!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTinhTrang.Text))
            {
                ShowErrorMessage("Nhập đầy đủ tình trạng!");
                return false;
            }


            return true;
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();

        }


        private void click_Sua(object sender, RoutedEventArgs e)
        {

            if (KiemTraDayDuThongTin())
            {
                string input = txtSL.Text;
                int output;
                bool success = int.TryParse(input, out output);
                if (!success)
                {
                    ShowErrorMessage("Nhập sai chuỗi tiền lương");
                    return;
                }
                int selectedMaNCC = GetMaNccFromComboBox();

                if (selectedMaNCC != -1)
                {
                    try
                    {
                        var existingThietBi = context.Thietbis.FirstOrDefault(tb => tb.MaTb == dTO.MaTb);

                        if (existingThietBi != null)
                        {

                            existingThietBi.TenTb = txtThietBi.Text;
                            existingThietBi.Tinhtrang = txtTinhTrang.Text;
                            existingThietBi.Sl = output;
                            existingThietBi.Mancc = selectedMaNCC;

                            context.SaveChanges();
                            this.Close();
                        }
                        else
                        {
                            ShowErrorMessage("Thiết bị không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Không thể cập nhật thông tin thiết bị: " + ex.Message);
                    }
                }
                else
                {
                    ShowErrorMessage("Chọn một nhà cung cấp.");
                }

            }

        }
        private void LoadDataIntoComboBox()
        {
            var chucVuQuery = from cv in context.Nhacungcaps select cv;
            foreach (var cv in chucVuQuery)
            {
                NhaCCList.Add(cv);
            }
            cbTenNCC.ItemsSource = NhaCCList;
            cbTenNCC.DisplayMemberPath = "TenNcc";
            cbTenNCC.SelectedValuePath = "MaNcc";
        }
        private int GetMaNccFromComboBox()
        {
            int selectedMaNcc = (int)cbTenNCC.SelectedValue;
            if (selectedMaNcc != null)
            {
                return selectedMaNcc;
            }
            return -1;
        }
        private void click_Them(object sender, RoutedEventArgs e)
        {
            if (KiemTraDayDuThongTin())
            {
                int selectedMaNCC = GetMaNccFromComboBox();
                if (selectedMaNCC != -1)
                {
                    string input = txtSL.Text;
                    int output;
                    bool success = int.TryParse(input, out output);
                    if (!success)
                    {
                        ShowErrorMessage("Nhập sai số lượng");
                    }
                    else
                    {


                        Thietbi newtb = new Thietbi
                        {
                            TenTb = txtThietBi.Text,
                            Tinhtrang = txtTinhTrang.Text,
                            Sl = output,
                            Mancc = selectedMaNCC,
                        };
                        try
                        {
                            context.Thietbis.Add(newtb);
                            context.SaveChanges();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            ShowErrorMessage("Không thể thêm thiết bị: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                ShowErrorMessage("Chọn nhà cung cấp.");
            }
        }
    }
}

