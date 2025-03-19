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

CREATE TABLE GIOHANG (
    id char(10) PRIMARY KEY,
    maUser char(10),
    maSp char(10),
    soLuong INT,
    gia BIGINT,
    FOREIGN KEY (maUser) REFERENCES USERS(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);

CREATE TABLE YEUTHICH (
    id char(10) PRIMARY KEY,
    maUser char(10),
    maSp char(10),
    UNIQUE (maUser, maSp),
    FOREIGN KEY (maUser) REFERENCES USERS(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);

CREATE TABLE DONHANG (
    id char(10) PRIMARY KEY,
    maUser char(10),
    tongTien BIGINT,
	 created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (maUser) REFERENCES USERS(id),
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






