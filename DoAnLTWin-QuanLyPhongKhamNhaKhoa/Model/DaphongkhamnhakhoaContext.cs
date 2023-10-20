using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;

public partial class DaphongkhamnhakhoaContext : DbContext
{
    public DaphongkhamnhakhoaContext()
    {
    }

    public DaphongkhamnhakhoaContext(DbContextOptions<DaphongkhamnhakhoaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Benhnhan> Benhnhans { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<Ctdt> Ctdts { get; set; }

    public virtual DbSet<Cthd> Cthds { get; set; }

    public virtual DbSet<Ctk> Ctks { get; set; }

    public virtual DbSet<Ctpdt> Ctpdts { get; set; }

    public virtual DbSet<Ctpdtb> Ctpdtbs { get; set; }

    public virtual DbSet<Ctpgt> Ctpgts { get; set; }

    public virtual DbSet<Ctpgtb> Ctpgtbs { get; set; }

    public virtual DbSet<Ctpkdt> Ctpkdts { get; set; }

    public virtual DbSet<Ctpkk> Ctpkks { get; set; }

    public virtual DbSet<Ctpktb> Ctpktbs { get; set; }

    public virtual DbSet<Dangthuoc> Dangthuocs { get; set; }

    public virtual DbSet<Dichvu> Dichvus { get; set; }

    public virtual DbSet<Donthuoc> Donthuocs { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phieudathang> Phieudathangs { get; set; }

    public virtual DbSet<Phieudieutri> Phieudieutris { get; set; }

    public virtual DbSet<Phieugiaohang> Phieugiaohangs { get; set; }

    public virtual DbSet<Phieuhen> Phieuhens { get; set; }

    public virtual DbSet<Phieukiem> Phieukiems { get; set; }

    public virtual DbSet<Phieuluong> Phieuluongs { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Thietbi> Thietbis { get; set; }

    public virtual DbSet<Thuoc> Thuocs { get; set; }

    public virtual DbSet<ViewChucVu> ViewChucVus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=zero\\sqlexpress;Initial Catalog=DAPHONGKHAMNHAKHOA;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Benhnhan>(entity =>
        {
            entity.HasKey(e => e.MaBn).HasName("PK__BENHNHAN__272475AD4C0519F7");

            entity.ToTable("BENHNHAN");

            entity.Property(e => e.MaBn).HasColumnName("MaBN");
            entity.Property(e => e.DiaChi).HasColumnType("ntext");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("EMAIL");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .UseCollation("Vietnamese_CI_AI");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenBn)
                .HasMaxLength(30)
                .HasColumnName("TenBN");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PK__CHUCVU__27258E76B2EBCB2B");

            entity.ToTable("CHUCVU");

            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.Mota)
                .HasColumnType("ntext")
                .HasColumnName("MOTA");
            entity.Property(e => e.TenCv)
                .HasMaxLength(30)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<Ctdt>(entity =>
        {
            entity.HasKey(e => e.MaCtdt).HasName("PK__CTDT__1E4E40E49CB2602C");

            entity.ToTable("CTDT");

            entity.Property(e => e.MaCtdt).HasColumnName("MaCTDT");
            entity.Property(e => e.Cachdung)
                .HasColumnType("ntext")
                .HasColumnName("CACHDUNG");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Dvt)
                .HasMaxLength(20)
                .HasColumnName("DVT");
            entity.Property(e => e.MaDt).HasColumnName("MaDT");
            entity.Property(e => e.Sl).HasColumnName("SL");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.Ctdts)
                .HasForeignKey(d => d.MaDt)
                .HasConstraintName("FK__CTDT__MaDT__25518C17");

            entity.HasOne(d => d.MaThuocNavigation).WithMany(p => p.Ctdts)
                .HasForeignKey(d => d.MaThuoc)
                .HasConstraintName("FK__CTDT__MaThuoc__2645B050");
        });

        modelBuilder.Entity<Cthd>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PK__CTHD__1E4FA77119E83340");

            entity.ToTable("CTHD");

            entity.Property(e => e.MaCthd).HasColumnName("MaCTHD");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.Mapdt).HasColumnName("MAPDT");
            entity.Property(e => e.Trangthai)
                .HasColumnType("ntext")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.Cthds)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__CTHD__MaHD__31B762FC");

