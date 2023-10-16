using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Ctpdt
{
    public int? MaPdh { get; set; }

    public int? MaThuoc { get; set; }

    public int Sl { get; set; }

    public decimal Gia { get; set; }

    public virtual Phieudathang? MaPdhNavigation { get; set; }

    public virtual Thuoc? MaThuocNavigation { get; set; }
}
