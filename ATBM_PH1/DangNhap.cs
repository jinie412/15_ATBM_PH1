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

namespace ATBM_PH1
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private bool isPasswordHidden = true;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string GoiHam_XacDinhRole(string input)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                    MainClass.conn.Open();

                string sql = "SELECT PDB_ADMIN.FUNC_XACDINH_DOITUONG(:p_input) FROM DUAL";

                OracleCommand cmd = new OracleCommand(sql, MainClass.conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_input", OracleDbType.Varchar2).Value = input;

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "(null)";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }


        private void load_Form()
        {
            if (MainClass.CurrentUser.Username.ToLower() == "pdb_admin")
            {
                frmMain_PDT main = new frmMain_PDT();
                main.Show();
                this.Hide();
            }
            else
            {
                string role = GoiHam_XacDinhRole(MainClass.CurrentUser.Username);
                if (role == "NV PĐT")
                {
                    frmMain_PDT main = new frmMain_PDT();
                    main.Show();
                    this.Hide();
                }
                else if (role == "TRGĐV")
                {
                    frmMain_trgDV main = new frmMain_trgDV();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Không xác định được quyền truy cập.");
                }
            }
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

                load_Form();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Đăng nhập thất bại:\n" + ex.Message);
            }
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            isPasswordHidden = !isPasswordHidden;

            // Toggle hiển thị mật khẩu
            txtPass.UseSystemPasswordChar = isPasswordHidden;

            // Đổi icon tương ứng
            btnPass.Image = isPasswordHidden
            ? Properties.Resources.hide   // Mắt đóng: đang ẩn
            : Properties.Resources.show;  // Mắt mở: đang hiện

        }


    }
}