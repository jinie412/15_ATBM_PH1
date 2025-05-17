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
                // Đặt tất cả các checkbox về false
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    row.Cells["checkSV"].Value = false;
                }

                // Chỉ bật checkbox của dòng được click
                dgvSV.Rows[e.RowIndex].Cells["checkSV"].Value = true;
                // Gán mã HP được chọn
                maSV = dgvSV.Rows[e.RowIndex].Cells["sv"].Value?.ToString() ?? "";
            }
        }

        private void pdt_mm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == pdt_mm.Columns["checkmm"].Index && e.RowIndex >= 0)
            {
                // Đặt tất cả các checkbox về false
                foreach (DataGridViewRow row in pdt_mm.Rows)
                {
                    row.Cells["checkmm"].Value = false;
                }

                // Chỉ bật checkbox của dòng được click
                pdt_mm.Rows[e.RowIndex].Cells["checkmm"].Value = true;
                // Gán mã HP được chọn
                maMM = pdt_mm.Rows[e.RowIndex].Cells["mm"].Value?.ToString() ?? "";
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
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_THEMDK", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Truyền tham số
                cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = maSV;
                cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = maMM;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Đăng ký học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký học phần:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
