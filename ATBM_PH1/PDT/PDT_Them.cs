using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class PDT_Them : Form
    {
        public PDT_Them()
        {
            InitializeComponent();
          
        }
        public string dvDangChon = "";
        public string gvDangChon = "";
        public string hpDangChon = "";

        private void PDT_Them_Load(object sender, EventArgs e)
        {
            LoadDSDonVi();
            if (PDT_momon.thaoTac == "Them")
            {
                Load_dulieu();
                Load_MaMM();
                btnCN.Text = "Thêm";
            }
            if (PDT_momon.thaoTac == "Sua")
            {
                txtMaMM.Text = PDT_momon.maMM;
                txtMaMM.Enabled = false;
                dvDangChon = PDT_momon.khoaDangChon;

                cbDV.SelectedValue = dvDangChon;
                hpDangChon = PDT_momon.hpDangChon;
                gvDangChon = PDT_momon.gvDangChon;

                Load_dulieu();
                btnCN.Text = "Cập nhật";

            }


        }
       


        private void Load_MaMM()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.FN_MAMM_TT", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("RETURN_VALUE", OracleDbType.Varchar2, 100).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                string nextMAMM = cmd.Parameters["RETURN_VALUE"].Value.ToString();
                txtMaMM.Text = nextMAMM;
        
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải mã mở môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Load_dulieu() { 
            Load_DSHP();
            Load_DSGV();
            if (PDT_momon.thaoTac == "Sua")
            {
                DanhDauGV_DangXet(PDT_momon.gvDangChon);
                DanhDauHP_DangXet(PDT_momon.hpDangChon);
            }
        }
        private void Load_DSGV()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_XEMGV", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_donvi", OracleDbType.Varchar2).Value = dvDangChon;
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu GV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_DSHP()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_XEMDSHP", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_donvi", OracleDbType.Varchar2).Value = dvDangChon;
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHP.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu HP: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDV.SelectedValue != null && cbDV.SelectedValue is string)
            {
                dvDangChon = cbDV.SelectedValue.ToString();
                // Gọi hàm Load_Dulieu() để tải lại dữ liệu
                Load_dulieu();

            }
        }

        private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGV.Columns["checkGV"].Index && e.RowIndex >= 0)
            {
                // Đặt tất cả các checkbox về false
                foreach (DataGridViewRow row in dgvGV.Rows)
                {
                    row.Cells["checkGV"].Value = false;
                }

                // Chỉ bật checkbox của dòng được click
                dgvGV.Rows[e.RowIndex].Cells["checkGV"].Value = true;
                // Gán mã HP được chọn
                gvDangChon = dgvGV.Rows[e.RowIndex].Cells["magv"].Value?.ToString() ?? "";
            }
        }

        private void dgvHP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHP.Columns["checkHP"].Index && e.RowIndex >= 0)
            {
                // Đặt tất cả các checkbox về false
                foreach (DataGridViewRow row in dgvHP.Rows)
                {
                    row.Cells["checkHP"].Value = false;
                }

                // Chỉ bật checkbox của dòng được click
                dgvHP.Rows[e.RowIndex].Cells["checkHP"].Value = true;
                // Gán mã HP được chọn
                hpDangChon = dgvHP.Rows[e.RowIndex].Cells["mahp"].Value?.ToString() ?? "";
            }
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            if (PDT_momon.thaoTac == "Them")
            {
                try
                {
                    if (MainClass.conn.State == ConnectionState.Closed)
                    {
                        MainClass.conn.Open();
                    }

                    OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_THEM_MOMON", MainClass.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = txtMaMM.Text;
                    cmd.Parameters.Add("p_mahp", OracleDbType.Varchar2).Value = hpDangChon;
                    cmd.Parameters.Add("p_magv", OracleDbType.Varchar2).Value = gvDangChon;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm môn mở thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm mở môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (PDT_momon.thaoTac == "Sua")
            {
                try
                {
                    if (MainClass.conn.State == ConnectionState.Closed)
                    {
                        MainClass.conn.Open();
                    }

                    OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_SUAMM", MainClass.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = txtMaMM.Text;
                    cmd.Parameters.Add("p_magv", OracleDbType.Varchar2).Value = gvDangChon;
                    cmd.Parameters.Add("p_mahp", OracleDbType.Varchar2).Value = hpDangChon;
                    

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa mở môn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa mở môn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void DanhDauGV_DangXet(string maGvHienTai)
        {
            foreach (DataGridViewRow row in dgvGV.Rows)
            {
                if (row.Cells["magv"].Value != null && row.Cells["magv"].Value.ToString() == maGvHienTai)
                {
                    row.Cells["checkGV"].Value = true;
                }
                else
                {
                    row.Cells["checkGV"].Value = false;
                }
            }
        }
        private void DanhDauHP_DangXet(string maHpHienTai)
        {
            foreach (DataGridViewRow row in dgvHP.Rows)
            {
                if (row.Cells["mahp"].Value != null && row.Cells["mahp"].Value.ToString() == maHpHienTai)
                {
                    row.Cells["checkHP"].Value = true;
                }
                else
                {
                    row.Cells["checkHP"].Value = false;
                }
            }
        }

    }
}
