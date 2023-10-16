using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Luong
{
    public int MaLuong { get; set; }

    public int? MaCv { get; set; }

    public decimal Tienluong { get; set; }

    public virtual Chucvu? MaCvNavigation { get; set; }

    public virtual ICollection<Phieuluong> Phieuluongs { get; set; } = new List<Phieuluong>();
}
