using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Nhacungcap
{
    public int MaNcc { get; set; }

    public string TenNcc { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Sdt { get; set; }

    public virtual ICollection<Phieudathang> Phieudathangs { get; set; } = new List<Phieudathang>();

    public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; } = new List<Phieugiaohang>();

    public virtual ICollection<Thietbi> Thietbis { get; set; } = new List<Thietbi>();

    public virtual ICollection<Thuoc> Thuocs { get; set; } = new List<Thuoc>();
}
