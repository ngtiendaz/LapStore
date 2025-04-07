--Lưu ý có một số thay đổi về cấu trúc database , user, danh mục, sản phẩm không đổi
-- đổi lại bắt đầu từ giỏ hàng nên xóa mấy cái cũ đi

--Xóa data cũ đi create cái mới cho nhanh

create database projectLap
use projectLap
CREATE TABLE USERS (
    id char(10) PRIMARY KEY,
    hoTen NVARCHAR(255),
    email VARCHAR(255) UNIQUE,
    pass VARCHAR(255),
    diaChi nvarchar(MAX),
    sdt char(10),
    [check] BIT DEFAULT 0,
	hinhAnh NVARCHAR(MAX)
);

CREATE TABLE DANHMUC (
    id char(10) PRIMARY KEY,
    tenDanhMuc NVARCHAR(255)
);

CREATE TABLE SANPHAM (
    maSp char(10) PRIMARY KEY,
    maDm char(10),
    tenSp NVARCHAR(255),
    hinhAnh NVARCHAR(MAX),
    moTa NVARCHAR(MAX),
    giaNhap BIGINT,
    giaBan BIGINT,
    soLuong INT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (maDm) REFERENCES DANHMUC(id),
    CHECK (giaNhap < giaBan)
);
-- xóa mấy bảng GIOHANG, DONHANG, THONGKE cũ đi xong mới add mấy bảng mới này vào
CREATE TABLE GIOHANG (
    id CHAR(10) PRIMARY KEY,
    maUser CHAR(10),
    maSp CHAR(10),
    soLuong INT,
    gia BIGINT,
    FOREIGN KEY (maUser) REFERENCES USERS(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);

-- Bảng DONHANG (Lưu thông tin đơn hàng)
CREATE TABLE DONHANG (
    id CHAR(10) PRIMARY KEY,
    maUser CHAR(10),
    diaChi NVARCHAR(MAX), -- Địa chỉ giao hàng
    tongTien BIGINT,
    phuongThucThanhToan NVARCHAR(50), -- 'Online' hoặc 'Khi nhận hàng'
    trangThai NVARCHAR(50) DEFAULT N'Chờ thanh toán', -- Mặc định là chưa thanh toán
    created_at DATETIME DEFAULT GETDATE(),
	sdt char(10),
    FOREIGN KEY (maUser) REFERENCES USERS(id)
	)
-- Bảng CHITIETDONHANG (Lưu danh sách sản phẩm trong đơn)
CREATE TABLE CHITIETDONHANG (
    id CHAR(10) PRIMARY KEY,
    maDonHang CHAR(10),
    maSp CHAR(10),
    soLuong INT,
    giaBan BIGINT,
    FOREIGN KEY (maDonHang) REFERENCES DONHANG(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);

-- Bảng THONGKE (Chỉ lưu đơn hàng đã thanh toán)
CREATE TABLE THONGKE (
    id CHAR(10) PRIMARY KEY,
    maDonHang CHAR(10),
    maSp CHAR(10),
    soLuong INT,
    doanhThu BIGINT, -- doanhThu = giaBan * soLuong
    loiNhuan BIGINT, -- loiNhuan = (giaBan - giaNhap) * soLuong
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (maDonHang) REFERENCES DONHANG(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);

INSERT INTO DANHMUC(id, tenDanhMuc)
VALUES 
    ('DM001', N'LapTop'),
    ('DM002', N'Màn Hình'),
    ('DM003', N'PC'),
	('DM004', N'Phím'),
    ('DM005', N'Chuột'),
    ('DM006', N'Tai Nghe'),
	('DM007', N'Microphone'),
    ('DM008', N'Loa'),
    ('DM009', N'Webcam'),
	('DM010', N'Máy chơi game'),
    ('DM011', N'Phụ Kiện');
--INSERT INTO SANPHAM (maSp, maDm, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong)
--VALUES 
--('SP001', 'DM001', N'tenSp', 'D:\DataC#\image\anh_o_day', N'moTa', 20000000, 25000000, 15);
INSERT INTO SANPHAM (maSp, maDm, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong)
VALUES 
('SP001', 'DM001', N'Laptop Asus Gaming TUF FX507VU-LP315W (Geforce RTX4050 6GB/i7 13620H/16GB RAM/512GB SSD/15.6 FHD 144hz/Win11/Xám)', 'D:\DataC#\image\84717_laptop_asus_gaming_tuf_fx507vu_lp315w__3_.jpg', N'Bộ vi xử lý: Intel Core i7-13620H
Bộ nhớ: Ram 16GB (2x 8GB) SO-DIMM DDR5 (Tối đa 32GB)
Ổ cứng: 512GB SSD M.2 2280 PCIe 4.0x4 NVMe (Còn trống 1)
VGA: NVIDIA® GeForce RTX™ 4050 6GB
Màn hình: 15.6" FHD (1920 x 1080) IPS, 144Hz, Wide View, 250nits, Narrow Bezel, Non-Glare with 72% NTSC, 100% sRGB, 75.35% Adobe RGB, G-Sync
Màu: Xám
Hệ điều hành: Windows 11 Home', 20000000, 25000000, 15),
('SP002', 'DM001', N'Asus Vivobook 14 OLED A1405VA-KM095W (i5 13500H/16GB RAM/512GB SSD/14 2.8K Oled/Win11/Bạc/Chuột)', 'D:\DataC#\image\71159_ltau870.png', N'CPU: Intel Core i5-13500H (upto 4.7GHz, 18MB)
RAM: 16GB (8GB onboard + 8gb cắm rời)
Ổ cứng: 512GB M.2 NVMe™ PCIe® 3.0
VGA: Intel Iris Xᵉ Graphics
Màn hình: 2.8K (2880 x 1800) OLED 16:10, 90Hz, 100% DCI-P3, 600nits
Màu sắc: Bạc
OS: Windows 11 Home', 10000000, 15000000, 20),
('SP003', 'DM001', N'Hình ảnh chụp
sản phẩm
Video
sản phẩm
Thông số
kỹ thuật
Laptop Apple Macbook Air 13 (MGN63SA/A) (Apple M1/8GB RAM/256GB SSD/13.3 inch IPS/Mac OS/Xám) (NEW)', 'D:\DataC#\image\56561_mba__4_.png', N'CPU: Apple M1
RAM: 8GB
Ổ cứng: 256GB SSD
VGA: Onboard
Màn hình: 13.3 inch Retina IPS
HĐH: Mac OS
Màu: Xám', 10000000, 15000000, 20),
('SP004', 'DM001', N'Laptop Dell Inspiron 3520 (25P2312) (i5 1235U 16GB RAM/512GB SSD/15.6 inch FHD 120Hz/Win11/OfficeHS21/Bạc)', 'D:\DataC#\image\75901_laptop_dell_inspiron_3520__i5_1135g7_8gb_ram512gb_ssd15_6_inch_fhd_120hzubuntub___c___2_.jpg', N'CPU: Intel® Core™ i5 1235U
RAM: 16HB (2x8GB) DDR4 2666 (Tối đa 16GB)
Ổ cứng: 512GB SSD M.2 NVMe (Nâng cấp thay thế)
VGA: Intel Iris Xe Graphics
Màn hình: 15.6inch Full HD 1920 x 1080,IPS 120hz 250nits
Màu: Bạc
OS: Windows 11 Home', 10000000, 15000000, 20),
('SP005', 'DM001', N'Laptop Asus Gaming ROG Strix G614JV-N4369W (i7 13650HX/16GB RAM/1TB SSD/16 WUXGA 240hz/RTX 4060 8GB/Win11/Xám/Balo/Chuột)', 'D:\DataC#\image\88195_laptop_asus_gaming_rog_strix_g614jv_n4369w_i7_13650hx_16gb_ram_1tb_ssd_16_wuxga_240hz_rtx_4060_8gb_win11_xam_balo_chuot.jpg', N'Bộ vi xử lý: CPU Intel Core i7-13650HX (24MB, up to 4.90GHz)
Bộ nhớ: RAM 16GB DDR5-4800 SO-DIMM
Ổ cứng: SSD 1TB PCIe® 4.0 NVMe™ M.2
Card màn hình: VGA NVIDIA® GeForce RTX™ 4060 8GB GDDR6
Màn hình: Display 16inch WUXGA, 16:10, 240Hz, 100% sRGB, IPS, Anti-glare
Pin: 4-cell 90WHrs
RGB Keyboard
Màu sắc: Eclipse Gray (Xám)
Trọng lượng: 2.50 Kg
Hệ điều hành: Windows 11 Home SL', 10000000, 15000000, 20);



--part2 mỗi danh mục 1 sản phẩm
INSERT INTO SANPHAM (maSp, maDm, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong)
VALUES 
('SP012', 'DM002', N'Màn hình LG UltraGear 27GS65F-B (27 inch/FHD/IPS/180Hz/1ms)', 'D:\DataC#\image\mh1.jpg', N'Kích thước: 27 inch
Độ phân giải: FHD 1920 x 1080
Tấm nền: IPS
Tần số quét: 180Hz
Thời gian phản hồi: 1ms
Độ sáng: 300 nits
Tỉ lệ tương phản: 1000:1
Tương thích ngàm VESA: 100 x 100mm
Cổng kết nối: DisplayPort x1, HDMI x1, Audio 3.5mm', 4089000, 4389000, 15),

('SP013', 'DM003', N'PC HACOM AI ULTRA MAX ( CORE ULTRA 285K / VGA RTX 5090 AORUS MASTER / GAMING GEAR/ MONITOR OLED 45" CURVED 240 HZ )', 'D:\DataC#\image\pc1.jpg', N'CPU : Intel CORE ULTRA 285K
MAIN : Z890
RAM : 96GB ( 2x48) DDR5
SSD : 4TB
VGA: NVIDIA RTX 5090
NGUỒN : 1600W
Màn hình LG OLED 45GS95QE-B', 200000000, 249999999, 15),

('SP014', 'DM005', N'Chuột Logitech B100 Black (910-006605) (USB)', 'D:\DataC#\image\chuot1.jpg', N'Chuột Logitech B100
Độ phân giải 800dpi
Kết nối USB
Thiết kế đối xứng, gọn nhẹ
Phù hợp với nhu cầu văn phòng, giải trí nhẹ', 70000, 79000, 15),

('SP015', 'DM006', N'Tai nghe không dây Logitech G535 Lightspeed wireless Black', 'D:\DataC#\image\tainghe1.jpg', N'Tai nghe không dây Logitech G535 Lightspeed
Chuẩn kết nối: LightSpeed Wireless
Thiết kế siêu nhẹ nặng chỉ 236g
Driver 40mm cho âm thanh chi tiết
Micro chất lượng cao được chứng nhận bởi Discord', 2499000, 2999000, 15),

('SP016', 'DM007', N'Microphone ASUS ROG Carnyx Black', 'D:\DataC#\image\mic1.jpg', N'Mang đến âm thanh thực sự phong phú và ấm áp
Cung cấp âm thanh có độ phân giải cao, cực kỳ chi tiết
Giảm tiếng ồn tần số thấp không mong muốn và tăng cường hơn nữa độ rõ của giọng nói
Giảm âm lượng giọng hát
Giảm rung động bên ngoài để ghi âm mượt mà
Điều khiển nhanh chóng, trực quan để ghi âm không bị gián đoạn
Giúp điều chỉnh âm lượng micrô và điều khiển âm thanh của tai nghe giám sát một cách thuận tiện
Tận hưởng khả năng cá nhân hóa và đồng bộ hóa chưa từng có với hệ sinh thái Aura Sync', 4999000, 5699000, 15),

('SP017', 'DM004', N'Bàn phím Corsair K100 RGB Optical switch (OPX-RF) (CH-912A01A-NA)', 'D:\DataC#\image\phim1.jpg', N'Bàn phím Corsair K100 RGB
Bàn phím cao cấp mới nhất đến từ Corsair
Sử dung switch độc quyền CORSAIR OPX optical
Công nghệ mới cho tốc độ truyền tín hiệu nhanh gấp 4 lần các loại phím khác
Trang bị núm xoay đa tác vụ cực kỳ tiện lợi
Thiết kế khung kim loại cực kỳ chắc chắn
Keycap PBT Doubleshot siêu bền
Tích hợp 6 phím macro truy cập nhanh ứng dung của Elgato Stream Deck
Đi kèm kê tay nam châm tiện lợi', 4899000, 6549000, 15),

('SP018', 'DM008', N'Loa di động JBL CHARGE 5 - Màu xanh dương', 'D:\DataC#\image\loa1.jpg', N'Thời lượng pin: 20 giờ
Thời gian sạc: 4 giờ
Cổng sạc: Type C
Công suất: 40W
Chống nước: IP67 (Bụi bẩn,nước bắn)
Tính năng khác: Sạc cho thiết bị khác qua cổng USB
Karaoke Mic có hỗ trợ Bluetooth
Số loa kết nối cùng lúc 2 loa có hỗ trợ PartyBoost
Bluetooth: 5.1
Ứng dụng điều khiển: JBL Portable
Điều khiển: Nút bấm
Thông số kỹ thuật
Cổng sạc vào: USB-A
Pin: Sử dụng lên đến 20 giờ
Dung lượng Pin: 7500mAh
Chống nước: IP67
Giao tiếp & kết nối: Bluetooth 5.1', 3699000, 3990000, 15),


('SP019', 'DM009', N'Webcam hội nghị truyền hình Logitech Meetup', 'D:\DataC#\image\web1.png', N'Camera hội nghị với tầm quan sát 120 độ và công nghệ quang học 4K
Trường ngắm siêu rộng 120°
3 micrô & loa tùy chỉnh
Cảm biến hình ảnh Ultra HD 4K
Thiết kế tất cả trong một', 10000000, 16399000, 15),


('SP020', 'DM010', N'Máy Chơi Game Sony Playstation 5 (PS5) Slim Console – 30th Anniversary Limited Edition', 'D:\DataC#\image\game1.jpg', N'Máy Chơi Game Sony Playstation 5 (PS5) Slim Console – 30th Anniversary Limited Edition
Phiên bản giới hạn kỷ niệm 30 năm ngày phát hành sản phẩm Playstation đầu tiên
Phiên bản máy chơi game PS5 mới với kích thước nhỏ gọn hơn phiên bản đầu tiên
Phần vỏ máy chia làm 4 phần có thể tháo rời
Trang bị SSD tốc độ cực cao tăng khả năng load game nhanh hơn - Dung lượng 1Tb
Tích hợp tính năng Ray Tracing cho đồ hoạ game chân thực hơn bao giờ hết
Hỗ trợ game có thể lên đến 120Fps với đầu ra tần số quét 120Hz với độ phân giải 4K
PlayStation 5 hỗ trợ độ phân giải 8K, người dùng có thể chơi game với độ phân giải 4320p
Phiên bản Digital không có ổ đĩa phù hợp với những người thích mua game qua cửa hàng trực tuyến của Sony
Thiết kế có thể tháo rời ổ đĩa Blue-ray
Có thể chơi được cả các game của hệ máy PS4
*Lưu ý: Máy không kèm chân đế dựng máy như trong hình', 15999000, 16999000, 15),


('SP021', 'DM011', N'Fan Case Tản Nhiệt NZXT F120RGB Duo Black(Triple)', 'D:\DataC#\image\pk1.jpg', N'Anh sáng RGB rực rỡ từ mọi góc độ với 20 đèn LED có thể tùy chỉnh
Thiết kế cánh quạt mang lại sự cân bằng tối ưu giữa luồng không khí và áp suất tĩnh cao, phù hợp để lắp ở nhiều vị trí khác nhau
Trục bi chất lỏng (FDB) đảm bảo hoạt động trơn tru và yên tĩnh với tuổi thọ cao
Cao su ở các góc giảm tiếng ồn và rung khi ử dụng
Có thể kết hợp sử dụng với quạt NZXT F120/F140 RGB
Cá nhân hóa hiệu ứng ánh sáng RGB và điều chỉnh quạt thông qua NZXT CAM
Kích thước 120mm
Bộ sản phẩm gồm 3 quạt tản nhiệt', 2000000, 2599000, 15);




INSERT INTO USERS (id, hoTen, email, pass, diaChi, sdt, [check], hinhAnh)  
VALUES ('1', N'Daz', 'user@gmail.com', '123456', N'Hà Nội', '0987654321', 1, N'D:\DataC#\image\daz.jpg');
INSERT INTO USERS (id, hoTen, email, pass, diaChi, sdt, [check], hinhAnh)  
VALUES ('2', N'Daz', 'admin@gmail.com', '123456', N'Hà Nội', '0987654321', 0, N'D:\DataC#\image\daz.jpg');

