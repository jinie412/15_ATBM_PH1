using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class UpdateScore : Form
    {
        // Các thuộc tính công khai để truy xuất dữ liệu
        public string MASV { get => textBoxMasv.Text.Trim(); }
        public string MAMM { get => textBoxMamm.Text.Trim(); }
        public float DIEMTH { get => float.TryParse(textBoxDiemTH.Text, out float result) ? result : -1; }
        public float DIEMQT { get => float.TryParse(textBoxDiemQT.Text, out float result) ? result : -1; }
        public float DIEMCK { get => float.TryParse(textBoxDiemCK.Text, out float result) ? result : -1; }
        public float DIEMTK { get => float.TryParse(textBoxDiemTK.Text, out float result) ? result : -1; }

        // Constructor để chỉnh sửa (nhận dữ liệu điểm số hiện tại)
        public UpdateScore(string masv, string mamm, float diemth, float diemqt, float diemck, float diemtk)
        {
            InitializeComponent();
            this.Text = "Cập nhật điểm số";

            // Gán dữ liệu vào các điều khiển
            textBoxMasv.Text = masv;
            textBoxMamm.Text = mamm;
            textBoxDiemTH.Text = diemth >= 0 ? diemth.ToString("0.00") : "";
            textBoxDiemQT.Text = diemqt >= 0 ? diemqt.ToString("0.00") : "";
            textBoxDiemCK.Text = diemck >= 0 ? diemck.ToString("0.00") : "";
            textBoxDiemTK.Text = diemtk >= 0 ? diemtk.ToString("0.00") : "";

            // Không cho sửa MASV và MAMM
            textBoxMasv.ReadOnly = true;
            textBoxMamm.ReadOnly = true;
            buttonLuu.Text = "Cập nhật";
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(MASV) || string.IsNullOrWhiteSpace(MAMM))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ MASV và MAMM.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DIEMTH < 0 || DIEMQT < 0 || DIEMCK < 0 || DIEMTK < 0 ||
                DIEMTH > 10 || DIEMQT > 10 || DIEMCK > 10 || DIEMTK > 10)
            {
                MessageBox.Show("Điểm số phải nằm trong khoảng từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                    MainClass.conn.Open();

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_UPDATE_DIEM", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số cho stored procedure
                    cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = MASV;
                    cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = MAMM;
                    cmd.Parameters.Add("p_diemth", OracleDbType.Decimal).Value = DIEMTH;
                    cmd.Parameters.Add("p_diemqt", OracleDbType.Decimal).Value = DIEMQT;
                    cmd.Parameters.Add("p_diemck", OracleDbType.Decimal).Value = DIEMCK;
                    cmd.Parameters.Add("p_diemtk", OracleDbType.Decimal).Value = DIEMTK;
                    cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    // Thực thi stored procedure
                    cmd.ExecuteNonQuery();

                    // Lấy kết quả từ tham số output
                    string result = cmd.Parameters["p_result"].Value.ToString();
                    MessageBox.Show(result);

                    // Nếu cập nhật thành công, đóng form
                    if (result.Contains("Cập nhật điểm số thành công"))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }

                    else
                    {
                        MessageBox.Show($"Cập nhật thất bại: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi cập nhật điểm số: {oraEx.Message}";
                if (oraEx.Number != 0)
                    errorMessage += $"\nMã lỗi Oracle: {oraEx.Number}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi cập nhật điểm số: {ex.Message}";
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
