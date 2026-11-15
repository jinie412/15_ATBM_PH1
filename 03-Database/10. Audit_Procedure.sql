--Procedure bật tắt audit
CREATE OR REPLACE PROCEDURE PROC_AUDIT_CONTROL(p_action IN VARCHAR2)
AUTHID CURRENT_USER --Thực thi với quyền của người đang gọi nó
AS
BEGIN
  IF UPPER(p_action) = 'SAVE' THEN
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

  ELSIF UPPER(p_action) = 'DISABLE' THEN
    -- Tắt Unified Audit Policies
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

    -- Tắt FGA Policies
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

    -- Tắt Standard Auditing
    BEGIN
      EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY';
      EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER SUCCESSFUL';
      EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER NOT SUCCESSFUL';
      EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON NHANVIEN';
      EXECUTE IMMEDIATE 'NOAUDIT SELECT, INSERT, UPDATE, DELETE ON DONVI';
      EXECUTE IMMEDIATE 'NOAUDIT SELECT ON DANGKY_VIEW';
      EXECUTE IMMEDIATE 'NOAUDIT EXECUTE ON UPDATE_DANGKY_GRADE';
    EXCEPTION
      WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Không thể tắt auditing chuẩn - ' || SQLERRM);
    END;

  ELSIF UPPER(p_action) = 'ENABLE' THEN
    -- Bật Unified Audit Policies
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

    -- Bật FGA Policies
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

    -- Bật Standard Auditing
    BEGIN
      EXECUTE IMMEDIATE 'AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY BY ACCESS';
      EXECUTE IMMEDIATE 'AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER SUCCESSFUL';
      EXECUTE IMMEDIATE 'AUDIT SELECT, INSERT, UPDATE, DELETE ON DANGKY WHENEVER NOT SUCCESSFUL';

      EXECUTE IMMEDIATE 'AUDIT SELECT, INSERT, UPDATE, DELETE ON NHANVIEN BY ACCESS';
      EXECUTE IMMEDIATE 'AUDIT SELECT, INSERT, UPDATE, DELETE ON DONVI BY ACCESS';

      EXECUTE IMMEDIATE 'AUDIT SELECT ON DANGKY_VIEW BY ACCESS';
      EXECUTE IMMEDIATE 'AUDIT EXECUTE ON UPDATE_DANGKY_GRADE BY ACCESS';
    EXCEPTION
      WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Không thể bật auditing chuẩn - ' || SQLERRM);
    END;

  ELSE
    DBMS_OUTPUT.PUT_LINE('Giá trị p_action không hợp lệ. Dùng: ENABLE, DISABLE, hoặc SAVE.');
  END IF;
END;
/

--Tải danh sách audit của QN với KH
--CREATE OR REPLACE PROCEDURE PROC_LOAD_AUDIT_LOG (
--    p_type IN VARCHAR2,
--    p_cursor OUT SYS_REFCURSOR
--)
--IS
--BEGIN
--    IF UPPER(p_type) = 'ALL' THEN
--        OPEN p_cursor FOR
--        SELECT 
--            audit_type,
--            dbusername,
--            action_name,
--            object_name,
--            sql_text,
--            return_code,
--            TO_CHAR(event_timestamp, 'DD/MM/YYYY HH24:MI:SS') AS event_time
--        FROM unified_audit_trail
--        WHERE object_name IN (
--            'DANGKY', 'DANGKY_VIEW', 'NHANVIEN', 'DONVI',
--            'UPDATE_DANGKY_GRADE', 'MOMON', 'SINHVIEN'
--        )
--        ORDER BY event_timestamp DESC;
--
--    ELSE
--        OPEN p_cursor FOR
--        SELECT 
--            audit_type,
--            dbusername,
--            action_name,
--            object_name,
--            sql_text,
--            return_code,
--            TO_CHAR(event_timestamp, 'DD/MM/YYYY HH24:MI:SS') AS event_time
--        FROM unified_audit_trail
--        WHERE UPPER(audit_type) = UPPER(p_type)
--          AND object_name IN (
--            'DANGKY', 'DANGKY_VIEW', 'NHANVIEN', 'DONVI',
--            'UPDATE_DANGKY_GRADE', 'MOMON', 'SINHVIEN'
--          )
--        ORDER BY event_timestamp DESC;
--    END IF;
--END;
--/

