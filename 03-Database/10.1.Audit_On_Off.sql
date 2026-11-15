--BẬT/ TẮT AUDIT
--7.1. Kích hoạt việc ghi nhật ký hệ thống. 
--============================================================================================================================
-- BẬT
-- Chạy lệnh trên sys
SHOW PARAMETER audit_trail;
--TH1: nếu trả về FALSE: Audit truyền thống được bật và và unified auditing bị vô hiệu hóa (disable)
-- Trên sys (sql plus: username sys as sysdba)
alter system set audit_sys_operations=TRUE scope=spfile;
alter system set audit_trail=DB,EXTENDED scope=spfile;
SHUTDOWN IMMEDIATE;
STARTUP;
-- Mở lại tất cả các PDB
ALTER PLUGGABLE DATABASE ALL OPEN;

--TH2: nếu trả về TRUE: dùng chung duy nhất 1 bảng UNIFIED_AUDIT_TRAIL cho cả ba loại audit: standard, FGA, unified)
-- Trên sys: 
ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;
GRANT AUDIT_ADMIN TO PDB_ADMIN;--Cho phép quản trị chính sách AUDIT: bật/tắt AUDIT, tạo policy, cấu hình...
GRANT AUDIT_VIEWER TO PDB_ADMIN;--Cho phép xem các bản ghi nhật ký audit trên UNIFIED_AUDIT_TRAIL
GRANT DBA TO PDB_ADMIN;

-- Tắt SQLDeveloper
-- Đăng nhập tài khoản admin: pdb_admin để kiểm tra
ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;

-- Kiểm tra có 2 quyền: audit system, audit any
SELECT * FROM session_privs WHERE privilege LIKE '%AUDIT%';
--=============================================================================================================================
--TẮT
--TH1: Phiên bản dưới 21c trở xuống (sys)
alter system set audit_sys_operations=FALSE scope=spfile;
alter system set audit_trail=NONE scope=spfile;
SHUTDOWN IMMEDIATE;
STARTUP;

--TH2: Phiên bản oracle 21c (pdb_admin: chạy script cho bật tắt)
-- Tắt toàn bộ audit đã bật standard audit
BEGIN
  EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY';
  EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON NHANVIEN';
  EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON DONVI';
  EXECUTE IMMEDIATE 'NOAUDIT SELECT ON DANGKY_VIEW';
  EXECUTE IMMEDIATE 'NOAUDIT EXECUTE ON UPDATE_DANGKY_GRADE';
EXCEPTION
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('Lỗi khi tắt audit: ' || SQLERRM);
END;
/

DECLARE
  v_action VARCHAR2(10) := 'ENABLE'; -- Đổi thành: 'LIST', 'DISABLE', hoặc 'ENABLE'
BEGIN
  IF v_action = 'LIST' THEN
    DBMS_OUTPUT.PUT_LINE('-- Unified Audit Policies đang bật:');
    FOR r IN (
      SELECT policy_name, enabled_option
      FROM audit_unified_enabled_policies
    ) LOOP
      DBMS_OUTPUT.PUT_LINE('AUDIT POLICY ' || r.policy_name || ';');
    END LOOP;

    DBMS_OUTPUT.PUT_LINE('-- FGA Policies đang bật:');
    FOR r IN (
      SELECT object_schema, object_name, policy_name
      FROM dba_audit_policies
      WHERE enabled = 'YES'
    ) LOOP
      DBMS_OUTPUT.PUT_LINE(
        'EXEC DBMS_FGA.ENABLE_POLICY(object_schema => ''' || r.object_schema ||
        ''', object_name => ''' || r.object_name ||
        ''', policy_name => ''' || r.policy_name || ''');'
      );
    END LOOP;

  ELSIF v_action = 'DISABLE' THEN
    FOR r IN (
      SELECT DISTINCT policy_name
      FROM audit_unified_enabled_policies
    ) LOOP
      BEGIN
        EXECUTE IMMEDIATE 'NOAUDIT POLICY ' || r.policy_name;
      EXCEPTION
        WHEN OTHERS THEN
          DBMS_OUTPUT.PUT_LINE('Không thể tắt policy: ' || r.policy_name || ' - ' || SQLERRM);
      END;
    END LOOP;

    FOR r IN (
      SELECT object_schema, object_name, policy_name
      FROM dba_audit_policies
      WHERE enabled = 'YES'
    ) LOOP
      BEGIN
        DBMS_FGA.DISABLE_POLICY(
          object_schema => r.object_schema,
          object_name   => r.object_name,
          policy_name   => r.policy_name
        );
      EXCEPTION
        WHEN OTHERS THEN
          DBMS_OUTPUT.PUT_LINE('Không thể tắt FGA policy: ' || r.policy_name || ' - ' || SQLERRM);
      END;
    END LOOP;

  ELSIF v_action = 'ENABLE' THEN
    FOR r IN (
      SELECT DISTINCT policy_name
      FROM audit_unified_policies
    ) LOOP
      BEGIN
        EXECUTE IMMEDIATE 'AUDIT POLICY ' || r.policy_name;
      EXCEPTION
        WHEN OTHERS THEN
          DBMS_OUTPUT.PUT_LINE('Không thể bật policy: ' || r.policy_name || ' - ' || SQLERRM);
      END;
    END LOOP;

    FOR r IN (
      SELECT object_schema, object_name, policy_name
      FROM dba_audit_policies
      WHERE enabled = 'NO'
    ) LOOP
      BEGIN
        DBMS_FGA.ENABLE_POLICY(
          object_schema => r.object_schema,
          object_name   => r.object_name,
          policy_name   => r.policy_name
        );
      EXCEPTION
        WHEN OTHERS THEN
          DBMS_OUTPUT.PUT_LINE('Không thể bật FGA policy: ' || r.policy_name || ' - ' || SQLERRM);
      END;
    END LOOP;
  END IF;
END;
/

--Xóa bản ghi trong AUDIT_TRAIL_UNIFIED
BEGIN
  DBMS_AUDIT_MGMT.CLEAN_AUDIT_TRAIL(
    AUDIT_TRAIL_TYPE => DBMS_AUDIT_MGMT.AUDIT_TRAIL_UNIFIED, 
    USE_LAST_ARCH_TIMESTAMP => FALSE
  );
END;
/



