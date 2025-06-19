using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ATBM_PH1
{
    public partial class CapQuyen_CSDL : Form
    {
        public CapQuyen_CSDL()
        {
            InitializeComponent();
            checkedListBox2.ItemCheck += checkedListBox2_ItemCheck;
            LoadRolesToComboBox();
            cbObjectType.SelectedIndexChanged += cbObjectType_SelectedIndexChanged;

            lbuser.Text = "";
            if (!string.IsNullOrEmpty(MainClass.Role))
            {
                cbCaprole.Enabled = false;
                checkbwgo.Enabled = false;
                lbuser.Text = "Role: " + MainClass.Role;
            }
            else
            {
                cbCaprole.Enabled = true;
                lbuser.Text = "User: " + MainClass.User;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox2.Visible = false;
            checkedListBox2.CheckOnClick = true;
            checkedListBox1.CheckOnClick = true;
            checkedListBox3.CheckOnClick = true;
            checkedListBox4.Visible = false;
            checkedListBox4.CheckOnClick = true;
            checkedListBox5.Visible = false;
            checkedListBox5.CheckOnClick = true;
            checkedListBox6.Visible = false;
            checkedListBox6.CheckOnClick = true;
            // Đăng ký sự kiện Click cho TextBox
            txtQuyen.Click += txtQuyen_Click;
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            checkedListBox2.Visible = !checkedListBox2.Visible;
            checkedListBox2.BringToFront();
            checkedListBox2.Location = new Point(txtQuyen.Left, txtQuyen.Bottom);
        }

        private void HandleItemCheck(CheckedListBox listBox, ItemCheckEventArgs e, Control targetTextBox, string defaultText)
        {
            List<string> selected = new List<string>();
            foreach (var item in listBox.CheckedItems)
            {
                selected.Add(item.ToString());
            }

            string currentItem = listBox.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                if (!selected.Contains(currentItem))
                    selected.Add(currentItem);
            }
            else
            {
                if (selected.Contains(currentItem))
                    selected.Remove(currentItem);
            }

            targetTextBox.Text = selected.Count > 0
                ? string.Join(", ", selected)
                : defaultText;
        }

        private void UpdateColumnChecklistStates()
        {
            bool selectChecked = checkedListBox2.CheckedItems.Contains("SELECT");
            bool updateChecked = checkedListBox2.CheckedItems.Contains("UPDATE");

            checkedListBox1.Enabled = selectChecked;
            checkedListBox3.Enabled = updateChecked;
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            HandleItemCheck(checkedListBox2, e, txtQuyen, "Chưa chọn quyền nào");
            // Dùng BeginInvoke để cập nhật sau khi trạng thái checkbox được thay đổi
            this.BeginInvoke(new Action(UpdateColumnChecklistStates));
        }

        private void cbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cbObjectType.SelectedItem.ToString();

            LoadObjectNamesByType(selectedType);  // Load vào cbBang
            LoadPrivilegesByType(selectedType);   // Load vào checkedListBox2
        }

        private void LoadObjectNamesByType(string objectType)
        {
            cbBang.Items.Clear();

            using (OracleCommand cmd = new OracleCommand("GET_OBJECTS_BY_TYPE", MainClass.conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_object_type", OracleDbType.Varchar2).Value = objectType;
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbBang.Items.Add(reader.GetString(0)); // object_name
                    }
                }
            }

            if (cbBang.Items.Count > 0)
                cbBang.SelectedIndex = 0;
        }

        private void LoadPrivilegesByType(string objectType)
        {
            checkedListBox2.Items.Clear();

            if (objectType == "TABLE" || objectType == "VIEW")
            {
                checkedListBox2.Items.Add("SELECT");
                checkedListBox2.Items.Add("INSERT");
                checkedListBox2.Items.Add("UPDATE");
                checkedListBox2.Items.Add("DELETE");
            }
            else if (objectType == "FUNCTION" || objectType == "PROCEDURE")
            {
                checkedListBox2.Items.Add("EXECUTE");
            }
        }


        private void cbBang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = cbBang.SelectedItem.ToString();

            // Xóa dữ liệu cũ
            checkedListBox1.Items.Clear(); // SELECT
            checkedListBox3.Items.Clear(); // UPDATE

            // Nếu quyền SELECT đang được chọn trong checkedListBox2
            if (checkedListBox2.CheckedItems.Contains("SELECT"))
            {
                checkedListBox1.Visible = true;
                LoadColumnsToChecklist(selectedTable, checkedListBox1);
            }
            else
            {
                checkedListBox1.Visible = true;
                LoadColumnsToChecklist(selectedTable, checkedListBox1);
                checkedListBox1.Enabled = false;
            }

            // Nếu quyền UPDATE đang được chọn trong checkedListBox2
            if (checkedListBox2.CheckedItems.Contains("UPDATE"))
            {
                checkedListBox3.Visible = true;
                LoadColumnsToChecklist(selectedTable, checkedListBox3);
            }
            else
            {
                checkedListBox3.Visible = true;
                LoadColumnsToChecklist(selectedTable, checkedListBox3);
                checkedListBox3.Enabled = false;
            }
        }

        private void LoadColumnsToChecklist(string tableName, CheckedListBox listBox)
        {
            listBox.Items.Clear();

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }
                using (OracleCommand cmd = new OracleCommand("get_columns_by_table", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = tableName;
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox.Items.Add(reader.GetString(0), false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách cột:\n" + ex.Message);
            }
        }

        private void LoadRolesToComboBox()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }
                OracleCommand cmd = new OracleCommand("get_custom_roles", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    cbCaprole.Items.Clear();

                    while (reader.Read())
                    {
                        string roleName = reader.GetString(0);
                        cbCaprole.Items.Add(roleName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách roles:\n" + ex.Message);
            }
        }

        private void txtQuyen_Click(object sender, EventArgs e)
        {
            // Khi người dùng nhấn vào textbox, sẽ hiện ra checklistbox tương ứng
            checkedListBox2.Visible = !checkedListBox2.Visible;
            checkedListBox2.BringToFront();
            checkedListBox2.Location = new Point(txtQuyen.Left, txtQuyen.Bottom);
        }

        private void btnCapQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedUser = !string.IsNullOrEmpty(MainClass.User)
                    ? MainClass.User
                    : (!string.IsNullOrEmpty(MainClass.Role) ? MainClass.Role : "");

                string selectedTable = cbBang.SelectedItem?.ToString();
                string selectedRole = cbCaprole.SelectedItem?.ToString();
                string selectedObjectType = cbObjectType.SelectedItem?.ToString()?.ToUpper();

                int insertChecked = checkedListBox2.CheckedItems.Contains("INSERT") ? 1 : 0;
                int deleteChecked = checkedListBox2.CheckedItems.Contains("DELETE") ? 1 : 0;
                int selectChecked = checkedListBox2.CheckedItems.Contains("SELECT") ? 1 : 0;
                int updateChecked = checkedListBox2.CheckedItems.Contains("UPDATE") ? 1 : 0;

                string selectedSelectCols = string.Join(",", checkedListBox1.CheckedItems.Cast<string>());
                string selectedUpdateCols = string.Join(",", checkedListBox3.CheckedItems.Cast<string>());

                bool withGrantOption = checkbwgo.Checked;

                // Kiểm tra bắt buộc chọn ít nhất 1 quyền hoặc role
                if (insertChecked == 0 && deleteChecked == 0 && selectChecked == 0 && updateChecked == 0
                    && string.IsNullOrWhiteSpace(selectedSelectCols)
                    && string.IsNullOrWhiteSpace(selectedUpdateCols)
                    && string.IsNullOrWhiteSpace(selectedRole))
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một quyền hoặc role để cấp.");
                    return;
                }

                if (!string.IsNullOrEmpty(selectedObjectType)
    && insertChecked == 0 && deleteChecked == 0 && selectChecked == 0 && updateChecked == 0)
                {
                    MessageBox.Show("Vui lòng chọn quyền cần cấp cho đối tượng.");
                    return;
                }


                // Nếu cấp quyền I/U/D/S nhưng chưa chọn object
                if ((insertChecked == 1 || deleteChecked == 1 || selectChecked == 1 || updateChecked == 1)
                    && string.IsNullOrWhiteSpace(selectedTable))
                {
                    MessageBox.Show("Vui lòng chọn đối tượng (bảng, view, hàm, thủ tục).");
                    return;
                }

                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("GRANT_PRIVS_TO_USER", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_user", OracleDbType.Varchar2).Value = selectedUser;
                    cmd.Parameters.Add("p_table", OracleDbType.Varchar2).Value = selectedTable;
                    cmd.Parameters.Add("p_insert", OracleDbType.Int32).Value = insertChecked;
                    cmd.Parameters.Add("p_delete", OracleDbType.Int32).Value = deleteChecked;
                    cmd.Parameters.Add("p_select", OracleDbType.Int32).Value = selectChecked;
                    cmd.Parameters.Add("p_update", OracleDbType.Int32).Value = updateChecked;

                    cmd.Parameters.Add("p_select_cols", OracleDbType.Varchar2).Value =
                        string.IsNullOrWhiteSpace(selectedSelectCols) ? (object)DBNull.Value : selectedSelectCols;
                    cmd.Parameters.Add("p_update_cols", OracleDbType.Varchar2).Value =
                        string.IsNullOrWhiteSpace(selectedUpdateCols) ? (object)DBNull.Value : selectedUpdateCols;

                    cmd.Parameters.Add("p_role", OracleDbType.Varchar2).Value =
                        string.IsNullOrWhiteSpace(selectedRole) ? (object)DBNull.Value : selectedRole;

                    cmd.Parameters.Add("p_with_grant", OracleDbType.Int32).Value = withGrantOption ? 1 : 0;
                    cmd.Parameters.Add("p_object_type", OracleDbType.Varchar2).Value = selectedObjectType;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cấp quyền thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấp quyền:\n" + ex.Message);
            }
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
