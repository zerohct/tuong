using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctpdtb
{
    public int MaCtpdtb { get; set; }

    public int? MaPdh { get; set; }

    public int? Matb { get; set; }

    public int Sl { get; set; }

    public decimal Gia { get; set; }

    public virtual Phieudathang? MaPdhNavigation { get; set; }

    public virtual Thietbi? MatbNavigation { get; set; }
}
