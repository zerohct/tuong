using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Phieuluong
{
    public int MaPl { get; set; }

    public DateTime? Ngaylap { get; set; }

    public string? Trangthai { get; set; }

    public decimal? Tienthuong { get; set; }

    public decimal? Tientru { get; set; }

    public int? MaNv { get; set; }

    public int? MaLuong { get; set; }

    public virtual Luong? MaLuongNavigation { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
