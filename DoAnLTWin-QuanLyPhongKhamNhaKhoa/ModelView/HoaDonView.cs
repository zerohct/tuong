using System;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView
{
    public class HoaDonView
    {
        public int MaPdt { get; set; }

        public string TenNv { get; set; } = null!;

        public string TenBn { get; set; } = null!;
        public string TrangThai { get; set; } = null!;
        public string Nddt { get; set; } = null!;
        public DateTime? Ngaylap { get; set; }

        public decimal Tongtien { get; set; }

    }
}
