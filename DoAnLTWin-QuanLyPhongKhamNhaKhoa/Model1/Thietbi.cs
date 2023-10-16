using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Thietbi
{
    public int MaTb { get; set; }

    public string TenTb { get; set; } = null!;

    public int? Sl { get; set; }

    public string? Tinhtrang { get; set; }

    public int? Mancc { get; set; }

    public virtual Nhacungcap? ManccNavigation { get; set; }
}
