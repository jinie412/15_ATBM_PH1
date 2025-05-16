using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ATBM_PH1
{
    public partial class DSDK : Form
    {
        private string username;
        private string mamm;

        public DSDK(string username, string mamm)
        {
            InitializeComponent();
            this.username = username;
            this.mamm = mamm;
            LoadDangKyData();
        }

        private void LoadDangKyData()
        {
            try
            {
                if (MainClass.conn == null || MainClass.conn.State != ConnectionState.Open)
                {
                    MessageBox.Show("Kết nối cơ sở dữ liệu không khả dụng.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OracleCommand cmd = new OracleCommand("pdb_admin.LayDSDK", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu vào
                    cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = mamm;

                    // Thêm tham số đầu ra kiểu SYS_REFCURSOR
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Gán dữ liệu vào DataGridView và cho phép tự động tạo cột
                        GridViewDangKy.AutoGenerateColumns = true; // Bật tự động tạo cột
                        GridViewDangKy.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu đăng ký: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void User_Click(object sender, EventArgs e)
        {
            GV newGV = new GV(username);
            newGV.Show();
            this.Close();
        }

        private void Role_Click(object sender, EventArgs e)
        {
            DSSV dSSV = new DSSV(username);
            dSSV.Show();
            this.Close();
        }

        //private void btnBack_Click(object sender, EventArgs e)
        //{
        //    // Quay lại form GV
        //    GV gvForm = new GV(username, /* password nếu cần */);
        //    gvForm.Show();
        //    this.Close();
        //}
    }
}