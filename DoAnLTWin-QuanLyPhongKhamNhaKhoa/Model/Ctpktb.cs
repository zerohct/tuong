using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctpktb
{
    public int MaCtpktb { get; set; }

    public int? MaPk { get; set; }

    public int? Matb { get; set; }

    public int Sl { get; set; }

    public string? Trangthai { get; set; }

    public virtual Phieukiem? MaPkNavigation { get; set; }

    public virtual Thietbi? MatbNavigation { get; set; }
}
