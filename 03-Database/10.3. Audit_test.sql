-- ================== CÂU 2 ==================
ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;

-- NV_PKT update trên bảng DANGKY (table)
UPDATE pdb_admin.DANGKY SET DIEMQT = 4.4 WHERE MASV = 'SV20221222' AND MAMM = 'MM00212';

-- NV PKT tra cứu trên bảng DANGKY_VIEW (view)
SELECT * FROM PDB_ADMIN.DANGKY_VIEW;

-- NV_PKT thực thi (proc)
EXEC PDB_ADMIN.UPDATE_DANGKY_GRADE('SV20211821', 'MM00204', 5.5);

-- NV_PKT thực thi (func)
DECLARE
    v_result NUMBER;
BEGIN
    v_result := PDB_ADMIN.GET_DANGKY_AUDIT_LOG('SV20232435', 'MM00238', 5.0);
    DBMS_OUTPUT.PUT_LINE('Rows updated: ' || v_result);
END;
/
-- ================== CÂU 3 ==================
-- Chạy trên pdb_admin
-- Câu a:
GRANT UPDATE ON PDB_ADMIN.DANGKY TO NV_PDT;
-- Câu b:
GRANT SELECT, UPDATE ON PDB_ADMIN.NHANVIEN TO TRGDV;
-- Câu c:
GRANT INSERT, UPDATE, DELETE ON PDB_ADMIN.DANGKY TO ROLE_SINHVIEN;

-- --------------------------------------------------------
-- a. Hành vi cập nhật quan hệ ĐANGKY tại các trường liên quan đến điểm số nhưng người đó không thuộc vai trò “NV PKT”. 

-- ------------ Không audit:
-- Đăng nhập vai trò NV PKT, username: NV000222, pass: 123

-- NV_PKT cập nhật trên quan hệ DANGKY
UPDATE PDB_ADMIN.DANGKY 
SET DIEMTK = 5.0
WHERE MASV = 'SV20220978' AND MAMM = 'MM00267';
commit;

-- ------------ Có audit:
-- Đăng nhập vai trò NV PĐT, username: NV000201, pass: 123

-- Không phải NV_KT cập nhật trên quan hệ DANGKY
ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;
UPDATE PDB_ADMIN.DANGKY 
SET DIEMTH = 8.0, DIEMQT = 7.5 
WHERE MASV = 'SV20220978' AND MAMM = 'MM00267';
COMMIT;

-- --------------------------------------------------------
-- b. Hành vi của người dùng (không thuộc vai trò “NV TCHC”) có thể đọc trên
-- trường LUONG, PHUCAP của người khác hoặc cập nhật ở quan hệ NHANVIEN.

-- ------------ Không audit:

-- 1. NV TCHC cập nhật trên quan hệ NHANVIEN
-- Đăng nhập vai trò NV TCHC, username: NV000231, pass: 123
SELECT LUONG, PHUCAP 
FROM PDB_ADMIN.NHANVIEN 
WHERE MANLD = 'NV000001';

UPDATE PDB_ADMIN.NHANVIEN 
SET LUONG = 20000000, PHUCAP = 3000000 
WHERE MANLD = 'NV000001';
COMMIT;

-- 2. NV đọc thông tin của mình trên quan hệ NHANVIEN
-- Đăng nhập vai trò NV PKT, username: NV000222, pass: 123
select * from pdb_admin.nhanvien where manld='NV000222';

-- ------------ Có audit:
-- Đăng nhập vai trò Trưởng đơn vị, username: NV000764, pass: 123

-- 1. Đọc trường LUONG, PHUCAP của người khác trên quan hệ NHANVIEN
SELECT LUONG, PHUCAP 
FROM PDB_ADMIN.NHANVIEN 
WHERE MANLD = 'NV000001';

-- 2. Cập nhật thông tin của người khác trên quan hệ NHANVIEN
UPDATE PDB_ADMIN.NHANVIEN 
SET LUONG=20002
WHERE MANLD='NV000212';
COMMIT;

-- 3. Cập nhật thông tin của mình trên quan hệ NHANVIEN
UPDATE PDB_ADMIN.NHANVIEN 
SET LUONG=20002
WHERE MANLD='NV000764';
COMMIT;


-- --------------------------------------------------------
-- c. Hành vi thêm, xóa, sửa trên quan hệ DANGKY của sinh viên nhưng trên dòng
-- dữ liệu của sinh viên khác hoặc thực hiện hiệu chỉnh đăng ký học phần ngoài
-- thời gian cho phép hiệu chỉnh đăng ký học phần. 

