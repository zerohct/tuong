using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView
{
    public class PhieuKhamDieuTriView
    {
        public int? MaPdt { get; set; }

        public int MaDv { get; set; }

        public string TenDv { get; set; } = null!;

        public string Dvt { get; set; } = null!;

        public int? Sl { get; set; }

        public int? Khuyenmai { get; set; }

        public decimal Giadv { get; set; }

        public double? Tgbh { get; set; }
        public decimal TongTien {  get; set; }

    }
}
