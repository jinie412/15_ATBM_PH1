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

        public UpdateUser(string username)
        {
            InitializeComponent();
            this.Size = new Size(330, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Gán giá trị USERNAME và PASSWORD vào biến
            _username = username;

            // Hiển thị thông tin trên giao diện
            Username.Text = _username;
            Username.ReadOnly = true;

            // Đăng ký sự kiện CheckedChanged cho checkbox
            CheckLock.CheckedChanged += CheckLock_CheckedChanged;
            CheckUnlock.CheckedChanged += CheckUnlock_CheckedChanged;

            // Tải trạng thái tài khoản
            LoadUserStatus(username);
        }

        private void Update_User_Button_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string newPassword = Password.Text.Trim();

            // Kiểm tra xem username hoặc mật khẩu có trống không
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cập nhật mật khẩu nếu có giá trị
                if (!string.IsNullOrEmpty(newPassword))
                {
                    UpdatePassword(username, newPassword);
                }

                // Xử lý khóa/mở khóa tài khoản
                if (CheckLock.Checked)
                {
                    LockUserAccount(username);
                }
                else if (CheckUnlock.Checked)
                {
                    UnlockUserAccount(username);
                }

                MessageBox.Show("Cập nhật thông tin user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi cập nhật thành công
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

                using (OracleCommand cmd = new OracleCommand("UpdateUserPassword", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
                    cmd.Parameters.Add("p_new_password", OracleDbType.Varchar2).Value = newPassword;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật mật khẩu: {ex.Message}");
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }


        private void LockUserAccount(string username)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("LockUserAccount", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi khóa tài khoản: {ex.Message}");
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }


        private void UnlockUserAccount(string username)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("UnlockUserAccount", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi mở khóa tài khoản: {ex.Message}");
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }


        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckLock_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu CheckLock được chọn, bỏ chọn CheckUnlock
            if (CheckLock.Checked)
            {
                CheckUnlock.Checked = false;
            }
        }

        private void CheckUnlock_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu CheckUnlock được chọn, bỏ chọn CheckLock
            if (CheckUnlock.Checked)
            {
                CheckLock.Checked = false;
            }
        }

        private void LoadUserStatus(string username)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("GetUserStatus", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
                    cmd.Parameters.Add("p_status", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    string status = cmd.Parameters["p_status"].Value.ToString();
                    if (status.Contains("LOCKED"))
                    {
                        CheckLock.Checked = true;
                        CheckUnlock.Checked = false;
                    }
                    else if (status.Contains("OPEN"))
                    {
                        CheckUnlock.Checked = true;
                        CheckLock.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra trạng thái tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }
    }
}