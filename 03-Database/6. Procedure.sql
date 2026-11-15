ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;

-- PHÂN HỆ 1
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------
-- Xem dữ liệu của role
CREATE OR REPLACE PROCEDURE GET_ROLES_INFO (p_cursor OUT SYS_REFCURSOR)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT 
            r.role AS "ROLE",
            CASE 
                WHEN r.authentication_type = 'PASSWORD' THEN 'Có mật khẩu'
                ELSE 'Không có mật khẩu'
            END AS "HAS_PASSWORD"
        FROM dba_roles r
        WHERE role NOT LIKE 'CDB$%'
  AND role NOT LIKE 'SYS%'
  AND role NOT LIKE 'AUDIT%'
  AND common = 'NO';
END GET_ROLES_INFO;
/

-------------------------------------------------------------------------------------
--- Tạo role mới
CREATE OR REPLACE PROCEDURE CREATE_NEW_ROLE (
    p_role_name IN VARCHAR2,
    p_password IN VARCHAR2,
    p_error OUT VARCHAR2
)
AS
    v_exists NUMBER;
BEGIN
    -- Kiểm tra nếu role đã tồn tại
    SELECT COUNT(*) 
    INTO v_exists 
    FROM dba_roles 
    WHERE role = UPPER(p_role_name)
    AND ROWNUM = 1;

    IF v_exists > 0 THEN
        p_error := 'Role ' || p_role_name || ' đã tồn tại.';
        RETURN;
    END IF;

    -- Tạo role
    IF p_password IS NULL OR TRIM(p_password) = '' THEN
        -- Không có mật khẩu
        EXECUTE IMMEDIATE 'CREATE ROLE "' || UPPER(p_role_name) || '"';
    ELSE
        -- Có mật khẩu
        EXECUTE IMMEDIATE 'CREATE ROLE "' || UPPER(p_role_name) || '" IDENTIFIED BY "' || p_password || '"';
    END IF;

    p_error := 'Role ' || p_role_name || ' được tạo thành công!'; -- Thành công
EXCEPTION
    WHEN OTHERS THEN
        p_error := 'Lỗi khi tạo role: ' || SQLERRM;
END CREATE_NEW_ROLE;
/

-------------------------------------------------------------------------------------
-- Xoá role 
CREATE OR REPLACE PROCEDURE DROP_EXISTING_ROLE (
    p_role_name IN VARCHAR2,
    p_error OUT VARCHAR2
)
AS
    v_exists NUMBER;
BEGIN
    -- Kiểm tra role có tồn tại không
    SELECT COUNT(*) 
    INTO v_exists 
    FROM dba_roles 
    WHERE role = UPPER(p_role_name)
    AND ROWNUM = 1;

    IF v_exists = 0 THEN
        p_error := 'Role ' || p_role_name || ' không tồn tại.';
        RETURN;
    END IF;

    -- Xoá role
    EXECUTE IMMEDIATE 'DROP ROLE "' || UPPER(p_role_name) || '"';

    p_error := 'Xoá thành công'; -- Không có lỗi
EXCEPTION
    WHEN OTHERS THEN
        p_error := 'Lỗi khi xoá role: ' || SQLERRM;
END DROP_EXISTING_ROLE;
/

-------------------------------------------------------------------------------------
-- Sửa mật khẩu cho role
CREATE OR REPLACE PROCEDURE UPDATE_ROLE_PASSWORD (
    p_role_name IN VARCHAR2,
    p_new_password IN VARCHAR2,
    p_result OUT VARCHAR2
)
AS
    v_role_exists NUMBER;
BEGIN
    -- Kiểm tra xem vai trò có tồn tại không
    SELECT COUNT(*) INTO v_role_exists
    FROM DBA_ROLES
    WHERE ROLE = UPPER(p_role_name);
    
    IF v_role_exists = 0 THEN
        p_result := 'Lỗi: Vai trò ' || p_role_name || ' không tồn tại.';
        RETURN;
    END IF;
    
    -- Cập nhật mật khẩu cho vai trò (bất kể trạng thái hiện tại)
    BEGIN
        EXECUTE IMMEDIATE 'ALTER ROLE ' || p_role_name || ' IDENTIFIED BY ' || p_new_password;
        p_result := 'Mật khẩu cho vai trò ' || p_role_name || ' đã được cập nhật thành công.';
    EXCEPTION
        WHEN OTHERS THEN
            p_result := 'Lỗi khi cập nhật mật khẩu cho vai trò ' || p_role_name || ': ' || SQLERRM;
    END;
    
EXCEPTION
    WHEN OTHERS THEN
        p_result := 'Lỗi: ' || SQLERRM;
END UPDATE_ROLE_PASSWORD;
/

-------------------------------------------------------------------------------------
-- Procedure kiểm tra tồn tại role/user
CREATE OR REPLACE PROCEDURE SP_KTRA_TON_TAI(
    p_grantee IN VARCHAR2,
    p_exists OUT NUMBER
)
AS
    v_count INTEGER := 0;
