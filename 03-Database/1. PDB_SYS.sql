------------------------------------------------------------------------------------------
-- Tạo Pluggable Database (PDB) mới tên là QLDULIEUNOIBO
-- Với admin user là pdb_admin, mật khẩu là MyPassword
-- FILE_NAME_CONVERT dùng để chỉ định thư mục lưu trữ dữ liệu PDB mới dựa trên PDB seed
-------------
-- CHÚ Ý: CẦN THAY ĐƯỜNG DẪN FILE_NAME_CONVERT TƯƠNG ỨNG
-------------
-- Đảm bảo đang ở CDB$ROOT
ALTER SESSION SET CONTAINER = CDB$ROOT;
CREATE PLUGGABLE DATABASE QLDULIEUNOIBO
ADMIN USER pdb_admin IDENTIFIED BY MyPassword
FILE_NAME_CONVERT = ('C:\APP\ADMIN\PRODUCT\21C\ORADATA\XE\PDBSEED\', 
                     'C:\APP\ADMIN\PRODUCT\21C\ORADATA\XE\QLDULIEUNOIBO\');
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
-- Mở PDB QLDULIEUNOIBO sau khi tạo xong (trạng thái OPEN)
ALTER PLUGGABLE DATABASE QLDULIEUNOIBO OPEN;

-- Chuyển phiên làm việc hiện tại (session) sang PDB QLDULIEUNOIBO
ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
-- Cấp quyền cơ bản cho pdb_admin
GRANT DBA TO PDB_ADMIN;
GRANT CONNECT TO PDB_ADMIN WITH ADMIN OPTION;

GRANT CREATE USER, CREATE ROLE, CREATE SESSION, CREATE VIEW, CREATE PROCEDURE, CREATE TABLE, CREATE SEQUENCE TO pdb_admin with admin option;
GRANT CREATE ANY CONTEXT, CREATE TRIGGER TO pdb_admin;
GRANT ALTER USER, DROP USER TO pdb_admin;

GRANT SELECT_CATALOG_ROLE TO pdb_admin;

GRANT SELECT ANY DICTIONARY TO pdb_admin;

GRANT DROP ANY TABLE, ALTER ANY TABLE TO pdb_admin;
GRANT DROP ANY PROCEDURE TO pdb_admin;

-- Xem & thu hồi quyền
GRANT GRANT ANY PRIVILEGE, GRANT ANY OBJECT PRIVILEGE, GRANT ANY ROLE TO pdb_admin;
-- Cấp quyền thực thi
GRANT EXECUTE ANY PROCEDURE TO pdb_admin;

-- Cấp quyền truy vấn từng bảng hệ thống
GRANT SELECT ON DBA_USERS TO pdb_admin; -- xem danh sách user
GRANT SELECT ON DBA_ROLES TO pdb_admin; -- xem danh sách role
GRANT SELECT ON DBA_ROLE_PRIVS TO pdb_admin; -- user được gán role gì
GRANT SELECT ON DBA_TAB_PRIVS TO pdb_admin; -- quyền trên bảng

GRANT SELECT ON V_$SESSION TO pdb_admin;
GRANT UNLIMITED TABLESPACE TO pdb_admin;

-- Cho phép pdb_admin xem quyền được cấp cho role
GRANT SELECT ON ROLE_SYS_PRIVS TO pdb_admin;
GRANT SELECT ON ROLE_TAB_PRIVS TO pdb_admin;



-- Cấp quyền SYSDBA 
GRANT SYSDBA TO pdb_admin CONTAINER = current;

-- Cấu hình quota cho pdb_admin
ALTER USER pdb_admin QUOTA 100M ON SYSTEM;


-- Cấp quyền cho LBACSYS
GRANT DROP ANY PROCEDURE TO lbacsys;
GRANT EXECUTE ANY PROCEDURE TO lbacsys;
GRANT CREATE PROCEDURE TO lbacsys;

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
-- GRANT execute cho package
GRANT EXECUTE ON DBMS_SESSION TO pdb_admin;
GRANT EXECUTE ON DBMS_RLS TO pdb_admin;

-- GRANT quyền tạo trigger trên database
GRANT ADMINISTER DATABASE TRIGGER TO pdb_admin;

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
-- Kích hoạt OLS
EXEC LBACSYS.CONFIGURE_OLS;
EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS;

SHUTDOWN IMMEDIATE;
STARTUP;

ALTER SESSION SET CONTAINER = CDB$ROOT;
-- Thay đổi mật khẩu và unlock tài khoản LBACSYS
ALTER USER lbacsys IDENTIFIED BY lbacsys ACCOUNT UNLOCK ;


ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;
-- Phục vụ cho việc backup logic
GRANT INHERIT PRIVILEGES ON USER lbacsys TO PDB_ADMIN;

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

--  AUDIT
GRANT AUDIT_ADMIN TO PDB_ADMIN;
GRANT AUDIT_VIEWER TO PDB_ADMIN;

-- Dùng để xóa log
GRANT EXECUTE ON DBMS_AUDIT_MGMT TO PDB_ADMIN;
GRANT EXECUTE ON DBMS_FGA TO PDB_ADMIN;


