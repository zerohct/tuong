using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Ctpkdt
{
    public int? MaPdt { get; set; }

    public int? MaDv { get; set; }

    public int Sl { get; set; }

    public decimal? Dongia { get; set; }

    public virtual Dichvu? MaDvNavigation { get; set; }

    public virtual Phieudieutri? MaPdtNavigation { get; set; }
}
