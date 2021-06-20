using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration
{
    public class HinhConfig : IEntityTypeConfiguration<Hinh>
    {
        public void Configure(EntityTypeBuilder<Hinh> builder)
        {
            builder.ToTable("Hinh");
            builder.HasKey(s => new { s.IdHinh , s.IdCam});
            builder.HasOne(s => s.Camera).WithMany(a => a.DsHinh).HasForeignKey(a => a.IdCam);
            builder.Property(s => s.IdHinh).HasColumnName("Id Hình").IsRequired().ValueGeneratedOnAdd();
            builder.Property(s => s.IdCam).HasColumnName("Id Cam").IsRequired();
            builder.Property(s => s.HinhDaiDien).HasColumnName("HinhDaiDien");
            builder.Property(s => s.Link).HasColumnName("Link");
        }
    }
}
