using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.View.userControl
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private string[] imagePaths;
        private int currentIndex = 0;
        public Home()
        {
            InitializeComponent();
            imagePaths = new string[]
                {
                    "D:/ca-master/DoAnLTWin-QuanLyPhongKhamNhaKhoa/image/Image/1.jpg",
                    "D:/ca-master/DoAnLTWin-QuanLyPhongKhamNhaKhoa/image/Image/2.jpg",
                    "D:/ca-master/DoAnLTWin-QuanLyPhongKhamNhaKhoa/image/Image/3.png",
                    "D:/ca-master/DoAnLTWin-QuanLyPhongKhamNhaKhoa/image/Image/4.png",
                    "D:/ca-master/DoAnLTWin-QuanLyPhongKhamNhaKhoa/image/Image/5.jpg",
                    "D:/ca-master/DoAnLTWin-QuanLyPhongKhamNhaKhoa/image/Image/6.png",
                };
            LoadImage();
        }
        private void LoadImage()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[currentIndex], UriKind.RelativeOrAbsolute));
            imageControl.Source = bitmapImage;
        }
        private void left_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = imagePaths.Length - 1;
            }

            LoadImage();

        }

        private void right_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex >= imagePaths.Length)
            {
                // Nếu currentIndex vượt qua độ dài của mảng, quay lại ảnh đầu tiên
                currentIndex = 0;
            }

            LoadImage();

        }
     
    }
}
