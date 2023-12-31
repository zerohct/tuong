﻿using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Ctpgtb
{
    public int MaCtpdtb { get; set; }

    public int? MaPgh { get; set; }

    public int? MaTb { get; set; }

    public int Sl { get; set; }

    public decimal Gia { get; set; }

    public virtual Phieugiaohang? MaPghNavigation { get; set; }

    public virtual Thietbi? MaTbNavigation { get; set; }
}
