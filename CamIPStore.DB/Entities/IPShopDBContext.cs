using Microsoft.EntityFrameworkCore;
using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class IPShopDBContext : DbContext
    {
        public IPShopDBContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NhaSanXuatConfig());
            modelBuilder.ApplyConfiguration(new CameraConfig());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonConfig());
            modelBuilder.ApplyConfiguration(new ChiTietKhuyenMaiConfig());
            modelBuilder.ApplyConfiguration(new GioHangConfig());
            modelBuilder.ApplyConfiguration(new HinhConfig());
            modelBuilder.ApplyConfiguration(new HoaDonConfig());
            modelBuilder.ApplyConfiguration(new KhuyenMaiConfig());
            modelBuilder.ApplyConfiguration(new TaiKhoanConfig());

            modelBuilder.Entity<NhaSanXuat>().HasData(
                new NhaSanXuat() { IdNSX = 1, TenNSX = "Xiaomi" },
                new NhaSanXuat() { IdNSX = 2, TenNSX = "TP-Link" },
                new NhaSanXuat() { IdNSX = 3, TenNSX = "EZVIZ - HIKVISION" },
                new NhaSanXuat() { IdNSX = 4, TenNSX = "Kbvision" },
                new NhaSanXuat() { IdNSX = 5, TenNSX = "Yoosee" },
                new NhaSanXuat() { IdNSX = 6, TenNSX = "CareCam" }
                );
            modelBuilder.Entity<TaiKhoan>().HasData(
                new TaiKhoan() { IdTK=1, TenTK="user1",MatKhau="12345",SDT="0253737775",DiaChi="Cần Thơ",Email="Hieu@gmail.com",HoTen="Trần Nguyễn Minh Hiếu",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=2,TenTK="user2",MatKhau="12345",SDT="0162332975",DiaChi="Cần Thơ",Email="Binh@abc.xyz",HoTen="Ngô Minh Bình",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=3,TenTK="user3",MatKhau="12345",SDT="0940895982",DiaChi="Cần Thơ",Email="Nga@cpm.ebc.cit",HoTen="Huỳnh Thảo Nga",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=4,TenTK="user4",MatKhau="12345",SDT="0486695231",DiaChi="Cần Thơ",Email="Duong@gmail.com",HoTen="Lưu Tường Dương",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=5,TenTK="user5",MatKhau="12345",SDT="0462578910",DiaChi="Cần Thơ",Email="Nga@gmail.com.vn",HoTen="Nguyễn Trần Kim Nga",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=6,TenTK="user6",MatKhau="12345",SDT="0976937303",DiaChi="Cần Thơ",Email="Linh@gmail.com.vn",HoTen="Lưu Mỹ Linh",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=7,TenTK="user7",MatKhau="12345",SDT="0435108713",DiaChi="Cần Thơ",Email="Ngan@gmail.com.vn",HoTen="Hồ Trung Ngân",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=8,TenTK="user8",MatKhau="12345",SDT="0821802554",DiaChi="Cần Thơ",Email="Hao@cpm.ebc.cit",HoTen="Trần Nguyễn Thanh Hảo",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=9,TenTK="user9",MatKhau="12345",SDT="0292595095",DiaChi="Cần Thơ",Email="Gia@cpm.ebc.cit",HoTen="Ngô Gia",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=10,TenTK="user10",MatKhau="12345",SDT="0617426056",DiaChi="Cần Thơ",Email="Ha@yahoo.com",HoTen="Vi Mỹ Hà",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=11,TenTK="user11",MatKhau="12345",SDT="0832714516",DiaChi="Cần Thơ",Email="Lan@gmail.com.vn",HoTen="Vi Minh Lan",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=12,TenTK="user12",MatKhau="12345",SDT="0154248463",DiaChi="Cần Thơ",Email="Hau@abc.xyz",HoTen="Mai Hậu",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=13,TenTK="user13",MatKhau="12345",SDT="0215600590",DiaChi="Cần Thơ",Email="Binh@gmail.com",HoTen="Ngô Huỳnh Bình",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=14,TenTK="user14",MatKhau="12345",SDT="0871156817",DiaChi="Cần Thơ",Email="Dao@gmail.com.vn",HoTen="Mai Minh Dao",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=15,TenTK="user15",MatKhau="12345",SDT="0545362661",DiaChi="Cần Thơ",Email="Dao@gmail.com.vn",HoTen="Lê Thanh Dao",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=16,TenTK="user16",MatKhau="12345",SDT="0309659439",DiaChi="Cần Thơ",Email="Bao@gmail.com",HoTen="Đỗ Cẩm Bảo",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=17,TenTK="user17",MatKhau="12345",SDT="0919491248",DiaChi="Cần Thơ",Email="Dao@yahoo.com",HoTen="Hồ Kim Dao",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=18,TenTK="user18",MatKhau="12345",SDT="0986292715",DiaChi="Cần Thơ",Email="Cong@abc.xyz",HoTen="Trần Minh Công",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=19,TenTK="user19",MatKhau="12345",SDT="0807155376",DiaChi="Cần Thơ",Email="Lan@gmail.com",HoTen="Nguyễn Trần Mỹ Lan",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=20,TenTK="user20",MatKhau="12345",SDT="0176530779",DiaChi="Cần Thơ",Email="Ngoc@cpm.ebc.cit",HoTen="Huỳnh Trung Ngọc",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=21,TenTK="user21",MatKhau="12345",SDT="0696679759",DiaChi="Cần Thơ",Email="Dat@yahoo.com",HoTen="Trần Nguyễn Huỳnh Đạt",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=22,TenTK="user22",MatKhau="12345",SDT="0699527986",DiaChi="Cần Thơ",Email="Hau@yahoo.com",HoTen="Nguyễn Phúc Thảo Hậu",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=23,TenTK="user23",MatKhau="12345",SDT="0882101189",DiaChi="Cần Thơ",Email="Dat@gmail.com",HoTen="Ngô Đạt",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=24,TenTK="user24",MatKhau="12345",SDT="0674060358",DiaChi="Cần Thơ",Email="An@abc.xyz",HoTen="Hồ Thị Tường An",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=25,TenTK="user25",MatKhau="12345",SDT="0355909778",DiaChi="Cần Thơ",Email="Manh@yahoo.com",HoTen="Mai Cẩm Mạnh",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=26,TenTK="user26",MatKhau="12345",SDT="0550851297",DiaChi="Cần Thơ",Email="Hau@yahoo.com",HoTen="Huỳnh Kim Hậu",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=27,TenTK="user27",MatKhau="12345",SDT="0549183731",DiaChi="Cần Thơ",Email="Hoa@yahoo.com",HoTen="Lưu Hoàng Hóa",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=28,TenTK="user28",MatKhau="12345",SDT="0312991267",DiaChi="Cần Thơ",Email="Binh@cpm.ebc.cit",HoTen="Trần Nguyễn Tường Bình",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=29,TenTK="user29",MatKhau="12345",SDT="0594100321",DiaChi="Cần Thơ",Email="Hanh@cpm.ebc.cit",HoTen="Lưu Hạnh",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=30,TenTK="user30",MatKhau="12345",SDT="0567477781",DiaChi="Cần Thơ",Email="Du@cpm.ebc.cit",HoTen="Lê Minh Du",QuyenSD=false,TrangThai=true},
                new TaiKhoan() { IdTK=31,TenTK="user31",MatKhau="12345",SDT="0457173781",DiaChi="Cần Thơ",Email="Gia@abc.xyz",HoTen="Nguyễn Trần Gia",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=32,TenTK="user32",MatKhau="12345",SDT="0120750995",DiaChi="Cần Thơ",Email="Ngan@gmail.com",HoTen="Nguyễn Trần Mộng Ngân",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=33,TenTK="user33",MatKhau="12345",SDT="0730168885",DiaChi="Cần Thơ",Email="Long@gmail.com",HoTen="Đỗ Trung Long",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=34,TenTK="user34",MatKhau="12345",SDT="0374077585",DiaChi="Cần Thơ",Email="Hanh@cpm.ebc.cit",HoTen="Dương Trung Hạnh",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=35,TenTK="user35",MatKhau="12345",SDT="0903639096",DiaChi="Cần Thơ",Email="Nga@yahoo.com",HoTen="Vi Trung Nga",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=36,TenTK="user36",MatKhau="12345",SDT="0146865028",DiaChi="Cần Thơ",Email="Manh@yahoo.com",HoTen="Nguyễn Trần Mộng Mạnh",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=37,TenTK="user37",MatKhau="12345",SDT="0418281298",DiaChi="Cần Thơ",Email="Duong@cpm.ebc.cit",HoTen="Nguyễn Phúc Cẩm Dương",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=38,TenTK="user38",MatKhau="12345",SDT="0295945376",DiaChi="Cần Thơ",Email="Hau@yahoo.com",HoTen="Nguyễn Trần Trung Hậu",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=39,TenTK="user39",MatKhau="12345",SDT="0268072701",DiaChi="Cần Thơ",Email="Hien@yahoo.com",HoTen="Lê Văn Hoàng Hiền",QuyenSD=true,TrangThai=true},
                new TaiKhoan() { IdTK=40,TenTK="user40",MatKhau="12345",SDT="0856764439",DiaChi="Cần Thơ",Email="Hung@yahoo.com",HoTen="Trần Nguyễn Thanh Hùng",QuyenSD=true,TrangThai=true}
                );
            modelBuilder.Entity<Camera>().HasData(
                new Camera() { IdCam=1,IdNSX=1,Ten="Camera Wifi Không dây Yoosee 3 Râu 720p",XuatXu="Trung Quốc",CamBien="Báo động khi có người đột nhập.",AmThanh="Đàm thoại 2 chiều",DoPhanGiai="Hình ảnh sắc nét HD - 720p.",DungLuong="max 64G",KhoangCach="",DoXoayNgang=360,DoXoayDoc=180,SoLuong=90,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=7000000,GiaBan=7000000, MoTa=""},
                new Camera() { IdCam=2,IdNSX=3,Ten="Camera IP Mi Home 360 Độ 1080P Xiaomi BHR4885GL",XuatXu="Trung Quốc",CamBien="Phát hiển chuyển động",AmThanh="Đàm thoại 2 chiều",DoPhanGiai="Full HD (1080p)",DungLuong="64 GB",KhoangCach="10m trong tối",DoXoayNgang=360,DoXoayDoc=180,SoLuong=89,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=4900000,GiaBan=4900000, MoTa=""},
                new Camera() { IdCam=3,IdNSX=3,Ten="Camera IP Mi Home 360 Độ 2K Pro Xiaomi BHR4193GL",XuatXu="Trung Quốc",CamBien="Phát hiển chuyển động",AmThanh="Đàm thoại 2 chiều, tích hợp còi thông báo",DoPhanGiai="2304 × 1296 2K",DungLuong="MicroSD <= 256GB",KhoangCach="10m trong tối",DoXoayNgang=360,DoXoayDoc=180,SoLuong=67,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=5600000,GiaBan=5600000, MoTa=""},
                new Camera() { IdCam=4,IdNSX=5,Ten="Thông số kỹ thuật Camera IP Ngoài Trời 3MP TP-link Tapo C310 Trắng",XuatXu="Trung Quốc",CamBien="Gửi thông báo đến bạn ngay khi phát hiện chuyển động.",AmThanh="Đàm thoại 2 chiều nhờ trang bị micro và loa tích hợp",DoPhanGiai="3MP (2048 x 1536)",DungLuong="MicroSD ≤ 128GB (15-20 ngày)",KhoangCach="30 m trong tối",DoXoayNgang=360,DoXoayDoc=180,SoLuong=96,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=3900000,GiaBan=3900000, MoTa=""},
                new Camera() { IdCam=5,IdNSX=2,Ten="Camera IP Mi Home 360 Độ 2K Xiaomi BHR4457GL",XuatXu="Trung Quốc",CamBien="",AmThanh="Tính năng Talkback (âm thanh 2 chiều)",DoPhanGiai="2304 × 1296 2K",DungLuong="MicroSD ≤ 32GB (4-5 ngày)",KhoangCach="10 m trong tối",DoXoayNgang=360,DoXoayDoc=108,SoLuong=99,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=800000,GiaBan=800000, MoTa=""},
                new Camera() { IdCam=6,IdNSX=2,Ten="Camera IP 1080P TP-Link Tapo TC60 Trắng",XuatXu="Trung Quốc",CamBien="",AmThanh="loa ngoài và micrô tích hợp.",DoPhanGiai="Full HD 1080p",DungLuong="MicroSD ≤ 128GB (15-20 ngày)",KhoangCach="9 m trong tối",DoXoayNgang=0,DoXoayDoc=0,SoLuong=12,KhongDay=false,CoDay=true,DKTuXa=true,GiaGoc=8900000,GiaBan=8900000, MoTa=""},
                new Camera() { IdCam=7,IdNSX=6,Ten="Camera KBVISION KX-Y3002N 3.0 megapixel, tầm xa hồng ngoại 30m, cảm biến ngày/đêm, chuẩn IP67",XuatXu="Trung Quốc",CamBien="1/3\" 3.0 Megapixel",AmThanh="",DoPhanGiai="20fps@3Mp(2048×1536) & 25/30fps@2.0Mp(1920×1080)",DungLuong="",KhoangCach="30m",DoXoayNgang=0,DoXoayDoc=0,SoLuong=97,KhongDay=false,CoDay=true,DKTuXa=true,GiaGoc=2700000,GiaBan=2700000, MoTa=""},
                new Camera() { IdCam=8,IdNSX=5,Ten="Camera IP Wifi Ezviz C6N 1080p",XuatXu="Trung Quốc",CamBien="CMOS Quét liên tục 1/4”",AmThanh="Trò chuyện hai chiều",DoPhanGiai="1080p",DungLuong="Khe cắm thẻ MicroSD (lên tới 256 GB)",KhoangCach="lên tới 10m/33ft",DoXoayNgang=340,DoXoayDoc=55,SoLuong=26,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=2200000,GiaBan=2200000, MoTa=""},
                new Camera() { IdCam=9,IdNSX=5,Ten="CAMERA PTZ NGOÀI TRỜI 2.0 ,KÈM THẺ NHỚ 64G",XuatXu="Trung Quốc",CamBien="HD 2.0MPx CMOS",AmThanh="Microphone tích hợp",DoPhanGiai="",DungLuong="64GB",KhoangCach="10m",DoXoayNgang=350,DoXoayDoc=100,SoLuong=62,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=8300000,GiaBan=8300000, MoTa=""},
                new Camera() { IdCam=10,IdNSX=1,Ten="Camera Ip Wifi Carecam XF2-200 720p",XuatXu="Trung Quốc",CamBien="Cảnh báo khi có người đột nhập.",AmThanh="Đàm thoại 2 chiều",DoPhanGiai="Hình ảnh sắc nét HD – 720p.",DungLuong="Micro SD(tối đa 128GB)",KhoangCach="10m trong tối",DoXoayNgang=355,DoXoayDoc=120,SoLuong=20,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=9200000,GiaBan=9200000, MoTa=""},
                new Camera() { IdCam=11,IdNSX=6,Ten="Camera IP Wifi HILook IPC-B120W 1080P",XuatXu="Trung Quốc",CamBien="1/2.8\" CMOS",AmThanh="Đàm thoại 2 chiều",DoPhanGiai="1080p",DungLuong="MicroSD (tối đa 256GB)",KhoangCach="30m trong tối",DoXoayNgang=360,DoXoayDoc=100,SoLuong=15,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=4700000,GiaBan=4700000, MoTa=""},
                new Camera() { IdCam=12,IdNSX=4,Ten="Camera IP không dây Ebitcam EBF4 1080P",XuatXu="Trung Quốc",CamBien="Cảnh báo khi có người đột nhập.",AmThanh="Đàm thoại 2 chiều, khử ồn tốt",DoPhanGiai="1080p",DungLuong="Micro SD(tối đa 128GB)",KhoangCach="10m trong tối",DoXoayNgang=350,DoXoayDoc=109,SoLuong=50,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=7900000,GiaBan=7900000, MoTa=""},
                new Camera() { IdCam=13,IdNSX=2,Ten="Camera ip Wifi Ezviz C3WN CS-CV310 1080P ",XuatXu="Trung Quốc",CamBien="Cảnh báo chuyển động",AmThanh="Đàm thoại 2 chiều",DoPhanGiai="1080p",DungLuong="MicroSD (tối đa 256GB)",KhoangCach="30m trong tối",DoXoayNgang=95,DoXoayDoc=110,SoLuong=58,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=2800000,GiaBan=2800000, MoTa=""},
                new Camera() { IdCam=14,IdNSX=1,Ten="Camera Ip wifi quay 360 độ cao cấp hãng ORIKON",XuatXu="Trung Quốc",CamBien="1/4 CMOS",AmThanh="Đàm thoại 2 chiều",DoPhanGiai="2MP :720P(1280*720)",DungLuong="Micro SD(tối đa 128GB)",KhoangCach="20m trong tối",DoXoayNgang=360,DoXoayDoc=110,SoLuong=26,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=8500000,GiaBan=8500000, MoTa=""},
                new Camera() { IdCam=15,IdNSX=6,Ten="Camera IP WIFI trong nhà YooSee New 2020 ( 3 anten Full HD 1080P)",XuatXu="Trung Quốc",CamBien="cảnh báo cho người dùng khi có chuyển động",AmThanh="Tích hợp micro: nghe đc âm thanh khi xem",DoPhanGiai="2304p x 1296P",DungLuong="MicroSD (tối đa 256GB)",KhoangCach="20m trong tối",DoXoayNgang=360,DoXoayDoc=120,SoLuong=97,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=5200000,GiaBan=5200000, MoTa=""},
                new Camera() { IdCam=16,IdNSX=1,Ten="Camera YooSee thế hệ mới - 3.0mpx",XuatXu="Trung Quốc",CamBien="",AmThanh="Tích hợp micro: nghe đc âm thanh khi xem",DoPhanGiai="2304P x 1296P - 3.0mpx Siêu nét",DungLuong="MicroSD (tối đa 256GB)",KhoangCach="30m trong tối",DoXoayNgang=360,DoXoayDoc=180,SoLuong=80,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=7600000,GiaBan=7600000, MoTa=""},
                new Camera() { IdCam=17,IdNSX=5,Ten="Camera wifi ngoài trời xoay 360 chống nước CARECAM CC8031",XuatXu="Trung Quốc",CamBien="Cảnh báo chuyển động",AmThanh="Đàm thoại 2 chiều. ️",DoPhanGiai="3.0Mpx ️",DungLuong="128Gb.",KhoangCach="30m trong tối",DoXoayNgang=355,DoXoayDoc=120,SoLuong=30,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=3000000,GiaBan=3000000, MoTa=""},
                new Camera() { IdCam=18,IdNSX=3,Ten="Carecam IP Ngoài Tròi 62DK200 ",XuatXu="Trung Quốc",CamBien="Phát hiện chuyển động. Báo động qua điện thoại khi kẻ lạ xâm nhập",AmThanh="Đàm thoại 2 chiều. ️",DoPhanGiai="2.0 MP (1920 x 1080P)",DungLuong="128GB",KhoangCach="10m trong tối",DoXoayNgang=360,DoXoayDoc=120,SoLuong=32,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=1300000,GiaBan=1300000, MoTa=""},
                new Camera() { IdCam=19,IdNSX=6,Ten="Camera Mini IP Vstarcam CB72 1080P 2.0 Sim 4G LTE Giám Sát Hành Trình Ô Tô",XuatXu="Trung Quốc",CamBien="1/2 CMOS",AmThanh="Đàm thoại 2 chiều. ️",DoPhanGiai="2.0M Full HD 1080P",DungLuong="128GB",KhoangCach="10m trong tối",DoXoayNgang=360,DoXoayDoc=120,SoLuong=65,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=1900000,GiaBan=1900000, MoTa=""},
                new Camera() { IdCam=20,IdNSX=2,Ten="Camera IP thông minh Xiaomi Mijia Basic 1080p QDJ4047GL",XuatXu="Trung Quốc",CamBien="Cảnh báo chuyển động",AmThanh="Đàm thoại 2 chiều. ️",DoPhanGiai="1080p",DungLuong="MicroSD (hỗ trợ tối thiểu 16GB, tối đa 64GB)",KhoangCach="10m trong tối",DoXoayNgang=360,DoXoayDoc=120,SoLuong=96,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=6300000,GiaBan=6300000, MoTa=""},
                new Camera() { IdCam=21,IdNSX=4,Ten="Camera IP WIFI IMOU RANGER 2 IPC - A22EP Full HD 1080P",XuatXu="Trung Quốc",CamBien="Cảnh báo chuyển động",AmThanh="Đàm thoại 2 chiều. ️",DoPhanGiai="FullHD 1080",DungLuong="Micro SD, Max 256 GB",KhoangCach="10m trong tối",DoXoayNgang=360,DoXoayDoc=120,SoLuong=77,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=5800000,GiaBan=5800000, MoTa=""},
                new Camera() { IdCam=22,IdNSX=3,Ten="Camera IP Wifi Ngoài Trời Imou F22FP Bullet 2E Full HD 1080P CÓ MÀU BAN ĐÊM ,KÈM PHÍCH CẮM ÂM",XuatXu="Trung Quốc",CamBien="Cảnh báo chuyển động",AmThanh="Micro chất lượng cao, đảm bảo âm thanh thu được rõ ràng.",DoPhanGiai="FullHD 1080",DungLuong="Micro SD, Max 256 GB",KhoangCach="30m trong tối",DoXoayNgang=90,DoXoayDoc=90,SoLuong=12,KhongDay=true,CoDay=true,DKTuXa=true,GiaGoc=3300000,GiaBan=3300000, MoTa=""},
                new Camera() { IdCam=23,IdNSX=2,Ten="Camera IP Wifi Ezviz C6N 2MPX",XuatXu="Trung Quốc",CamBien="1/4 CMOS",AmThanh="Đàm thoại 2 chiều. ️",DoPhanGiai="1080p",DungLuong="MicroSD (lên tới 256 GB)",KhoangCach="Tầm nhìn ban đêm thông minh với Smart IR (lên tới 10m/33ft.)",DoXoayNgang=340,DoXoayDoc=55,SoLuong=62,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=6400000,GiaBan=6400000, MoTa=""},
                new Camera() { IdCam=24,IdNSX=6,Ten="Camera ip wifi mini V380 Pro - Hỗ trợ xem hồng ngoại ban đêm",XuatXu="Trung Quốc",CamBien="Cảnh báo chuyển động",AmThanh="Đàm thoại 2 chiều. ️",DoPhanGiai="FullHD 1080",DungLuong="Micro SD, Max 256 GB",KhoangCach="10m trong tối",DoXoayNgang=0,DoXoayDoc=90,SoLuong=4,KhongDay=true,CoDay=false,DKTuXa=true,GiaGoc=7000000,GiaBan=7000000, MoTa=""}
                );
            modelBuilder.Entity<KhuyenMai>().HasData(
                new KhuyenMai() { IdKM=1,TenKM="Flash Sale cuối tuần",PhanTramGiam=25,TuNgay = new DateTime(2021,5,26),DenNgay= new DateTime(2021,6,15),Banner=""},
                new KhuyenMai() { IdKM=2,TenKM="Tháng 6 Vui Vẻ",PhanTramGiam=25,TuNgay = new DateTime(2021,06,09),DenNgay= new DateTime(2021,06,27),Banner=""},
                new KhuyenMai() { IdKM=3,TenKM="Khai trương",PhanTramGiam=45,TuNgay = new DateTime(2021,07,01),DenNgay= new DateTime(2021,07,16),Banner=""},
                new KhuyenMai() { IdKM=4,TenKM="Ưu đãi khách mới",PhanTramGiam=25,TuNgay = new DateTime(2021,05,24),DenNgay= new DateTime(2021,06,16),Banner=""},
                new KhuyenMai() { IdKM=5,TenKM="Ưu đãi tân sinh viên",PhanTramGiam=15,TuNgay = new DateTime(2021,06,03),DenNgay= new DateTime(2021,07,02),Banner=""},
                new KhuyenMai() { IdKM=6,TenKM="Sinh nhật vui vẻ",PhanTramGiam=25,TuNgay = new DateTime(2021,05,31),DenNgay= new DateTime(2021,06,20),Banner=""}
                );
            modelBuilder.Entity<Hinh>().HasData(
                new Hinh() { IdHinh=1, IdCam=1, HinhDaiDien=true, Link=""}
                );
            modelBuilder.Entity<HoaDon>().HasData(
                new HoaDon() { IdHD = 1, IdTK=1, NgayTao = new DateTime(2021, 5, 1), TongGia=123000, GhiChu="", TrangThai=1}
                );
            modelBuilder.Entity<ChiTietHoaDon>().HasData(
                new ChiTietHoaDon() { IdHD=1, IdCam=1, SLMua=1, GiaBan=123000}
                );
            modelBuilder.Entity<GioHang>().HasData(
                new GioHang() { IdTK=1, IdCam=1, Sl=1}
                );
            modelBuilder.Entity<ChiTietKhuyenMai>().HasData(
                new ChiTietKhuyenMai() { IdCam = 1, IdKM = 1}
                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<ChiTietKhuyenMai> ChiTietKhuyenMai { get; set; }
        public DbSet<GioHang> GioHang { get; set; }
        public DbSet<Hinh> Hinh { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<KhuyenMai> KhuyenMai { get; set; }
        public DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
    }
         
}
