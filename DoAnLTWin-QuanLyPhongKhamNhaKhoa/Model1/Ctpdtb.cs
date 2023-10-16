using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Ctpdtb
{
    public int? MaPdh { get; set; }

    public int? Matb { get; set; }

    public int Sl { get; set; }

    public decimal Gia { get; set; }

    public virtual Phieudathang? MaPdhNavigation { get; set; }

    public virtual Thietbi? MatbNavigation { get; set; }
}
