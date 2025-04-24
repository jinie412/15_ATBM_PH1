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
                this.Close();
                return;
            }

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                // Tạo user
                try
                {
                    string createUserQuery = $"CREATE USER {username} IDENTIFIED BY {password}";
                    MainClass.ExecuteQuery(createUserQuery);
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1920)
                    {
                        MessageBox.Show($"User '{username}' đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Number == 1031)
                    {
                        MessageBox.Show("Tài khoản hiện tại không có quyền tạo user. Vui lòng kiểm tra quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi tạo user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close(); // Đóng form nếu tạo user thất bại
                    return;
                }

                // Gán quyền cơ bản cho user
                try
                {
                    string grantPrivilegesQuery = $"GRANT CREATE SESSION TO {username}";
                    MainClass.ExecuteQuery(grantPrivilegesQuery);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tạo user thành công nhưng lỗi khi gán quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // Nếu tới đây thì thành công
                MessageBox.Show($"Tạo user '{username}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult result = MessageBox.Show(
                    "Bạn có muốn gán thêm quyền cho user này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    MainClass.User = username;
                    MainClass.Role = "";
                    CapQuyen_CSDL capQuyen = new CapQuyen_CSDL();
                    capQuyen.StartPosition = FormStartPosition.CenterScreen;
                    capQuyen.Show();
                    this.Hide();
                }
                else
                {
                    this.Close(); // Đóng nếu không gán thêm quyền
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
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
