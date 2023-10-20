using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctpdt
{
    public int MaCtpdt { get; set; }

    public int? MaPdh { get; set; }

    public int? MaThuoc { get; set; }

    public int Sl { get; set; }

    public decimal Gia { get; set; }

    public virtual Phieudathang? MaPdhNavigation { get; set; }

    public virtual Thuoc? MaThuocNavigation { get; set; }
}
