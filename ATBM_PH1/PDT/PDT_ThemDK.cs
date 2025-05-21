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
    public partial class PDT_ThemDK : Form
    {
        public PDT_ThemDK()
        {
            InitializeComponent();
        }

        public int hocKy = 3;
        public int Nam = 2025;
        public string maMM = "";
        public string maSV = "";
        public string dvDangChon = "";
        private void PDT_ThemDK_Load(object sender, EventArgs e)
        {
            LoadDSDonVi();
            Load_DSMM();   
            Load_SV();
        }

        private void Load_DSMM()
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_XEMDSMM", MainClass.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_hk", OracleDbType.Int32).Value = hocKy;
            cmd.Parameters.Add("p_nam", OracleDbType.Int32).Value = Nam;

            OracleParameter paramMADV = new OracleParameter("p_madv", OracleDbType.Varchar2);
            if (string.IsNullOrEmpty(dvDangChon))
            {
                paramMADV.Value = DBNull.Value;
            }
            else
            {
                paramMADV.Value = dvDangChon;
            }
            cmd.Parameters.Add(paramMADV);

            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            pdt_mm.DataSource = dt;

        }


        private void Load_SV()
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_XEMSV", MainClass.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Tham số MASV 
            OracleParameter paramMasv = new OracleParameter("p_masv", OracleDbType.Varchar2);
            if (string.IsNullOrEmpty(maSV))
            {
                paramMasv.Value = DBNull.Value; // Không truyền gì -> trả hết
            }
            else
            {
                paramMasv.Value = maSV;
            }
            cmd.Parameters.Add(paramMasv);

            
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvSV.DataSource = dt;
        }

        private void cbDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDV.SelectedValue != null && cbDV.SelectedValue is string)
            {
                dvDangChon = cbDV.SelectedValue.ToString();
                Load_DSMM();
                Load_CacMM_Da_DK();
            }
        }

        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dgvSV.Columns["checkSV"].Index && e.RowIndex >= 0)
            {
                bool current = Convert.ToBoolean(dgvSV.Rows[e.RowIndex].Cells["checkSV"].Value ?? false);
                dgvSV.Rows[e.RowIndex].Cells["checkSV"].Value = !current; // Toggle chọn/bỏ chọn
            }
        }

        private void pdt_mm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == pdt_mm.Columns["checkMM"].Index && e.RowIndex >= 0)
            {
                bool current = Convert.ToBoolean(pdt_mm.Rows[e.RowIndex].Cells["checkMM"].Value ?? false);
                pdt_mm.Rows[e.RowIndex].Cells["checkMM"].Value = !current; // Toggle chọn/bỏ chọn
            }
        }

        void Load_CacMM_Da_DK()
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_CAC_MMDADK", MainClass.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Cho phép null cho các tham số đầu vào
            cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(maSV) ? DBNull.Value : (object)maSV;
            cmd.Parameters.Add("p_hk", OracleDbType.Int32).Value = hocKy;
            cmd.Parameters.Add("p_nam", OracleDbType.Int32).Value = Nam;
            cmd.Parameters.Add("p_khoa", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(dvDangChon) ? DBNull.Value : (object)dvDangChon;

            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Lấy danh sách MaMM từ kết quả
            var maMMs = dt.AsEnumerable()
               .Select(row => row["MAMM"].ToString())
               .ToHashSet();

            // Duyệt DataGridView gốc (đã được load từ trước)
            foreach (DataGridViewRow row in pdt_mm.Rows)
            {
                if (row.IsNewRow) continue;

                string maMM = row.Cells["mm"].Value?.ToString();
                if (maMMs.Contains(maMM))
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    row.ReadOnly = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }


        private void txtSV_IconRightClick(object sender, EventArgs e)
        {
            maSV = txtSV.Text.Trim();
            Load_SV();

        }

        private void LoadDSDonVi()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_XEMDV", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbDV.DataSource = dt;
                cbDV.DisplayMember = "MADV";
                cbDV.ValueMember = "MADV";

                if (dt.Rows.Count > 0)
                {
                    dvDangChon = dt.Rows[0]["MADV"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Lấy danh sách sinh viên được chọn
                List<string> selectedSVs = new List<string>();
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["checkSV"].Value ?? false);
                    if (isChecked)
                    {
                        string masv = row.Cells["sv"].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(masv))
                            selectedSVs.Add(masv);
                    }
                }

                // Lấy danh sách mở môn được chọn
                List<string> selectedMMs = new List<string>();
                foreach (DataGridViewRow row in pdt_mm.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["checkMM"].Value ?? false);
                    if (isChecked)
                    {
                        string mamm = row.Cells["mm"].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(mamm))
                            selectedMMs.Add(mamm);
                    }
                }

                if (selectedSVs.Count == 0 || selectedMMs.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sinh viên và một học phần!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string csvSV = string.Join(",", selectedSVs);
                string csvMM = string.Join(",", selectedMMs);

                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_DANGKY_NHIEU", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_masvs", OracleDbType.Varchar2).Value = csvSV;
                    cmd.Parameters.Add("p_mamms", OracleDbType.Varchar2).Value = csvMM;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đăng ký thành công cho tất cả sinh viên và học phần đã chọn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
    }
}
