namespace WebLaptop3.Models.NewData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyLaptopModel1 : DbContext
    {
        public QuanLyLaptopModel1()
            : base("name=QuanLyLaptopModel1")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<LoaiLaptop> LoaiLaptops { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaLaptop)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Laptop>()
                .Property(e => e.MaLaptop)
                .IsUnicode(false);

            modelBuilder.Entity<Laptop>()
                .Property(e => e.MaLoaiLaptop)
                .IsUnicode(false);

            modelBuilder.Entity<Laptop>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<Laptop>()
                .Property(e => e.MaNhaCungCap)
                .IsUnicode(false);

            modelBuilder.Entity<Laptop>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.Laptop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiLaptop>()
                .Property(e => e.MaLoaiLaptop)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNhaCungCap)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT)
                .IsUnicode(false);
        }
    }
}
