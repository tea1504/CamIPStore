using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
namespace Configuration
{
    public class ChiTietHoaDonConfig : IEntityTypeConfiguration<ChiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.ToTable("ChiTietHoaDon");
            builder.HasKey(s => new { s.IdCam, s.IdHD });
            builder.HasOne(s => s.Camera).WithMany(a => a.DsChiTietHoaDon).HasForeignKey(a => a.IdCam);
            builder.HasOne(s => s.HoaDon).WithMany(a => a.DsChiTietHoaDon).HasForeignKey(a => a.IdHD);
            builder.Property(s => s.IdCam).HasColumnName("IdCam").IsRequired();
            builder.Property(s => s.IdHD).HasColumnName("IdHD").IsRequired();
            builder.Property(s => s.SLMua).HasColumnName("SoLuongMua");
            builder.Property(s => s.GiaBan).HasColumnName("GiaBan");
        }
    }
}
