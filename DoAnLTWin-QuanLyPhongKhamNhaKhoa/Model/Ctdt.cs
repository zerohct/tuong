using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctdt
{
    public int MaCtdt { get; set; }

    public int? MaDt { get; set; }

    public int? MaThuoc { get; set; }

    public string? Dvt { get; set; }

    public int Sl { get; set; }

    public string? Cachdung { get; set; }

    public decimal? Dongia { get; set; }

    public virtual Donthuoc? MaDtNavigation { get; set; }

    public virtual Thuoc? MaThuocNavigation { get; set; }
}
