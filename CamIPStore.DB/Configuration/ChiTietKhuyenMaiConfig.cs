using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration
{
    public class ChiTietKhuyenMaiConfig : IEntityTypeConfiguration<ChiTietKhuyenMai>
    {
        public void Configure(EntityTypeBuilder<ChiTietKhuyenMai> builder)
        {
            builder.ToTable("ChiTietKhuyenMai");
            builder.HasKey(s => new { s.IdCam, s.IdKM });
            builder.HasOne(s => s.Camera).WithMany(a => a.DsChiTietKhuyenMai).HasForeignKey(a => a.IdCam);
            builder.HasOne(s => s.KhuyenMai).WithMany(a => a.DsChiTietKhuyenMai).HasForeignKey(a => a.IdKM);
            builder.Property(s => s.IdCam).HasColumnName("IdCam").IsRequired();
            builder.Property(s => s.IdKM).HasColumnName("IdKM").IsRequired();
        }
    }
}
