using Oracle.ManagedDataAccess.Client;
using Sushi_Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class CreateRoleForm : Form
    {
        public CreateRoleForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text.Trim();
            string password = textPassword.Text.Trim();

            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Tên role không được để trống.");
                return;
            }

            string connectionString = "User Id=pdb_admin;Password=MyPassword;Data Source=localhost:1521/QLDULIEUNOIBO";
            using (var conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("CREATE_NEW_ROLE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_role_name", OracleDbType.Varchar2).Value = roleName;
                        cmd.Parameters.Add("p_password", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(password) ? null : password;
                        cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 4000).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        string error = cmd.Parameters["p_error"].Value?.ToString();
                        if (string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show(error);
                            return;
                        }

                        MessageBox.Show($"Đã tạo role '{roleName}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult result = MessageBox.Show("Bạn có muốn cấp quyền cho role này không?", "Cấp quyền", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.Hide();
                            MainClass.Role = roleName;
                            MainClass.User = "";
                            CapQuyen_CSDL capQuyen = new CapQuyen_CSDL();
                            capQuyen.StartPosition = FormStartPosition.CenterScreen;
                            capQuyen.Show();
                            

                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo role: {ex.Message}");
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