-- ------------ Có audit:
-- 1. Sinh viên khác cập nhật thông tin đăng ký học phần của mình
-- Đăng nhập vai trò Sinh viên, username: SV20210001, pass: 123

-- Cập nhật điểm của sinh viên khác
UPDATE PDB_ADMIN.DANGKY 
SET DIEMTK = 8.0
WHERE MASV = 'SV20220978' AND MAMM = 'MM00267';
commit;

-- Xoá dòng của sinh viên khác
DELETE FROM PDB_ADMIN.DANGKY WHERE MASV = 'SV20220978' AND MAMM = 'MM00267';
commit;

-- Thêm dòng của sinh viên khác
INSERT INTO PDB_ADMIN.DANGKY (MASV, MAMM, DIEMTH, DIEMQT, DIEMCK, DIEMTK) 
VALUES ('SV20220978', 'MM00267', 6.0, 7.0, 8.0, 7.0);
commit;

-- 2. Sinh viên cập nhật thông tin đăng ký học phần của mình ngoài thời gian cho phép

-- Thêm
INSERT INTO PDB_ADMIN.DANGKY (MASV, MAMM, DIEMTH, DIEMQT, DIEMCK, DIEMTK) 
VALUES ('SV20210001', 'MM00202', 6.0, 7.0, 8.0, 7.0);
commit;

-- Sửa
UPDATE PDB_ADMIN.DANGKY 
SET DIEMTK = 8.0
WHERE MASV = 'SV20210001' AND MAMM = 'MM00202';
commit;


-- Xoá
DELETE FROM PDB_ADMIN.DANGKY WHERE MASV = 'SV20210001' AND MAMM = 'MM00202';
commit;



-- ------------ Không audit:
-- Sinh viên thay đổi thông tin đăng ký học phần của mình trong thời gian cho phép (thay đổi function để test: đổi ngày bắt đầu của kỳ 3)

-- Hàm kiểm tra điều kiện audit
CREATE OR REPLACE FUNCTION FN_AUDIT_DANGKY(p_masv IN VARCHAR2)
RETURN NUMBER
IS
  v_user        VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
  v_today       DATE := SYSDATE;
  v_month       NUMBER;
  v_nam         NUMBER;
  v_hk          NUMBER;
  v_start_date  DATE;
BEGIN
  -- Kiểm tra có phải là sinh viên không
  IF SUBSTR(UPPER(v_user), 1, 2) != 'SV' THEN
    RETURN 0;
  END IF;

  -- Nếu MASV khác user thì audit
  IF UPPER(p_masv) != UPPER(v_user) THEN
    RETURN 1;
  END IF;

  -- Xác định học kỳ và năm hiện tại
  v_month := TO_NUMBER(TO_CHAR(v_today, 'MM'));
  v_nam   := TO_NUMBER(TO_CHAR(v_today, 'YYYY'));

  IF v_month >= 9 THEN
    v_hk := 1;
  ELSIF v_month BETWEEN 1 AND 4 THEN
    v_hk := 2;
  ELSE
    v_hk := 3;
  END IF;

  -- Đổi ngày bắt đầu học kỳ 3
  v_start_date := TO_DATE(
    CASE v_hk
      WHEN 1 THEN '01-09-' || v_nam
      WHEN 2 THEN '01-01-' || v_nam
      WHEN 3 THEN '20-05-' || v_nam
    END,
    'DD-MM-YYYY'
  );

  -- Nếu vượt quá 14 ngày kể từ ngày bắt đầu học kỳ thì audit
  IF v_today > (v_start_date + 14) THEN
    RETURN 1;
  END IF;

  -- Không rơi vào các trường hợp cần audit
  RETURN 0;

EXCEPTION
  WHEN OTHERS THEN
    RETURN 1;  
END;
/

-- Xoá chính sách FGA nếu đã tồn tại
BEGIN
  DBMS_FGA.DROP_POLICY(
    object_schema => 'PDB_ADMIN',
    object_name   => 'DANGKY',
    policy_name   => 'AUDIT_DANGKY_CAUC'
  );
EXCEPTION
  WHEN OTHERS THEN NULL;
END;
/

-- Tạo chính sách FGA 
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema   => 'PDB_ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'AUDIT_DANGKY_CAUC',
    audit_condition => 'PDB_ADMIN.FN_AUDIT_DANGKY(MASV) = 1',
    audit_column    => NULL,
    statement_types => 'INSERT, UPDATE, DELETE',
    audit_trail     => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
    enable          => TRUE
  );
END;
/


