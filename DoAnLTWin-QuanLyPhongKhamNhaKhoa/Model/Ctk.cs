using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctk
{
    public int MaCtk { get; set; }

    public int? MaKho { get; set; }

    public int? Mathuoc { get; set; }

    public int Sl { get; set; }

    public string? Trangthai { get; set; }

    public virtual Kho? MaKhoNavigation { get; set; }

    public virtual Thuoc? MathuocNavigation { get; set; }
}
