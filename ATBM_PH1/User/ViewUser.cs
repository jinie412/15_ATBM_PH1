// BaseForm.cs
using Oracle.ManagedDataAccess.Client;
using Sushi_Restaurant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class ViewUser : Form
    {
        private DataTable _cachedDataTable; // Bảng tạm lưu trữ danh sách user
        public ViewUser()
        {
            InitializeComponent();
            this.Size = new Size(720, 500);
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
                // Câu lệnh SQL để lấy danh sách user
                string query = "SELECT USERNAME FROM ALL_USERS";
                _cachedDataTable = MainClass.ExecuteQuery(query);

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

                // Cập nhật vị trí các cột hiển thị trong DataGridView
                LoadViewUser.Columns["STT"].DisplayIndex = 0;
                LoadViewUser.Columns["USERNAME"].DisplayIndex = 1;

                // Nếu có thêm cột chỉnh sửa và xóa (qua Designer), sắp xếp lại
                if (LoadViewUser.Columns.Contains("CUpdate"))
                    LoadViewUser.Columns["CUpdate"].DisplayIndex = 2;
                if (LoadViewUser.Columns.Contains("CDelete"))
                    LoadViewUser.Columns["CDelete"].DisplayIndex = 3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InsertUser_Click(object sender, EventArgs e)
        {
            InsertUser insertUser = new InsertUser();
            // Đăng ký sự kiện FormClosed để tải lại danh sách user khi form UpdateUser đóng
            insertUser.FormClosed += (s, args) => LoadUserList();
            insertUser.Show();
        }
        private void LoadViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào cột "CUpdate"
            if (e.ColumnIndex >= 0 && LoadViewUser.Columns[e.ColumnIndex].Name == "CUpdate" && e.RowIndex >= 0)
            {
                string username = LoadViewUser.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
                string inputPassword;

                // Lặp cho đến khi người dùng nhập đúng mật khẩu hoặc hủy
                while (true)
                {
                    inputPassword = PromptForPassword();

                    if (string.IsNullOrEmpty(inputPassword))
                    {
                        MessageBox.Show("Bạn đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (ValidatePassword(username, inputPassword))
                    {
                        KillUserSessions(username);
                        UpdateUser updateUser = new UpdateUser(username, inputPassword);
                        updateUser.FormClosed += (s, args) => LoadUserList();
                        updateUser.Show();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Kiểm tra nếu người dùng click vào cột "CDelete"
            else if (e.ColumnIndex >= 0 && LoadViewUser.Columns[e.ColumnIndex].Name == "CDelete" && e.RowIndex >= 0)
            {
                string username = LoadViewUser.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
                string inputPassword;

                // Lặp cho đến khi người dùng nhập đúng mật khẩu hoặc hủy
                while (true)
                {
                    inputPassword = PromptForPassword();

                    if (string.IsNullOrEmpty(inputPassword))
                    {
                        MessageBox.Show("Bạn đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (ValidatePassword(username, inputPassword))
                    {
                        // Xóa user nếu mật khẩu đúng
                        DeleteUser(username);
                        LoadUserList(); // Tải lại danh sách user sau khi xóa
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteUser(string username)
        {
            KillUserSessions(username);
            try
            {
                // Câu lệnh SQL để xóa user
                string query = $"DROP USER {username} CASCADE";
                MainClass.ExecuteQuery(query);

                MessageBox.Show($"User {username} đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Hàm hiển thị hộp thoại nhập mật khẩu
        private string PromptForPassword()
        {
            using (Form passwordForm = new Form())
            {
                passwordForm.Text = "Nhập mật khẩu";
                passwordForm.Size = new Size(300, 150);
                passwordForm.StartPosition = FormStartPosition.CenterParent;

                Label lblPassword = new Label() { Left = 20, Top = 20, Text = "Mật khẩu:", AutoSize = true };
                TextBox txtPassword = new TextBox() { Left = 100, Top = 20, Width = 150, PasswordChar = '*' };
                Button btnOK = new Button() { Text = "OK", Left = 100, Top = 60, Width = 70, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Hủy", Left = 180, Top = 60, Width = 70, DialogResult = DialogResult.Cancel };

                passwordForm.Controls.Add(lblPassword);
                passwordForm.Controls.Add(txtPassword);
                passwordForm.Controls.Add(btnOK);
                passwordForm.Controls.Add(btnCancel);

                passwordForm.AcceptButton = btnOK;
                passwordForm.CancelButton = btnCancel;

                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    return txtPassword.Text;
                }
                else
                {
                    return null;
                }
            }
        }
        //        •	Kết nối tạm thời chỉ được sử dụng để kiểm tra thông tin đăng nhập của tài khoản user.
        //•	Sau khi kiểm tra xong, bạn có thể đóng kết nối tạm thời và tiếp tục sử dụng kết nối của tài khoản SYS.
        // Hàm xác thực mật khẩu
        public static bool ValidatePassword(string username, string password)
        {
            try
            {
                // Tạo chuỗi kết nối tạm thời với thông tin user
                string tempConnectionString = $"User Id={username};Password={password};Data Source=localhost:1521/XEPDB1;";

                // Tạo kết nối tạm thời
                using (OracleConnection tempConn = new OracleConnection(tempConnectionString))
                {
                    tempConn.Open(); // Thử mở kết nối
                    tempConn.Close(); // Đóng kết nối ngay sau khi kiểm tra
                }

                // Nếu kết nối thành công, mật khẩu đúng
                return true;
            }
            catch
            {
                // Nếu kết nối thất bại, mật khẩu sai
                return false;
            }
        }

        private void BaseView_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Kill kết nối để đảm bảo không còn lưu mật khẩu cũ
        private void KillUserSessions(string username)
        {
            try
            {
                // Truy vấn để lấy danh sách SID và SERIAL# của các phiên của user
                string query = $@"
                SELECT SID, SERIAL# 
                FROM V$SESSION 
                WHERE USERNAME = '{username.ToUpper()}'";

                DataTable sessions = MainClass.ExecuteQuery(query);

                // Ngắt từng phiên của user
                foreach (DataRow row in sessions.Rows)
                {
                    string sid = row["SID"].ToString();
                    string serial = row["SERIAL#"].ToString();

                    string killQuery = $"ALTER SYSTEM KILL SESSION '{sid},{serial}' IMMEDIATE";
                    MainClass.ExecuteQuery(killQuery);
                }

                //MessageBox.Show($"Đã ngắt tất cả các kết nối của user {username}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ngắt kết nối user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CancellationTokenSource _searchCancellationTokenSource;

        private void Search_TextChanged(object sender, EventArgs e)
        {
            // Hủy token cũ nếu có
            _searchCancellationTokenSource?.Cancel();

            // Tạo token mới
            _searchCancellationTokenSource = new CancellationTokenSource();
            var token = _searchCancellationTokenSource.Token;

            // Thực hiện debounce với Task.Delay
            Task.Run(async () =>
            {
                try
                {
                    // Chờ 300ms trước khi thực hiện tìm kiếm
                    await Task.Delay(300, token);

                    // Nếu không bị hủy, thực hiện tìm kiếm
                    Invoke(new Action(() =>
                    {
                        PerformSearch(Search.Text.Trim());
                    }));
                }
                catch (TaskCanceledException)
                {
                    // Bỏ qua nếu task bị hủy
                }
            }, token);
        }

        private void PerformSearch(string searchText)
        {
            try
            {
                // Kiểm tra nếu _cachedDataTable không null
                if (_cachedDataTable != null)
                {
                    // Sử dụng DataView để lọc dữ liệu từ _cachedDataTable
                    DataView dataView = _cachedDataTable.DefaultView;
                    dataView.RowFilter = string.IsNullOrEmpty(searchText)
                        ? string.Empty // Nếu không có nội dung tìm kiếm, hiển thị tất cả
                        : $"USERNAME LIKE '%{searchText}%'"; // Lọc theo cột USERNAME

                    // Gán lại DataView đã lọc vào DataGridView
                    LoadViewUser.DataSource = dataView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