BEGIN
    -- Mặc định là không tồn tại
    p_exists := 0;

   SELECT COUNT(*) INTO v_count
    FROM DBA_ROLES
    WHERE ROLE = UPPER(p_grantee);

    IF v_count > 0 THEN
        p_exists := 2; -- Là ROLE
    ELSE
        -- Nếu không phải role, kiểm tra USER
        SELECT COUNT(*) INTO v_count
        FROM ALL_USERS
        WHERE USERNAME = UPPER(p_grantee);

        IF v_count > 0 THEN
            p_exists := 1; -- Là USER
        ELSE
            p_exists := 0; -- Không tồn tại
        END IF;
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        p_exists := 0;
END;
/
-------------------------------------------------------------------------------------
-- Procedure các quyền đã cấp trên bảng/view/functio/procedure cho 1 user/role
CREATE OR REPLACE PROCEDURE SP_TAB_DA_CAP (
    p_grantee IN VARCHAR2,
    p_result  OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_result FOR
    SELECT GRANTEE, OWNER, TABLE_NAME, PRIVILEGE, GRANTABLE, TYPE
    FROM DBA_TAB_PRIVS
    WHERE UPPER(GRANTEE) = UPPER(p_grantee);
END;
/

-------------------------------------------------------------------------------------
-- Procedure xác định role của user
CREATE OR REPLACE PROCEDURE SP_XAC_DINH_ROLE_CHO_USER (
    p_grantee IN VARCHAR2,
    p_result  OUT SYS_REFCURSOR
) AS
   
BEGIN
    OPEN p_result FOR
    SELECT GRANTEE, GRANTED_ROLE
    FROM DBA_ROLE_PRIVS
    WHERE UPPER(GRANTEE) = UPPER(p_grantee);

END;
/

-------------------------------------------------------------------------------------
-- Procedure các cột đã cấp cho 1 user/role
CREATE OR REPLACE PROCEDURE SP_COL_DA_CAP (
    p_grantee IN VARCHAR2,
    p_result  OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_result FOR
    SELECT GRANTEE, TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, PRIVILEGE, GRANTABLE
    FROM ALL_COL_PRIVS
    WHERE UPPER(GRANTEE) = UPPER(p_grantee);
END;
/

-------------------------------------------------------------------------------------
-- Procedure thu hồi quyền trên tab
CREATE OR REPLACE PROCEDURE SP_THU_HOI_QUYEN_TAB(
    p_grantee IN VARCHAR2,
    p_owner IN VARCHAR2,
    p_table IN VARCHAR2,
    p_priv IN VARCHAR2
) AS
BEGIN
    EXECUTE IMMEDIATE 
    'REVOKE ' || p_priv || ' ON ' || p_owner || '.' || p_table || ' FROM ' || p_grantee;
END;
/

-------------------------------------------------------------------------------------
-- Procedure thu hồi quyền trên cột
CREATE OR REPLACE PROCEDURE SP_THU_HOI_QUYEN_COL(
    p_grantee IN VARCHAR2,
    p_owner IN VARCHAR2,
    p_table IN VARCHAR2,
    p_col IN VARCHAR2,
    p_priv IN VARCHAR2
) AS
BEGIN
    EXECUTE IMMEDIATE 
    'REVOKE ' || p_priv || '(' || p_col || ')' || ' ON ' || p_owner || '.' || p_table || ' FROM ' || p_grantee;
END;
/

-------------------------------------------------------------------------------------
-- Procedure thu hồi quyền update trên cột
CREATE OR REPLACE PROCEDURE SP_THU_HOI_QUYEN_UPDATE_COL (
    p_grantee IN VARCHAR2,
    p_owner   IN VARCHAR2,
    p_table   IN VARCHAR2,
    p_col     IN VARCHAR2
) AS
    v_all_columns  VARCHAR2(1000);
    v_remain_cols  VARCHAR2(1000);
    v_sql          VARCHAR2(2000);
BEGIN
    -- Lấy toàn bộ cột đang được cấp quyền UPDATE trước khi REVOKE
    SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_NAME)
    INTO v_all_columns
    FROM ALL_COL_PRIVS
    WHERE GRANTEE = UPPER(p_grantee)
      AND TABLE_SCHEMA = UPPER(p_owner)
      AND TABLE_NAME = UPPER(p_table)
      AND PRIVILEGE = 'UPDATE';

    -- Loại bỏ cột cần thu hồi khỏi danh sách
    IF v_all_columns IS NOT NULL THEN
        -- Tách và loại bỏ cột cần thu hồi
        SELECT LISTAGG(COLUMN_NAME, ',') WITHIN GROUP (ORDER BY COLUMN_NAME)
        INTO v_remain_cols
        FROM (
            SELECT COLUMN_NAME
            FROM ALL_COL_PRIVS
            WHERE GRANTEE = UPPER(p_grantee)
              AND TABLE_SCHEMA = UPPER(p_owner)
              AND TABLE_NAME = UPPER(p_table)
              AND PRIVILEGE = 'UPDATE'
              AND COLUMN_NAME <> UPPER(p_col)
        );

        EXECUTE IMMEDIATE 
            'REVOKE UPDATE ON ' || p_owner || '.' || p_table || ' FROM ' || p_grantee;

        -- Cấp lại quyền UPDATE cho các cột còn lại
        IF v_remain_cols IS NOT NULL THEN
            v_sql := 'GRANT UPDATE(' || v_remain_cols || ') ON ' || p_owner || '.' || p_table || ' TO ' || p_grantee;
            EXECUTE IMMEDIATE v_sql;
        END IF;
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20001, 'Thu hồi quyền thất bại: ' || SQLERRM);
END;
/

