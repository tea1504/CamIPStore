using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
namespace Configuration
{
    public class CameraConfig : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.ToTable("Camera");
            builder.HasKey(k => k.IdCam);
            builder.HasOne(k => k.NhaSanXuat).WithMany(a => a.DsCamera).HasForeignKey(a => a.IdNSX);
            builder.Property(k => k.Ten).IsRequired();
            builder.Property(k => k.IdCam).HasColumnName("IdCam").IsRequired().ValueGeneratedOnAdd();
            builder.Property(k => k.IdNSX).HasColumnName("IdNSX");
            builder.Property(k => k.Ten).HasColumnName("TenCamera");
            builder.Property(k => k.XuatXu).HasColumnName("XuatXu");
            builder.Property(k => k.CamBien).HasColumnName("CamBien");
            builder.Property(k => k.AmThanh).HasColumnName("AmThanh");
            builder.Property(k => k.DoPhanGiai).HasColumnName("DoPhanGiai");
            builder.Property(k => k.DungLuong).HasColumnName("DungLuong");
            builder.Property(k => k.KhoangCach).HasColumnName("KhoangCach");
            builder.Property(k => k.DoXoayNgang).HasColumnName("DoXoayNgang");
            builder.Property(k => k.DoXoayDoc).HasColumnName("DoXoayDoc");
            builder.Property(k => k.SoLuong).HasColumnName("SoLuong");
            builder.Property(k => k.KhongDay).HasColumnName("KhongDay");
            builder.Property(k => k.CoDay).HasColumnName("CoDay");
            builder.Property(k => k.DKTuXa).HasColumnName("DieuKhiTuXa");
            builder.Property(k => k.GiaBan).HasColumnName("GiaBan");
            builder.Property(k => k.GiaGoc).HasColumnName("GiaGoc");
            builder.Property(k => k.MoTa).HasColumnName("MoTa");
        }
    }
}
