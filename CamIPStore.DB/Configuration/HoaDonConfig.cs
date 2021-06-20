using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(a => a.IdHD);
            builder.HasKey(a => new {  a.IdTK });
            builder.HasOne(a=> a.TaiKhoan).WithMany(b => b.DsHoaDon).HasForeignKey(b => b.IdTK);
            builder.Property(a => a.IdHD).HasColumnName("IdHD").IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.IdTK).HasColumnName("IdTK").IsRequired();
            builder.Property(a => a.NgayLap).HasColumnName("NgayLap").HasColumnType("datetime"); ;
            builder.Property(a => a.NgayTao).HasColumnName("NgayTao").HasColumnType("datetime"); ;
            builder.Property(a => a.TongGia).HasColumnName("TongGia");
            builder.Property(a => a.TrangThai).HasColumnName("TrangThai");
            builder.Property(a => a.BaoHanh).HasColumnName("BaoHanh");
        }
    }
}
