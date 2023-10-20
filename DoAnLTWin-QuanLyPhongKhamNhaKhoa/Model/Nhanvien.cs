using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Nhanvien
{
    public int MaNv { get; set; }

    public string TenNv { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public string? Gt { get; set; }

    public string? DiaChi { get; set; }

    public string Email { get; set; } = null!;

    public string? Sdt { get; set; }

    public int? MaCv { get; set; }

    public virtual ICollection<Donthuoc> Donthuocs { get; set; } = new List<Donthuoc>();

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual Chucvu? MaCvNavigation { get; set; }

    public virtual ICollection<Phieudathang> Phieudathangs { get; set; } = new List<Phieudathang>();

    public virtual ICollection<Phieudieutri> Phieudieutris { get; set; } = new List<Phieudieutri>();

    public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; } = new List<Phieugiaohang>();

    public virtual ICollection<Phieuhen> Phieuhens { get; set; } = new List<Phieuhen>();

    public virtual ICollection<Phieukiem> Phieukiems { get; set; } = new List<Phieukiem>();

    public virtual ICollection<Phieuluong> Phieuluongs { get; set; } = new List<Phieuluong>();

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
