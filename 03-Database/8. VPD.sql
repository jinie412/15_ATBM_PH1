ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;
-- ========================= VPD - DANGKY ========================================

GRANT SELECT, INSERT, UPDATE, DELETE ON DANGKY TO NV_PDT, ROLE_SINHVIEN;

GRANT SELECT, UPDATE ON DANGKY TO NV_PKT;

-- VPD - DANGKY: DELETE - INSERT (SV - PDT)
CREATE OR REPLACE FUNCTION check_registration_period (
    p_schema IN VARCHAR2,
    p_object IN VARCHAR2
) RETURN VARCHAR2 AS
    v_user      VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_prefix    VARCHAR2(5);
    v_role      VARCHAR2(20);
    v_hk        NUMBER(1);
    v_nam       NUMBER(4);
    v_start_date DATE;
    v_current_date DATE := SYSDATE;
    v_month     NUMBER;
BEGIN
    v_prefix := SUBSTR(v_user, 1, 2); -- kiểm tra 2 ký tự đầu
    
    v_month := TO_NUMBER(TO_CHAR(v_current_date, 'MM'));
    v_nam   := TO_NUMBER(TO_CHAR(v_current_date, 'YYYY'));

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
                WHEN 3 THEN '20-05-' || v_nam
            END,
            'DD-MM-YYYY'
        );
    -- Nếu là PDB_ADMIN
    IF v_user = 'PDB_ADMIN' THEN
        RETURN '1=1';  -- Toàn quyền
    ELSIF v_prefix = 'SV' THEN
        -- Nếu là SINHVIEN
        IF (v_current_date BETWEEN v_start_date AND v_start_date + 14) THEN
            RETURN 'MASV = ''' || v_user || ''' AND MAMM IN (SELECT MAMM FROM MOMON WHERE HK = ' 
                || v_hk || ' AND NAM = ' || v_nam || ') AND DIEMTH IS NULL AND DIEMQT IS NULL AND DIEMCK IS NULL AND DIEMTK IS NULL';
        ELSE
            RETURN '1=2';
        END IF;
    ELSE
        -- Nếu là nhân viên, lấy vai trò từ bảng NHANVIEN
        BEGIN
            SELECT MADV INTO v_role FROM NHANVIEN WHERE MANLD = v_user;

            IF v_role = 'PDT' THEN
                IF (v_current_date BETWEEN v_start_date AND v_start_date + 14) THEN
                    RETURN 'MAMM IN (SELECT MAMM FROM MOMON WHERE HK = ' 
               || v_hk || ' AND NAM = ' || v_nam || ') AND DIEMTH IS NULL AND DIEMQT IS NULL AND DIEMCK IS NULL AND DIEMTK IS NULL'; -- NV PĐT có toàn quyền trong thời gian này
                ELSE
                    RETURN '1=2';
                END IF;
            ELSE
                RETURN '1=2'; -- Các vai trò NV khác không được phép
            END IF;

        EXCEPTION
            WHEN NO_DATA_FOUND THEN
                RETURN '1=2'; -- Không tìm thấy vai trò
        END;
    END IF;

    EXCEPTION
        WHEN OTHERS THEN
            RETURN '1=2'; -- fallback an toàn
END;
/

BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema => 'pdb_admin',
    object_name   => 'DANGKY',
    policy_name   => 'DK_EDIT_POLICY'
  );
END;
/

BEGIN
  DBMS_RLS.ADD_POLICY (
    object_schema   => 'PDB_ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'DK_EDIT_POLICY',
    function_schema => 'PDB_ADMIN',
    policy_function => 'check_registration_period',
    statement_types => 'INSERT, DELETE',
    update_check    => TRUE
  );
END;
/



-- VPD - DANGKY: UPDATE (NV PKT)
CREATE OR REPLACE FUNCTION FUNC_DANGKY_UPDATE (
    schema_p IN VARCHAR2,
    table_p IN VARCHAR2
) RETURN VARCHAR2 AS
    v_role VARCHAR2 (20);
BEGIN
    SELECT VAITRO INTO v_role 
    FROM NHANVIEN 
    WHERE MANLD = SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    IF v_role = 'NV PKT' OR SYS_CONTEXT('USERENV', 'SESSION_USER') = 'PDB_ADMIN' THEN
        RETURN NULL; -- Cho phép UPDATE trên các cột điểm
    ELSE
        RETURN '1=0'; -- Chặn các vai trò khác
    END IF;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN '1=0'; -- Chặn nếu không tìm thấy vai trò
END;
/

BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema => 'pdb_admin',
    object_name   => 'DANGKY',
    policy_name   => 'DK_UPDATE_POLICY'
  );
END;
/

BEGIN 
    DBMS_RLS.ADD_POLICY (
        object_schema => 'PDB_ADMIN',
        object_name => 'DANGKY',
        policy_name => 'DK_UPDATE_POLICY',
        function_schema => 'PDB_ADMIN',
        policy_function => 'FUNC_DANGKY_UPDATE',
        statement_types => 'UPDATE',
        update_check => TRUE,
        sec_relevant_cols => 'DIEMTH, DIEMQT, DIEMCK, DIEMTK'
    );
END;
/


-- VPD - DANGKY: SELECT (SV - NV PĐT - NV PKT)
CREATE OR REPLACE FUNCTION FN_DK_SELECT (
    p_schema IN VARCHAR2,
    p_object IN VARCHAR2
) RETURN VARCHAR2 AS
    v_user    VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_prefix  VARCHAR2(5);
    v_role    VARCHAR2(20);
BEGIN
    v_prefix := SUBSTR(v_user, 1, 2);

    IF v_user = 'PDB_ADMIN' THEN
        RETURN '1=1';  -- Toàn quyền
    -- Trường hợp SINHVIEN
    ELSIF v_prefix = 'SV' THEN

        RETURN 'MASV = ''' || v_user || '''';

    ELSE
        -- Trường hợp NHANVIEN: truy vấn vai trò
        BEGIN
            SELECT VAITRO INTO v_role FROM NHANVIEN WHERE MANLD = v_user;

            IF v_role = 'NV PĐT' OR v_role = 'NV PKT' THEN
                RETURN '1=1';
            ELSIF v_role = 'GV' THEN
                IF UPPER(p_object) = 'DANGKY' THEN
                    RETURN 'MAMM IN (SELECT MAMM FROM PDB_ADMIN.MOMON WHERE MAGV = ''' || v_user || ''')'; -- Giảng viên thấy đăng ký của môn mình dạy
                ELSE
                    RETURN '1=0'; -- Cấm truy cập bảng khác
                END IF;
            ELSE
                RETURN '1=2'; -- nhân viên khác không có quyền
            END IF;

        EXCEPTION
            WHEN NO_DATA_FOUND THEN
                RETURN '1=2'; -- Không tìm thấy trong bảng NHANVIEN
        END;
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        RETURN '1=2';
END;
/

-- Xóa policy
BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema => 'PDB_ADMIN',
    object_name   => 'DANGKY',
    policy_name   => 'DK_SELECT_POLICY'
  );
END;
/

-- Gán policy cho DANGKY
BEGIN
  DBMS_RLS.ADD_POLICY (
    object_schema   => 'PDB_ADMIN',
    object_name     => 'DANGKY',
    policy_name     => 'DK_SELECT_POLICY',
    function_schema => 'PDB_ADMIN',
    policy_function => 'FN_DK_SELECT',
    statement_types => 'SELECT',
    update_check    => FALSE
  );
END;
/

-- ========================= VPD - SINHVIEN ========================================


-- VPD - SINHVIEN: SELECT (NV CTSV - SV - PDT -GV)
CREATE OR REPLACE FUNCTION FUNC_SINHVIEN_SEL (
    schema_p IN VARCHAR2,
    table_p IN VARCHAR2
) RETURN VARCHAR2 AS
    v_user    VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_prefix  VARCHAR2(5);
    v_role    VARCHAR2(20);
    v_madv    VARCHAR2(10);
BEGIN
    v_prefix := SUBSTR(v_user, 1, 2);

    IF v_user = 'PDB_ADMIN' THEN
        RETURN '1=1';  -- Toàn quyền

    ELSIF v_prefix = 'SV' THEN
        RETURN 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';

    ELSE
        SELECT VAITRO INTO v_role FROM NHANVIEN WHERE MANLD = v_user;

        IF v_role = 'NV CTSV' OR v_role = 'NV PĐT' THEN
            RETURN '1=1';

        ELSIF v_role = 'GV' THEN
            SELECT MADV INTO v_madv
            FROM PDB_ADMIN.NHANVIEN
            WHERE MANLD = v_user;

            RETURN 'KHOA = ''' || v_madv || '''';  

        ELSE
            RETURN '1=0'; -- Các vai trò khác thì chặn hết
        END IF;

    END IF;    

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN '1=0'; -- Không tìm thấy nhân viên
END;
/


-- Xóa policy
BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema  => 'pdb_admin',
    object_name    => 'SINHVIEN',
    policy_name    => 'SV_VPD_SEL_POLICY'
  );
END;
/


BEGIN
    DBMS_RLS.ADD_POLICY (
        object_schema   => 'pdb_admin', 
        object_name     => 'SINHVIEN',
        policy_name     => 'SV_VPD_SEL_POLICY',
        function_schema => 'pdb_admin', 
        policy_function => 'FUNC_SINHVIEN_SEL',
        statement_types  => 'SELECT',
        update_check    => TRUE
    );
END;
/



-- VPD - SINHVIEN: UPDATE (NV CTSV - SV - PDT)
CREATE OR REPLACE FUNCTION FUNC_SINHVIEN_UPDATE (
    schema_p IN VARCHAR2,
    table_p IN VARCHAR2
) RETURN VARCHAR2 AS
    v_user    VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_prefix  VARCHAR2(5);
    v_role    VARCHAR2(20);
    v_madv    VARCHAR2(10);
BEGIN
    v_prefix := SUBSTR(v_user, 1, 2);

    IF v_user = 'PDB_ADMIN' THEN
        RETURN '1=1';  -- Toàn quyền

    ELSIF v_prefix = 'SV' THEN
        RETURN 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';

    ELSE
        SELECT VAITRO INTO v_role FROM NHANVIEN WHERE MANLD = v_user;

        IF v_role = 'NV CTSV' OR v_role = 'NV PĐT' THEN
            RETURN '1=1';
        ELSE
            RETURN '1=0'; -- Các vai trò khác thì chặn hết
        END IF;

    END IF;    

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN '1=0'; -- Không tìm thấy nhân viên
END;
/


-- Xóa policy
BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema  => 'pdb_admin',
    object_name    => 'SINHVIEN',
    policy_name    => 'SV_VPD_UPD_POLICY'
  );
END;
/


BEGIN
    DBMS_RLS.ADD_POLICY (
        object_schema   => 'pdb_admin', 
        object_name     => 'SINHVIEN',
        policy_name     => 'SV_VPD_UPD_POLICY',
        function_schema => 'pdb_admin', 
        policy_function => 'FUNC_SINHVIEN_UPDATE',
        statement_types  => 'UPDATE',
        update_check    => TRUE
    );
END;
/

CREATE OR REPLACE TRIGGER TRG_SINHVIEN_CHECK_UPDATE
BEFORE UPDATE ON SINHVIEN
FOR EACH ROW
DECLARE
    v_user     VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_prefix   VARCHAR2(5);
    v_role     VARCHAR2(20);
BEGIN
    v_prefix := SUBSTR(v_user, 1, 2);

    -- Admin toàn quyền, bỏ qua kiểm tra
    IF v_user = 'PDB_ADMIN' THEN
        RETURN;
    END IF;

    -- Sinh viên chỉ được sửa địa chỉ và số điện thoại của chính mình
    IF v_prefix = 'SV' THEN
        IF :NEW.HOTEN <> :OLD.HOTEN OR
           :NEW.MASV <> :OLD.MASV OR
           :NEW.NGSINH <> :OLD.NGSINH OR 
           :NEW.PHAI <> :OLD.PHAI OR 
           :NEW.KHOA <> :OLD.KHOA OR 
           :NEW.TINHTRANG <> :OLD.TINHTRANG THEN
            RAISE_APPLICATION_ERROR(-20001, N'Sinh viên chỉ được phép cập nhật ĐCHI và ĐT của chính mình.');
        END IF;

    ELSE
        
        BEGIN
            SELECT VAITRO INTO v_role
            FROM NHANVIEN
            WHERE MANLD = v_user;
        EXCEPTION
            WHEN NO_DATA_FOUND THEN
                RAISE_APPLICATION_ERROR(-20003, 'Không xác định được vai trò nhân viên.');
        END;

        -- NV PĐT chỉ được cập nhật TINHTRANG
        IF v_role = 'NV PĐT' THEN
            IF NOT UPDATING('TINHTRANG') THEN
                RAISE_APPLICATION_ERROR(-20004, 'NV PĐT chỉ được cập nhật cột TINHTRANG.');
            END IF;

        -- NV CTSV được sửa tất cả, trừ TINHTRANG
        ELSIF v_role = 'NV CTSV' THEN
            IF UPDATING('TINHTRANG') THEN
                RAISE_APPLICATION_ERROR(-20005, 'NV CTSV không được phép cập nhật cột TINHTRANG.');
            END IF;
        END IF;
    END IF;
END;
/


-- VPD - SINHVIEN: INSERT, DELETE (NV CTSV)
CREATE OR REPLACE FUNCTION FUNC_SINHVIEN_INS_DEL (
    schema_p IN VARCHAR2,
    table_p IN VARCHAR2
) RETURN VARCHAR2 AS
    v_user   VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_role   VARCHAR2(20);
BEGIN
    -- Cho phép toàn quyền nếu là admin
    IF v_user = 'PDB_ADMIN' THEN
        RETURN '1=1';

    ELSE
        -- Truy xuất vai trò nhân viên
        BEGIN
            SELECT VAITRO INTO v_role FROM NHANVIEN WHERE MANLD = v_user;

            IF v_role = 'NV CTSV' THEN
               IF SYS_CONTEXT('USERENV', 'CURRENT_SQL') LIKE '%INSERT%' THEN
            -- Cho phép INSERT nhưng buộc TINHTRANG = NULL
                RETURN 'TINHTRANG IS NULL';
            ELSE
            -- Cho phép SELECT, UPDATE (trừ cột TINHTRANG), DELETE
                RETURN '1=1';
        END IF;
            ELSE
                RETURN '1=0';  
            END IF;

        EXCEPTION
            WHEN NO_DATA_FOUND THEN
                RETURN '1=0';  -- Không tìm thấy nhân viên
        END;
    END IF;
END;
/



-- Xóa policy
BEGIN
  DBMS_RLS.DROP_POLICY(
    object_schema  => 'PDB_ADMIN',
    object_name    => 'SINHVIEN',
    policy_name    => 'SV_VPD_INS_DEL_POLICY'
  );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY (
        object_schema   => 'PDB_ADMIN',
        object_name     => 'SINHVIEN',
        policy_name     => 'SV_VPD_INS_DEL_POLICY',
        function_schema => 'PDB_ADMIN',
        policy_function => 'FUNC_SINHVIEN_INS_DEL',
        statement_types => 'INSERT,DELETE',
         update_check    => TRUE
    );
END;
/
