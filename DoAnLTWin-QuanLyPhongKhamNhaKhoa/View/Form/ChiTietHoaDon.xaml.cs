using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form
{
    /// <summary>
    /// Interaction logic for ChiTietHoaDon.xaml
    /// </summary>
    public partial class ChiTietHoaDon : Window
    {
        private PhongkhamnhakhoaContext context;
        private ObservableCollection<Ctpdt> invoiceDetails;
        private Phieudieutri currentInvoice;
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
        private int GetMaDVFromComboBox()
        {
            int selectedMaDV = (int)cbTenDv.SelectedValue;
            if (selectedMaDV != null)
            {
                return selectedMaDV;
            }
            return -1;
        }
        public PhieuKhamDieuTriView GetEnteredDetail()
        {
            if (decimal.TryParse(txtGiaDv.Text, out decimal gia))
            {
                PhieuKhamDieuTriView newDetail = new PhieuKhamDieuTriView
                {
                    MaPdt = currentInvoice.MaPdt,
                    TenDv= cbTenDv.Text,
                   
                };
                return newDetail;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ.");
                return null;
            }
        }

        private void Click_Them(object sender, RoutedEventArgs e)
        {
          /*  string? selectedGender = cbGioiTinh.SelectionBoxItem as string;
            DateTime? selectedNgaySinh = dtNTNS.SelectedDate;

            if (KiemTraDayDuThongTin())
            {
                int selectedMaCv = GetMaCvFromComboBox();

                if (selectedMaCv != -1)
                {
                    bool isEmailExist = context.Nhanviens.Any(nv => nv.Email == txtEmail.Text);
                    bool isSdtExist = context.Nhanviens.Any(nv => nv.Sdt == txtSDT.Text);
                    if (isEmailExist || isSdtExist)
                    {
                        ShowErrorMessage("Email hoặc số điện thoại đã tồn tại!");
                    }
                    else
                    {
                        Nhanvien newEmployee = new Nhanvien
                        {
                            TenNv = txtName.Text,
                            NgaySinh = selectedNgaySinh ?? DateTime.MinValue,
                            Gt = selectedGender,
                            DiaChi = txtDiaChi.Text,
                            Email = txtEmail.Text,
                            Sdt = txtSDT.Text,
                            MaCv = selectedMaCv
                        };
                        try
                        {
                            context.Nhanviens.Add(newEmployee);
                            context.SaveChanges();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            ShowErrorMessage("Không thể thêm nhân viên mới: " + ex.Message);
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Chọn một chức vụ.");
                }
            }*/

        }
    
        private void click_Sua(object sender, RoutedEventArgs e)
        {
            /*string? selectedGender = cbGioiTinh.SelectionBoxItem as string;
            DateTime? selectedNgaySinh = dtNTNS.SelectedDate;

            if (KiemTraDayDuThongTin())
            {
                int selectedMaCv = GetMaCvFromComboBox();

                if (selectedMaCv != -1)
                {
                    try
                    {
                        var existingEmployee = context.Nhanviens.FirstOrDefault(nv => nv.MaNv == dTO.MaNv);

                        if (existingEmployee != null)
                        {

                            existingEmployee.TenNv = txtName.Text;
                            existingEmployee.NgaySinh = selectedNgaySinh ?? DateTime.MinValue;
                            existingEmployee.Gt = selectedGender;
                            existingEmployee.DiaChi = txtDiaChi.Text;
                            existingEmployee.Email = txtEmail.Text;
                            existingEmployee.Sdt = txtSDT.Text;
                            existingEmployee.MaCv = selectedMaCv;

                            context.SaveChanges();
                            this.Close();
                        }
                        else
                        {
                            ShowErrorMessage("Nhân viên không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Không thể cập nhật thông tin nhân viên: " + ex.Message);
                    }
                }
                else
                {
                    ShowErrorMessage("Chọn một chức vụ.");
                }*/
            }

        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }
    }

  }
