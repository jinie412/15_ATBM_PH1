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
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_GetDangKyData", MainClass.conn))
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

       
    }
}