using System.Windows;
using System.Windows.Input;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Form
{
    /// <summary>
    /// Interaction logic for About_us_form.xaml
    /// </summary>
    public partial class About_us_form : Window
    {
        public About_us_form()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
