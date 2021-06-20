using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CamIPStore.DB.Migrations
{
    public partial class DataSeed : Migration
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
                    DenNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    Banner = table.Column<string>(nullable: true)
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
                    GhiChu = table.Column<string>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "KhuyenMai",
                columns: new[] { "IdKM", "Banner", "DenNgay", "PhanTramGiam", "TenKM", "TuNgay" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Flash Sale cuối tuần", new DateTime(2021, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Tháng 6 Vui Vẻ", new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, "Khai trương", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Ưu đãi khách mới", new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2021, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Ưu đãi tân sinh viên", new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "", new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Sinh nhật vui vẻ", new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "NhaSanXuat",
                columns: new[] { "IdNSX", "TenNSX" },
                values: new object[,]
                {
                    { 6, "CareCam" },
                    { 5, "Yoosee" },
                    { 4, "Kbvision" },
                    { 2, "TP-Link" },
                    { 1, "Xiaomi" },
                    { 3, "EZVIZ - HIKVISION" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "IdTK", "DiaChi", "Email", "HoTen", "MatKhau", "QuyenSD", "SDT", "TenTK", "TrangThai" },
                values: new object[,]
                {
                    { 28, "Cần Thơ", "Binh@cpm.ebc.cit", "Trần Nguyễn Tường Bình", "12345", true, "0312991267", "user28", true },
                    { 22, "Cần Thơ", "Hau@yahoo.com", "Nguyễn Phúc Thảo Hậu", "12345", true, "0699527986", "user22", true },
                    { 23, "Cần Thơ", "Dat@gmail.com", "Ngô Đạt", "12345", true, "0882101189", "user23", true },
                    { 24, "Cần Thơ", "An@abc.xyz", "Hồ Thị Tường An", "12345", true, "0674060358", "user24", true },
                    { 25, "Cần Thơ", "Manh@yahoo.com", "Mai Cẩm Mạnh", "12345", false, "0355909778", "user25", true },
                    { 26, "Cần Thơ", "Hau@yahoo.com", "Huỳnh Kim Hậu", "12345", true, "0550851297", "user26", true },
                    { 27, "Cần Thơ", "Hoa@yahoo.com", "Lưu Hoàng Hóa", "12345", true, "0549183731", "user27", true },
                    { 29, "Cần Thơ", "Hanh@cpm.ebc.cit", "Lưu Hạnh", "12345", true, "0594100321", "user29", true },
                    { 35, "Cần Thơ", "Nga@yahoo.com", "Vi Trung Nga", "12345", true, "0903639096", "user35", true },
                    { 31, "Cần Thơ", "Gia@abc.xyz", "Nguyễn Trần Gia", "12345", true, "0457173781", "user31", true },
                    { 32, "Cần Thơ", "Ngan@gmail.com", "Nguyễn Trần Mộng Ngân", "12345", true, "0120750995", "user32", true },
                    { 33, "Cần Thơ", "Long@gmail.com", "Đỗ Trung Long", "12345", true, "0730168885", "user33", true },
                    { 34, "Cần Thơ", "Hanh@cpm.ebc.cit", "Dương Trung Hạnh", "12345", true, "0374077585", "user34", true },
                    { 21, "Cần Thơ", "Dat@yahoo.com", "Trần Nguyễn Huỳnh Đạt", "12345", false, "0696679759", "user21", true },
                    { 36, "Cần Thơ", "Manh@yahoo.com", "Nguyễn Trần Mộng Mạnh", "12345", true, "0146865028", "user36", true },
                    { 37, "Cần Thơ", "Duong@cpm.ebc.cit", "Nguyễn Phúc Cẩm Dương", "12345", true, "0418281298", "user37", true },
                    { 38, "Cần Thơ", "Hau@yahoo.com", "Nguyễn Trần Trung Hậu", "12345", true, "0295945376", "user38", true },
                    { 30, "Cần Thơ", "Du@cpm.ebc.cit", "Lê Minh Du", "12345", false, "0567477781", "user30", true },
                    { 20, "Cần Thơ", "Ngoc@cpm.ebc.cit", "Huỳnh Trung Ngọc", "12345", false, "0176530779", "user20", true },
                    { 14, "Cần Thơ", "Dao@gmail.com.vn", "Mai Minh Dao", "12345", true, "0871156817", "user14", true },
                    { 18, "Cần Thơ", "Cong@abc.xyz", "Trần Minh Công", "12345", true, "0986292715", "user18", true },
                    { 1, "Cần Thơ", "Hieu@gmail.com", "Trần Nguyễn Minh Hiếu", "12345", true, "0253737775", "user1", true },
                    { 2, "Cần Thơ", "Binh@abc.xyz", "Ngô Minh Bình", "12345", true, "0162332975", "user2", true },
                    { 3, "Cần Thơ", "Nga@cpm.ebc.cit", "Huỳnh Thảo Nga", "12345", false, "0940895982", "user3", true },
                    { 4, "Cần Thơ", "Duong@gmail.com", "Lưu Tường Dương", "12345", false, "0486695231", "user4", true },
                    { 5, "Cần Thơ", "Nga@gmail.com.vn", "Nguyễn Trần Kim Nga", "12345", true, "0462578910", "user5", true },
                    { 6, "Cần Thơ", "Linh@gmail.com.vn", "Lưu Mỹ Linh", "12345", false, "0976937303", "user6", true },
                    { 7, "Cần Thơ", "Ngan@gmail.com.vn", "Hồ Trung Ngân", "12345", false, "0435108713", "user7", true },
                    { 8, "Cần Thơ", "Hao@cpm.ebc.cit", "Trần Nguyễn Thanh Hảo", "12345", true, "0821802554", "user8", true },
                    { 9, "Cần Thơ", "Gia@cpm.ebc.cit", "Ngô Gia", "12345", false, "0292595095", "user9", true },
                    { 10, "Cần Thơ", "Ha@yahoo.com", "Vi Mỹ Hà", "12345", false, "0617426056", "user10", true },
                    { 11, "Cần Thơ", "Lan@gmail.com.vn", "Vi Minh Lan", "12345", false, "0832714516", "user11", true },
                    { 12, "Cần Thơ", "Hau@abc.xyz", "Mai Hậu", "12345", true, "0154248463", "user12", true },
                    { 13, "Cần Thơ", "Binh@gmail.com", "Ngô Huỳnh Bình", "12345", false, "0215600590", "user13", true },
                    { 39, "Cần Thơ", "Hien@yahoo.com", "Lê Văn Hoàng Hiền", "12345", true, "0268072701", "user39", true },
                    { 15, "Cần Thơ", "Dao@gmail.com.vn", "Lê Thanh Dao", "12345", false, "0545362661", "user15", true },
                    { 16, "Cần Thơ", "Bao@gmail.com", "Đỗ Cẩm Bảo", "12345", false, "0309659439", "user16", true },
                    { 17, "Cần Thơ", "Dao@yahoo.com", "Hồ Kim Dao", "12345", false, "0919491248", "user17", true },
                    { 19, "Cần Thơ", "Lan@gmail.com", "Nguyễn Trần Mỹ Lan", "12345", false, "0807155376", "user19", true },
                    { 40, "Cần Thơ", "Hung@yahoo.com", "Trần Nguyễn Thanh Hùng", "12345", true, "0856764439", "user40", true }
                });

            migrationBuilder.InsertData(
                table: "Camera",
                columns: new[] { "IdCam", "AmThanh", "CamBien", "CoDay", "DieuKhiTuXa", "DoPhanGiai", "DoXoayDoc", "DoXoayNgang", "DungLuong", "GiaBan", "GiaGoc", "IdNSX", "KhoangCach", "KhongDay", "MoTa", "SoLuong", "TenCamera", "XuatXu" },
                values: new object[,]
                {
                    { 1, "Đàm thoại 2 chiều", "Báo động khi có người đột nhập.", true, true, "Hình ảnh sắc nét HD - 720p.", 180, 360, "max 64G", 7000000f, 7000000f, 1, "", true, "", 90, "Camera Wifi Không dây Yoosee 3 Râu 720p", "Trung Quốc" },
                    { 19, "Đàm thoại 2 chiều. ️", "1/2 CMOS", true, true, "2.0M Full HD 1080P", 120, 360, "128GB", 1900000f, 1900000f, 6, "10m trong tối", true, "", 65, "Camera Mini IP Vstarcam CB72 1080P 2.0 Sim 4G LTE Giám Sát Hành Trình Ô Tô", "Trung Quốc" },
                    { 15, "Tích hợp micro: nghe đc âm thanh khi xem", "cảnh báo cho người dùng khi có chuyển động", true, true, "2304p x 1296P", 120, 360, "MicroSD (tối đa 256GB)", 5200000f, 5200000f, 6, "20m trong tối", true, "", 97, "Camera IP WIFI trong nhà YooSee New 2020 ( 3 anten Full HD 1080P)", "Trung Quốc" },
                    { 11, "Đàm thoại 2 chiều", "1/2.8\" CMOS", true, true, "1080p", 100, 360, "MicroSD (tối đa 256GB)", 4700000f, 4700000f, 6, "30m trong tối", true, "", 15, "Camera IP Wifi HILook IPC-B120W 1080P", "Trung Quốc" },
                    { 7, "", "1/3\" 3.0 Megapixel", true, true, "20fps@3Mp(2048×1536) & 25/30fps@2.0Mp(1920×1080)", 0, 0, "", 2700000f, 2700000f, 6, "30m", false, "", 97, "Camera KBVISION KX-Y3002N 3.0 megapixel, tầm xa hồng ngoại 30m, cảm biến ngày/đêm, chuẩn IP67", "Trung Quốc" },
                    { 17, "Đàm thoại 2 chiều. ️", "Cảnh báo chuyển động", true, true, "3.0Mpx ️", 120, 355, "128Gb.", 3000000f, 3000000f, 5, "30m trong tối", true, "", 30, "Camera wifi ngoài trời xoay 360 chống nước CARECAM CC8031", "Trung Quốc" },
                    { 9, "Microphone tích hợp", "HD 2.0MPx CMOS", true, true, "", 100, 350, "64GB", 8300000f, 8300000f, 5, "10m", true, "", 62, "CAMERA PTZ NGOÀI TRỜI 2.0 ,KÈM THẺ NHỚ 64G", "Trung Quốc" },
                    { 8, "Trò chuyện hai chiều", "CMOS Quét liên tục 1/4”", true, true, "1080p", 55, 340, "Khe cắm thẻ MicroSD (lên tới 256 GB)", 2200000f, 2200000f, 5, "lên tới 10m/33ft", true, "", 26, "Camera IP Wifi Ezviz C6N 1080p", "Trung Quốc" },
                    { 4, "Đàm thoại 2 chiều nhờ trang bị micro và loa tích hợp", "Gửi thông báo đến bạn ngay khi phát hiện chuyển động.", true, true, "3MP (2048 x 1536)", 180, 360, "MicroSD ≤ 128GB (15-20 ngày)", 3900000f, 3900000f, 5, "30 m trong tối", true, "", 96, "Thông số kỹ thuật Camera IP Ngoài Trời 3MP TP-link Tapo C310 Trắng", "Trung Quốc" },
                    { 21, "Đàm thoại 2 chiều. ️", "Cảnh báo chuyển động", true, true, "FullHD 1080", 120, 360, "Micro SD, Max 256 GB", 5800000f, 5800000f, 4, "10m trong tối", true, "", 77, "Camera IP WIFI IMOU RANGER 2 IPC - A22EP Full HD 1080P", "Trung Quốc" },
                    { 12, "Đàm thoại 2 chiều, khử ồn tốt", "Cảnh báo khi có người đột nhập.", false, true, "1080p", 109, 350, "Micro SD(tối đa 128GB)", 7900000f, 7900000f, 4, "10m trong tối", true, "", 50, "Camera IP không dây Ebitcam EBF4 1080P", "Trung Quốc" },
                    { 24, "Đàm thoại 2 chiều. ️", "Cảnh báo chuyển động", false, true, "FullHD 1080", 90, 0, "Micro SD, Max 256 GB", 7000000f, 7000000f, 6, "10m trong tối", true, "", 4, "Camera ip wifi mini V380 Pro - Hỗ trợ xem hồng ngoại ban đêm", "Trung Quốc" },
                    { 22, "Micro chất lượng cao, đảm bảo âm thanh thu được rõ ràng.", "Cảnh báo chuyển động", true, true, "FullHD 1080", 90, 90, "Micro SD, Max 256 GB", 3300000f, 3300000f, 3, "30m trong tối", true, "", 12, "Camera IP Wifi Ngoài Trời Imou F22FP Bullet 2E Full HD 1080P CÓ MÀU BAN ĐÊM ,KÈM PHÍCH CẮM ÂM", "Trung Quốc" },
                    { 3, "Đàm thoại 2 chiều, tích hợp còi thông báo", "Phát hiển chuyển động", false, true, "2304 × 1296 2K", 180, 360, "MicroSD <= 256GB", 5600000f, 5600000f, 3, "10m trong tối", true, "", 67, "Camera IP Mi Home 360 Độ 2K Pro Xiaomi BHR4193GL", "Trung Quốc" },
                    { 2, "Đàm thoại 2 chiều", "Phát hiển chuyển động", false, true, "Full HD (1080p)", 180, 360, "64 GB", 4900000f, 4900000f, 3, "10m trong tối", true, "", 89, "Camera IP Mi Home 360 Độ 1080P Xiaomi BHR4885GL", "Trung Quốc" },
                    { 23, "Đàm thoại 2 chiều. ️", "1/4 CMOS", false, true, "1080p", 55, 340, "MicroSD (lên tới 256 GB)", 6400000f, 6400000f, 2, "Tầm nhìn ban đêm thông minh với Smart IR (lên tới 10m/33ft.)", true, "", 62, "Camera IP Wifi Ezviz C6N 2MPX", "Trung Quốc" },
                    { 20, "Đàm thoại 2 chiều. ️", "Cảnh báo chuyển động", false, true, "1080p", 120, 360, "MicroSD (hỗ trợ tối thiểu 16GB, tối đa 64GB)", 6300000f, 6300000f, 2, "10m trong tối", true, "", 96, "Camera IP thông minh Xiaomi Mijia Basic 1080p QDJ4047GL", "Trung Quốc" },
                    { 13, "Đàm thoại 2 chiều", "Cảnh báo chuyển động", true, true, "1080p", 110, 95, "MicroSD (tối đa 256GB)", 2800000f, 2800000f, 2, "30m trong tối", true, "", 58, "Camera ip Wifi Ezviz C3WN CS-CV310 1080P ", "Trung Quốc" },
                    { 6, "loa ngoài và micrô tích hợp.", "", true, true, "Full HD 1080p", 0, 0, "MicroSD ≤ 128GB (15-20 ngày)", 8900000f, 8900000f, 2, "9 m trong tối", false, "", 12, "Camera IP 1080P TP-Link Tapo TC60 Trắng", "Trung Quốc" },
                    { 5, "Tính năng Talkback (âm thanh 2 chiều)", "", false, true, "2304 × 1296 2K", 108, 360, "MicroSD ≤ 32GB (4-5 ngày)", 800000f, 800000f, 2, "10 m trong tối", true, "", 99, "Camera IP Mi Home 360 Độ 2K Xiaomi BHR4457GL", "Trung Quốc" },
                    { 16, "Tích hợp micro: nghe đc âm thanh khi xem", "", false, true, "2304P x 1296P - 3.0mpx Siêu nét", 180, 360, "MicroSD (tối đa 256GB)", 7600000f, 7600000f, 1, "30m trong tối", true, "", 80, "Camera YooSee thế hệ mới - 3.0mpx", "Trung Quốc" },
                    { 14, "Đàm thoại 2 chiều", "1/4 CMOS", false, true, "2MP :720P(1280*720)", 110, 360, "Micro SD(tối đa 128GB)", 8500000f, 8500000f, 1, "20m trong tối", true, "", 26, "Camera Ip wifi quay 360 độ cao cấp hãng ORIKON", "Trung Quốc" },
                    { 10, "Đàm thoại 2 chiều", "Cảnh báo khi có người đột nhập.", true, true, "Hình ảnh sắc nét HD – 720p.", 120, 355, "Micro SD(tối đa 128GB)", 9200000f, 9200000f, 1, "10m trong tối", true, "", 20, "Camera Ip Wifi Carecam XF2-200 720p", "Trung Quốc" },
                    { 18, "Đàm thoại 2 chiều. ️", "Phát hiện chuyển động. Báo động qua điện thoại khi kẻ lạ xâm nhập", true, true, "2.0 MP (1920 x 1080P)", 120, 360, "128GB", 1300000f, 1300000f, 3, "10m trong tối", true, "", 32, "Carecam IP Ngoài Tròi 62DK200 ", "Trung Quốc" }
                });

            migrationBuilder.InsertData(
                table: "HoaDon",
                columns: new[] { "IdHD", "GhiChu", "IdTK", "NgayTao", "TongGia", "TrangThai" },
                values: new object[] { 1, "", 1, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123000f, 1 });

            migrationBuilder.InsertData(
                table: "ChiTietHoaDon",
                columns: new[] { "IdCam", "IdHD", "GiaBan", "SoLuongMua" },
                values: new object[] { 1, 1, 123000f, 1 });

            migrationBuilder.InsertData(
                table: "ChiTietKhuyenMai",
                columns: new[] { "IdCam", "IdKM" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "GioHang",
                columns: new[] { "IdCam", "IdTK", "SoLuong" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Hinh",
                columns: new[] { "IdHinh", "HinhDaiDien", "IdCam", "Link" },
                values: new object[] { 1, true, 1, "" });

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
