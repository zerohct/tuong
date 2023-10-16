using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView
{
    public class ThietBiView
    {
        public int MaTb { get; set; }

        public string TenTb { get; set; } = null!;

        public int? Sl { get; set; }

        public string? Tinhtrang { get; set; }

        public string TenNcc { get; set; } = null!;
    }
}
