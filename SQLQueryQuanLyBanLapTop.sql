
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
ALTER TABLE dbo.KhachHang
ADD  MaKhachHang  int IDENTITY(1,1)

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

GO 
UPDATE dbo.Laptop SET TrangThai =1

GO 
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('7',N'Asus UX430UQ','1',15000000,10,'_Laptop Asus UX430UQ -9.jpg','1',N'_Laptop Asus UX430UQ -9',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('8',N'Asus Zenbook UX41','1',16000000,10,'asus_zenbook_ux410_review05_thumb1200_4-3.jpg','1',N'asus_zenbook_ux410_review05_thumb1200_4-3',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('9',N'dell-vostro','2',15500000,10,'dell-vostro.jpg','2',N'dell-vostro-5468-p75g001-vangdong-3-1',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('10',N'dell 1570000','2',15900000,10,'dell1570000.jpg','2',N'dell1570000',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('11',N'dell-inspiron-15-i15r','2',15900000,10,'dell-inspiron-15-i15rv-6190-blk.jpg','2',N'dell-inspiron-15-i15rv-6190-blk',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('13',N'dellxps12','2',15900000,10,'dellxps12.jpg','2',N'dellxps12',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('12',N'dell-vostro-v5468i5','2',15900000,10,'dell-vostro-v5468i5-7200u-1.jpg','2',N'dell-vostro-v5468i5-7200u-1',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('14',N'hp14bs561tu','3',12000000,10,'hp14bs561tu.jpg','3',N'hp14bs561tu',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('15',N'hp2018best','3',15900000,10,'hp2018bestk.jpg','3',N'hp2018best',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('16',N'hppavilion15','3',15900000,10,'hppavilion15.jpg','3',N'hp pavilion 15',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('17',N'macbook air 99','4',35000000,10,'macbook-air99.jpg','4',N'macbook-air99',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('18',N'macbook-pro-15','4',35000000,10,'macbook-pro-15.jpg','4',N'macbook-pro-15',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('19',N'macbook-pro-windows-3','4',35000000,10,'macbook-pro-windows-3.jpg','4',N'macbook-pro-windows-3',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('20',N'lenovo500s','5',35000000,10,'lenovo500s.jpg','5',N'lenovo500s',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('21',N'Sony_SVE14112FX','5',35000000,10,'Sony_SVE14112FX.jpg','5',N'Sony_SVE14112FX',1)
INSERT dbo.Laptop( MaLaptop ,TenLaptop ,MaLoaiLaptop ,Gia ,SoLuong,Anh ,MaNhaCungCap, Mota,TrangThai)
VALUES  ('22',N'Sonny vaio','5',35000000,10,'sonnywo.jpg','5',N'sonny vaio',1)
