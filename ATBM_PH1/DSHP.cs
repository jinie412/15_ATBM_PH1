using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class DSHP : Form
    {
        public DSHP()
        {
            InitializeComponent();
            LoadDSHP();
        }

        void LoadDSHP()
        {

            // Truy vấn dữ liệu
            OracleCommand cmd = new OracleCommand("SELECT * FROM pdb_admin.V_MOMON_HIEN_TAI", MainClass.conn);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Thêm cột STT tự động
            dt.Columns.Add("STT", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }

            // Cấu hình DataGridView
            dgvDSHP.Columns.Clear();
            dgvDSHP.AutoGenerateColumns = false;

            // Cột checkbox
            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.HeaderText = "";
            checkCol.Width = 30;
            checkCol.Name = "CheckBoxColumn";
            dgvDSHP.Columns.Add(checkCol);
            // Cột STT
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "STT";
            colSTT.DataPropertyName = "STT";
            colSTT.Width = 50;
            dgvDSHP.Columns.Add(colSTT);

            // Cột MAMM
            DataGridViewTextBoxColumn colMAMM = new DataGridViewTextBoxColumn();
            colMAMM.HeaderText = "Mã MM";
            colMAMM.DataPropertyName = "MAMM";
            colMAMM.Name = "MAMM";
            colMAMM.Width = 90;
            dgvDSHP.Columns.Add(colMAMM);

            // Cột MAHP
            DataGridViewTextBoxColumn colMAHP = new DataGridViewTextBoxColumn();
            colMAHP.HeaderText = "Mã HP";
            colMAHP.DataPropertyName = "MAHP";
            colMAHP.Width = 90;
            dgvDSHP.Columns.Add(colMAHP);

            // Cột TENHP
            DataGridViewTextBoxColumn colTENHP = new DataGridViewTextBoxColumn();
            colTENHP.HeaderText = "Tên HP";
            colTENHP.DataPropertyName = "TENHP";
            colTENHP.Width = 200;
            dgvDSHP.Columns.Add(colTENHP);

            // Cột HK
            DataGridViewTextBoxColumn colHK = new DataGridViewTextBoxColumn();
            colHK.HeaderText = "HK";
            colHK.DataPropertyName = "HK";
            colHK.Width = 50;
            dgvDSHP.Columns.Add(colHK);

            // Cột NAM
            DataGridViewTextBoxColumn colNAM = new DataGridViewTextBoxColumn();
            colNAM.HeaderText = "Năm";
            colNAM.DataPropertyName = "NAM";
            colNAM.Width = 60;
            dgvDSHP.Columns.Add(colNAM);


            // Gán nguồn dữ liệu
            dgvDSHP.DataSource = dt;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            List<string> selectedMAMMs = new List<string>();

            foreach (DataGridViewRow row in dgvDSHP.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["CheckBoxColumn"].Value);
                if (isChecked)
                {
                    selectedMAMMs.Add(row.Cells["MAMM"].Value.ToString());
                }
            }

            if (selectedMAMMs.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn môn học nào để đăng ký!");
                return;
            }

            string mammsCsv = string.Join(",", selectedMAMMs);

            try
            {
                using (OracleCommand cmd = new OracleCommand("SP_DANGKY_MONHOC", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_mamms", OracleDbType.Varchar2).Value = mammsCsv;
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đăng ký thành công!");
                this.Close(); // Đóng form DSHP sau khi đăng ký
            }
            catch (OracleException ex)
            {
                if (ex.Number == 28115)
                {
                    MessageBox.Show("Bạn không được phép đăng ký môn học này do chính sách bảo mật dữ liệu.", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi khi đăng ký môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