            entity.HasOne(d => d.MapdtNavigation).WithMany(p => p.Cthds)
                .HasForeignKey(d => d.Mapdt)
                .HasConstraintName("FK__CTHD__MAPDT__32AB8735");
        });

        modelBuilder.Entity<Ctk>(entity =>
        {
            entity.HasKey(e => e.MaCtk).HasName("PK__CTK__3DCB54FCE0B89CE8");

            entity.ToTable("CTK");

            entity.Property(e => e.MaCtk).HasColumnName("MaCTK");
            entity.Property(e => e.MaKho).HasColumnName("MaKHO");
            entity.Property(e => e.Mathuoc).HasColumnName("MATHUOC");
            entity.Property(e => e.Sl).HasColumnName("SL");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(20)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaKhoNavigation).WithMany(p => p.Ctks)
                .HasForeignKey(d => d.MaKho)
                .HasConstraintName("FK__CTK__MaKHO__3587F3E0");

            entity.HasOne(d => d.MathuocNavigation).WithMany(p => p.Ctks)
                .HasForeignKey(d => d.Mathuoc)
                .HasConstraintName("FK__CTK__MATHUOC__367C1819");
        });

        modelBuilder.Entity<Ctpdt>(entity =>
        {
            entity.HasKey(e => e.MaCtpdt).HasName("PK__CTPDT__5A2D17C9E7AAFD17");

            entity.ToTable("CTPDT");

            entity.Property(e => e.MaCtpdt).HasColumnName("MaCTPDT");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GIA");
            entity.Property(e => e.MaPdh).HasColumnName("MaPDH");
            entity.Property(e => e.Sl).HasColumnName("SL");

            entity.HasOne(d => d.MaPdhNavigation).WithMany(p => p.Ctpdts)
                .HasForeignKey(d => d.MaPdh)
                .HasConstraintName("FK__CTPDT__MaPDH__08B54D69");

            entity.HasOne(d => d.MaThuocNavigation).WithMany(p => p.Ctpdts)
                .HasForeignKey(d => d.MaThuoc)
                .HasConstraintName("FK__CTPDT__MaThuoc__09A971A2");
        });

        modelBuilder.Entity<Ctpdtb>(entity =>
        {
            entity.HasKey(e => e.MaCtpdtb).HasName("PK__CTPDTB__9EC168FD1583B288");

            entity.ToTable("CTPDTB");

            entity.Property(e => e.MaCtpdtb).HasColumnName("MaCTPDTB");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GIA");
            entity.Property(e => e.MaPdh).HasColumnName("MaPDH");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Sl).HasColumnName("SL");

            entity.HasOne(d => d.MaPdhNavigation).WithMany(p => p.Ctpdtbs)
                .HasForeignKey(d => d.MaPdh)
                .HasConstraintName("FK__CTPDTB__MaPDH__14270015");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Ctpdtbs)
                .HasForeignKey(d => d.Matb)
                .HasConstraintName("FK__CTPDTB__MATB__151B244E");
        });

        modelBuilder.Entity<Ctpgt>(entity =>
        {
            entity.HasKey(e => e.MaCtpgh).HasName("PK__CTPGT__5A2DF07B830CED76");

            entity.ToTable("CTPGT");

            entity.Property(e => e.MaCtpgh).HasColumnName("MaCTPGH");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GIA");
            entity.Property(e => e.MaPgh).HasColumnName("MaPGH");
            entity.Property(e => e.Sl).HasColumnName("SL");

            entity.HasOne(d => d.MaPghNavigation).WithMany(p => p.Ctpgts)
                .HasForeignKey(d => d.MaPgh)
                .HasConstraintName("FK__CTPGT__MaPGH__04E4BC85");

            entity.HasOne(d => d.MaThuocNavigation).WithMany(p => p.Ctpgts)
                .HasForeignKey(d => d.MaThuoc)
                .HasConstraintName("FK__CTPGT__MaThuoc__05D8E0BE");
        });

        modelBuilder.Entity<Ctpgtb>(entity =>
        {
            entity.HasKey(e => e.MaCtpdtb).HasName("PK__CTPGTB__9EC168FDF63990EE");

            entity.ToTable("CTPGTB");

            entity.Property(e => e.MaCtpdtb).HasColumnName("MaCTPDTB");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GIA");
            entity.Property(e => e.MaPgh).HasColumnName("MaPGH");
            entity.Property(e => e.MaTb).HasColumnName("MaTB");
            entity.Property(e => e.Sl).HasColumnName("SL");

            entity.HasOne(d => d.MaPghNavigation).WithMany(p => p.Ctpgtbs)
                .HasForeignKey(d => d.MaPgh)
                .HasConstraintName("FK__CTPGTB__MaPGH__10566F31");

            entity.HasOne(d => d.MaTbNavigation).WithMany(p => p.Ctpgtbs)
                .HasForeignKey(d => d.MaTb)
                .HasConstraintName("FK__CTPGTB__MaTB__114A936A");
        });

        modelBuilder.Entity<Ctpkdt>(entity =>
        {
            entity.HasKey(e => e.MaCtpkdt).HasName("PK__CTPKDT__9C81F4C014479F00");

            entity.ToTable("CTPKDT");

            entity.Property(e => e.MaCtpkdt).HasColumnName("MaCTPKDT");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.MaPdt).HasColumnName("MaPDT");
            entity.Property(e => e.Sl).HasColumnName("SL");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.Ctpkdts)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__CTPKDT__MaDV__2A164134");

            entity.HasOne(d => d.MaPdtNavigation).WithMany(p => p.Ctpkdts)
                .HasForeignKey(d => d.MaPdt)
                .HasConstraintName("FK__CTPKDT__MaPDT__29221CFB");
        });

        modelBuilder.Entity<Ctpkk>(entity =>
        {
            entity.HasKey(e => e.MaCtpkk).HasName("PK__CTPKK__5A2D4EF7DE6D154A");

            entity.ToTable("CTPKK");

            entity.Property(e => e.MaCtpkk).HasColumnName("MaCTPKK");
            entity.Property(e => e.MaPk).HasColumnName("MaPK");
            entity.Property(e => e.Sl).HasColumnName("SL");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(20)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaPkNavigation).WithMany(p => p.Ctpkks)
                .HasForeignKey(d => d.MaPk)
                .HasConstraintName("FK__CTPKK__MaPK__0C85DE4D");

            entity.HasOne(d => d.MakhoNavigation).WithMany(p => p.Ctpkks)
                .HasForeignKey(d => d.Makho)
                .HasConstraintName("FK__CTPKK__Makho__0D7A0286");
        });

        modelBuilder.Entity<Ctpktb>(entity =>
        {
            entity.HasKey(e => e.MaCtpktb).HasName("PK__CTPKTB__9C8176FA28FDE581");

            entity.ToTable("CTPKTB");

            entity.Property(e => e.MaCtpktb).HasColumnName("MaCTPKTB");
            entity.Property(e => e.MaPk).HasColumnName("MaPK");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Sl).HasColumnName("SL");
            entity.Property(e => e.Trangthai)
                .HasColumnType("ntext")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaPkNavigation).WithMany(p => p.Ctpktbs)
                .HasForeignKey(d => d.MaPk)
                .HasConstraintName("FK__CTPKTB__MaPK__17F790F9");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Ctpktbs)
                .HasForeignKey(d => d.Matb)
                .HasConstraintName("FK__CTPKTB__MATB__18EBB532");
        });

        modelBuilder.Entity<Dangthuoc>(entity =>
        {
            entity.HasKey(e => e.MaDt).HasName("PK__DANGTHUO__27258655329508BF");

            entity.ToTable("DANGTHUOC");

            entity.Property(e => e.MaDt).HasColumnName("MaDT");
            entity.Property(e => e.TenDt)
                .HasMaxLength(20)
                .HasColumnName("TenDT");
        });

        modelBuilder.Entity<Dichvu>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK__DICHVU__272586576D01EA36");

            entity.ToTable("DICHVU");

            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.Dvt)
                .HasMaxLength(20)
                .HasColumnName("DVT");
            entity.Property(e => e.Giadv)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GIADV");
            entity.Property(e => e.Khuyenmai).HasColumnName("KHUYENMAI");
            entity.Property(e => e.TenDv)
                .HasMaxLength(30)
                .HasColumnName("TenDV");
            entity.Property(e => e.Tgbh).HasColumnName("TGBH");
        });

        modelBuilder.Entity<Donthuoc>(entity =>
        {
            entity.HasKey(e => e.MaDt).HasName("PK__DONTHUOC__27258655E6F1E38F");

            entity.ToTable("DONTHUOC");

            entity.Property(e => e.MaDt).HasColumnName("MaDT");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MaPdt).HasColumnName("MaPDT");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TONGTIEN");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Donthuocs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__DONTHUOC__MaNV__2180FB33");

            entity.HasOne(d => d.MaPdtNavigation).WithMany(p => p.Donthuocs)
                .HasForeignKey(d => d.MaPdt)
                .HasConstraintName("FK__DONTHUOC__MaPDT__22751F6C");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HOADON__2725A6E0BEA63BEC");

            entity.ToTable("HOADON");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaBn).HasColumnName("MaBN");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasColumnType("ntext")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaBnNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.MaBn)
                .HasConstraintName("FK__HOADON__MaBN__2EDAF651");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__HOADON__MaNV__2DE6D218");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.MaKho).HasName("PK__KHO__3BD980E891D94AE1");

            entity.ToTable("KHO");

            entity.Property(e => e.MaKho).HasColumnName("MaKHO");
            entity.Property(e => e.ViTri).HasColumnType("ntext");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK__LUONG__94873021F4875DA3");

            entity.ToTable("LUONG");

            entity.Property(e => e.MaLuong).HasColumnName("MaLUONG");
            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.Tienluong)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TIENLUONG");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK__LUONG__MaCV__5CD6CB2B");
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NHACUNGC__3A185DEB6401E6CD");

            entity.ToTable("NHACUNGCAP");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasColumnType("ntext");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(30)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NHANVIEN__2725D70A8E321055");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasColumnType("ntext");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gt)
                .HasMaxLength(10)
                .UseCollation("Vietnamese_CI_AI")
                .HasColumnName("GT");
            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNv)
                .HasMaxLength(30)
                .HasColumnName("TenNV");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK__NHANVIEN__MaCV__5441852A");
        });

        modelBuilder.Entity<Phieudathang>(entity =>
        {
            entity.HasKey(e => e.MaPdh).HasName("PK__PHIEUDAT__3AE048C75F30FC45");

            entity.ToTable("PHIEUDATHANG");

            entity.Property(e => e.MaPdh).HasColumnName("MaPDH");
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasColumnType("ntext")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.Phieudathangs)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__PHIEUDATH__MaNCC__68487DD7");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Phieudathangs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PHIEUDATHA__MaNV__6754599E");
        });

        modelBuilder.Entity<Phieudieutri>(entity =>
        {
            entity.HasKey(e => e.MaPdt).HasName("PK__phieudie__3AE048CB8456B32D");

            entity.ToTable("phieudieutri");

            entity.Property(e => e.MaPdt).HasColumnName("MaPDT");
            entity.Property(e => e.MaBn).HasColumnName("MaBN");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Nddt)
                .HasColumnType("ntext")
                .HasColumnName("NDDT");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.TrangThai).HasColumnType("ntext");

            entity.HasOne(d => d.MaBnNavigation).WithMany(p => p.Phieudieutris)
                .HasForeignKey(d => d.MaBn)
                .HasConstraintName("FK__phieudieut__MaBN__1DB06A4F");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Phieudieutris)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__phieudieut__MaNV__1CBC4616");
        });

        modelBuilder.Entity<Phieugiaohang>(entity =>
        {
            entity.HasKey(e => e.MaPgh).HasName("PK__PHIEUGIA__3AE3DEBF76627D92");

            entity.ToTable("PHIEUGIAOHANG");

            entity.Property(e => e.MaPgh).HasColumnName("MaPGH");
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MaPdh).HasColumnName("MaPDH");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasColumnType("ntext")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.Phieugiaohangs)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__PHIEUGIAO__MaNCC__6E01572D");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Phieugiaohangs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PHIEUGIAOH__MaNV__6C190EBB");

            entity.HasOne(d => d.MaPdhNavigation).WithMany(p => p.Phieugiaohangs)
                .HasForeignKey(d => d.MaPdh)
                .HasConstraintName("FK__PHIEUGIAO__MaPDH__6D0D32F4");
        });

        modelBuilder.Entity<Phieuhen>(entity =>
        {
            entity.HasKey(e => e.MaPh).HasName("PK__PHIEUHEN__2725E7FAA57E90AC");

            entity.ToTable("PHIEUHEN");

            entity.Property(e => e.MaPh).HasColumnName("MaPH");
            entity.Property(e => e.MaBn).HasColumnName("MaBN");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Ngayhen)
                .HasColumnType("date")
                .HasColumnName("NGAYHEN");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Trangthai)
                .HasColumnType("ntext")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaBnNavigation).WithMany(p => p.Phieuhens)
                .HasForeignKey(d => d.MaBn)
                .HasConstraintName("FK__PHIEUHEN__MaBN__797309D9");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Phieuhens)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PHIEUHEN__MaNV__787EE5A0");
        });

        modelBuilder.Entity<Phieukiem>(entity =>
        {
            entity.HasKey(e => e.MaPk).HasName("PK__PHIEUKIE__2725E7FD9CA8E1A1");

            entity.ToTable("PHIEUKIEM");

            entity.Property(e => e.MaPk).HasColumnName("MaPK");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Phieukiems)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PHIEUKIEM__MaNV__02084FDA");
        });

        modelBuilder.Entity<Phieuluong>(entity =>
        {
            entity.HasKey(e => e.MaPl).HasName("PK__PHIEULUO__2725E7FE99159611");

            entity.ToTable("PHIEULUONG");

            entity.Property(e => e.MaPl).HasColumnName("MaPL");
            entity.Property(e => e.MaLuong).HasColumnName("MaLUONG");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tienthuong)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TIENTHUONG");
            entity.Property(e => e.Tientru)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TIENTRU");
            entity.Property(e => e.Trangthai)
                .HasColumnType("ntext")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaLuongNavigation).WithMany(p => p.Phieuluongs)
                .HasForeignKey(d => d.MaLuong)
                .HasConstraintName("FK__PHIEULUON__MaLUO__6383C8BA");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Phieuluongs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PHIEULUONG__MaNV__628FA481");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.MaTk).HasName("PK__TAIKHOAN__272500701962D2F8");

            entity.ToTable("TAIKHOAN");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TAIKHOAN__55F68FC042BD80E6").IsUnique();

            entity.Property(e => e.MaTk).HasColumnName("MaTK");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__TAIKHOAN__MaNV__59FA5E80");
        });

        modelBuilder.Entity<Thietbi>(entity =>
        {
            entity.HasKey(e => e.MaTb).HasName("PK__thietbi__2725006FBE562F9A");

            entity.ToTable("thietbi");

            entity.Property(e => e.MaTb).HasColumnName("MaTB");
            entity.Property(e => e.Mancc).HasColumnName("mancc");
            entity.Property(e => e.Sl).HasColumnName("sl");
            entity.Property(e => e.TenTb)
                .HasMaxLength(30)
                .HasColumnName("TenTB");
            entity.Property(e => e.Tinhtrang)
                .HasColumnType("ntext")
                .HasColumnName("tinhtrang");

            entity.HasOne(d => d.ManccNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Mancc)
                .HasConstraintName("FK__thietbi__mancc__7E37BEF6");
        });

        modelBuilder.Entity<Thuoc>(entity =>
        {
            entity.HasKey(e => e.MaThuoc).HasName("PK__THUOC__4BB1F620F7938E5B");

            entity.ToTable("THUOC");

            entity.Property(e => e.Gia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GIA");
            entity.Property(e => e.Hsd)
                .HasColumnType("date")
                .HasColumnName("HSD");
            entity.Property(e => e.MaDt).HasColumnName("MaDT");
            entity.Property(e => e.Mancc).HasColumnName("MANCC");
            entity.Property(e => e.Mota)
                .HasColumnType("ntext")
                .HasColumnName("MOTA");
            entity.Property(e => e.TenThuoc).HasMaxLength(30);

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.Thuocs)
                .HasForeignKey(d => d.MaDt)
                .HasConstraintName("FK__THUOC__MaDT__72C60C4A");

            entity.HasOne(d => d.ManccNavigation).WithMany(p => p.Thuocs)
                .HasForeignKey(d => d.Mancc)
                .HasConstraintName("FK__THUOC__MANCC__73BA3083");
        });

        modelBuilder.Entity<ViewChucVu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewChucVu");

            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.MoTa).HasColumnType("ntext");
            entity.Property(e => e.Tencv)
                .HasMaxLength(30)
                .HasColumnName("TENCV");
            entity.Property(e => e.TienLuong).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
