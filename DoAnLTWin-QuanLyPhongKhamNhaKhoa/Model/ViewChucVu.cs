using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class ViewChucVu
{
    public int MaCv { get; set; }

    public string Tencv { get; set; } = null!;

    public string? MoTa { get; set; }

    public decimal TienLuong { get; set; }
}
