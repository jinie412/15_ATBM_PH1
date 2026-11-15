ALTER SESSION SET CONTAINER = QLDULIEUNOIBO;
-- =========================== NV PDT ==========================
-- Hàm lấy mã môn tiếp theo
CREATE OR REPLACE FUNCTION FN_MAMM_TT
RETURN VARCHAR2
IS
  v_max_number NUMBER;
BEGIN
  SELECT NVL(MAX(TO_NUMBER(SUBSTR(MAMM, 3))), 0) + 1
  INTO v_max_number
  FROM MOMON;

  RETURN 'MM' || LPAD(v_max_number, 5, '0');
END;
/

GRANT EXECUTE ON PDB_ADMIN.FN_MAMM_TT TO NV_PDT;

-- ============================ NV TCHC ==========================
-- Hàm lấy mã nhan viên tiếp theo
CREATE OR REPLACE FUNCTION FN_MANV_TT
RETURN VARCHAR2
IS
  v_max_number NUMBER;
BEGIN
  -- Lấy phần số lớn nhất hiện có trong mã nhân viên
  SELECT NVL(MAX(TO_NUMBER(SUBSTR(MANLD, 3))), 0) + 1
  INTO v_max_number
  FROM NHANVIEN;

  -- Trả về mã nhân viên mới với định dạng NV + 6 chữ số
  RETURN 'NV' || LPAD(v_max_number, 6, '0');
END;
/

GRANT EXECUTE ON PDB_ADMIN.FN_MANV_TT TO NV_TCHC;
-- ============================= NV CTSV ==========================

CREATE OR REPLACE FUNCTION FN_SV_TT
RETURN VARCHAR2
IS
  v_max_number NUMBER;
  v_year VARCHAR2(4);
BEGIN
  -- Lấy năm hiện tại
  v_year := TO_CHAR(SYSDATE, 'YYYY');

  -- Lấy phần số lớn nhất hiện có trong mã sinh viên thuộc năm hiện tại
  SELECT NVL(MAX(TO_NUMBER(SUBSTR(MASV, 9))), 0) + 1
  INTO v_max_number
  FROM SINHVIEN
  WHERE SUBSTR(MASV, 3, 4) = v_year;

  RETURN 'SV' || v_year || LPAD(v_max_number, 4, '0');
END;
/
GRANT EXECUTE ON PDB_ADMIN.FN_SV_TT TO NV_CTSV;

-- ============================ ALL ==========================
-- Hàm kiểm tra role của user
CREATE OR REPLACE FUNCTION FUNC_XACDINH_DOITUONG(p_input VARCHAR2)
RETURN VARCHAR2
IS
    v_result VARCHAR2(100);
BEGIN
    -- Nếu bắt đầu bằng 'SV'
    IF SUBSTR(p_input, 1, 2) = 'SV' THEN
        v_result := 'SV';

    -- Nếu bắt đầu bằng 'NV'
    ELSIF SUBSTR(p_input, 1, 2) = 'NV' THEN
        SELECT VAITRO  INTO v_result
        FROM NHANVIEN
        WHERE MANLD = p_input;

    ELSE
        v_result := 'KHONG_XAC_DINH';
    END IF;

    RETURN v_result;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN 'KHONG_TIM_THAY_NV';
    WHEN OTHERS THEN
        RETURN 'LOI: ' || SQLERRM;
END;
/
