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
//using System.Data.OracleClient; 

namespace ATBM_PH1
{
    public partial class InsertUser : Form
    {
        public InsertUser()
        {
            InitializeComponent();
            this.Size = new Size(300, 330);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Insert_User_Button_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username và Password không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                // Tạo user
                string createUserQuery = $"CREATE USER {username} IDENTIFIED BY {password}";
                MainClass.ExecuteQuery(createUserQuery);

                // Gán quyền cho user
                string grantPrivilegesQuery = $"GRANT CREATE SESSION, RESOURCE TO {username}";
                MainClass.ExecuteQuery(grantPrivilegesQuery);

                // Thông báo thành công
                MessageBox.Show($"Tạo user '{username}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form sau khi thêm thành công
                this.Close();
            }
            catch (OracleException ex)
            {
                // Xử lý lỗi cụ thể từ Oracle
                if (ex.Number == 1920) // ORA-01920: user already exists
                {
                    MessageBox.Show($"User '{username}' đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1031) // ORA-01031: insufficient privileges
                {
                    MessageBox.Show("Tài khoản hiện tại không có quyền tạo user. Vui lòng kiểm tra quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Lỗi khác
                    MessageBox.Show($"Lỗi khi tạo user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
