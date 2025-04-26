using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security.AntiXss;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ATBM_PH1
{
    public partial class PhanQuyen : Form
    {
        public PhanQuyen()
        {
            InitializeComponent();
        }
        private int CheckUserOrRoleExists(string grantee)
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            // Ngắt kết nối các session của user
            using (OracleCommand cmd = new OracleCommand("SP_KTRA_TON_TAI", MainClass.conn))
            {
                
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee.ToUpper();
                cmd.Parameters.Add("p_exists", OracleDbType.Int32).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                OracleDecimal oracleDec = (OracleDecimal)cmd.Parameters["p_exists"].Value;
                int exists = oracleDec.ToInt32();
                return exists;
            }
        }
        private void ClearDataGrids()
        {
            if (tablePrivs.DataSource != null)
                ((DataTable)tablePrivs.DataSource).Clear();

            if (colPrivs.DataSource != null)
                ((DataTable)colPrivs.DataSource).Clear();

            if (rolePrivs.DataSource != null)
                ((DataTable)rolePrivs.DataSource).Clear();
        }
        private void LoadPrivileges()
        {

            string grantee = MainClass.Role;

            //string grantee = "";
            if (!string.IsNullOrWhiteSpace(MainClass.User) && string.IsNullOrWhiteSpace(MainClass.Role))
            {
                grantee = MainClass.User;
            }
            else
            {
                grantee = MainClass.Role;
            }

            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            // Load quyền bảng/view/function
            OracleCommand cmdTab = new OracleCommand("SP_TAB_DA_CAP", MainClass.conn);
            cmdTab.CommandType = CommandType.StoredProcedure;
            cmdTab.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
            cmdTab.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter daTab = new OracleDataAdapter(cmdTab);
            DataTable dtTab = new DataTable();
            daTab.Fill(dtTab);
            tablePrivs.DataSource = dtTab;

            // Load quyền cột
            OracleCommand cmdCol = new OracleCommand("SP_COL_DA_CAP", MainClass.conn);
            cmdCol.CommandType = CommandType.StoredProcedure;
            cmdCol.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
            cmdCol.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter daCol = new OracleDataAdapter(cmdCol);
            DataTable dtCol = new DataTable();
            daCol.Fill(dtCol);
            colPrivs.DataSource = dtCol;

            // Load role của user
            OracleCommand cmdRole = new OracleCommand("SP_XAC_DINH_ROLE_CHO_USER", MainClass.conn);
            cmdRole.CommandType = CommandType.StoredProcedure;
            cmdRole.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
            cmdRole.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter daRole = new OracleDataAdapter(cmdRole);
            DataTable dtRole = new DataTable();
            daRole.Fill(dtRole);
            rolePrivs.DataSource = dtRole;

        }

        private void txtGrantee_IconRightClick(object sender, EventArgs e)
        {
            string grantee = txtGrantee.Text.Trim();

            MainClass.Role = grantee;




            if (string.IsNullOrWhiteSpace(grantee))
            {
                ClearDataGrids();
                lblSelected.Visible = false;
                MessageBox.Show("Vui lòng nhập tên user hoặc role.");
                return;
            }
            int res = CheckUserOrRoleExists(grantee);
            if (res==0)
            {
                ClearDataGrids();
                lblSelected.Visible = false;
                MessageBox.Show("User hoặc role không tồn tại trong hệ thống.");
                return;
            }
            try
            {
               
                lblSelected.Visible = true;
                if (res == 1)
                {
                    MainClass.User = grantee.ToUpper();
                    MainClass.Role = "";    
                    lblSelected.Text = "USER: " + MainClass.User;
                }
                else
                {
                    MainClass.Role = grantee.ToUpper();
                    MainClass.User = "";
                    lblSelected.Text = "ROLE: " + MainClass.Role;
                }
                LoadPrivileges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }

        private void btnRevoke_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(MainClass.Role))

            if (string.IsNullOrWhiteSpace(MainClass.User))

            {
                MessageBox.Show("Vui lòng nhập user hoặc role.");
                return;
            }
            try
            {
                // Mở kết nối nếu chưa mở
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                bool hasChecked = false;

                // 1. Thu hồi quyền theo bảng
                foreach (DataGridViewRow row in tablePrivs.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["checkTab"].Value);
                    if (isChecked)
                    {
                        hasChecked = true;
                        string grantee = row.Cells["tabGrantee"].Value.ToString();
                        string owner = row.Cells["tabOwner"].Value.ToString();
                        string table = row.Cells["tabTable"].Value.ToString();
                        string privilege = row.Cells["tabPriv"].Value.ToString();

                        using (OracleCommand cmd = new OracleCommand("SP_THU_HOI_QUYEN_TAB", MainClass.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
                            cmd.Parameters.Add("p_owner", OracleDbType.Varchar2).Value = owner;
                            cmd.Parameters.Add("p_table", OracleDbType.Varchar2).Value = table;
                            cmd.Parameters.Add("p_priv", OracleDbType.Varchar2).Value = privilege;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // 2. Thu hồi quyền theo cột
                foreach (DataGridViewRow row in colPrivs.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["checkCol"].Value);
                    if (isChecked)
                    {
                        hasChecked = true;
                        string grantee = row.Cells["colGrantee"].Value.ToString();
                        string owner = row.Cells["colSchema"].Value.ToString();
                        string table = row.Cells["colTable"].Value.ToString();
                        string col = row.Cells["colCol"].Value.ToString();
                        string privilege = row.Cells["colPriv"].Value.ToString();

                        using (OracleCommand cmd = (privilege == "UPDATE")
                            ? new OracleCommand("SP_THU_HOI_QUYEN_UPDATE_COL", MainClass.conn)
                            : new OracleCommand("SP_THU_HOI_QUYEN_COL", MainClass.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
                            cmd.Parameters.Add("p_owner", OracleDbType.Varchar2).Value = owner;
                            cmd.Parameters.Add("p_table", OracleDbType.Varchar2).Value = table;
                            cmd.Parameters.Add("p_col", OracleDbType.Varchar2).Value = col;

                            if (privilege != "UPDATE")
                            {
                                cmd.Parameters.Add("p_priv", OracleDbType.Varchar2).Value = privilege;
                            }

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // 3. Thu hồi role
                foreach (DataGridViewRow row in rolePrivs.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["checkRole"].Value);
                    if (isChecked)
                    {
                        hasChecked = true;
                        string grantee = row.Cells["roleGrantee"].Value.ToString();
                        string role = row.Cells["dgvRole"].Value.ToString();

                        using (OracleCommand cmd = new OracleCommand("SP_THU_HOI_ROLE", MainClass.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = grantee;
                            cmd.Parameters.Add("p_role", OracleDbType.Varchar2).Value = role;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (hasChecked)
                {
                    MessageBox.Show("Thu hồi quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một quyền để thu hồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadPrivileges();
        }

        private void tablePrivs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tablePrivs.Columns["checkTab"].Index && e.RowIndex >= 0)
            {
                // Chuyển đổi trạng thái checkbox khi click
                bool current = Convert.ToBoolean(tablePrivs.Rows[e.RowIndex].Cells["checkTab"].Value);
                tablePrivs.Rows[e.RowIndex].Cells["checkTab"].Value = !current;
            }
        }

        private void colPrivs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colPrivs.Columns["checkCol"].Index && e.RowIndex >= 0)
            {
                // Chuyển đổi trạng thái checkbox khi click
                bool current = Convert.ToBoolean(colPrivs.Rows[e.RowIndex].Cells["checkCol"].Value);
                colPrivs.Rows[e.RowIndex].Cells["checkCol"].Value = !current;
            }
        }

        private void rolePrivs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == rolePrivs.Columns["checkRole"].Index && e.RowIndex >= 0)
            {
                // Chuyển đổi trạng thái checkbox khi click
                bool current = Convert.ToBoolean(rolePrivs.Rows[e.RowIndex].Cells["checkRole"].Value);
                rolePrivs.Rows[e.RowIndex].Cells["checkRole"].Value = !current;
            }
        }

        private void btnGrant_Click(object sender, EventArgs e)
        {
            CapQuyen_CSDL capQuyen = new CapQuyen_CSDL();
            capQuyen.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(capQuyen);
            this.Hide();
        }
    }
}
