using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Sushi_Restaurant;
using System.Security.Cryptography;
using System.Web.Security;
using TheArtOfDevHtmlRenderer.Adapters;

namespace ATBM_PH1
{
    public partial class Role : Form
    {
        private bool isDragging = false;
        private Point dragStartPosition;
        private string selectedGrantRole = "";
        private string selectedRevokeRole = "";
        private CancellationTokenSource _searchCancellationTokenSource;
        private DataTable _cachedDataTable;



        public Role()
        {
            try
            {
                InitializeComponent();

                // Enable dragging on the title bar
                panelTitleBar.MouseDown += new MouseEventHandler(panelTitleBar_MouseDown);
                panelTitleBar.MouseMove += new MouseEventHandler(panelTitleBar_MouseMove);
                panelTitleBar.MouseUp += new MouseEventHandler(panelTitleBar_MouseUp);
                labelFormTitle.MouseDown += new MouseEventHandler(panelTitleBar_MouseDown);
                labelFormTitle.MouseMove += new MouseEventHandler(panelTitleBar_MouseMove);
                labelFormTitle.MouseUp += new MouseEventHandler(panelTitleBar_MouseUp);

                // Show Manage Roles content by default
                ShowManageRolesContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}");
            }
        }

        private void Role_Load(object sender, EventArgs e)
        {
#if DEBUG
            ShowManageRolesContent();
#endif
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPosition = new Point(e.X, e.Y);
            }
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(new Point(e.X, e.Y));
                Location = new Point(p.X - dragStartPosition.X, p.Y - dragStartPosition.Y);
            }
        }

        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form Quản lý User");
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizeRestore_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximizeRestore.Text = "❐";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximizeRestore.Text = "□";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            // Mở form CreateRoleForm
            CreateRoleForm createRoleForm = new CreateRoleForm();
            createRoleForm.ShowDialog(); // Mở form dưới dạng dialog (chờ người dùng nhập xong)

            // Sau khi form đóng, làm mới danh sách role
            ShowManageRolesContent();
            //dataGridViewRoles.Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một Role để sửa.");
                return;
            }

            string roleName = dataGridViewRoles.SelectedRows[0].Cells[0].Value.ToString();

            // Hiển thị form nhập mật khẩu
            using (UpdatePasswordForm passwordForm = new UpdatePasswordForm(roleName))
            {
                if (passwordForm.ShowDialog() != DialogResult.OK)
                {
                    return; // Người dùng nhấn Cancel
                }

                string newPassword = passwordForm.NewPassword;

                // Gọi stored procedure để cập nhật mật khẩu
                try
                {
                    string connectionString = "User Id=pdb_admin;Password=MyPassword;Data Source=localhost:1521/QLDULIEUNOIBO";
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        conn.Open();
                        using (OracleCommand cmd = new OracleCommand("UPDATE_ROLE_PASSWORD", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số cho stored procedure
                            cmd.Parameters.Add("p_role_name", OracleDbType.Varchar2).Value = roleName;
                            cmd.Parameters.Add("p_new_password", OracleDbType.Varchar2).Value = newPassword;
                            cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                            // Thực thi stored procedure
                            cmd.ExecuteNonQuery();

                            // Lấy kết quả từ tham số output
                            string result = cmd.Parameters["p_result"].Value.ToString();
                            MessageBox.Show(result);

                            // Nếu cập nhật thành công, làm mới DataGridView
                            if (result.Contains("thành công"))
                            {
                                ShowManageRolesContent();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật mật khẩu: " + ex.Message);
                }
            }  
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một Role để xóa.");
                return;
            }

            string roleName = string.Empty;

            if (dataGridViewRoles.SelectedRows.Count > 0)
            {
                // Lấy giá trị từ cột "Tên Role" (khớp với tên cột từ stored procedure)
                var cellValue = dataGridViewRoles.SelectedRows[0].Cells["Tên Role"].Value;
                roleName = cellValue != null ? cellValue.ToString() : string.Empty;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách role!");
            }

            // Xác nhận người dùng
            var result = MessageBox.Show($"Do you want to delete '{roleName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            string connectionString = "User Id=pdb_admin;Password=MyPassword;Data Source=localhost:1521/QLDULIEUNOIBO";

            using (var conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("DROP_EXISTING_ROLE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_role_name", OracleDbType.Varchar2).Value = roleName;
                        cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 4000).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        string error = cmd.Parameters["p_error"].Value?.ToString();
                        if (string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Đã xoá role '{roleName}' thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             
                        }
                        ShowManageRolesContent(); // Tải lại danh sách role
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xoá role: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        private void ShowManageRolesContent()
        {
            panelManageRoles.Visible = true;
           

            string connectionString = "User Id=pdb_admin;Password=MyPassword;Data Source=localhost:1521/QLDULIEUNOIBO";
            using (var conn = new OracleConnection(connectionString))
            {

                try
                {
                    conn.Open();

                    using (var cmd = new OracleCommand("GET_ROLES_INFO", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        var pCursor = new OracleParameter("p_cursor", OracleDbType.RefCursor)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(pCursor);

                        using (var adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewRoles.DataSource = null; // Xóa dữ liệu cũ
                            dataGridViewRoles.Refresh();
                            dataGridViewRoles.DataSource = dt;   // Gán dữ liệu mới
                            dataGridViewRoles.Refresh();         // Làm mới giao diện
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            _cachedDataTable = new DataTable();
                            _cachedDataTable.Load(reader);

                            // Kiểm tra DataGridView có tồn tại không
                            if (dataGridViewRoles == null)
                            {
                                MessageBox.Show("Lỗi: DataGridViewRoles không được khởi tạo!");
                                return;
                            }

                            // Tạo DataTable mới chỉ chứa các cột "Tên Role" và "Mật Khẩu"
                            DataTable filteredTable = new DataTable();
                            if (_cachedDataTable.Columns.Contains("Tên Role") && _cachedDataTable.Columns.Contains("Mật Khẩu"))
                            {
                                filteredTable.Columns.Add("Tên Role", typeof(string));
                                filteredTable.Columns.Add("Mật Khẩu", typeof(string));

                                // Sao chép dữ liệu từ _cachedDataTable sang filteredTable
                                foreach (DataRow row in _cachedDataTable.Rows)
                                {
                                    filteredTable.Rows.Add(row["Tên Role"], row["Mật Khẩu"]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lỗi: Tên cột không khớp với kết quả từ stored procedure!");
                                return;
                            }

                            // Kiểm tra số cột
                            if (filteredTable.Columns.Count != 2)
                            {
                                MessageBox.Show($"Lỗi: Dữ liệu sau khi lọc có {filteredTable.Columns.Count} cột, nhưng cần 2 cột.");
                                return;
                            }

                            // Xóa cột cũ và gán DataSource
                            dataGridViewRoles.Columns.Clear();

                            // Thêm cột STT trước khi gán DataSource
                            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                            {
                                Name = "STT",
                                HeaderText = "STT",
                                ReadOnly = true
                            };
                            dataGridViewRoles.Columns.Add(sttColumn); // Thêm cột STT

                            // Gán DataSource
                            dataGridViewRoles.DataSource = filteredTable;

                            // Đặt lại tiêu đề cột
                            dataGridViewRoles.Columns["Tên Role"].HeaderText = "Tên Role";
                            dataGridViewRoles.Columns["Mật Khẩu"].HeaderText = "Mật Khẩu";

                            // Đảm bảo cột STT ở vị trí đầu tiên
                            dataGridViewRoles.Columns["STT"].DisplayIndex = 0;

                            // Tự động điền giá trị STT sau khi dữ liệu được gán
                            dataGridViewRoles.DataBindingComplete += (sender, e) =>
                            {
                                int stt = 1;
                                foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                                {
                                    if (row.IsNewRow) continue; // Bỏ qua hàng mới (nếu có)
                                    row.Cells[0].Value = stt++; // Sử dụng chỉ số cột 0 (cột STT)
                                }
                            };
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải role: {ex.Message}\nStackTrace: {ex.StackTrace}");
                }
            }
        }


       
        private void textRole_TextChanged(object sender, EventArgs e)
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
                        PerformSearch(textRole.Text.Trim());
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
                        : $"[Tên Role] LIKE '%{searchText}%'";

                    dataGridViewRoles.DataSource = dataView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}