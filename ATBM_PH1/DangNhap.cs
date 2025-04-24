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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
                return;
            }

            try
            {
                // Đổi từ XEPDB1 sang đúng tên PDB của bạn
                string connStr = $"User Id={username};Password={password};Data Source=localhost:1521/QLDULIEUNOIBO;";

                // Nếu login với SYS thì thêm quyền SYSDBA
                if (username.ToLower() == "sys")
                {
                    connStr += "DBA Privilege=SYSDBA;";
                }

                OracleConnection conn = new OracleConnection(connStr);
                conn.Open();

                // Nếu kết nối thành công, gán giá trị và chuyển form
                MainClass.CurrentUser.Username = username;
                MainClass.CurrentUser.Password = password;
                MainClass.conn = conn;

                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Đăng nhập thất bại:\n" + ex.Message);
            }
        }

    }
}