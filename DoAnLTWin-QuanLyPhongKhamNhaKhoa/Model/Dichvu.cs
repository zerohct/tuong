﻿using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Dichvu
{
    public int MaDv { get; set; }

    public string TenDv { get; set; } = null!;

    public string Dvt { get; set; } = null!;

    public int? Khuyenmai { get; set; }

    public decimal Giadv { get; set; }

    public double? Tgbh { get; set; }

    public virtual ICollection<Ctpkdt> Ctpkdts { get; set; } = new List<Ctpkdt>();
}
