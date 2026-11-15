-- Đăng nhập bằng tài khoản pdb_admin
ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;

-- =================== CÂU 2 ===================

-- Tạo view trên DANGKY
CREATE OR REPLACE VIEW DANGKY_VIEW AS
SELECT MASV, MAMM, DIEMTK FROM DANGKY WHERE DIEMTK >= 5;


GRANT SELECT ON DANGKY_VIEW TO NVCB; -- người dùng NVCB sẽ k thấy vì RBAC
GRANT SELECT ON DANGKY_VIEW TO NV_PKT; -- sẽ thầy khi select và sẽ bị ghi vết
-- Tạo stored procedure
CREATE OR REPLACE PROCEDURE UPDATE_DANGKY_GRADE (
    p_masv IN VARCHAR2,
    p_mamm IN VARCHAR2,
    p_diemtk IN NUMBER
) AS
BEGIN
    UPDATE DANGKY
    SET DIEMTK = p_diemtk
    WHERE MASV = p_masv AND MAMM = p_mamm;
    COMMIT;
END;
/

-- Cấp quyền thực thi procedure (nhớ đưa vô vòng lặp tạo user)
GRANT EXECUTE ON UPDATE_DANGKY_GRADE TO NV_PKT, NVCB;

-- Tạo function
CREATE OR REPLACE FUNCTION GET_DANGKY_AUDIT_LOG (
    p_masv IN VARCHAR2,
    p_mamm IN VARCHAR2,
    p_diemtk IN NUMBER
) RETURN NUMBER AS
BEGIN
    UPDATE DANGKY
    SET DIEMTK = p_diemtk
    WHERE MASV = p_masv AND MAMM = p_mamm;
    
    COMMIT;
    
    RETURN SQL%ROWCOUNT; -- Returns the number of rows affected
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RETURN -1; -- Returns -1 to indicate an error
END;
/

GRANT EXECUTE ON GET_DANGKY_AUDIT_LOG TO NV_PKT, NVCB;

-- Standard Auditing
-- DANGKY
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY BY ACCESS;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER SUCCESSFUL;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER NOT SUCCESSFUL;

-- DANGKY_VIEW
AUDIT SELECT ON DANGKY_VIEW BY ACCESS;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER SUCCESSFUL;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER NOT SUCCESSFUL;

-- UPDATE_DANGKY_GRADE (thủ tục)
AUDIT EXECUTE ON UPDATE_DANGKY_GRADE BY ACCESS;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER SUCCESSFUL;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER NOT SUCCESSFUL;

-- FUNCTION GET_DANGKY_AUDIT_LOG
AUDIT EXECUTE ON GET_DANGKY_AUDIT_LOG BY ACCESS;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER SUCCESSFUL;
AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER NOT SUCCESSFUL;

-- Chạy được trên bảng DBA_AUDIT_TRAIL
SELECT USERNAME, ACTION_NAME, OBJ_NAME, SQL_TEXT, 
      TO_CHAR(TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS TIMESTAMP
FROM DBA_AUDIT_TRAIL
WHERE OBJ_NAME IN ('DONVI', 'NHANVIEN', 'DANGKY', 'DANGKY_VIEW', 'UPDATE_DANGKY_GRADE', 'GET_DANGKY_AUDIT_LOG')
AND USERNAME IN (
    SELECT MANLD 
    FROM NHANVIEN 
    WHERE VAITRO IN ('NV PKT', 'NVCB')
)
ORDER BY TIMESTAMP DESC;

-- Chạy được trên bảng UNIFIED_AUDIT_TRAIL
SELECT 
    AUDIT_TYPE,
    DBUSERNAME,
    ACTION_NAME,
    OBJECT_NAME,
    SQL_TEXT, SQL_BINDS, RLS_INFO, 
    RETURN_CODE, -- 0 = thành công, khác 0 là lỗi
    TO_CHAR(EVENT_TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME
FROM UNIFIED_AUDIT_TRAIL
WHERE OBJECT_NAME IN ('DANGKY', 'DANGKY_VIEW', 'NHANVIEN', 'DONVI', 'UPDATE_DANGKY_GRADE', 'GET_DANGKY_AUDIT_LOG')
AND DBUSERNAME IN (
    SELECT MANLD 
    FROM NHANVIEN 
    WHERE VAITRO IN ('NV PKT', 'NVCB')
)
ORDER BY EVENT_TIMESTAMP DESC;

-- =================== CÂU 3 ===================

ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;
-- drop hết tất cả chính sách VPD
BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema => 'PDB_ADMIN',
    object_name   => 'DANGKY',
    policy_name   => 'DK_EDIT_POLICY'
  );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema => 'PDB_ADMIN',
    object_name   => 'DANGKY',
    policy_name   => 'DK_UPDATE_POLICY'
  );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema => 'PDB_ADMIN',
    object_name   => 'DANGKY',
    policy_name   => 'DK_SELECT_POLICY'
  );
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

