using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Cthd
{
    public int MaCthd { get; set; }

    public int? MaHd { get; set; }

    public int? Mapdt { get; set; }

    public string? Trangthai { get; set; }

    public decimal? Dongia { get; set; }

    public virtual Hoadon? MaHdNavigation { get; set; }

    public virtual Phieudieutri? MapdtNavigation { get; set; }
}
