using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
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
    public partial class PDT_Dangky : Form
    {
        public PDT_Dangky()
        {
            InitializeComponent();
        }


        public int hocKy = 3;
        public int Nam = 2025;
        public string maMM = "";
        public string maSV = "";
        public string dvDangChon = "";

        private void PDT_Dangky_Load(object sender, EventArgs e)
        {
            Load_DSDK();
        }
        void Load_DSDK()
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
            pdt_mm.DataSource = dt;

        }

        private void txtSV_IconRightClick(object sender, EventArgs e)
        {
            maSV = txtSV.Text.Trim();
            Load_DSDK(); 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PDT_ThemDK frm = new PDT_ThemDK();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            Load_DSDK();    
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (pdt_mm.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maMM = pdt_mm.SelectedRows[0].Cells[0].Value.ToString();
                string masv = pdt_mm.SelectedRows[0].Cells[3].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa dòng đăng ký:\nMã môn: {maMM}\nMã sinh viên: {masv}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_XOA_DANGKY", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm đầy đủ tham số
                cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = maMM;
                cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = masv;

                var deletedCountParam = new OracleParameter("p_deleted_count", OracleDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(deletedCountParam);

                // Thực thi duy nhất 1 lần
                cmd.ExecuteNonQuery();

                // Lấy kết quả
                int deletedRows = ((OracleDecimal)deletedCountParam.Value).ToInt32();
                if (deletedRows > 0)
                {
                    MessageBox.Show("Xóa thành công.");
                    Load_DSDK();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Có thể bạn không có quyền hoặc dòng đã bị thay đổi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