-------------------------------------------------------------------------------------
-- Procedure thu hồi role
CREATE OR REPLACE PROCEDURE SP_THU_HOI_ROLE(
    p_grantee IN VARCHAR2,
    p_role IN VARCHAR2
) AS
BEGIN
    EXECUTE IMMEDIATE 
    'REVOKE ' || p_role || ' FROM ' || p_grantee;
END;
/

-------------------------------------------------------------------------------------
-- Load cột của bảng 
CREATE OR REPLACE PROCEDURE get_columns_by_table(
    p_table_name IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT column_name
        FROM user_tab_columns
        WHERE table_name = UPPER(p_table_name);
END;
/

-------------------------------------------------------------------------------------
-- Load role
CREATE OR REPLACE PROCEDURE get_custom_roles(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT role FROM dba_roles
        WHERE oracle_maintained = 'N'
        ORDER BY role;
END;
/
-------------------------------------------------------------------------------------
--Cập nhật mật khẩu
CREATE OR REPLACE PROCEDURE UpdateUserPassword(
    p_username IN VARCHAR2,
    p_new_password IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'ALTER USER ' || p_username || ' IDENTIFIED BY "' || p_new_password || '"';
END;
/

-------------------------------------------------------------------------------------
--Mở khóa tài khoản
CREATE OR REPLACE PROCEDURE LockUserAccount(
    p_username IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'ALTER USER ' || p_username || ' ACCOUNT LOCK';
END;
/

-------------------------------------------------------------------------------------
--Khóa tài khoản
CREATE OR REPLACE PROCEDURE UnlockUserAccount(
    p_username IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'ALTER USER ' || p_username || ' ACCOUNT UNLOCK';
END;
/

-------------------------------------------------------------------------------------
--Lấy trạng thái tài khoản
CREATE OR REPLACE PROCEDURE GetUserStatus(
    p_username IN VARCHAR2,
    p_status OUT VARCHAR2
)
AS
BEGIN
    SELECT ACCOUNT_STATUS INTO p_status
    FROM DBA_USERS
    WHERE USERNAME = UPPER(p_username);
END;
/

-------------------------------------------------------------------------------------
--Tạo user
CREATE OR REPLACE PROCEDURE CreateUser(
    p_username IN VARCHAR2,
    p_password IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'CREATE USER ' || p_username || ' IDENTIFIED BY "' || p_password || '"';
END;
/

-------------------------------------------------------------------------------------
--Gán quyền
CREATE OR REPLACE PROCEDURE GrantBasicPrivileges(
    p_username IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO ' || p_username;
END;
/

-------------------------------------------------------------------------------------
--Lấy danh sách user
CREATE OR REPLACE PROCEDURE GetUserList(p_cursor OUT SYS_REFCURSOR)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT USERNAME
        FROM DBA_USERS
        WHERE ORACLE_MAINTAINED = 'N'
          AND USERNAME NOT IN ('SYS', 'SYSTEM')
          AND USERNAME NOT LIKE 'PDB_ADMIN'
        ORDER BY USERNAME;
END;
/

-------------------------------------------------------------------------------------
--Drop User
CREATE OR REPLACE PROCEDURE DropUser(p_username IN VARCHAR2)
AS
BEGIN
    EXECUTE IMMEDIATE 'DROP USER ' || p_username || ' CASCADE';
END;
/

--Kill session
CREATE OR REPLACE PROCEDURE KillUserSessions(p_username IN VARCHAR2)
AS
BEGIN
    FOR session IN (
        SELECT SID, SERIAL#
        FROM V$SESSION
        WHERE USERNAME = UPPER(p_username)
    )
    LOOP
        EXECUTE IMMEDIATE 'ALTER SYSTEM KILL SESSION ''' || session.SID || ',' || session.SERIAL# || ''' IMMEDIATE';
    END LOOP;
END;
/


-- PHÂN HỆ 2
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

-- ------------------------------------ YÊU CẦU 1 ----------------------------------------
-- =========================NVCB==========================================
-- proc lấy thông tin nhân viên cơ bản 
CREATE OR REPLACE PROCEDURE SP_GET_NVCB_EDIT (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, VAITRO, MADV
        FROM NVCB_EDIT;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_GET_NVCB_EDIT TO NVCB; 

 -- proc update số điện thoại
CREATE OR REPLACE PROCEDURE SP_UPDATE_DT_NVCB (
    p_new_dt IN VARCHAR2,
    p_result OUT VARCHAR2
)
AS
BEGIN
    UPDATE NVCB_EDIT
    SET DT = p_new_dt;

    IF SQL%ROWCOUNT = 0 THEN
        p_result := 'Lỗi: Không có dòng nào được cập nhật.';
    ELSE
        p_result := 'Cập nhật số điện thoại thành công.';
        COMMIT;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        p_result := 'Lỗi: ' || SQLERRM;
        ROLLBACK;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_UPDATE_DT_NVCB TO NVCB;

-- =========================NV CTSV==========================================
-- proc lấy thông tin sinh viên
CREATE OR REPLACE PROCEDURE SP_GET_SINHVIEN (
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT * FROM SINHVIEN;
EXCEPTION
    WHEN OTHERS THEN
        CLOSE p_result;
        RAISE;
END SP_GET_SINHVIEN;
/
GRANT EXECUTE ON PDB_Admin.SP_GET_SINHVIEN TO NV_CTSV;

-- proc thêm sinh viên
CREATE OR REPLACE PROCEDURE SP_INSERT_SINHVIEN (
    p_masv       IN VARCHAR2,
    p_hoten      IN VARCHAR2,
    p_phai       IN VARCHAR2,
    p_ngaysinh   IN DATE,
    p_diachi     IN VARCHAR2,
    p_sdt        IN VARCHAR2,
    p_khoa       IN VARCHAR2,
    p_result     OUT VARCHAR2
) AS
BEGIN
    INSERT INTO SINHVIEN (
        MASV, HOTEN, PHAI, NGSINH, DCHI, DT, KHOA
    )
    VALUES (
        p_masv, p_hoten, p_phai, p_ngaysinh, p_diachi, p_sdt, p_khoa
    );
    COMMIT;
    p_result := 'Thêm mới sinh viên thành công.';
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK; -- Đảm bảo rollback
        p_result := 'Lỗi thêm mới: ' || SQLERRM;
END SP_INSERT_SINHVIEN;
/
GRANT EXECUTE ON PDB_ADMIN.SP_INSERT_SINHVIEN TO NV_CTSV;

-- proc xóa sinh viên
CREATE OR REPLACE PROCEDURE SP_DELETE_SINHVIEN (
    p_masv   IN VARCHAR2,
    p_result OUT VARCHAR2
) AS
BEGIN
    DELETE FROM SINHVIEN
    WHERE MASV = p_masv;
    IF SQL%ROWCOUNT > 0 THEN
        COMMIT;
        p_result := 'Xóa sinh viên thành công.';
    ELSE
        ROLLBACK;
        p_result := 'Không tìm thấy sinh viên có mã ' || p_masv;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        p_result := 'Lỗi xóa: ' || SQLERRM;
END SP_DELETE_SINHVIEN;
/
GRANT EXECUTE ON PDB_ADMIN.SP_DELETE_SINHVIEN TO NV_CTSV;


-- proc sửa sinh viên
CREATE OR REPLACE PROCEDURE SP_UPDATE_SINHVIEN (
    p_masv IN VARCHAR2, p_hoten IN VARCHAR2, p_phai IN VARCHAR2, p_ngaysinh IN DATE,
    p_diachi IN VARCHAR2, p_sdt IN VARCHAR2, p_khoa IN VARCHAR2, p_result OUT VARCHAR2
) AS
BEGIN
    UPDATE SINHVIEN
    SET HOTEN = p_hoten, PHAI = p_phai, NGSINH = p_ngaysinh, DCHI = p_diachi, DT = p_sdt, KHOA = p_khoa
    WHERE MASV = p_masv;
    
    IF SQL%ROWCOUNT > 0 THEN
        COMMIT;
        p_result := 'Cập nhật sinh viên thành công';     
    ELSE
        p_result := 'Không tìm thấy sinh viên để cập nhật';
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        p_result := 'Lỗi cập nhật sinh viên: ' || SQLERRM;    
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_UPDATE_SINHVIEN TO NV_CTSV;

-- =========================NV PKT==========================================
-- proc lấy thông tin sinh viên đã đăng ký môn học
CREATE OR REPLACE PROCEDURE SP_VIEW_DANGKY (
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT * FROM DANGKY;
EXCEPTION
    WHEN OTHERS THEN
        p_result := NULL;
END SP_VIEW_DANGKY;
/

GRANT EXECUTE ON PDB_ADMIN.SP_VIEW_DANGKY TO NV_PKT;

-- proc chỉnh sửa điểm sinh viên
CREATE OR REPLACE PROCEDURE SP_UPDATE_DIEM (
    p_masv IN VARCHAR2,
    p_mamm IN VARCHAR2,
    p_diemth IN NUMBER,
    p_diemqt IN NUMBER,
    p_diemck IN NUMBER,
    p_diemtk IN NUMBER,
    p_result OUT VARCHAR2
) AS
BEGIN

    -- Kiểm tra dữ liệu đầu vào
    IF p_masv IS NULL OR p_mamm IS NULL THEN
        p_result := 'Lỗi: MASV và MAMM không được để trống.';
        RETURN;
    END IF;

    IF p_diemth < 0 OR p_diemth > 10 OR
       p_diemqt < 0 OR p_diemqt > 10 OR
       p_diemck < 0 OR p_diemck > 10 OR
       p_diemtk < 0 OR p_diemtk > 10 THEN
        p_result := 'Lỗi: Điểm số phải nằm trong khoảng từ 0 đến 10.';
        RETURN;
    END IF;

    -- Cập nhật điểm số trong bảng DANGKY
    UPDATE DANGKY
    SET DIEMTH = p_diemth,
        DIEMQT = p_diemqt,
        DIEMCK = p_diemck,
        DIEMTK = p_diemtk
    WHERE MASV = p_masv AND MAMM = p_mamm;

    -- Kiểm tra xem có bản ghi nào được cập nhật không
    IF SQL%ROWCOUNT > 0 THEN
        p_result := 'Cập nhật điểm số thành công cho MASV: ' || p_masv || ', MAMM: ' || p_mamm;
        COMMIT;
    ELSE
        p_result := 'Không tìm thấy bản ghi đăng ký để cập nhật.';
        ROLLBACK;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        p_result := 'Lỗi khi cập nhật điểm số: ' || SQLERRM;
        ROLLBACK;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_UPDATE_DIEM TO NV_PKT;

-- ========================= PDT =========================

-- =============== MO MON
-- Procedure thêm mở môn 
CREATE OR REPLACE PROCEDURE SP_PDT_THEM_MOMON(
  p_mamm MOMON.MAMM%TYPE,
  p_mahp MOMON.MAHP%TYPE,
  p_magv MOMON.MAGV%TYPE
)
IS
BEGIN
  INSERT INTO MOMON (MAMM, MAHP, MAGV, HK, NAM)
  VALUES (p_mamm, p_mahp, p_magv,
          CASE 
            WHEN EXTRACT(MONTH FROM SYSDATE) >= 9 THEN 1
            WHEN EXTRACT(MONTH FROM SYSDATE) >= 5 THEN 3
            ELSE 2
          END,
          EXTRACT(YEAR FROM SYSDATE));
    COMMIT;
END;
/

--GRANT INSERT ON PDB_ADMIN.MOMON TO NV_PDT;
GRANT EXECUTE ON PDB_ADMIN.SP_PDT_THEM_MOMON TO NV_PDT;


-- Procedure xóa mở môn
CREATE OR REPLACE PROCEDURE SP_PDT_XOAMM (
p_mamm IN MOMON.MAMM%TYPE)
IS 
BEGIN
    DELETE FROM PDB_ADMIN.MOMON WHERE MAMM=p_mamm;
    COMMIT;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_PDT_XOAMM TO NV_PDT;
--GRANT DELETE ON PDB_ADMIN.MOMON TO NV_PDT;

-- Procedure sửa mở môn
CREATE OR REPLACE PROCEDURE SP_PDT_SUAMM (
p_mamm IN MOMON.MAMM%TYPE,
p_magv IN MOMON.MAGV%TYPE,
p_mahp IN MOMON.MAHP%TYPE)
IS 
BEGIN
    UPDATE MOMON 
    SET MAHP = p_mahp,
        MAGV = p_magv
    WHERE MAMM = p_mamm;
    COMMIT;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_PDT_SUAMM TO NV_PDT;
--GRANT UPDATE ON PDB_ADMIN.MOMON TO NV_PDT;

-- =============== DANG KY
-- Tạo view xem mã sinh viên và họ tên
CREATE OR REPLACE VIEW V_PDT_XEMSV AS
SELECT  MASV, HOTEN
FROM SINHVIEN;

-- Procedure xem danh sách sinh viên
CREATE OR REPLACE PROCEDURE SP_PDT_XEMSV (
    p_masv   IN VARCHAR2 DEFAULT NULL,
    p_cursor OUT SYS_REFCURSOR
)
AS
    v_sql   VARCHAR2(1000);
BEGIN
    v_sql := 'SELECT * FROM V_PDT_XEMSV';

    IF p_masv IS NOT NULL THEN
        v_sql := v_sql || ' WHERE MASV = :masv';
        OPEN p_cursor FOR v_sql USING p_masv;
    ELSE
        OPEN p_cursor FOR v_sql;
    END IF;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_PDT_XEMSV TO NV_PDT;

-- Procedure xem danh sách môn học đã đăng ký
CREATE OR REPLACE PROCEDURE SP_PDT_CAC_MMDADK (
    p_masv   IN VARCHAR2,
    p_hk     IN NUMBER,
    p_nam    IN NUMBER,
    p_khoa   IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
   OPEN p_cursor FOR
    SELECT DK.MAMM, V.MAHP, V.TENHP, DK.MASV, S.HOTEN, DK.DIEMTH, DK.DIEMQT, DK.DIEMCK, DK.DIEMTK
    FROM DANGKY DK
    JOIN PDB_ADMIN.V_PDT_XEMMOMON V ON DK.MAMM = V.MAMM
    JOIN PDB_ADMIN.V_PDT_XEMSV S ON S.MASV = DK.MASV 
    WHERE
        V.HK = p_hk
        AND V.NAM = p_nam
        AND (p_masv IS NULL OR DK.MASV = p_masv)
        AND (p_khoa IS NULL OR V.MADV = p_khoa);
END;
/

 GRANT EXECUTE ON PDB_ADMIN.SP_PDT_CAC_MMDADK TO NV_PDT;

-- =============== SINH VIEN

 CREATE OR REPLACE PROCEDURE SP_PDT_SUA_TINHTRANG (
    p_masv      IN SINHVIEN.MASV%TYPE,
    p_tinhtrang IN SINHVIEN.TINHTRANG%TYPE
)
AS
BEGIN
   -- Nếu tồn tại, cập nhật tình trạng
    UPDATE SINHVIEN
    SET TINHTRANG = p_tinhtrang
    WHERE MASV = p_masv;

    COMMIT;


EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE_APPLICATION_ERROR(-20002, 'Lỗi khi cập nhật tình trạng: ' || SQLERRM);
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_PDT_SUA_TINHTRANG TO NV_PDT;

-- ========================= TCHC =========================
-- Procedure xem ds học phần của 1 đơn vị
CREATE OR REPLACE PROCEDURE SP_TCHC_XEMDV (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT MADV FROM DONVI;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_TCHC_XEMDV TO NV_TCHC;

-- Proc xem danh sách nhân viên
CREATE OR REPLACE PROCEDURE SP_GET_NHANVIEN (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT * FROM NHANVIEN;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_GET_NHANVIEN TO NV_TCHC;

-- Proc thêm nhân viên
CREATE OR REPLACE PROCEDURE SP_INSERT_NHANVIEN (
    p_manld   IN VARCHAR2,
    p_hoten   IN VARCHAR2,
    p_phai    IN VARCHAR2,
    p_ngsinh  IN DATE,
    p_luong   IN NUMBER,
    p_phucap  IN NUMBER,
    p_dt      IN VARCHAR2,
    p_vaitro  IN VARCHAR2,
    p_madv    IN VARCHAR2,
    p_result  OUT VARCHAR2
)
AS
BEGIN
    INSERT INTO NHANVIEN (
        MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, VAITRO, MADV
    ) VALUES (
        p_manld, p_hoten, p_phai, p_ngsinh, p_luong, p_phucap, p_dt, p_vaitro, p_madv
    );

    p_result := 'Thêm nhân viên thành công.';
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        p_result := 'Lỗi thêm nhân viên: ' || SQLERRM;
        ROLLBACK;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_INSERT_NHANVIEN TO NV_TCHC;


-- Proc xóa nhân viên
CREATE OR REPLACE PROCEDURE SP_DELETE_NHANVIEN (
    p_manld IN VARCHAR2,
    p_result OUT VARCHAR2
)
AS
BEGIN
    DELETE FROM NHANVIEN WHERE MANLD = p_manld;

    IF SQL%ROWCOUNT = 0 THEN
        p_result := 'Không tìm thấy nhân viên để xoá.';
    ELSE
        p_result := 'Xoá nhân viên thành công.';
        COMMIT;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        p_result := 'Lỗi xoá nhân viên: ' || SQLERRM;
        ROLLBACK;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_DELETE_NHANVIEN TO NV_TCHC;

-- Proc sửa nhân viên
CREATE OR REPLACE PROCEDURE SP_UPDATE_NHANVIEN (
    p_manld   IN VARCHAR2,
    p_hoten   IN VARCHAR2,
    p_phai    IN VARCHAR2,
    p_ngsinh  IN DATE,
    p_luong   IN NUMBER,
    p_phucap  IN NUMBER,
    p_dt      IN VARCHAR2,
    p_vaitro  IN VARCHAR2,
    p_madv    IN VARCHAR2,
    p_result  OUT VARCHAR2
)
AS
BEGIN
    UPDATE NHANVIEN
    SET
        HOTEN = p_hoten,
        PHAI = p_phai,
        NGSINH = p_ngsinh,
        LUONG = p_luong,
        PHUCAP = p_phucap,
        DT = p_dt,
        VAITRO = p_vaitro,
        MADV = p_madv
    WHERE MANLD = p_manld;

    IF SQL%ROWCOUNT = 0 THEN
        p_result := 'Không tìm thấy nhân viên để cập nhật.';
    ELSE
        p_result := 'Cập nhật nhân viên thành công.';
        COMMIT;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        p_result := 'Lỗi cập nhật nhân viên: ' || SQLERRM;
        ROLLBACK;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_UPDATE_NHANVIEN TO NV_TCHC;

-- ========================= TRGDV =========================
-- Proc xem danh sách nhân viên trong đơn vị
CREATE OR REPLACE PROCEDURE SP_TRGDV_XEMDSNV (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT * FROM PDB_ADMIN.V_TRGDVI_TTNVIEN;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_TRGDV_XEMDSNV TO TRGDV;


-- Proc xem danh sách phân công
CREATE OR REPLACE PROCEDURE SP_TRGDV_XEMDSPC (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT * FROM PDB_ADMIN.V_TRGDVI_DSPHANCONG;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_TRGDV_XEMDSPC TO TRGDV;

-- ========================= GIAO VIEN =========================

-- Proc xem danh sách lớp
CREATE OR REPLACE PROCEDURE SP_LayDSLop(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT * FROM pdb_admin.momon_gv_view;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_LayDSLop TO ROLE_GV;

-- Proc xem danh sách học sinh
CREATE OR REPLACE PROCEDURE SP_LayDSHocSinh(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT MASV, HOTEN, PHAI, NGSINH, DCHI, DT, KHOA, TINHTRANG
    FROM pdb_admin.SINHVIEN;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_LayDSHocSinh TO ROLE_GV;

-- Proc xem danh sách đăng ký
CREATE OR REPLACE PROCEDURE SP_GetDangKyData(
    p_mamm IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT * 
    FROM pdb_admin.DANGKY
    WHERE MAMM = p_mamm;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_GetDangKyData TO ROLE_GV;


-- ========================= SINHVIEN =========================

-- Proc xem thông tin sinh viên
CREATE OR REPLACE PROCEDURE PROC_GET_MYINFO (
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT * FROM pdb_admin.SINHVIEN;
END;
/
GRANT EXECUTE ON PDB_ADMIN.PROC_GET_MYINFO TO ROLE_SINHVIEN;

-- Proc chỉnh sửa DT sinh viên
CREATE OR REPLACE PROCEDURE PROC_UPDATE_CONTACT (
    p_dchi IN VARCHAR2,
    p_dt   IN VARCHAR2
)
IS
BEGIN
    IF p_dchi IS NOT NULL THEN
        UPDATE pdb_admin.SINHVIEN
        SET DCHI = p_dchi;
    END IF;

    IF p_dt IS NOT NULL THEN
        UPDATE pdb_admin.SINHVIEN
        SET DT = p_dt;
    END IF;

    COMMIT;
END;
/
GRANT EXECUTE ON PDB_ADMIN.PROC_UPDATE_CONTACT TO ROLE_SINHVIEN;

-- Proc xem mở môn trong khoa
CREATE OR REPLACE PROCEDURE SP_GET_MOMON_SV (
    p_result OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_result FOR
    SELECT 
        v.HK,
        v.NAM,
        v.MAMM,
        v.MAHP,
        v.TENHP,
        d.DIEMTH,
        d.DIEMQT,
        d.DIEMCK,
        d.DIEMTK
    FROM pdb_admin.V_MOMON_SINHVIEN v
    INNER JOIN pdb_admin.DANGKY d ON v.MAMM = d.MAMM;
END;
/
GRANT EXECUTE ON PDB_ADMIN.SP_GET_MOMON_SV TO ROLE_SINHVIEN;

-- Proc xóa đăng ký
CREATE OR REPLACE PROCEDURE SP_XOA_DANGKY (
    p_mamm IN VARCHAR2,
    p_masv IN VARCHAR2 DEFAULT NULL,
    p_deleted_count OUT NUMBER
) AS
    v_masv VARCHAR2(50);
BEGIN
    -- Nếu p_masv không được truyền vào (NULL), lấy MASV từ SESSION_USER
    IF p_masv IS NULL THEN
        v_masv := SYS_CONTEXT('USERENV', 'SESSION_USER');
    ELSE
        v_masv := p_masv;
    END IF;

    DELETE FROM PDB_ADMIN.DANGKY
    WHERE MAMM = p_mamm
      AND MASV = v_masv;

    p_deleted_count := SQL%ROWCOUNT;

    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        p_deleted_count := 0;
        RAISE;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_XOA_DANGKY TO ROLE_SINHVIEN;
GRANT EXECUTE ON PDB_ADMIN.SP_XOA_DANGKY TO NV_PDT;


-- Proc để đăng ký nhiều mở môn - sinh viên 
CREATE OR REPLACE PROCEDURE SP_DANGKY_NHIEU (
    p_masvs IN VARCHAR2,  -- 'SV1,SV2'
    p_mamms IN VARCHAR2   -- 'MM1,MM2'
)
AS
    TYPE T_STR_TABLE IS TABLE OF VARCHAR2(20);

    v_svs T_STR_TABLE := T_STR_TABLE();  -- khởi tạo ngay
    v_mms T_STR_TABLE := T_STR_TABLE();

    -- Hàm nội bộ tách chuỗi
    PROCEDURE split_csv(p_str IN VARCHAR2, p_list IN OUT T_STR_TABLE) IS
        v_token VARCHAR2(20);
        v_start PLS_INTEGER := 1;
        v_idx   PLS_INTEGER := 1;
        v_pos   PLS_INTEGER;
    BEGIN
        p_list.DELETE;  -- Xóa nếu đã có dữ liệu cũ
        LOOP
            v_pos := INSTR(p_str, ',', v_start);
            IF v_pos > 0 THEN
                v_token := TRIM(SUBSTR(p_str, v_start, v_pos - v_start));
                p_list.EXTEND;
                p_list(v_idx) := v_token;
                v_idx := v_idx + 1;
                v_start := v_pos + 1;
            ELSE
                v_token := TRIM(SUBSTR(p_str, v_start));
                IF v_token IS NOT NULL THEN
                    p_list.EXTEND;
                    p_list(v_idx) := v_token;
                END IF;
                EXIT;
            END IF;
        END LOOP;
    END;

BEGIN
    -- Gọi hàm tách chuỗi
    IF p_masvs IS NULL OR TRIM(p_masvs) IS NULL THEN
    v_svs.EXTEND;
    v_svs(1) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    ELSE
     split_csv(p_masvs, v_svs);
    END IF;


    split_csv(p_mamms, v_mms);

    -- Lặp tất cả MASV x MAMM
    FOR i IN 1..v_svs.COUNT LOOP
        FOR j IN 1..v_mms.COUNT LOOP
            BEGIN
                INSERT INTO DANGKY(MASV, MAMM)
                VALUES (v_svs(i), v_mms(j));
            EXCEPTION
                WHEN DUP_VAL_ON_INDEX THEN NULL;  -- Bỏ qua nếu đã có
            END;
        END LOOP;
    END LOOP;

    COMMIT;
END;
/

GRANT EXECUTE ON PDB_ADMIN.SP_DANGKY_NHIEU TO NV_PDT;
GRANT EXECUTE ON PDB_ADMIN.SP_DANGKY_NHIEU TO ROLE_SINHVIEN;


-- ------------------------------------ YÊU CẦU 2 ----------------------------------------

-- OLS
CREATE OR REPLACE PROCEDURE SP_XEMTHONGBAO(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT * 
    FROM pdb_admin.THONGBAO;
END;
/

-------------------------------- SỬA ----------------------
CREATE OR REPLACE PROCEDURE GET_OBJECTS_BY_TYPE (
    p_object_type IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT object_name
        FROM user_objects
        WHERE object_type = UPPER(p_object_type)
        ORDER BY object_name;
END;
/

CREATE OR REPLACE PROCEDURE GRANT_PRIVS_TO_USER(
    p_user          IN VARCHAR2,
    p_table         IN VARCHAR2 DEFAULT NULL, -- Tên object: TABLE/VIEW/FUNCTION/PROCEDURE
    p_insert        IN NUMBER DEFAULT 0,
    p_delete        IN NUMBER DEFAULT 0,
    p_select        IN NUMBER DEFAULT 0,
    p_update        IN NUMBER DEFAULT 0,
    p_select_cols   IN VARCHAR2 DEFAULT NULL,
    p_update_cols   IN VARCHAR2 DEFAULT NULL,
    p_role          IN VARCHAR2 DEFAULT NULL,
    p_with_grant    IN NUMBER DEFAULT 0,
    p_object_type   IN VARCHAR2 DEFAULT NULL
) IS
    v_sql        VARCHAR2(4000);
    v_view_name  VARCHAR2(100);
    v_suffix     VARCHAR2(30);
BEGIN
    -- WITH GRANT OPTION nếu được chọn
    v_suffix := CASE WHEN p_with_grant = 1 THEN ' WITH GRANT OPTION' ELSE '' END;

    -- Cấp quyền ROLE nếu có
    IF p_role IS NOT NULL THEN
        v_sql := 'GRANT ' || p_role || ' TO ' || p_user;
        EXECUTE IMMEDIATE v_sql;
    END IF;

    -- Xử lý theo OBJECT_TYPE nếu có
    IF p_object_type IS NOT NULL THEN
        CASE UPPER(p_object_type)

            WHEN 'TABLE' THEN
                IF p_insert = 1 THEN
                    EXECUTE IMMEDIATE 'GRANT INSERT ON ' || p_table || ' TO ' || p_user || v_suffix;
                END IF;

                IF p_delete = 1 THEN
                    EXECUTE IMMEDIATE 'GRANT DELETE ON ' || p_table || ' TO ' || p_user || v_suffix;
                END IF;

                IF p_select = 1 THEN
                    IF p_select_cols IS NOT NULL THEN
                        v_view_name := 'V_' || UPPER(p_user) || '_' || UPPER(p_table);
                        v_sql := 'CREATE OR REPLACE VIEW ' || v_view_name || ' AS SELECT ' || p_select_cols || ' FROM ' || p_table;
                        EXECUTE IMMEDIATE v_sql;

                        v_sql := 'GRANT SELECT ON ' || v_view_name || ' TO ' || p_user || v_suffix;
                    ELSE
                        v_sql := 'GRANT SELECT ON ' || p_table || ' TO ' || p_user || v_suffix;
                    END IF;
                    EXECUTE IMMEDIATE v_sql;
                END IF;

                IF p_update = 1 THEN
                    IF p_update_cols IS NOT NULL THEN
                        v_sql := 'GRANT UPDATE (' || p_update_cols || ') ON ' || p_table || ' TO ' || p_user || v_suffix;
                    ELSE
                        v_sql := 'GRANT UPDATE ON ' || p_table || ' TO ' || p_user || v_suffix;
                    END IF;
                    EXECUTE IMMEDIATE v_sql;
                END IF;

            WHEN 'VIEW' THEN
                IF p_select = 1 THEN
                    IF p_select_cols IS NOT NULL THEN
                        v_view_name := 'V_' || UPPER(p_user) || '_' || UPPER(p_table);
                        v_sql := 'CREATE OR REPLACE VIEW ' || v_view_name || ' AS SELECT ' || p_select_cols || ' FROM ' || p_table;
                        EXECUTE IMMEDIATE v_sql;

                        v_sql := 'GRANT SELECT ON ' || v_view_name || ' TO ' || p_user || v_suffix;
                    ELSE
                        v_sql := 'GRANT SELECT ON ' || p_table || ' TO ' || p_user || v_suffix;
                    END IF;
                    EXECUTE IMMEDIATE v_sql;
                END IF;

                IF p_update = 1 THEN
                    IF p_update_cols IS NOT NULL THEN
                        v_sql := 'GRANT UPDATE (' || p_update_cols || ') ON ' || p_table || ' TO ' || p_user || v_suffix;
                    ELSE
                        v_sql := 'GRANT UPDATE ON ' || p_table || ' TO ' || p_user || v_suffix;
                    END IF;
                    EXECUTE IMMEDIATE v_sql;
                END IF;

                IF p_insert = 1 THEN
                    EXECUTE IMMEDIATE 'GRANT INSERT ON ' || p_table || ' TO ' || p_user || v_suffix;
                END IF;

                IF p_delete = 1 THEN
                    EXECUTE IMMEDIATE 'GRANT DELETE ON ' || p_table || ' TO ' || p_user || v_suffix;
                END IF;

            WHEN 'FUNCTION' THEN
                v_sql := 'GRANT EXECUTE ON ' || p_table || ' TO ' || p_user || v_suffix;
                EXECUTE IMMEDIATE v_sql;

            WHEN 'PROCEDURE' THEN
                v_sql := 'GRANT EXECUTE ON ' || p_table || ' TO ' || p_user || v_suffix;
                EXECUTE IMMEDIATE v_sql;

            ELSE
                RAISE_APPLICATION_ERROR(-20001, 'Loại đối tượng không hỗ trợ: ' || p_object_type);

        END CASE;
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20003, 'Lỗi trong GRANT_PRIVS_TO_USER: ' || SQLERRM);
END;
/

-- Proc xem danh sách thông báo
CREATE OR REPLACE PROCEDURE SP_XEMTHONGBAO(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT T.ID, T.NOIDUNG, L.LABEL
    FROM pdb_admin.THONGBAO T
    JOIN all_sa_labels L ON T.LABEL = L.LABEL_TAG;
END;
/

