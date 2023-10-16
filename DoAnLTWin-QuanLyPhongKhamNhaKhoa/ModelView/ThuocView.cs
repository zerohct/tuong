using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView
{
    public class ThuocView
    {
        public int MaThuoc { get; set; }

        public string TenThuoc { get; set; } = null!;

        public string? Mota { get; set; }

        public decimal Gia { get; set; }

        public string TenDt { get; set; } = null!;

        public string TenNcc { get; set; } = null!;

        public DateTime? Hsd { get; set; }
    }
}
