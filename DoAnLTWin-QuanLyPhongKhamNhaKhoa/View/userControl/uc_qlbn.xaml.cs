using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model.export;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.Form;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for uc_qlbn.xaml
    /// </summary>
    public partial class uc_qlbn : UserControl
    {
        private DaphongkhamnhakhoaContext context;
        private ExportToExcel excel;
        public uc_qlbn()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
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
            var row = DataGridBenhNhan.SelectedItem as Benhnhan;
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

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            excel = new ExportToExcel();
            excel.ExportToExcelpost(DataGridBenhNhan);
        }
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {


            string searchKeyword = textBoxSearch.Text.ToLower();
            ICollectionView view = CollectionViewSource.GetDefaultView(DataGridBenhNhan.ItemsSource);
            if (view != null)
            {
                view.Filter = item =>
                {

                    var employeeView = (Benhnhan)item;
                    return employeeView.TenBn.ToLower().Contains(searchKeyword);
                };
            }
        }
    }
}