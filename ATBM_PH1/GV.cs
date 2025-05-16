using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ATBM_PH1
{
    public partial class GV : Form
    {
        private string username;
        //private string password;

        //public GV(string username, string password)
        
        public GV(string username)
        {
            InitializeComponent();
            this.username = username;
            //this.password = password;
            LoadMomonData();

            // Gán sự kiện CellClick cho DataGridView
            GridViewLoadAssignment.CellClick += GridViewLoadAssignment_CellClick;
        }

        private void GridViewLoadAssignment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem có chọn dòng hợp lệ không
                if (e.RowIndex >= 0)
                {
                    // Lấy giá trị MAMM từ cột tương ứng (giả sử cột MAMM là cột đầu tiên, index 0)
                    DataGridViewRow row = GridViewLoadAssignment.Rows[e.RowIndex];
                    string mamm = row.Cells[0].Value?.ToString(); // Điều chỉnh index cột nếu cần

                    if (!string.IsNullOrEmpty(mamm))
                    {
                        // Mở form DSDDK và truyền username, mamm
                        DSDK dsDK = new DSDK(username, mamm);
                        dsDK.Show();
                        this.Hide(); // Ẩn form hiện tại nếu cần
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void LoadTeacherName()
        //{
        //    try
        //    {
        //        if (MainClass.conn == null || MainClass.conn.State != ConnectionState.Open)
        //        {
        //            MessageBox.Show("Kết nối cơ sở dữ liệu không khả dụng.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        string magv = MainClass.CurrentUser.Username;
        //        string query = "SELECT HOTEN FROM SYS.NHANVIEN WHERE MANLD = :Username";
        //        MessageBox.Show($"Query: {query}, Username: {username}");

        //        using (OracleCommand cmd = new OracleCommand(query, MainClass.conn))
        //        {
        //            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;

        //            object result = cmd.ExecuteScalar();
        //            if (result != null)
        //            {
        //                lb_teacherName.Text = result.ToString();
        //            }
        //            else
        //            {
        //                lb_teacherName.Text = "Không tìm thấy giảng viên";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải tên giảng viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void LoadMomonData()
        {
            try
            {
                if (MainClass.conn == null || MainClass.conn.State != ConnectionState.Open)
                {
                    MessageBox.Show("Kết nối cơ sở dữ liệu không khả dụng.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OracleCommand cmd = new OracleCommand("pdb_admin.GetMomonData", MainClass.conn)) // Gọi procedure với schema pdb_admin
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu ra kiểu SYS_REFCURSOR
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        GridViewLoadAssignment.AutoGenerateColumns = false;
                        GridViewLoadAssignment.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu môn học: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Role_Click(object sender, EventArgs e)
        {
            DSSV dSSV = new DSSV(username);
            dSSV.Show();
            this.Hide();
        }
    }
}
