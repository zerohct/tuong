﻿using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctpgt
{
    public int MaCtpgh { get; set; }

    public int? MaPgh { get; set; }

    public int? MaThuoc { get; set; }

    public int Sl { get; set; }

    public decimal Gia { get; set; }

    public virtual Phieugiaohang? MaPghNavigation { get; set; }

    public virtual Thuoc? MaThuocNavigation { get; set; }
}
