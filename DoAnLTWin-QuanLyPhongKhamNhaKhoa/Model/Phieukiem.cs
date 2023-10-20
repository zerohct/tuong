using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Phieukiem
{
    public int MaPk { get; set; }

    public DateTime? Ngaylap { get; set; }

    public int? MaNv { get; set; }

    public virtual ICollection<Ctpkk> Ctpkks { get; set; } = new List<Ctpkk>();

    public virtual ICollection<Ctpktb> Ctpktbs { get; set; } = new List<Ctpktb>();

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
