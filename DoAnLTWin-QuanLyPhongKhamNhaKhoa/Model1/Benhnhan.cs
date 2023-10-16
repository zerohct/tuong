using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Benhnhan
{
    public int MaBn { get; set; }

    public string TenBn { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string Email { get; set; } = null!;

    public string? Sdt { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual ICollection<Phieudieutri> Phieudieutris { get; set; } = new List<Phieudieutri>();

    public virtual ICollection<Phieuhen> Phieuhens { get; set; } = new List<Phieuhen>();
}