-- Tải danh sách audit của TN với KP
CREATE OR REPLACE PROCEDURE PROC_LOAD_AUDIT_LOG (
    p_type   IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    IF UPPER(p_type) = 'STANDARD' THEN
        OPEN p_cursor FOR
            SELECT 'STANDARD' AS AUDIT_TYPE,
                   USERNAME AS DB_USER,
                   OWNER AS DBUSERNAME,
                   ACTION_NAME,
                   OBJ_NAME AS OBJECT_NAME,
                   SQL_TEXT,
                   Returncode AS RETURN_CODE,
                   TO_CHAR(TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME
            FROM DBA_AUDIT_TRAIL
            WHERE OBJ_NAME IN (
                    'DONVI', 'NHANVIEN', 'DANGKY', 
                    'DANGKY_VIEW', 'UPDATE_DANGKY_GRADE', 'GET_DANGKY_AUDIT_LOG'
                  )
            ORDER BY EVENT_TIME DESC;

    ELSIF UPPER(p_type) = 'FGA' THEN
        OPEN p_cursor FOR
            SELECT 'FGA' AS AUDIT_TYPE,
                   CURRENT_USER AS DB_USER,
                   OBJECT_SCHEMA AS DBUSERNAME,
                   STATEMENT_TYPE AS ACTION_NAME,
                   OBJECT_NAME AS OBJECT_NAME,
                   SQL_TEXT,
                   RETURNCODE AS RETURN_CODE,
                   TO_CHAR(EXTENDED_TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME
            FROM DBA_COMMON_AUDIT_TRAIL
            WHERE POLICY_NAME IN (
                    'AUDIT_DANGKY_SCORES',
                    'AUDIT_NHANVIEN_SALARY',
                    'AUDIT_DANGKY_CAUC'
                  )
            ORDER BY EVENT_TIME DESC;

    ELSIF UPPER(p_type) = 'ALL' THEN
        OPEN p_cursor FOR
            SELECT 'STANDARD' AS AUDIT_TYPE,
                   USERNAME AS DB_USER,
                   OWNER AS DBUSERNAME,
                   ACTION_NAME,
                   OBJ_NAME AS OBJECT_NAME,
                   SQL_TEXT,
                   Returncode AS RETURN_CODE,
                   TO_CHAR(TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME
            FROM DBA_AUDIT_TRAIL
            WHERE OBJ_NAME IN (
                    'DONVI', 'NHANVIEN', 'DANGKY', 
                    'DANGKY_VIEW', 'UPDATE_DANGKY_GRADE', 'GET_DANGKY_AUDIT_LOG'
                  )
            UNION ALL
            SELECT 'FGA' AS AUDIT_TYPE,
                   CURRENT_USER AS DB_USER,
                   OBJECT_SCHEMA AS DBUSERNAME,
                   STATEMENT_TYPE AS ACTION_NAME,
                   OBJECT_NAME AS OBJECT_NAME,
                   SQL_TEXT,
                   RETURNCODE AS RETURN_CODE,
                   TO_CHAR(EXTENDED_TIMESTAMP, 'DD/MM/YYYY HH24:MI:SS') AS EVENT_TIME
            FROM DBA_COMMON_AUDIT_TRAIL
            WHERE POLICY_NAME IN (
                    'AUDIT_DANGKY_SCORES',
                    'AUDIT_NHANVIEN_SALARY',
                    'AUDIT_DANGKY_CAUC'
                  )
            ORDER BY EVENT_TIME DESC;

    ELSE
        OPEN p_cursor FOR
            SELECT NULL AS AUDIT_TYPE,
                   NULL AS DB_USER,
                   NULL AS OBJECT_NAME,
                   NULL AS SQL_TEXT,
                   NULL AS EVENT_TIME
            FROM DUAL WHERE 1 = 0;
    END IF;
END;
/

--Xóa dữ liệu audit
-- QN + KH
--CREATE OR REPLACE PROCEDURE PROC_DELETE_AUDIT_UNIFIED
--IS
--BEGIN
--  DBMS_AUDIT_MGMT.CLEAN_AUDIT_TRAIL(
--    AUDIT_TRAIL_TYPE => DBMS_AUDIT_MGMT.AUDIT_TRAIL_UNIFIED,
--    USE_LAST_ARCH_TIMESTAMP => FALSE 
--  );
--
--  DBMS_OUTPUT.PUT_LINE('Đã xoá tất cả dữ liệu unified audit trail!');
--EXCEPTION
--  WHEN OTHERS THEN
--    DBMS_OUTPUT.PUT_LINE('Lỗi: ' || SQLERRM);
--END;
--/

-- KP + TN
CREATE OR REPLACE PROCEDURE PROC_DELETE_AUDIT_UNIFIED
IS
BEGIN
    -- Initialize audit management (if not already initialized)
    DBMS_AUDIT_MGMT.INIT_CLEANUP(
        audit_trail_type => DBMS_AUDIT_MGMT.AUDIT_TRAIL_ALL,
        default_cleanup_interval => 24 /* hours */
    );

    -- Purge all audit records (both standard and FGA)
    DBMS_AUDIT_MGMT.CLEAN_AUDIT_TRAIL(
        audit_trail_type => DBMS_AUDIT_MGMT.AUDIT_TRAIL_ALL,
        use_last_arch_timestamp => FALSE
    );

    -- Commit the changes
    COMMIT;

EXCEPTION
    WHEN OTHERS THEN
        -- Roll back on error
        ROLLBACK;
        -- Re-raise the exception to inform the caller
        RAISE;
END;
/

--exec 
--VARIABLE rc REFCURSOR;
--BEGIN
--  PROC_LOAD_AUDIT_LOG('ALL', :rc);
--END;
--/
--PRINT rc;
--
--exec PROC_AUDIT_CONTROL('enable');


