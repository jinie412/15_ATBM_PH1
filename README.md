# Internal University Data Management and Database Security

![Course](https://img.shields.io/badge/course-CSC12001-blue)
![Application](https://img.shields.io/badge/application-WinForms-informational)
![Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)
![Database](https://img.shields.io/badge/database-Oracle-red)
![Provider](https://img.shields.io/badge/ODP.NET%20Managed-23.8.0-orange)

**Course:** Data Security in Information Systems (CSC12001)  
**Faculty:** Faculty of Information Technology, University of Science, VNU-HCM

This repository contains the Windows Forms client for the first subsystem of a
database-security course project. The client connects directly to an Oracle
database and exposes database administration screens as well as role-specific
internal university data-management screens.

> **Repository scope note:** The repository contains the WinForms client,
> database deployment scripts, report documents, a demo PDF, and a guideline
> PDF. This README documents the actual files and object names found during the
> repository inspection.

## Overview

The application has two cooperating areas:

1. **Database Administration (DBA) area** - user and role administration,
   privilege grant/revoke workflows, privilege inspection, and audit controls.
2. **Internal University Data area** - role-specific workflows for students,
   lecturers, academic affairs, accounting, human resources, student affairs,
   and department heads. These workflows rely on Oracle-side stored procedures,
   views, VPD/RBAC rules, and OLS labels.

The runtime flow is:

```text
WinForms login
    -> Oracle.ManagedDataAccess connection
    -> Oracle user/schema determines the application area
    -> role-specific forms call PDB_ADMIN procedures/views
    -> Oracle RBAC, VPD, OLS, and auditing enforce database security
```

The login form connects to `localhost:1521/QLDULIEUNOIBO`. The application
keeps the active `OracleConnection` and current username in `MainClass`.
Role resolution for ordinary users calls
`PDB_ADMIN.FUNC_XACDINH_DOITUONG`.

## Project structure

The following is the relevant source layout (generated `bin`, `obj`, and
NuGet package contents are intentionally omitted):

```text
.
├── ATBM_PH1.sln                         Visual Studio solution
├── 03-Database/                          Oracle provisioning and test scripts
├── 04-Report/                            Course report in DOCX and PDF
├── 05-Demo/                              Demonstration PDF
├── 06-Guideline/                         Project guideline PDF
├── README.md                            Project documentation
└── ATBM_PH1/
    ├── ATBM_PH1.csproj                  .NET Framework WinForms project
    ├── App.config                       ODP.NET and .NET runtime configuration
    ├── packages.config                  NuGet package versions
    ├── Program.cs                       Application entry point
    ├── MainClass.cs                     Shared connection and current-user state
    ├── DangNhap.cs                      Oracle login and role-based routing
    ├── frmMain.cs                       DBA dashboard
    ├── PH1/                             DBA roles and privilege management
    ├── User/                             User listing, creation, update, locking
    ├── audit_/                           Audit enable/disable and log viewer
    ├── OLS/                              OLS label and user-label management
    ├── NVCB/                             Basic staff workflows
    ├── GV/                               Lecturer workflows
    ├── PDT/                              Academic affairs workflows
    ├── NVKT/                             Accounting/finance workflows
    ├── TCHC/                             Human-resources workflows
    ├── CTSV/                             Student-affairs workflows
    ├── TRGDV/                            Department-head workflows
    ├── SV/                               Student workflows
    ├── RBAC_VPD_GV/                      Additional lecturer form
    ├── Audit/                             Additional audit form assets
    ├── Resources/                        Images and UI resources
    └── Properties/                       Assembly and application resources
```

### Database scripts

`03-Database/` is the database-side part of this checkout:

| File                      | Purpose                                                                                    |
| ------------------------- | ------------------------------------------------------------------------------------------ |
| `1. PDB_SYS.sql`          | Creates/opens `QLDULIEUNOIBO`, provisions `PDB_ADMIN`, and enables OLS/audit prerequisites |
| `2. CSDL.sql`             | Creates the core university tables                                                         |
| `3. RBAC.sql`             | Creates RBAC views/procedures and role grants                                              |
| `4. Data.sql`             | Loads university seed data                                                                 |
| `5. Function.sql`         | Creates helper and role-resolution functions                                               |
| `6. Procedure.sql`        | Creates application and DBA procedures                                                     |
| `7. TaoUser.sql`          | Creates role-based users and OLS demo users                                                |
| `8. VPD.sql`              | Creates VPD predicates and `DBMS_RLS` policies                                             |
| `9. PDB_ADMIN_OLS.sql`    | Grants notification access to OLS users                                                    |
| `9.1. OLS_LBACSYS.sql`    | Creates `OLS_NOTIFY_POLICY`, labels, assignments, and notification data                    |
| `10. Audit_Procedure.sql` | Creates audit control and audit-log procedures                                             |
| `10.1.Audit_On_Off.sql`   | Documents and configures audit mode                                                        |
| `10.2. Audit.sql`         | Configures Standard Audit and FGA/Unified Audit objects                                    |
| `10.3. Audit_test.sql`    | Exercises audit and FGA behavior                                                           |

The numbered filenames provide the intended execution order. Run each script
in the correct Oracle container, review errors before continuing, and keep
`4. Data.sql` under change control because it is a large seed-data script.

Each form has a `.cs` implementation, a generated `.Designer.cs` layout file,
and (where applicable) a `.resx` resource file. The project is a classic
non-SDK-style Visual Studio project targeting `net472`.

## Implemented functionality

### Subsystem 1 - Oracle DBA client

The DBA dashboard (`frmMain`) opens the following workflows:

- **Users:** `User/ViewUser.cs`, `User/InsertUser.cs`, and
  `User/UpdateUser.cs` call `GetUserList`, `CreateUser`,
  `GrantBasicPrivileges`, `UpdateUserPassword`, `LockUserAccount`,
  `UnlockUserAccount`, `GetUserStatus`, `KillUserSessions`, and `DropUser`.
- **Roles:** `PH1/Role.cs` and `PH1/CreateRoleForm.cs` support role listing and
  role creation through `CREATE_NEW_ROLE`.
- **Object and column privileges:** `PH1/CapQuyen_CSDL.cs` loads object names
  and columns, supports `TABLE`, `VIEW`, `FUNCTION`, and `PROCEDURE`, and
  exposes `SELECT`, `INSERT`, `UPDATE`, `DELETE`, and `EXECUTE`. Column-level
  `SELECT` and `UPDATE` selections are represented in the UI. Granting is
  delegated to `GRANT_PRIVS_TO_USER`.
- **Privilege inspection and revocation:** `PH1/PhanQuyen.cs` loads table,
  column, and role privileges through `SP_TAB_DA_CAP`, `SP_COL_DA_CAP`, and
  `SP_XAC_DINH_ROLE_CHO_USER`. It uses
  `SP_THU_HOI_QUYEN_TAB`, `SP_THU_HOI_QUYEN_COL`,
  `SP_THU_HOI_QUYEN_UPDATE_COL`, and `SP_THU_HOI_ROLE` for revocation.
- **Object discovery and validation:** the client calls
  `GET_OBJECTS_BY_TYPE`, `get_columns_by_table`, `get_custom_roles`, and
  `SP_KTRA_TON_TAI`.

The deployment scripts define the stored procedures used by the client. The
client exposes object types `TABLE`, `VIEW`, `FUNCTION`, and `PROCEDURE`, with
table/view privileges `SELECT`, `INSERT`, `UPDATE`, and `DELETE`, executable
privilege `EXECUTE`, and separate column-level `SELECT`/`UPDATE` selection.
Check the scripts for the exact `WITH GRANT OPTION` behavior before
demonstrating delegated grants.

### Subsystem 2 - Internal university data

The application contains screens for the following business areas:

| Area                        | Source folder | Evidence in the client                              |
| --------------------------- | ------------- | --------------------------------------------------- |
| Basic staff (`NVCB`)        | `NVCB/`       | Personal-data update and retrieval                  |
| Lecturer (`GV`)             | `GV/`         | Classes, students, and registrations                |
| Academic affairs (`NV PĐT`) | `PDT/`        | Courses, course offerings, student registration     |
| Accounting (`NV PKT`)       | `NVKT/`       | Registration viewing and score updates              |
| Human resources (`NV TCHC`) | `TCHC/`       | Employee CRUD workflows                             |
| Student affairs (`NV CTSV`) | `CTSV/`       | Student CRUD and student information                |
| Department head (`TRGĐV`)   | `TRGDV/`      | Department employee listing                         |
| Student                     | `SV/`         | Course offering, enrollment, and common information |

The client references the core `PDB_ADMIN` data model, including
`NHANVIEN` and `THONGBAO`, and views such as
`PDB_ADMIN.V_MOMON_HIEN_TAI` and `PDB_ADMIN.V_MOMON_SINHVIEN`.
`03-Database/2. CSDL.sql` defines `DONVI`, `NHANVIEN`, `SINHVIEN`, `HOCPHAN`,
`MOMON`, `DANGKY`, and `THONGBAO`, including keys and integrity checks.

#### RBAC and VPD

The login router recognizes `NVCB`, `GV`, `NV PĐT`, `NV PKT`, `NV TCHC`,
`NV CTSV`, and `TRGĐV` values returned by
`PDB_ADMIN.FUNC_XACDINH_DOITUONG`. Student usernames beginning with `SV` are
sent to the student area. `03-Database/3. RBAC.sql` defines role-specific
views/procedures and grants, while `03-Database/8. VPD.sql` uses `DBMS_RLS`
for row and operation restrictions, including the first 14 days of the
current semester for registration changes.

#### Oracle Label Security (OLS)

The `OLS/` screens use policy `OLS_NOTIFY_POLICY` and query
`ALL_SA_LEVELS`, `ALL_SA_COMPARTMENTS`, `ALL_SA_GROUPS`, and `ALL_SA_LABELS`.
They support:

- creating a notification label through `PROC_CREATE_LABEL`;
- assigning a label to a database user through
  `SA_USER_ADMIN.SET_USER_LABELS`;
- storing notification content in `PDB_ADMIN.THONGBAO`;
- viewing notifications through `PDB_ADMIN.SP_XEMTHONGBAO`.

The source constructs labels from a level, selected compartments, and selected
groups. `03-Database/9.1. OLS_LBACSYS.sql` defines levels `SV`, `NV`, and
`TRUONG`, compartments `TOAN`, `LY`, `HOA`, and `HC`, and groups `CS1` and
`CS2`, then assigns labels to demo and university users.

#### Auditing

`audit_/Audit.cs` provides buttons to enable or disable auditing through
`PDB_ADMIN.PROC_AUDIT_CONTROL`. It loads `STANDARD` or `FGA` audit results
through `PDB_ADMIN.PROC_LOAD_AUDIT_LOG` into a grid. A unified-audit deletion
call is present only as commented code (`PROC_DELETE_AUDIT_UNIFIED`).

The database-side audit scripts configure Standard Audit and FGA/Unified Audit
objects; the client controls and reads the resulting logs. The scripts also
contain audit test cases for sensitive operations.

#### Backup and recovery

No RMAN command, Data Pump script, Flashback configuration, scheduler job, or
recovery script was found in `03-Database/`. Backup and recovery are therefore
not reproducible from this checkout. A production deployment should add
versioned, tested RMAN/Data Pump/Flashback procedures and document restore
point and retention requirements.

## Installation and setup

### Prerequisites

- Windows with Visual Studio capable of building .NET Framework 4.7.2 projects.
- .NET Framework 4.7.2 Developer Pack.
- Oracle Database with a service named `QLDULIEUNOIBO` reachable at
  `localhost:1521`, or a corresponding connection-string change.
- Oracle ODP.NET Managed Driver 23.8.0 (restored from `packages.config`).
- Oracle-side provisioning from `03-Database/1. PDB_SYS.sql` through
  `03-Database/10.3. Audit_test.sql`.
- Oracle Label Security must be installed and enabled for the OLS screens.
- An Oracle account with the administrative privileges required by the DBA and
  OLS operations.

Run the numbered scripts in this order with the database administrator:

1. `1. PDB_SYS.sql` (adjust the local `FILE_NAME_CONVERT` paths first).
2. `2. CSDL.sql`.
3. `3. RBAC.sql`.
4. `4. Data.sql`.
5. `5. Function.sql`.
6. `6. Procedure.sql`.
7. `7. TaoUser.sql`.
8. `8. VPD.sql`.
9. `9. PDB_ADMIN_OLS.sql`.
10. `9.1. OLS_LBACSYS.sql`.
11. `10. Audit_Procedure.sql`.
12. `10.1.Audit_On_Off.sql`.
13. `10.2. Audit.sql`.
14. `10.3. Audit_test.sql` (validation only).

Run scripts in the intended container and review every `DBMS_OUTPUT` and
Oracle error. The scripts contain development credentials and broad
administrative grants; use an isolated Oracle instance and rotate credentials
before any non-demo deployment.

### Connection configuration

The login form currently builds a connection string with:

```text
User Id={username};******;Data Source=localhost:1521/QLDULIEUNOIBO;
```

The masked segment is a placeholder in the checked-in source, not a usable
password attribute. Before running the application, replace it in a secure
local working copy with the Oracle password attribute populated from the
login form's password value, or implement an approved secret-management
approach.
Never commit real passwords to source control. The `sys` username additionally
requests `DBA Privilege=SYSDBA`.

### Build and run

1. Open `ATBM_PH1.sln` in Visual Studio.
2. Restore NuGet packages from `ATBM_PH1/packages.config`, especially
   `Oracle.ManagedDataAccess` 23.8.0 and `Guna.UI2.WinForms` 2.0.4.7.
3. Configure the Oracle service and the local connection string.
4. Build the `ATBM_PH1` project for `Debug|Any CPU` or `Release|Any CPU`.
5. Start the application. `Program.Main` opens `DangNhap`.
6. Log in with an Oracle account provisioned by the database administrator.

## Demo accounts

The database scripts create the following verified username categories:

| Username pattern/value     | Destination                                         |
| -------------------------- | --------------------------------------------------- |
| `pdb_admin`                | DBA dashboard; created by `1. PDB_SYS.sql`          |
| `lbacsys`                  | OLS dashboard; configured by `1. PDB_SYS.sql`       |
| `sys`                      | Oracle `SYSDBA` connection mode                     |
| `SV...`                    | Student workflow                                    |
| `u1` through `u8`          | Notification/OLS users; created by `7. TaoUser.sql` |
| Any other provisioned user | Role determined by `FUNC_XACDINH_DOITUONG`          |

`7. TaoUser.sql` also generates users for each role from the seeded
`NHANVIEN`/`SINHVIEN` data. It contains development passwords; do not reuse
them outside an isolated demonstration database.

## Security and operational notes

- Use least-privilege Oracle accounts for routine demonstrations; reserve
  `SYSDBA` for controlled administration.
- Keep passwords and connection strings out of Git and out of screenshots.
- Validate all Oracle-side grants, VPD predicates, OLS labels, and audit policies
  in a disposable test database before using the client with real data.
- Treat the application as a client of Oracle security controls, not as a
  replacement for database enforcement.
