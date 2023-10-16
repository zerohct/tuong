using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Phieuhen
{
    public int MaPh { get; set; }

    public DateTime? Ngaylap { get; set; }

    public DateTime? Ngayhen { get; set; }

    public string? Trangthai { get; set; }

    public int? MaNv { get; set; }

    public int? MaBn { get; set; }

    public virtual Benhnhan? MaBnNavigation { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
