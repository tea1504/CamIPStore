using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CamIPStore.DB.Migrations
{
    public partial class CamIPStoreDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    IdKM = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKM = table.Column<string>(nullable: false),
                    PhanTramGiam = table.Column<int>(nullable: false),
                    TuNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    DenNgay = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.IdKM);
                });

            migrationBuilder.CreateTable(
                name: "NhaSanXuat",
                columns: table => new
                {
                    IdNSX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNSX = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaSanXuat", x => x.IdNSX);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    IdTK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTK = table.Column<string>(maxLength: 12, nullable: false),
                    MatKhau = table.Column<string>(maxLength: 12, nullable: false),
                    SDT = table.Column<string>(maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HoTen = table.Column<string>(nullable: false),
                    QuyenSD = table.Column<bool>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.IdTK);
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    IdCam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNSX = table.Column<int>(nullable: false),
                    TenCamera = table.Column<string>(nullable: false),
                    XuatXu = table.Column<string>(nullable: true),
                    CamBien = table.Column<string>(nullable: true),
                    AmThanh = table.Column<string>(nullable: true),
                    DoPhanGiai = table.Column<string>(nullable: true),
                    DungLuong = table.Column<string>(nullable: true),
                    KhoangCach = table.Column<string>(nullable: true),
                    DoXoayNgang = table.Column<int>(nullable: false),
                    DoXoayDoc = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    KhongDay = table.Column<bool>(nullable: false),
                    CoDay = table.Column<bool>(nullable: false),
                    DieuKhiTuXa = table.Column<bool>(nullable: false),
                    GiaGoc = table.Column<float>(nullable: false),
                    GiaBan = table.Column<float>(nullable: false),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.IdCam);
                    table.ForeignKey(
                        name: "FK_Camera_NhaSanXuat_IdNSX",
                        column: x => x.IdNSX,
                        principalTable: "NhaSanXuat",
                        principalColumn: "IdNSX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    IdHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTK = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    TongGia = table.Column<float>(nullable: false),
                    BaoHanh = table.Column<int>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.IdHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_TaiKhoan_IdTK",
                        column: x => x.IdTK,
                        principalTable: "TaiKhoan",
                        principalColumn: "IdTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKhuyenMai",
                columns: table => new
                {
                    IdCam = table.Column<int>(nullable: false),
                    IdKM = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKhuyenMai", x => new { x.IdCam, x.IdKM });
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMai_Camera_IdCam",
                        column: x => x.IdCam,
                        principalTable: "Camera",
                        principalColumn: "IdCam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMai_KhuyenMai_IdKM",
                        column: x => x.IdKM,
                        principalTable: "KhuyenMai",
                        principalColumn: "IdKM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    IdCam = table.Column<int>(nullable: false),
                    IdTK = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => new { x.IdCam, x.IdTK });
                    table.ForeignKey(
                        name: "FK_GioHang_Camera_IdCam",
                        column: x => x.IdCam,
                        principalTable: "Camera",
                        principalColumn: "IdCam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHang_TaiKhoan_IdTK",
                        column: x => x.IdTK,
                        principalTable: "TaiKhoan",
                        principalColumn: "IdTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hinh",
                columns: table => new
                {
                    IdHinh = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCam = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    HinhDaiDien = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinh", x => x.IdHinh);
                    table.ForeignKey(
                        name: "FK_Hinh_Camera_IdCam",
                        column: x => x.IdCam,
                        principalTable: "Camera",
                        principalColumn: "IdCam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    IdCam = table.Column<int>(nullable: false),
                    IdHD = table.Column<int>(nullable: false),
                    SoLuongMua = table.Column<int>(nullable: false),
                    GiaBan = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => new { x.IdCam, x.IdHD });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_Camera_IdCam",
                        column: x => x.IdCam,
                        principalTable: "Camera",
                        principalColumn: "IdCam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_IdHD",
                        column: x => x.IdHD,
                        principalTable: "HoaDon",
                        principalColumn: "IdHD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camera_IdNSX",
                table: "Camera",
                column: "IdNSX");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_IdHD",
                table: "ChiTietHoaDon",
                column: "IdHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMai_IdKM",
                table: "ChiTietKhuyenMai",
                column: "IdKM");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdTK",
                table: "GioHang",
                column: "IdTK");

            migrationBuilder.CreateIndex(
                name: "IX_Hinh_IdCam",
                table: "Hinh",
                column: "IdCam");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdTK",
                table: "HoaDon",
                column: "IdTK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "ChiTietKhuyenMai");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "Hinh");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "NhaSanXuat");
        }
    }
}
