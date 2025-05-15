using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class SinhVienForm : Form
    {
        private bool _isEditMode = false; // Biến để xác định chế độ (thêm mới hay chỉnh sửa)

        // Các thuộc tính công khai để truy xuất dữ liệu
        public string MASV { get => textBoxMasv.Text.Trim(); }
        public string HOTEN { get => textBoxHoten.Text.Trim(); }
        public string PHAI { get => comboBoxPhai.SelectedItem?.ToString(); }
        public DateTime NGSINH { get => dateTimePickerNgSinh.Value; }
        public string DCHI { get => textBoxDiaChi.Text.Trim(); }
        public string DT { get => textBoxDT.Text.Trim(); }
        public string KHOA { get => textBoxKhoa.Text.Trim(); }
        public string TINHTRANG { get => textBoxTrangThai.Text.Trim(); }

        // Constructor mặc định (dùng khi thêm mới)
        public SinhVienForm()
        {
            InitializeComponent();
            _isEditMode = false;
            this.Text = "Thêm sinh viên mới";
            InitializeComboBoxes();
        }

        // Constructor để chỉnh sửa (nhận dữ liệu sinh viên hiện tại)
        public SinhVienForm(string masv, string hoten, string phai, DateTime ngsinh, string dchi, string dt, string khoa, string tinhtrang)
        {
            InitializeComponent();
            _isEditMode = true;
            this.Text = "Chỉnh sửa sinh viên";
            InitializeComboBoxes();

            // Gán dữ liệu vào các điều khiển
            textBoxMasv.Text = masv;
            textBoxHoten.Text = hoten;
            comboBoxPhai.SelectedItem = phai;
            dateTimePickerNgSinh.Value = ngsinh;
            textBoxDiaChi.Text = dchi;
            textBoxDT.Text = dt;
            textBoxKhoa.Text = khoa;
            textBoxTrangThai.Text = tinhtrang;

            // Không cho sửa MASV khi chỉnh sửa
            textBoxMasv.ReadOnly = true;
            buttonLuu.Text = "Cập nhật";
        }

        private void InitializeComboBoxes()
        {
            if (comboBoxPhai.Items.Count == 0)
            {
                comboBoxPhai.Items.AddRange(new object[] { "Nam", "Nữ" });
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MASV) || string.IsNullOrWhiteSpace(HOTEN) ||
                comboBoxPhai.SelectedItem == null || string.IsNullOrWhiteSpace(DCHI) ||
                string.IsNullOrWhiteSpace(DT) || string.IsNullOrWhiteSpace(KHOA))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                    MainClass.conn.Open();

                using (OracleCommand cmd = new OracleCommand(_isEditMode ? "pdb_admin.SP_UPDATE_SINHVIEN" : "pdb_admin.SP_INSERT_SINHVIEN", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số chung cho cả INSERT và UPDATE
                    cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = MASV;
                    cmd.Parameters.Add("p_hoten", OracleDbType.Varchar2).Value = HOTEN;
                    cmd.Parameters.Add("p_phai", OracleDbType.Varchar2).Value = PHAI;
                    cmd.Parameters.Add("p_ngaysinh", OracleDbType.Date).Value = NGSINH;
                    cmd.Parameters.Add("p_diachi", OracleDbType.Varchar2).Value = DCHI;
                    cmd.Parameters.Add("p_sdt", OracleDbType.Varchar2).Value = DT;
                    cmd.Parameters.Add("p_khoa", OracleDbType.Varchar2).Value = KHOA;
                    //cmd.Parameters.Add("p_tinhtrang", OracleDbType.Varchar2).Value = TINHTRANG;
                    if (!string.IsNullOrWhiteSpace(TINHTRANG))
                    {
                        cmd.Parameters.Add("p_tinhtrang", OracleDbType.Varchar2).Value = TINHTRANG;
                    }
                    else
                    {
                        cmd.Parameters.Add("p_tinhtrang", OracleDbType.Varchar2).Value = DBNull.Value;
                    }
                    //// Chỉ thêm p_tinhtrang khi gọi SP_INSERT_SINHVIEN (thêm mới)
                    //if (!_isEditMode)
                    //{
                    //    cmd.Parameters.Add("p_tinhtrang", OracleDbType.Varchar2).Value = TINHTRANG;
                    //}

                    // Thêm tham số p_result (chung cho cả INSERT và UPDATE)
                    cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    string result = cmd.Parameters["p_result"].Value.ToString();
                    MessageBox.Show(result);

                    //if (result.Contains("Cập nhật sinh viên thành công"))
                    //{
                    //    DialogResult = DialogResult.OK;
                    //    Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show($"Cập nhật thất bại: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    if ((_isEditMode && result.Contains("Cập nhật sinh viên thành công")) ||
                        (!_isEditMode && result.Contains("Thêm mới sinh viên thành công")))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"{(_isEditMode ? "Cập nhật" : "Thêm")} thất bại: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi {(_isEditMode ? "cập nhật" : "thêm")} sinh viên: {oraEx.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi {(_isEditMode ? "cập nhật" : "thêm")} sinh viên: {ex.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                    MainClass.conn.Close();
            }
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