-- Xoá chính sách VPD trên bảng SINHVIEN
BEGIN
  DBMS_RLS.DROP_POLICY('PDB_ADMIN', 'SINHVIEN', 'SV_VPD_SEL_POLICY');
END;
/

BEGIN
  DBMS_RLS.DROP_POLICY('PDB_ADMIN', 'SINHVIEN', 'SV_VPD_UPD_POLICY');
END;
/

BEGIN
  DBMS_RLS.DROP_POLICY('PDB_ADMIN', 'SINHVIEN', 'SV_VPD_INS_DEL_POLICY');
END;
/

-- Xoá trigger 
DROP TRIGGER TRG_SINHVIEN_CHECK_UPDATE;

-- --------------------------------------------------------
-- a. Hành vi cập nhật quan hệ ĐANGKY tại các trường liên quan đến điểm số nhưng người đó không thuộc vai trò “NV PKT”. 


-- Tạo hàm kiểm tra người dùng có phải là NV PKT hay không
CREATE OR REPLACE FUNCTION FN_IS_NV_PKT(p_user IN VARCHAR2)
RETURN NUMBER
IS
  v_count INTEGER := 0;
BEGIN
  -- Nếu không phải NV -> không audit
  IF SUBSTR(UPPER(p_user), 1, 2) != 'NV' THEN
    RETURN 0;
  END IF;

  -- Kiểm tra role
  SELECT COUNT(*)
  INTO v_count
  FROM DBA_ROLE_PRIVS
  WHERE GRANTEE = UPPER(p_user)
    AND GRANTED_ROLE = 'NV_PKT';

  IF v_count > 0 THEN
    RETURN 1; -- Có role NV_PKT -> không audit
  ELSE
    RETURN 0; -- Không có role -> audit
  END IF;

EXCEPTION
  WHEN OTHERS THEN
    RETURN 0; -- Nếu lỗi, vẫn audit để an toàn
END;
/


-- Xoá chính sách FGA nếu đã tồn tại
BEGIN
  DBMS_FGA.DROP_POLICY(
    object_schema => 'PDB_ADMIN',
    object_name   => 'DANGKY',
    policy_name   => 'AUDIT_DANGKY_SCORES'
  );
EXCEPTION
  WHEN OTHERS THEN NULL;
END;
/


-- Tạo chính sách FGA để audit các cập nhật điểm số trên bảng DANGKY
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema   => 'PDB_ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'AUDIT_DANGKY_SCORES',
    statement_types => 'UPDATE',
    audit_column    => 'DIEMTH,DIEMQT,DIEMCK,DIEMTK',
    audit_condition => 'PDB_ADMIN.FN_IS_NV_PKT(USER) = 0',
    audit_trail     => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
    enable          => TRUE
  );
END;
/

