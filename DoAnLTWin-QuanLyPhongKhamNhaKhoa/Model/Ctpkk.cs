using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctpkk
{
    public int MaCtpkk { get; set; }

    public int? MaPk { get; set; }

    public int? Makho { get; set; }

    public int Sl { get; set; }

    public string? Trangthai { get; set; }

    public virtual Phieukiem? MaPkNavigation { get; set; }

    public virtual Kho? MakhoNavigation { get; set; }
}
