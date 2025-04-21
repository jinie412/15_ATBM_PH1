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

                string createUserQuery = $"CREATE USER {username} IDENTIFIED BY {password}";
                MainClass.ExecuteQuery(createUserQuery);

                string grantPrivilegesQuery = $"GRANT CONNECT, RESOURCE TO {username}";
                MainClass.ExecuteQuery(grantPrivilegesQuery);

                MessageBox.Show("Tạo user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn form InsertUser sau khi thêm thành công
                this.Close(); // Đóng form thay vì chỉ ẩn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
