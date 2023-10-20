using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model.export;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>   
    /// Interaction logic for uc_ThemNCC.xaml
    /// </summary>

    public partial class uc_ThemNCC : UserControl
    {
        private DaphongkhamnhakhoaContext context;
        private ExportToExcel excel;
        public uc_ThemNCC()
        {
            InitializeComponent();
            context = new DaphongkhamnhakhoaContext();
            LoadNhaCungCap();

        }
        public void LoadNhaCungCap()
        {
            var ncc = context.Nhacungcaps.ToList();
            dataaGridNCC.ItemsSource = ncc;

        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            NhaCungCap ncc  = new NhaCungCap();
            ncc.Closed += (s, args) =>
            {
                LoadNhaCungCap();
            };
            ncc.Show();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var row = dataaGridNCC.SelectedItem as Nhacungcap;
            if (row == null) return;
            NhaCungCap ncc = new NhaCungCap(row);
            ncc.Closed += (s, args) =>
            {
                LoadNhaCungCap();
            };
            ncc.Show();
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK);
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var selectedNCC = dataaGridNCC.SelectedItem as Nhacungcap;
            if (selectedNCC != null)
            {
                try
                {
                    var NCCToDelete = context.Nhacungcaps.FirstOrDefault(ncc =>ncc.MaNcc == selectedNCC.MaNcc);

                    if (NCCToDelete != null)
                    {
                        context.Nhacungcaps.Remove(NCCToDelete);
                        context.SaveChanges();
                        LoadNhaCungCap();
                    }
                    else
                    {
                        ShowErrorMessage("Không thể tìm thấy nhà cung cấp để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Không thể xóa nhà cung cấp: " + ex.Message);
                }
            }
            else
            {
                ShowErrorMessage("Chọn một nhà cung cấp để xóa.");
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            excel = new ExportToExcel();
            excel.ExportToExcelpost(dataaGridNCC);
        }
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {


            string searchKeyword = textBoxSearch.Text.ToLower();
            ICollectionView view = CollectionViewSource.GetDefaultView(dataaGridNCC.ItemsSource);
            if (view != null)
            {
                view.Filter = item =>
                {

                    var employeeView = (Nhacungcap)item;
                    return employeeView.TenNcc.ToLower().Contains(searchKeyword);
                };
            }
        }
    }
}
