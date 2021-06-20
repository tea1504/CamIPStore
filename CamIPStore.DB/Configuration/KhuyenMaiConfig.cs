using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration
{
    public class KhuyenMaiConfig : IEntityTypeConfiguration<KhuyenMai>
    {
        public void Configure(EntityTypeBuilder<KhuyenMai> builder)
        {
            builder.ToTable("KhuyenMai");
            builder.HasKey(s => s.IdKM);
            builder.Property(s => s.IdKM).HasColumnName("IdKM").IsRequired().ValueGeneratedOnAdd();
            builder.Property(s => s.TenKM).HasColumnName("TenKM").IsRequired();
            builder.Property(s => s.PhanTramGiam).HasColumnName("PhanTramGiam");
            builder.Property(s => s.TuNgay).HasColumnName("TuNgay").HasColumnType("datetime"); ;
            builder.Property(s => s.DenNgay).HasColumnName("DenNgay").HasColumnType("datetime"); ;
            builder.Property(s => s.Banner).HasColumnName("Banner");
        }
    }
}
