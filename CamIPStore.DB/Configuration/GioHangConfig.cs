using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration
{
    public class GioHangConfig : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang");
            builder.HasKey(s => new { s.IdCam, s.IdTK});
            builder.HasOne(s => s.Camera).WithMany(a => a.DsGioHang).HasForeignKey(a=>a.IdCam);
            builder.HasOne(s => s.TaiKhoan).WithMany(a => a.DsGioHang).HasForeignKey(a => a.IdTK);
            builder.Property(s => s.IdCam).HasColumnName("IdCam").IsRequired();
            builder.Property(s => s.IdTK).HasColumnName("IdTK").IsRequired();
            builder.Property(s => s.Sl).HasColumnName("SoLuong");
        }
    }
}
