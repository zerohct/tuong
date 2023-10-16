using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_qlbn.xaml
    /// </summary>
    public partial class uc_qlbn : UserControl
    {
        private PhongkhamnhakhoaContext context;
        public uc_qlbn()
        {
            InitializeComponent();
            context = new PhongkhamnhakhoaContext();
            LoadPatient();
        }
        public void LoadPatient()
        {
            var query = from bn in context.Benhnhans
                        select new Benhnhan
                        {
                            MaBn = bn.MaBn,
                            TenBn = bn.TenBn,
                            NgaySinh = bn.NgaySinh,
                            GioiTinh = bn.GioiTinh,
                            DiaChi = bn.DiaChi,
                            Email = bn.Email,
                            Sdt = bn.Sdt,

                        };
            DataGridBenhNhan.ItemsSource = query.ToList();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemBenhNhan bn = new ThemBenhNhan();
            bn.Closed += (s, args) =>
            {
                LoadPatient();
            };
            bn.Show();

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridBenhNhan.SelectedItem as Benhnhan
                ;
            if (row == null) return;
            ThemBenhNhan bn = new ThemBenhNhan(row);
            bn.Closed += (s, args) =>
            {
                LoadPatient();
            };
            bn.Show();
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var selectedPatient = DataGridBenhNhan.SelectedItem as Benhnhan;
            if (selectedPatient != null)
            {
                try
                {
                    var PatientDelete = context.Benhnhans.FirstOrDefault(bn => bn.MaBn == selectedPatient.MaBn);

                    if (PatientDelete != null)
                    {
                        context.Benhnhans.Remove(PatientDelete);
                        context.SaveChanges();
                        LoadPatient();
                    }
                    else
                    {
                        ShowErrorMessage("Không thể tìm thấy bệnh nhân để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể xóa bệnh nhân: " + ex.Message);
                }
            }
            else
            {
                ShowErrorMessage("Chọn một bệnh nhân để xóa.");
            }
        }
    }
}