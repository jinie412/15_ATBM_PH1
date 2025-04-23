using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class Role : Form
    {
        private bool isDragging = false;
        private Point dragStartPosition;
        private string selectedGrantRole = "";
        private string selectedRevokeRole = "";

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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một Role để sửa.");
                return;
            }

            string roleName = dataGridViewRoles.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show($"Sửa role: {roleName}");
            // Thêm logic để sửa role nếu cần
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một Role để xóa.");
                return;
            }

            string roleName = dataGridViewRoles.SelectedRows[0].Cells["RoleName"].Value.ToString();

            // Xác nhận người dùng
            var result = MessageBox.Show($"Bạn có chắc muốn xoá role '{roleName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                        if (!string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Đã xoá role '{roleName}' thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowManageRolesContent(); // Tải lại danh sách role
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xoá role: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnGrant_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cấp quyền cho role đã chọn");
        }

        private void btnRevoke_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRevokeRole))
            {
                MessageBox.Show("Vui lòng chọn role để thu hồi quyền.");
                return;
            }

            List<string> revokePrivs = new List<string>();

            if (checkBoxRevokeSelect.Checked) revokePrivs.Add("SELECT");
            if (checkBoxRevokeInsert.Checked) revokePrivs.Add("INSERT");
            if (checkBoxRevokeUpdate.Checked) revokePrivs.Add("UPDATE");
            if (checkBoxRevokeDelete.Checked) revokePrivs.Add("DELETE");

            if (revokePrivs.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một quyền để thu hồi.");
                return;
            }

            string objectName = comboBoxObjectName.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(objectName))
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần thu hồi quyền.");
                return;
            }

            foreach (var priv in revokePrivs)
            {
                string sql = $"REVOKE {priv} ON {objectName} FROM {selectedRevokeRole}";
                ExecuteNonQuery(sql);
            }

            MessageBox.Show("Thu hồi quyền thành công.");
        }

        private void dataGridViewGrantRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedGrantRole = dataGridViewGrantRoles.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageBox.Show($"Đã chọn role để cấp quyền: {selectedGrantRole}");
            }
        }

        private void dataGridViewRevokeRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRevokeRole = dataGridViewRevokeRoles.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageBox.Show($"Đã chọn role để thu hồi quyền: {selectedRevokeRole}");
            }
        }

        private void ShowManageRolesContent()
        {
            panelManageRoles.Visible = true;
            panelGrantPermissions.Visible = false;
            panelRevokePermissions.Visible = false;
            panelViewPermissions.Visible = false;

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

                        using (var reader = cmd.ExecuteReader())
                        {
                            int columnCount = reader.FieldCount;
                            if (columnCount != 3)
                            {
                                MessageBox.Show($"Lỗi: Stored procedure trả về {columnCount} cột, nhưng cần 3 cột.");
                                return;
                            }

                            dataGridViewRoles.Rows.Clear();
                            while (reader.Read())
                            {
                                int roleIndex = reader.GetOrdinal("ROLE");
                                int privilegesIndex = reader.GetOrdinal("PRIVILEGES");
                                int hasPasswordIndex = reader.GetOrdinal("HAS_PASSWORD");

                                string role = reader.IsDBNull(roleIndex) ? "" : reader.GetString(roleIndex);
                                string privileges = reader.IsDBNull(privilegesIndex) ? "Không có quyền" : reader.GetString(privilegesIndex);
                                string hasPassword = reader.IsDBNull(hasPasswordIndex) ? "Không xác định" : reader.GetString(hasPasswordIndex);

                                dataGridViewRoles.Rows.Add(role, privileges, hasPassword);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải role: {ex.Message}\nStackTrace: {ex.StackTrace}");
                }
            }
        }

        private void ShowGrantPermissionsContent()
        {
            panelManageRoles.Visible = false;
            panelGrantPermissions.Visible = true;
            panelRevokePermissions.Visible = false;
            panelViewPermissions.Visible = false;

            // Load roles from database
            List<string> roles = ExecuteColumnQuery("SELECT role FROM dba_roles");
            dataGridViewGrantRoles.Rows.Clear();
            foreach (var role in roles)
            {
                dataGridViewGrantRoles.Rows.Add(role);
            }
        }

        private void ShowRevokePermissionsContent()
        {
            panelManageRoles.Visible = false;
            panelGrantPermissions.Visible = false;
            panelRevokePermissions.Visible = true;
            panelViewPermissions.Visible = false;

            // Load roles from database
            List<string> roles = ExecuteColumnQuery("SELECT role FROM dba_roles");
            dataGridViewRevokeRoles.Rows.Clear();
            foreach (var role in roles)
            {
                dataGridViewRevokeRoles.Rows.Add(role);
            }
        }

        private void ShowViewPermissionsContent()
        {
            panelManageRoles.Visible = false;
            panelGrantPermissions.Visible = false;
            panelRevokePermissions.Visible = false;
            panelViewPermissions.Visible = true;

            // Load permissions from database
            string sql = "SELECT table_name, privilege FROM dba_tab_privs WHERE grantee IN (SELECT role FROM dba_roles)";
            using (var conn = new OracleConnection("User Id=pdb_admin;Password=MyPassword;Data Source=localhost:1521/QLDULIEUNOIBO"))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataGridViewPermissions.Rows.Clear();
                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);
                            string privilege = reader.GetString(1);
                            // Add to DataGridView based on privilege
                            int rowIndex = -1;
                            foreach (DataGridViewRow row in dataGridViewPermissions.Rows)
                            {
                                if (row.Cells["TableName"].Value?.ToString() == tableName)
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                            if (rowIndex == -1)
                            {
                                rowIndex = dataGridViewPermissions.Rows.Add();
                                dataGridViewPermissions.Rows[rowIndex].Cells["TableName"].Value = tableName;
                            }
                            if (privilege == "SELECT") dataGridViewPermissions.Rows[rowIndex].Cells["Select"].Value = "Yes";
                            else if (privilege == "INSERT") dataGridViewPermissions.Rows[rowIndex].Cells["Insert"].Value = "Yes";
                            else if (privilege == "UPDATE") dataGridViewPermissions.Rows[rowIndex].Cells["Update"].Value = "Yes";
                            else if (privilege == "DELETE") dataGridViewPermissions.Rows[rowIndex].Cells["Delete"].Value = "Yes";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải quyền: {ex.Message}");
                }
            }
        }

        private void btnManageRolesTab_Click(object sender, EventArgs e)
        {
            ShowManageRolesContent();
            SetActiveButton(btnManageRolesTab);
        }

        private void btnGrantPermissionsTab_Click(object sender, EventArgs e)
        {
            ShowGrantPermissionsContent();
            SetActiveButton(btnGrantPermissionsTab);
        }

        private void btnRevokePermissionsTab_Click(object sender, EventArgs e)
        {
            ShowRevokePermissionsContent();
            SetActiveButton(btnRevokePermissionsTab);
        }

        private void btnViewPermissionsTab_Click(object sender, EventArgs e)
        {
            ShowViewPermissionsContent();
            SetActiveButton(btnViewPermissionsTab);
        }

        private void SetActiveButton(Guna.UI2.WinForms.Guna2Button activeButton)
        {
            btnManageRolesTab.FillColor = Color.Transparent;
            btnGrantPermissionsTab.FillColor = Color.Transparent;
            btnRevokePermissionsTab.FillColor = Color.Transparent;
            btnViewPermissionsTab.FillColor = Color.Transparent;

            activeButton.FillColor = Color.FromArgb(76, 132, 255);
        }

        private void btnGrantPermission_Click(object sender, EventArgs e)
        {
            string role = selectedGrantRole;
            string objectType = comboBoxObjectType.SelectedItem?.ToString();
            string objectName = comboBoxObjectName.SelectedItem?.ToString();
            List<string> privileges = new List<string>();

            if (checkBoxSelect.Checked) privileges.Add("SELECT");
            if (checkBoxInsert.Checked) privileges.Add("INSERT");
            if (checkBoxUpdate.Checked) privileges.Add("UPDATE");
            if (checkBoxDelete.Checked) privileges.Add("DELETE");

            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(objectName) || privileges.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Role, Đối tượng và Quyền.");
                return;
            }

            string withGrant = checkBoxWithGrantOption.Checked ? " WITH GRANT OPTION" : "";
            foreach (var priv in privileges)
            {
                string sql = $"GRANT {priv} ON {objectName} TO {role}{withGrant}";
                ExecuteNonQuery(sql);
            }

            MessageBox.Show("Đã cấp quyền thành công.");
        }

        private List<string> ExecuteColumnQuery(string sql)
        {
            List<string> result = new List<string>();
            string connectionString = "User Id=pdb_admin;Password=MyPassword;Data Source=localhost:1521/QLDULIEUNOIBO";

            using (var conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi truy vấn: {ex.Message}");
                }
            }

            return result;
        }

        private void ExecuteNonQuery(string sql)
        {
            string connectionString = "User Id=pdb_admin;Password=MyPassword;Data Source=localhost:1521/QLDULIEUNOIBO";

            using (var conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi thực thi: {ex.Message}");
                }
            }
        }

        private void checkBoxSelect_CheckedChanged(object sender, EventArgs e)
        {
            panelSelectColumns.Visible = checkBoxSelect.Checked;
        }

        private void checkBoxUpdate_CheckedChanged(object sender, EventArgs e)
        {
            panelUpdateColumns.Visible = checkBoxUpdate.Checked;
        }

        private void comboBoxObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string objectType = comboBoxObjectType.SelectedItem?.ToString();
            comboBoxObjectName.Items.Clear();

            if (string.IsNullOrEmpty(objectType)) return;

            string sql = "";
            switch (objectType)
            {
                case "TABLE":
                    sql = "SELECT table_name FROM user_tables";
                    break;
                case "VIEW":
                    sql = "SELECT view_name FROM user_views";
                    break;
                case "PROCEDURE":
                    sql = "SELECT object_name FROM user_procedures WHERE object_type = 'PROCEDURE'";
                    break;
                case "FUNCTION":
                    sql = "SELECT object_name FROM user_procedures WHERE object_type = 'FUNCTION'";
                    break;
            }

            List<string> objects = ExecuteColumnQuery(sql);
            comboBoxObjectName.Items.AddRange(objects.ToArray());
        }

        private void LoadColumnsToPanels(string tableName)
        {
            panelSelectColumns.Controls.Clear();
            panelUpdateColumns.Controls.Clear();

            string sql = $"SELECT column_name FROM user_tab_columns WHERE table_name = '{tableName.ToUpper()}'";
            List<string> columns = ExecuteColumnQuery(sql);

            foreach (string col in columns)
            {
                var chkSelect = new Guna.UI2.WinForms.Guna2CheckBox
                {
                    Text = col,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10)
                };
                panelSelectColumns.Controls.Add(chkSelect);

                var chkUpdate = new Guna.UI2.WinForms.Guna2CheckBox
                {
                    Text = col,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10)
                };
                panelUpdateColumns.Controls.Add(chkUpdate);
            }
        }
    }
}