-- Chạy được trên bảng DBA_AUDIT_TRAIL
SELECT db_user, object_name, sql_text, TO_CHAR(TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME
FROM DBA_FGA_AUDIT_TRAIL
WHERE policy_name = 'AUDIT_DANGKY_SCORES';

-- Chạy được trên bảng UNIFIED_AUDIT_TRAIL
SELECT 
    AUDIT_TYPE,
    DBUSERNAME,
    ACTION_NAME,
    OBJECT_NAME,
    SQL_TEXT, SQL_BINDS,  
    RETURN_CODE, 
    TO_CHAR(EVENT_TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME, FGA_POLICY_NAME
FROM UNIFIED_AUDIT_TRAIL 
WHERE fga_policy_name='AUDIT_DANGKY_SCORES' ORDER BY EVENT_TIMESTAMP DESC;

-- --------------------------------------------------------
-- b. Hành vi của người dùng (không thuộc vai trò “NV TCHC”) có thể đọc trên
-- trường LUONG, PHUCAP của người khác hoặc cập nhật ở quan hệ NHANVIEN.

CREATE OR REPLACE FUNCTION FN_NHANVIEN_AUDIT(p_user VARCHAR2, p_manld VARCHAR2)
RETURN NUMBER IS
  v_count INTEGER := 0;
BEGIN
  -- Nếu user khác mã người lao động
  IF p_user != p_manld THEN
    -- Kiểm tra xem user có được cấp role 'NV_TCHC' không
    SELECT COUNT(*)
    INTO v_count
    FROM DBA_ROLE_PRIVS
    WHERE GRANTEE = UPPER(p_user)
      AND GRANTED_ROLE = 'NV_TCHC';

    -- Nếu không có role thì cần audit
    IF v_count = 0 THEN
      RETURN 1;
    END IF;
  END IF;

  RETURN 0; -- Trường hợp còn lại thì không audit
EXCEPTION
  WHEN OTHERS THEN
    RETURN 0; -- Trong trường hợp lỗi, không báo lỗi ra ngoài mà xử lý như cần audit
END;
/


BEGIN
  DBMS_FGA.DROP_POLICY(
    object_schema => 'PDB_ADMIN',
    object_name   => 'NHANVIEN',
    policy_name   => 'AUDIT_NHANVIEN_SALARY'
  );
EXCEPTION
  WHEN OTHERS THEN NULL;
END;
/


BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema   => 'PDB_ADMIN',
    object_name     => 'NHANVIEN',
    policy_name     => 'AUDIT_NHANVIEN_SALARY',
    audit_condition => 'PDB_ADMIN.FN_NHANVIEN_AUDIT(USER, MANLD) = 1',   -- Audit nếu KHÔNG có role NV_TCHC
    audit_column    => 'LUONG, PHUCAP',
    statement_types => 'SELECT, UPDATE',
    audit_trail     => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
    enable          => TRUE
  );
END;
/

-- Chạy được trên bảng DBA_AUDIT_TRAIL
SELECT db_user, object_name, sql_text, TO_CHAR(TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME  
FROM DBA_FGA_AUDIT_TRAIL
WHERE policy_name = 'AUDIT_NHANVIEN_SALARY';

-- Chạy được trên bảng UNIFIED_AUDIT_TRAIL
SELECT 
    AUDIT_TYPE,
    DBUSERNAME,
    ACTION_NAME,
    OBJECT_NAME,
    SQL_TEXT, SQL_BINDS,  
    RETURN_CODE, 
    TO_CHAR(EVENT_TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME, FGA_POLICY_NAME
FROM UNIFIED_AUDIT_TRAIL
WHERE fga_policy_name='AUDIT_NHANVIEN_SALARY' ORDER BY EVENT_TIMESTAMP DESC;

-- --------------------------------------------------------
-- c. Hành vi thêm, xóa, sửa trên quan hệ DANGKY của sinh viên nhưng trên dòng
-- dữ liệu của sinh viên khác hoặc thực hiện hiệu chỉnh đăng ký học phần ngoài
-- thời gian cho phép hiệu chỉnh đăng ký học phần. 


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

  -- Xác định ngày bắt đầu học kỳ
  v_start_date := TO_DATE(
    CASE v_hk
      WHEN 1 THEN '01-09-' || v_nam
      WHEN 2 THEN '01-01-' || v_nam
      WHEN 3 THEN '01-05-' || v_nam
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

-- Chạy được trên bảng DBA_AUDIT_TRAIL
SELECT db_user, object_name, sql_text, TO_CHAR(TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME
FROM DBA_FGA_AUDIT_TRAIL
WHERE policy_name = 'AUDIT_DANGKY_CAUC';

-- Chạy được trên bảng UNIFIED_AUDIT_TRAIL
SELECT 
    AUDIT_TYPE,
    DBUSERNAME,
    ACTION_NAME,
    OBJECT_NAME,
    SQL_TEXT, SQL_BINDS,  
    RETURN_CODE, 
    TO_CHAR(EVENT_TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME, FGA_POLICY_NAME    
FROM UNIFIED_AUDIT_TRAIL
WHERE fga_policy_name='AUDIT_DANGKY_CAUC' ORDER BY EVENT_TIMESTAMP DESC;



