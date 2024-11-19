
CREATE TABLE GroupManagement
(
    GroupID nvarchar(50) PRIMARY KEY,
    GroupName nvarchar(50) NOT NULL
);

CREATE TABLE AccountManagement
(
    AccountUsername nvarchar(50) PRIMARY KEY,
    AccountPassword nvarchar(50) NOT NULL,
    GroupID nvarchar(50),
    FOREIGN KEY (GroupID) REFERENCES GroupManagement (GroupID)
);

CREATE TABLE Functions
(
    FunctionID nvarchar(50) PRIMARY KEY,
    FunctionName nvarchar(100) NOT NULL

);

CREATE TABLE GroupFunctions
(
    FunctionID nvarchar(50),
    GroupID nvarchar(50) ,
	IsEnable bit,
	Primary key( FunctionID, GroupID),
	FOREIGN KEY (GroupID) REFERENCES GroupManagement (GroupID),
    FOREIGN KEY (FunctionID) REFERENCES Functions (FunctionID),
);

-- Tạo bảng HangHoa

CREATE TABLE HangHoa ( 
MaHangHoa nvarchar(50) PRIMARY KEY,
TenHangHoa nvarchar(100) NOT NULL,
Gia nvarchar(50) NOT NULL, 
SoLuong int NOT NULL, 
AccountUsername nvarchar(50),
FOREIGN KEY (AccountUsername) REFERENCES AccountManagement (AccountUsername)
);


CREATE TABLE LoaiHangHoa (
    MaLoaiHang INT PRIMARY KEY,
    TenLoaiHang NVARCHAR(255) NOT NULL,
    MaHangHoa nvarchar(50) ,
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa)
);

-- Tạo bảng PhieuDatHang, với HangHoa là khóa chính
CREATE TABLE PhieuDatHang (
    MaPhieuDat nvarchar(50)  PRIMARY KEY,
    NgayDatHang DATE NOT NULL,
    MaHangHoa nvarchar(50) ,
    SoLuongDat INT NOT NULL,
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa)
);
-- Tạo bảng ChiTietPhieuDat, với PhieuDatHang là khóa phụ
CREATE TABLE ChiTietPhieuDat (
    MaChiTietDat nvarchar(50)  PRIMARY KEY,
    MaPhieuDat nvarchar(50) ,
    MaHangHoa nvarchar(50) ,
    SoLuongDat nvarchar(50)  NOT NULL,
    FOREIGN KEY (MaPhieuDat) REFERENCES PhieuDatHang(MaPhieuDat),
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa)
);


-- Tạo bảng PhieuGiaoHang, với PhieuDatHang là khóa chính
CREATE TABLE PhieuGiaoHang (
    MaPhieuGiao nvarchar(50)  PRIMARY KEY,
    NgayGiaoHang DATE NOT NULL,
    MaPhieuDat nvarchar(50) ,
    FOREIGN KEY (MaPhieuDat) REFERENCES PhieuDatHang(MaPhieuDat)
);

-- Tạo bảng ChiTietPhieuGiao, với PhieuGiaoHang là khóa phụ
CREATE TABLE ChiTietPhieuGiao (
    MaChiTietGiao nvarchar(50) PRIMARY KEY,
    MaPhieuGiao nvarchar(50) ,
    MaHangHoa nvarchar(50) ,
    SoLuongGiao nvarchar(50)  NOT NULL,
    FOREIGN KEY (MaPhieuGiao) REFERENCES PhieuGiaoHang(MaPhieuGiao),
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa)
);
