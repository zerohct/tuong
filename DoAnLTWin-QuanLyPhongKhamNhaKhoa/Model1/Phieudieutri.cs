using System;
using System.Collections.Generic;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model1;

public partial class Phieudieutri
{
    public int MaPdt { get; set; }

    public DateTime? Ngaylap { get; set; }

    public string Chuandoan { get; set; } = null!;

    public string Nddt { get; set; } = null!;

    public decimal Tongtien { get; set; }

    public int? MaNv { get; set; }

    public int? MaBn { get; set; }

    public virtual ICollection<Donthuoc> Donthuocs { get; set; } = new List<Donthuoc>();

    public virtual Benhnhan? MaBnNavigation { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
