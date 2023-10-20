using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Thuoc
{
    public int MaThuoc { get; set; }

    public string TenThuoc { get; set; } = null!;

    public string? Mota { get; set; }

    public decimal Gia { get; set; }

    public int? MaDt { get; set; }

    public int? Mancc { get; set; }

    public DateTime? Hsd { get; set; }

    public virtual ICollection<Ctdt> Ctdts { get; set; } = new List<Ctdt>();

    public virtual ICollection<Ctk> Ctks { get; set; } = new List<Ctk>();

    public virtual ICollection<Ctpdt> Ctpdts { get; set; } = new List<Ctpdt>();

    public virtual ICollection<Ctpgt> Ctpgts { get; set; } = new List<Ctpgt>();

    public virtual Dangthuoc? MaDtNavigation { get; set; }

    public virtual Nhacungcap? ManccNavigation { get; set; }
}
