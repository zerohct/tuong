using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView
{

    public class NhanVienView

    {
        public int MaNv { get; set; }

        public string TenNv { get; set; } = null!;

        public DateTime? NgaySinh { get; set; }

        public int SL { get; set; }

        public string? Gt { get; set; }

        public string? DiaChi { get; set; }

        public string Email { get; set; } = null!;

        public string? Sdt { get; set; }

        public string TenCv { get; set; } = null!;
    }

}
