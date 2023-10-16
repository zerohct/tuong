﻿using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Phieugiaohang
{
    public int MaPgh { get; set; }

    public DateTime? Ngaylap { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public int? MaNv { get; set; }

    public int? MaPdh { get; set; }

    public int? MaNcc { get; set; }

    public virtual Nhacungcap? MaNccNavigation { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }

    public virtual Phieudathang? MaPdhNavigation { get; set; }
}
