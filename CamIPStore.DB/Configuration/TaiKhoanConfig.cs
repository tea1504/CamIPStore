using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration
{
    public class TaiKhoanConfig : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.ToTable("TaiKhoan");
            builder.HasKey(s => s.IdTK);
            builder.Property(s => s.IdTK).IsRequired().HasColumnName("IdTK").ValueGeneratedOnAdd();
            builder.Property(s => s.TenTK).IsRequired().HasColumnName("TenTK").HasMaxLength(12);
            builder.Property(s => s.MatKhau).IsRequired().HasColumnName("MatKhau").HasMaxLength(12);
            builder.Property(s => s.HoTen).IsRequired().HasColumnName("HoTen");
            builder.Property(s => s.DiaChi).IsRequired().HasColumnName("DiaChi");
            builder.Property(s => s.Email).IsRequired().HasColumnName("Email");
            builder.Property(s => s.SDT).IsRequired().HasColumnName("SDT").HasMaxLength(10);
            builder.Property(s => s.QuyenSD).IsRequired().HasColumnName("QuyenSD");
            builder.Property(s => s.TrangThai).IsRequired().HasColumnName("TrangThai");
        }
    }
}
