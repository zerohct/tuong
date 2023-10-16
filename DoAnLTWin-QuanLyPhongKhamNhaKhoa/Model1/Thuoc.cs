using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Thuoc
{
    public int MaThuoc { get; set; }

    public string TenThuoc { get; set; } = null!;

    public string? Mota { get; set; }

    public decimal Gia { get; set; }

    public int? MaDt { get; set; }

    public int? Mancc { get; set; }

    public DateTime? Hsd { get; set; }

    public virtual Dangthuoc? MaDtNavigation { get; set; }

    public virtual Nhacungcap? ManccNavigation { get; set; }
}
