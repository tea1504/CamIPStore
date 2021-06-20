using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Configuration
{
    public class NhaSanXuatConfig : IEntityTypeConfiguration<NhaSanXuat>
    {
        
        public void Configure(EntityTypeBuilder<NhaSanXuat> builder)
        {
            builder.ToTable("NhaSanXuat");
            builder.HasKey(k => k.IdNSX);
            builder.Property(k => k.TenNSX).IsRequired(true).HasColumnName("TenNSX");
            builder.Property(k => k.IdNSX).HasColumnName("IdNSX").IsRequired().ValueGeneratedOnAdd();
        }
    }
}
