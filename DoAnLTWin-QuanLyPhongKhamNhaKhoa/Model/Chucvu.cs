using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Chucvu
{
    public int MaCv { get; set; }

    public string TenCv { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
