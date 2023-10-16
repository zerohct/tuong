using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Hoadon
{
    public int MaHd { get; set; }

    public DateTime? Ngaylap { get; set; }

    public decimal Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public int? MaNv { get; set; }

    public int? MaBn { get; set; }

    public virtual Benhnhan? MaBnNavigation { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
