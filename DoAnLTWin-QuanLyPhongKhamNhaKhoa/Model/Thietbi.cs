using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Thietbi
{
    public int MaTb { get; set; }

    public string TenTb { get; set; } = null!;

    public int? Sl { get; set; }

    public string? Tinhtrang { get; set; }

    public int? Mancc { get; set; }

    public virtual ICollection<Ctpdtb> Ctpdtbs { get; set; } = new List<Ctpdtb>();

    public virtual ICollection<Ctpgtb> Ctpgtbs { get; set; } = new List<Ctpgtb>();

    public virtual ICollection<Ctpktb> Ctpktbs { get; set; } = new List<Ctpktb>();

    public virtual Nhacungcap? ManccNavigation { get; set; }
}
