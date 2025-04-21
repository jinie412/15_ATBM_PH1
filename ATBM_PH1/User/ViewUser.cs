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
        private string _adminPassword; // Lưu mật khẩu admin

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
                string query = @"
                    SELECT USERNAME
                    FROM DBA_USERS
                    WHERE ORACLE_MAINTAINED = 'N'
                      AND ACCOUNT_STATUS = 'OPEN'
                      AND USERNAME NOT IN ('SYS', 'SYSTEM')
                        AND USERNAME NOT LIKE 'PDB_ADMIN'
                    ORDER BY USERNAME
                ";

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
            insertUser.FormClosed += (s, args) => LoadUserList();
            insertUser.Show();
        }

        private void LoadViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string username = LoadViewUser.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();

                // Kiểm tra nếu người dùng click vào cột "CUpdate"
                if (LoadViewUser.Columns[e.ColumnIndex].Name == "CUpdate")
                {
                    if (PromptForAdminPassword())
                    {
                        KillUserSessions(username);
                        UpdateUser updateUser = new UpdateUser(username);
                        updateUser.FormClosed += (s, args) => LoadUserList();
                        updateUser.Show();
                    }
                }
                // Kiểm tra nếu người dùng click vào cột "CDelete"
                else if (LoadViewUser.Columns[e.ColumnIndex].Name == "CDelete")
                {
                    if (PromptForAdminPassword())
                    {
                        DeleteUser(username);
                        LoadUserList();
                    }
                }
            }
        }

        private void DeleteUser(string username)
        {
            KillUserSessions(username);
            try
            {
                string query = $"DROP USER {username} CASCADE";
                MainClass.ExecuteQuery(query);

                MessageBox.Show($"User {username} đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool PromptForAdminPassword()
        {
            string inputPassword = PromptForPassword();
            if (string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Bạn đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ValidateAdminPassword(inputPassword))
            {
                _adminPassword = inputPassword; // Lưu mật khẩu admin để sử dụng
                return true;
            }
            else
            {
                MessageBox.Show("Mật khẩu admin không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string PromptForPassword()
        {
            using (Form passwordForm = new Form())
            {
                passwordForm.Text = "Mật khẩu admin";
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

        private bool ValidateAdminPassword(string password)
        {
            try
            {
                string adminConnectionString = $"User Id=PDB_ADMIN;Password={password};Data Source=localhost:1521/QLDULIEUNOIBO;";
                using (OracleConnection adminConn = new OracleConnection(adminConnectionString))
                {
                    adminConn.Open();
                    adminConn.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void KillUserSessions(string username)
        {
            try
            {
                string query = $@"
                SELECT SID, SERIAL# 
                FROM V$SESSION 
                WHERE USERNAME = '{username.ToUpper()}'";

                DataTable sessions = MainClass.ExecuteQuery(query);

                foreach (DataRow row in sessions.Rows)
                {
                    string sid = row["SID"].ToString();
                    string serial = row["SERIAL#"].ToString();

                    string killQuery = $"ALTER SYSTEM KILL SESSION '{sid},{serial}' IMMEDIATE";
                    MainClass.ExecuteQuery(killQuery);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ngắt kết nối user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
