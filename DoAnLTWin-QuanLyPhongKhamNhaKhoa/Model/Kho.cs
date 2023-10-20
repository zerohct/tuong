using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class Kho
{
    public int MaKho { get; set; }

    public string? ViTri { get; set; }

    public virtual ICollection<Ctk> Ctks { get; set; } = new List<Ctk>();

    public virtual ICollection<Ctpkk> Ctpkks { get; set; } = new List<Ctpkk>();
}
