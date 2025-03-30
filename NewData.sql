CREATE DATABASE projectLap;
USE projectLap;

-- B?ng USERS (Kh�ng thay ??i)
CREATE TABLE USERS (
    id CHAR(10) PRIMARY KEY,
    hoTen NVARCHAR(255),
    email VARCHAR(255) UNIQUE,
    pass VARCHAR(255),
    diaChi NVARCHAR(MAX),
    sdt CHAR(10),
    [check] BIT DEFAULT 0,
    hinhAnh NVARCHAR(MAX)
);

-- B?ng DANHMUC (Kh�ng thay ??i)
CREATE TABLE DANHMUC (
    id CHAR(10) PRIMARY KEY,
    tenDanhMuc NVARCHAR(255)
);

-- B?ng SANPHAM (Kh�ng thay ??i)
CREATE TABLE SANPHAM (
    maSp CHAR(10) PRIMARY KEY,
    maDm CHAR(10),
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

-- B?ng GIOHANG (L?u gi? h�ng c?a t?ng ng??i d�ng, c� th? ch?a nhi?u s?n ph?m)
CREATE TABLE GIOHANG (
    id CHAR(10) PRIMARY KEY,
    maUser CHAR(10),
    maSp CHAR(10),
    soLuong INT,
    gia BIGINT,
    FOREIGN KEY (maUser) REFERENCES USERS(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);

-- B?ng DONHANG (Ch?a th�ng tin chung v? ??n h�ng)
CREATE TABLE DONHANG (
    id CHAR(10) PRIMARY KEY,
    maUser CHAR(10),
    tongTien BIGINT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (maUser) REFERENCES USERS(id)
);

-- B?ng CHITIETDONHANG (L?u chi ti?t t?ng s?n ph?m trong ??n h�ng)
CREATE TABLE CHITIETDONHANG (
    id CHAR(10) PRIMARY KEY,
    maDonHang CHAR(10),
    maSp CHAR(10),
    soLuong INT,
    giaBan BIGINT,
    FOREIGN KEY (maDonHang) REFERENCES DONHANG(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);

-- B?ng THONGKE (L?u doanh thu & l?i nhu?n t? c�c ??n h�ng)
CREATE TABLE THONGKE (
    id CHAR(10) PRIMARY KEY,
    maDonHang CHAR(10),
    maSp CHAR(10),
    soLuong INT,
    doanhThu BIGINT,
    loiNhuan BIGINT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (maDonHang) REFERENCES DONHANG(id),
    FOREIGN KEY (maSp) REFERENCES SANPHAM(maSp)
);
