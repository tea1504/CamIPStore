using Microsoft.EntityFrameworkCore;
using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class IPShopDBContext : DbContext
    {
        public IPShopDBContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NhaSanXuatConfig());
            modelBuilder.ApplyConfiguration(new CameraConfig());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonConfig());
            modelBuilder.ApplyConfiguration(new ChiTietKhuyenMaiConfig());
            modelBuilder.ApplyConfiguration(new GioHangConfig());
            modelBuilder.ApplyConfiguration(new HinhConfig());
            modelBuilder.ApplyConfiguration(new HoaDonConfig());
            modelBuilder.ApplyConfiguration(new KhuyenMaiConfig());
            modelBuilder.ApplyConfiguration(new TaiKhoanConfig());
           base.OnModelCreating(modelBuilder);
        }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<ChiTietKhuyenMai> ChiTietKhuyenMai { get; set; }
        public DbSet<GioHang> GioHang { get; set; }
        public DbSet<Hinh> Hinh { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<KhuyenMai> KhuyenMai { get; set; }
        public DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
    }
         
}
