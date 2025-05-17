using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class NhanVienForm : Form
    {
        private bool _isEditMode = false; // Biến để xác định chế độ (thêm mới hay chỉnh sửa)

        // Các thuộc tính công khai để truy xuất dữ liệu
        public string MANLD { get => textBoxManld.Text.Trim(); }
        public string HOTEN { get => textBoxHoten.Text.Trim(); }
        public string PHAI { get => comboBoxPhai.SelectedItem?.ToString(); }
        public DateTime NGSINH { get => dateTimePickerNgSinh.Value; }
        public decimal LUONG { get => decimal.TryParse(textBoxLuong.Text, out decimal result) ? result : 0; }
        public decimal PHUCAP { get => decimal.TryParse(textBoxPhuCap.Text, out decimal result) ? result : 0; }
        public string DT { get => textBoxDT.Text.Trim(); }
        public string VAITRO { get => comboBoxVaiTro.SelectedItem?.ToString(); }
        public string MADV { get => comboBoxDV.Text.Trim(); }

        // Constructor mặc định (dùng khi thêm mới)
        public NhanVienForm()
        {
            InitializeComponent();
            _isEditMode = false;
            this.Text = "Thêm nhân viên mới";
            textBoxManld.Enabled = false; // Không cho sửa mã nhân viên
            InitializeComboBoxes();
            LayMaNhanVienMoi();
            LoadDSDonVi();
        }

        // Constructor để chỉnh sửa (nhận dữ liệu nhân viên hiện tại)
        public NhanVienForm(string manld, string hoten, string phai, DateTime ngsinh, decimal luong, decimal phucap, string dt, string vaitro, string madv)
        {
            InitializeComponent();
            _isEditMode = true;
            this.Text = "Chỉnh sửa nhân viên";
            InitializeComboBoxes();
            LoadDSDonVi();

            // Gán dữ liệu vào các điều khiển
            textBoxManld.Text = manld;
            textBoxHoten.Text = hoten;
            comboBoxPhai.SelectedItem = phai;
            dateTimePickerNgSinh.Value = ngsinh;
            textBoxLuong.Text = luong.ToString();
            textBoxPhuCap.Text = phucap.ToString();
            textBoxDT.Text = dt;
            comboBoxVaiTro.SelectedItem = vaitro;
            comboBoxDV.Text = madv;

            // Không cho sửa MANLD khi chỉnh sửa
            textBoxManld.ReadOnly = true;
            buttonLuu.Text = "Cập nhật"; // Đổi nhãn nút Lưu thành Cập nhật
        }

        private void InitializeComboBoxes()
        {
            // Điền dữ liệu cho comboBoxPhai nếu chưa có
            if (comboBoxPhai.Items.Count == 0)
            {
                comboBoxPhai.Items.AddRange(new object[] { "Nam", "Nữ" });
            }

            // Điền dữ liệu cho comboBoxVaiTro nếu chưa có
            if (comboBoxVaiTro.Items.Count == 0)
            {
                comboBoxVaiTro.Items.AddRange(new object[] { "Nhân viên", "Quản lý", "TCHC" }); // Có thể thay bằng dữ liệu từ DB
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(textBoxManld.Text) || string.IsNullOrWhiteSpace(textBoxHoten.Text) ||
                comboBoxPhai.SelectedItem == null || comboBoxVaiTro.SelectedItem == null ||
                string.IsNullOrWhiteSpace(comboBoxDV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số cho LUONG và PHUCAP
            if (!decimal.TryParse(textBoxLuong.Text, out decimal luong) || luong < 0)
            {
                MessageBox.Show("Lương phải là số hợp lệ và không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(textBoxPhuCap.Text, out decimal phucap) || phucap < 0)
            {
                MessageBox.Show("Phụ cấp phải là số hợp lệ và không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                    MainClass.conn.Open();

                using (OracleCommand cmd = new OracleCommand(_isEditMode ? "pdb_admin.SP_UPDATE_NHANVIEN" : "pdb_admin.SP_INSERT_NHANVIEN", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số cho stored procedure
                    cmd.Parameters.Add("p_manld", OracleDbType.Varchar2).Value = MANLD;
                    cmd.Parameters.Add("p_hoten", OracleDbType.Varchar2).Value = HOTEN;
                    cmd.Parameters.Add("p_phai", OracleDbType.Varchar2).Value = PHAI;
                    cmd.Parameters.Add("p_ngsinh", OracleDbType.Date).Value = NGSINH;
                    cmd.Parameters.Add("p_luong", OracleDbType.Decimal).Value = LUONG;
                    cmd.Parameters.Add("p_phucap", OracleDbType.Decimal).Value = PHUCAP;
                    cmd.Parameters.Add("p_dt", OracleDbType.Varchar2).Value = DT;
                    cmd.Parameters.Add("p_vaitro", OracleDbType.Varchar2).Value = VAITRO;
                    cmd.Parameters.Add("p_madv", OracleDbType.Varchar2).Value = MADV;
                    cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    // Thực thi stored procedure
                    cmd.ExecuteNonQuery();

                    // Lấy kết quả từ tham số output
                    string result = cmd.Parameters["p_result"].Value.ToString();
                    MessageBox.Show(result);

                    // Nếu thành công, đóng form với DialogResult.OK
                    if (result.Contains("thành công"))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi {(_isEditMode ? "cập nhật" : "thêm")} nhân viên: {oraEx.Message}";
                if (oraEx.Number != 0)
                    errorMessage += $"\nMã lỗi Oracle: {oraEx.Number}";
                if (oraEx.InnerException != null)
                    errorMessage += $"\nChi tiết: {oraEx.InnerException.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi {(_isEditMode ? "cập nhật" : "thêm")} nhân viên: {ex.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
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

        private void LayMaNhanVienMoi()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.FN_MANV_TT", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số trả về của FUNCTION
                    cmd.Parameters.Add("return_value", OracleDbType.Varchar2, 20).Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    string maSV = cmd.Parameters["return_value"].Value.ToString();
                    textBoxManld.Text = maSV;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy mã nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadDSDonVi()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_TCHC_XEMDV", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBoxDV.DataSource = dt;
                comboBoxDV.DisplayMember = "MADV";
                comboBoxDV.ValueMember = "MADV";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}