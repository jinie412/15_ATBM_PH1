using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ATBM_PH1
{
    public partial class DSSV : Form
    {
        private string username;
        //        private string password;

        // public DSSV(string username, string password)
        public DSSV(string username)
        {
            InitializeComponent();
            this.username = username;
       //     this.password = password;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_LayDSHocSinh", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu ra kiểu SYS_REFCURSOR
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Gán dữ liệu vào DataGridView
                        GridViewStudents.AutoGenerateColumns = false; // Tắt tự động tạo cột
                        GridViewStudents.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sinh viên: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}