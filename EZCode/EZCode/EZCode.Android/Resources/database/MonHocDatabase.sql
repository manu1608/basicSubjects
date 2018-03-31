--
-- File generated with SQLiteStudio v3.1.1 on Ba?y Thg3 31 15:36:37 2018
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: BaiTap
CREATE TABLE BaiTap (Id INTEGER PRIMARY KEY ASC AUTOINCREMENT UNIQUE DEFAULT (0), Name STRING UNIQUE NOT NULL DEFAULT TBD);
INSERT INTO BaiTap (Id, Name) VALUES (1, 'Bài t?p v?t lý 2');
INSERT INTO BaiTap (Id, Name) VALUES (2, 'Bài t?p v?t lý 1');
INSERT INTO BaiTap (Id, Name) VALUES (3, 'Bài t?p gi?i tích 2');
INSERT INTO BaiTap (Id, Name) VALUES (4, 'Bài t?p gi?i tích 1');
INSERT INTO BaiTap (Id, Name) VALUES (5, 'Bài t?p d?i s? 1');

-- Table: CongThuc
CREATE TABLE CongThuc (Id INTEGER PRIMARY KEY ASC AUTOINCREMENT UNIQUE DEFAULT (0), Name STRING UNIQUE NOT NULL DEFAULT TBD);
INSERT INTO CongThuc (Id, Name) VALUES (4, 'Phép c?ng');
INSERT INTO CongThuc (Id, Name) VALUES (5, 'Tích phân du?ng');
INSERT INTO CongThuc (Id, Name) VALUES (6, 'Phép tr?');
INSERT INTO CongThuc (Id, Name) VALUES (7, 'phuong trình dao d?ng');
INSERT INTO CongThuc (Id, Name) VALUES (8, 'Công th?c sóng');
INSERT INTO CongThuc (Id, Name) VALUES (9, 'Vi phân');

-- Table: DeThi
CREATE TABLE DeThi (Id INTEGER PRIMARY KEY ASC AUTOINCREMENT UNIQUE DEFAULT (0), Name STRING UNIQUE NOT NULL DEFAULT TBD);
INSERT INTO DeThi (Id, Name) VALUES (1, 'Ð? thi v?t lý 2');
INSERT INTO DeThi (Id, Name) VALUES (2, 'Ð? thi v?t lý 1');
INSERT INTO DeThi (Id, Name) VALUES (3, 'Ð? thi gi?i tích 2');
INSERT INTO DeThi (Id, Name) VALUES (4, 'Ð? thi gi?i tích 1');
INSERT INTO DeThi (Id, Name) VALUES (5, 'Ð? thi d?i s?');

-- Table: MonHoc
CREATE TABLE MonHoc (Id INTEGER PRIMARY KEY ASC AUTOINCREMENT DEFAULT (0) UNIQUE, Name STRING UNIQUE NOT NULL DEFAULT TBD);
INSERT INTO MonHoc (Id, Name) VALUES (1, 'Ð?i s?');
INSERT INTO MonHoc (Id, Name) VALUES (2, 'V?t lý I');
INSERT INTO MonHoc (Id, Name) VALUES (3, 'V?t lý II');
INSERT INTO MonHoc (Id, Name) VALUES (4, 'Gi?i tích I');
INSERT INTO MonHoc (Id, Name) VALUES (5, 'Gi?i tích II');

-- Table: MonHocBaiTap
CREATE TABLE MonHocBaiTap (MonHocId INTEGER REFERENCES MonHoc (Id), BaiTapId INTEGER REFERENCES BaiTap (Id));
INSERT INTO MonHocBaiTap (MonHocId, BaiTapId) VALUES (5, 3);
INSERT INTO MonHocBaiTap (MonHocId, BaiTapId) VALUES (4, 4);
INSERT INTO MonHocBaiTap (MonHocId, BaiTapId) VALUES (3, 1);
INSERT INTO MonHocBaiTap (MonHocId, BaiTapId) VALUES (2, 2);
INSERT INTO MonHocBaiTap (MonHocId, BaiTapId) VALUES (1, 5);

-- Table: MonHocCongThuc
CREATE TABLE MonHocCongThuc (MonHocId INTEGER REFERENCES MonHoc (Id), CongThucId INTEGER REFERENCES CongThuc (Id));
INSERT INTO MonHocCongThuc (MonHocId, CongThucId) VALUES (5, 9);
INSERT INTO MonHocCongThuc (MonHocId, CongThucId) VALUES (4, 5);
INSERT INTO MonHocCongThuc (MonHocId, CongThucId) VALUES (3, 8);
INSERT INTO MonHocCongThuc (MonHocId, CongThucId) VALUES (2, 7);
INSERT INTO MonHocCongThuc (MonHocId, CongThucId) VALUES (1, 6);
INSERT INTO MonHocCongThuc (MonHocId, CongThucId) VALUES (1, 4);

-- Table: MonHocDeThi
CREATE TABLE MonHocDeThi (MonHocId INTEGER REFERENCES MonHoc (Id), DeThiId INTEGER REFERENCES DeThi (Id));
INSERT INTO MonHocDeThi (MonHocId, DeThiId) VALUES (5, 3);
INSERT INTO MonHocDeThi (MonHocId, DeThiId) VALUES (4, 4);
INSERT INTO MonHocDeThi (MonHocId, DeThiId) VALUES (3, 1);
INSERT INTO MonHocDeThi (MonHocId, DeThiId) VALUES (2, 2);
INSERT INTO MonHocDeThi (MonHocId, DeThiId) VALUES (1, 5);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
