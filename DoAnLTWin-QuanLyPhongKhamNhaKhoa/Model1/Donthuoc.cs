using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Donthuoc
{
    public int MaDt { get; set; }

    public DateTime? Ngaylap { get; set; }

    public decimal Tongtien { get; set; }

    public int? MaNv { get; set; }

    public int? MaPdt { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }

    public virtual Phieudieutri? MaPdtNavigation { get; set; }
}
