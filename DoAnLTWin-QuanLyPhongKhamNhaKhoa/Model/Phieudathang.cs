using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Phieudathang
{
    public int MaPdh { get; set; }

    public DateTime? Ngaylap { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public int? MaNv { get; set; }

    public int? MaNcc { get; set; }

    public virtual ICollection<Ctpdtb> Ctpdtbs { get; set; } = new List<Ctpdtb>();

    public virtual ICollection<Ctpdt> Ctpdts { get; set; } = new List<Ctpdt>();

    public virtual Nhacungcap? MaNccNavigation { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }

    public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; } = new List<Phieugiaohang>();
}
