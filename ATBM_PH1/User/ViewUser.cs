using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Web.Security;

namespace ATBM_PH1
{
    public partial class ViewUser : Form
    {
        private DataTable _cachedDataTable; // Bảng tạm lưu trữ danh sách user
        private string _adminPassword; // Lưu mật khẩu admin

        public ViewUser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Load += ViewUser_Load;

            // Đăng ký sự kiện CellClick cho DataGridView
            LoadViewUser.CellClick += LoadViewUser_CellClick;

            // Đăng ký sự kiện TextChanged cho TextBox tìm kiếm
            Search.TextChanged += Search_TextChanged;
        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            LoadUserList();
        }

        private void LoadUserList()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("GetUserList", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        _cachedDataTable = new DataTable();
                        adapter.Fill(_cachedDataTable);
                    }
                }

                    //_cachedDataTable = MainClass.ExecuteQuery(query);

                // Thêm cột STT vào datatable
                _cachedDataTable.Columns.Add("STT", typeof(int));

                // Gán giá trị STT (1, 2, 3, ...)
                for (int i = 0; i < _cachedDataTable.Rows.Count; i++)
                {
                    _cachedDataTable.Rows[i]["STT"] = i + 1;
                }

                // Đặt STT là cột đầu tiên
                _cachedDataTable.Columns["STT"].SetOrdinal(0);

                // Gán dữ liệu vào DataGridView
                LoadViewUser.DataSource = _cachedDataTable;

                // Đặt tiêu đề cho các cột
                LoadViewUser.Columns["STT"].HeaderText = "STT";
                LoadViewUser.Columns["USERNAME"].HeaderText = "User";

                // Thêm cột CUpdate nếu chưa tồn tại
                if (!LoadViewUser.Columns.Contains("CUpdate"))
                {
                    DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn
                    {
                        Name = "CUpdate",
                        HeaderText = "Cập nhật",
                        Text = "Cập nhật",
                        UseColumnTextForButtonValue = true
                    };
                    LoadViewUser.Columns.Add(updateColumn);
                }

                // Thêm cột CGrant nếu chưa tồn tại
                if (!LoadViewUser.Columns.Contains("CGrant"))
                {
                    DataGridViewButtonColumn grantColumn = new DataGridViewButtonColumn
                    {
                        Name = "CGrant",
                        HeaderText = "Cấp quyền",
                        Text = "Cấp quyền",
                        UseColumnTextForButtonValue = true
                    };
                    LoadViewUser.Columns.Add(grantColumn);
                }

                // Thêm cột CDelete nếu chưa tồn tại
                if (!LoadViewUser.Columns.Contains("CDelete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "CDelete",
                        HeaderText = "Xóa",
                        Text = "Xóa",
                        UseColumnTextForButtonValue = true
                    };
                    LoadViewUser.Columns.Add(deleteColumn);
                }

                // Cập nhật vị trí các cột hiển thị trong DataGridView
                LoadViewUser.Columns["STT"].DisplayIndex = 0;
                LoadViewUser.Columns["USERNAME"].DisplayIndex = 1;
                LoadViewUser.Columns["CUpdate"].DisplayIndex = 2;
                LoadViewUser.Columns["CGrant"].DisplayIndex = 3;
                LoadViewUser.Columns["CDelete"].DisplayIndex = 4;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertUser_Click(object sender, EventArgs e)
        {
            InsertUser insertUser = new InsertUser();
            insertUser.FormClosed += (s, args) => LoadUserList();
            insertUser.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(insertUser, this);

        }

        private void LoadViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string username = LoadViewUser.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();

                // Kiểm tra nếu người dùng click vào cột "CUpdate"
                if (LoadViewUser.Columns[e.ColumnIndex].Name == "CUpdate")
                {
                    KillUserSessions(username);
                    UpdateUser updateUser = new UpdateUser(username);
                    updateUser.FormClosed += (s, args) => LoadUserList();
                    updateUser.StartPosition = FormStartPosition.CenterScreen;
                    MainClass.BlurBackground(updateUser, this);
                }
                // Kiểm tra nếu người dùng click vào cột "CGrant"
                else if (LoadViewUser.Columns[e.ColumnIndex].Name == "CGrant")
                {
                    MainClass.User = username;
                    MainClass.Role = "";
                    CapQuyen_CSDL capQuyen = new CapQuyen_CSDL();
                    capQuyen.StartPosition = FormStartPosition.CenterScreen;
                    MainClass.BlurBackground(capQuyen, this);
                }
                // Kiểm tra nếu người dùng click vào cột "CDelete"
                else if (LoadViewUser.Columns[e.ColumnIndex].Name == "CDelete")
                {
                    DeleteUser(username);
                    LoadUserList();
                }
            }
        }

        private void DeleteUser(string username)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa user '{username}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Nếu người dùng chọn "No", thoát khỏi phương thức
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                // Ngắt kết nối các session của user
                using (OracleCommand killCmd = new OracleCommand("KillUserSessions", MainClass.conn))
                {
                    killCmd.CommandType = CommandType.StoredProcedure;
                    killCmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
                    killCmd.ExecuteNonQuery();
                }

                // Xóa user
                using (OracleCommand dropCmd = new OracleCommand("DropUser", MainClass.conn))
                {
                    dropCmd.CommandType = CommandType.StoredProcedure;
                    dropCmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
                    dropCmd.ExecuteNonQuery();
                }

                // Thông báo thành công
                MessageBox.Show($"User '{username}' đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu xóa không thành công
                MessageBox.Show($"Lỗi khi xóa user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }

        private void KillUserSessions(string username)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("KillUserSessions", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ngắt kết nối user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }


        private CancellationTokenSource _searchCancellationTokenSource;

        private void Search_TextChanged(object sender, EventArgs e)
        {
            _searchCancellationTokenSource?.Cancel();
            _searchCancellationTokenSource = new CancellationTokenSource();
            var token = _searchCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(300, token);

                    Invoke(new Action(() =>
                    {
                        PerformSearch(Search.Text.Trim());
                    }));
                }
                catch (TaskCanceledException)
                {
                }
            }, token);
        }

        private void PerformSearch(string searchText)
        {
            try
            {
                if (_cachedDataTable != null)
                {
                    DataView dataView = _cachedDataTable.DefaultView;
                    dataView.RowFilter = string.IsNullOrEmpty(searchText)
                        ? string.Empty
                        : $"USERNAME LIKE '%{searchText}%'";

                    LoadViewUser.DataSource = dataView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
           
            this.Close();
         
        }
    }
}