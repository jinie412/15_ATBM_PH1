using Oracle.ManagedDataAccess.Client;
using Sushi_Restaurant;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class UpdateUser : Form
    {
        private string _username;
        private string _password;

        public UpdateUser(string username, string password)
        {
            InitializeComponent();
            this.Size = new Size(300, 330);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Gán giá trị USERNAME và PASSWORD vào biến
            _username = username;
            _password = password;

            // Hiển thị thông tin trên giao diện
            Username.Text = _username;
            Password.Text = _password;

            Username.ReadOnly = true;
        }

        private void Update_User_Button_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string newPassword = Password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Username và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cập nhật mật khẩu
                UpdatePassword(username, newPassword);

                //// Yêu cầu nhập lại mật khẩu mới để kiểm tra đăng nhập
                //PromptForNewPassword(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật user: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePassword(string username, string newPassword)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                // Câu lệnh ALTER USER để cập nhật mật khẩu
                string alterUserQuery = $"ALTER USER {username} IDENTIFIED BY {newPassword}";
                MainClass.ExecuteQuery(alterUserQuery);

                MessageBox.Show("Cập nhật thông tin user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi cập nhật thành công
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật mật khẩu: {ex.Message}");
            }
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void PromptForNewPassword(string username)
        //{
        //    string newPassword = PromptForPassword();

        //    if (string.IsNullOrEmpty(newPassword))
        //    {
        //        MessageBox.Show("Bạn phải nhập mật khẩu mới để tiếp tục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Kiểm tra mật khẩu mới
        //    if (ValidatePassword(username, newPassword))
        //    {
        //        MessageBox.Show("Đăng nhập thành công với mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.Close(); // Đóng form sau khi kiểm tra thành công
        //    }
        //    else
        //    {
        //        MessageBox.Show("Mật khẩu mới không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private string PromptForPassword()
        //{
        //    using (Form passwordForm = new Form())
        //    {
        //        passwordForm.Text = "Nhập mật khẩu mới";
        //        passwordForm.Size = new Size(300, 150);
        //        passwordForm.StartPosition = FormStartPosition.CenterParent;

        //        Label lblPassword = new Label() { Left = 20, Top = 20, Text = "Mật khẩu:", AutoSize = true };
        //        TextBox txtPassword = new TextBox() { Left = 100, Top = 20, Width = 150, PasswordChar = '*' };
        //        Button btnOK = new Button() { Text = "OK", Left = 100, Top = 60, Width = 70, DialogResult = DialogResult.OK };
        //        Button btnCancel = new Button() { Text = "Hủy", Left = 180, Top = 60, Width = 70, DialogResult = DialogResult.Cancel };

        //        passwordForm.Controls.Add(lblPassword);
        //        passwordForm.Controls.Add(txtPassword);
        //        passwordForm.Controls.Add(btnOK);
        //        passwordForm.Controls.Add(btnCancel);

        //        passwordForm.AcceptButton = btnOK;
        //        passwordForm.CancelButton = btnCancel;

        //        if (passwordForm.ShowDialog() == DialogResult.OK)
        //        {
        //            return txtPassword.Text;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        //private bool ValidatePassword(string username, string password)
        //{
        //    try
        //    {
        //        // Tạo chuỗi kết nối tạm thời với thông tin user
        //        string tempConnectionString = $"User Id={username};Password={password};Data Source=localhost:1521/XEPDB1;";

        //        // Tạo kết nối tạm thời
        //        using (OracleConnection tempConn = new OracleConnection(tempConnectionString))
        //        {
        //            tempConn.Open(); // Thử mở kết nối
        //            tempConn.Close(); // Đóng kết nối ngay sau khi kiểm tra
        //        }

        //        // Nếu kết nối thành công, mật khẩu đúng
        //        return true;
        //    }
        //    catch
        //    {
        //        // Nếu kết nối thất bại, mật khẩu sai
        //        return false;
        //    }
        //}
    }
}
