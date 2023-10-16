using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Phieukiem
{
    public int MaPk { get; set; }

    public DateTime? Ngaylap { get; set; }

    public int? MaNv { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
