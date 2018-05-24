
CREATE DATABASE QuanLyBanLaptop
GO 
USE QuanLyBanLaptop

GO 
CREATE TABLE LoaiLaptop(
	MaLoaiLaptop VARCHAR(15) PRIMARY KEY,
	TenLoaiLaptop NVARCHAR(50)
)

GO
CREATE TABLE NhaCungCap(
	MaNhaCungCap VARCHAR(15) PRIMARY KEY,
	TenNhaCungCap NVARCHAR(50),
	DiaChi NVARCHAR(50),
	SDT VARCHAR(20)
)

GO 
CREATE TABLE Laptop(
	MaLaptop VARCHAR(15) PRIMARY KEY,
	TenLaptop NVARCHAR(50),
	MaLoaiLaptop VARCHAR(15) FOREIGN KEY REFERENCES dbo.LoaiLaptop(MaLoaiLaptop),
	Gia INT ,
	SoLuong INT ,
	Anh VARCHAR(50),
	MaNhaCungCap VARCHAR(15) FOREIGN KEY REFERENCES dbo.NhaCungCap(MaNhaCungCap),
	Mota NVARCHAR(50)
)

GO 
CREATE TABLE KhachHang
(
	MaKhachHang VARCHAR(15) PRIMARY KEY ,
	TenKhachHang NVARCHAR(50),
	Tuoi INT ,
	GioiTinh NVARCHAR(5) CHECK (GioiTinh IN (N'Nam',N'Nữ')),
	SDT VARCHAR(20),
	DiaChi NVARCHAR(50),
	Email VARCHAR(30),
	TaiKhoan VARCHAR(30),
	MatKhau NVARCHAR(30)
)

GO 
CREATE TABLE HoaDon(
	MaHoaDon VARCHAR(15) PRIMARY KEY,
	MaKhachHang VARCHAR(15) FOREIGN KEY REFERENCES dbo.KhachHang(MaKhachHang),
	NgayDatHang DATE,
	NgayGiaoHang DATE,
	TinhTrang NVARCHAR(50),
	DaThanhToan INT 
)
GO 
CREATE TABLE ChiTietHoaDon(
	MaHoaDon VARCHAR(15) REFERENCES dbo.HoaDon(MaHoaDon),
	MaLaptop VARCHAR(15) REFERENCES dbo.Laptop(MaLaptop),
	SoLuong INT ,
	DonGia INT ,
	PRIMARY KEY(MaHoaDon,MaLaptop) 
)

GO 
INSERT dbo.KhachHang( MaKhachHang ,TenKhachHang ,Tuoi ,GioiTinh ,SDT ,DiaChi ,Email ,TaiKhoan ,MatKhau)
VALUES  ('1',N'Vương Văn Thanh',23,'Nam','0984940835','HN','vuongthanhmta@gamil.com','vgthanh','12345')
INSERT dbo.KhachHang( MaKhachHang ,TenKhachHang ,Tuoi ,GioiTinh ,SDT ,DiaChi ,Email ,TaiKhoan ,MatKhau)
VALUES  ('2',N'Nguyễn Hồng Sơn',21,'Nam','0972456332','HN','hongsonmta@gamil.com','hongson','12345')
INSERT dbo.KhachHang( MaKhachHang ,TenKhachHang ,Tuoi ,GioiTinh ,SDT ,DiaChi ,Email ,TaiKhoan ,MatKhau)
VALUES  ('3',N'Phan Duy Duong',21,'Nam','0966352124','HN','duyduongmta@gamil.com','duyduong','12345')
INSERT dbo.KhachHang( MaKhachHang ,TenKhachHang ,Tuoi ,GioiTinh ,SDT ,DiaChi ,Email ,TaiKhoan ,MatKhau)
VALUES  ('4',N'Nguyễn Tuấn Anh',22,'Nam','09126548654','HN','anhtuanmta@gamil.com','anhtuan','12345')
INSERT dbo.KhachHang( MaKhachHang ,TenKhachHang ,Tuoi ,GioiTinh ,SDT ,DiaChi ,Email ,TaiKhoan ,MatKhau)
VALUES  ('5',N'Phan Duy Kien',20,'Nam','0966552142','HN','duykienmo@gamil.com','duydkien','12345')

INSERT dbo.LoaiLaptop( MaLoaiLaptop, TenLoaiLaptop )
VALUES  ('1',N'ASUS')
INSERT dbo.LoaiLaptop( MaLoaiLaptop, TenLoaiLaptop )
VALUES  ('2',N'DELL')
INSERT dbo.LoaiLaptop( MaLoaiLaptop, TenLoaiLaptop )
VALUES  ('3',N'HP')
INSERT dbo.LoaiLaptop( MaLoaiLaptop, TenLoaiLaptop )
VALUES  ('4',N'APPLE')
INSERT dbo.LoaiLaptop( MaLoaiLaptop, TenLoaiLaptop )
VALUES  ('5',N'MAC')
INSERT dbo.LoaiLaptop( MaLoaiLaptop, TenLoaiLaptop )
VALUES  ('6',N'SONNY')

INSERT dbo.NhaCungCap( MaNhaCungCap ,TenNhaCungCap ,DiaChi ,SDT)
VALUES  ('1',N'ASUSTeK Computer Incorporated',N'Hà Nội','0999555666')
INSERT dbo.NhaCungCap( MaNhaCungCap ,TenNhaCungCap ,DiaChi ,SDT)
VALUES  ('2',N'Dell Inc',N'TP HCM','01266589458')
INSERT dbo.NhaCungCap( MaNhaCungCap ,TenNhaCungCap ,DiaChi ,SDT)
VALUES  ('3',N' Hewlett-Packard',N'Hà Nội','01255564646')
INSERT dbo.NhaCungCap( MaNhaCungCap ,TenNhaCungCap ,DiaChi ,SDT)
VALUES  ('4',N'APPLE',N'Hà Nội','0966644466')
INSERT dbo.NhaCungCap( MaNhaCungCap ,TenNhaCungCap ,DiaChi ,SDT)
VALUES  ('5',N'SONNY',N'Hà Nội','0123456789')

INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota)
VALUES  ('1',N'ASUS K501L','1',15000000,10,'asusk501l.jpg','1',N'K501L ')
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota)
VALUES  ('2',N'ASUS K501LB','1',15500000,10,'asusk501lb.jpg','1',N'K501LB ')
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota)
VALUES  ('3',N' Dell Latitude E7440','2',14000000,10,'delllatitude.jpg','2',N'Dell Latitude E7440')
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota)
VALUES  ('4',N'Dell Inspiron 14-7000','2',15000000,10,'dellinspiron.jpg','2',N'Dell Inspiron')
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota)
VALUES  ('5',N'Apple Macbook Air','4',35000000,10,'AppleMacbookAir.jpg','4',N'Air MQD32SA/A i5 (2017)')
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota)
VALUES  ('6',N'Apple Macbook Pro','4',35000000,10,'AppleMacbookPro.jpg','4',N'Pro MPXR2SA/A i5  (2017)')

