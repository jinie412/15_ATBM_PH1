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
    public partial class PDT_SuaTT : Form
    {
        public PDT_SuaTT()
        {
            InitializeComponent();
        }

       public string maSV = "";

        private void PDT_ThemDK_Load(object sender, EventArgs e)
        {
           
            Load_SV();
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

      
        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dgvSV.Columns["checkSV"].Index && e.RowIndex >= 0)
            {
                bool current = Convert.ToBoolean(dgvSV.Rows[e.RowIndex].Cells["checkSV"].Value ?? false);
                dgvSV.Rows[e.RowIndex].Cells["checkSV"].Value = !current; // Toggle chọn/bỏ chọn
            }
        }

       

       


        private void txtSV_IconRightClick(object sender, EventArgs e)
        {
            maSV = txtSV.Text.Trim();
            Load_SV();

        }



        private void btnCN_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    // Giả sử cột checkbox là kiểu bool hoặc CheckBoxColumn và tên là "chon"
                    bool isChecked = Convert.ToBoolean(row.Cells["checkSV"].Value);

                    if (isChecked)
                    {
                        string maSV = row.Cells["sv"].Value.ToString();      
                        string tinhTrang = cbTT.SelectedItem.ToString();      

                        using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_SUA_TINHTRANG", MainClass.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Thêm tham số
                            cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = maSV;
                            cmd.Parameters.Add("p_tinhtrang", OracleDbType.Varchar2).Value = tinhTrang;

                            // Gọi procedure
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Cập nhật tình trạng thành công cho sinh viên đã chọn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_SV();

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
