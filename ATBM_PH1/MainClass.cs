using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using ATBM_PH1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATBM_PH1
{
    public static class MainClass
    {
        // ---------- [1] Người dùng đang đăng nhập vào app ----------
        public static User CurrentUser = new User();

        public static string User = ""; // Role/user đang được chọn để thao tác.
        public static string Role = "";

        // ---------- [2] Thông tin kết nối Oracle ----------
        public static OracleConnection conn;
        public static string ConnectionString = "";


        // ---------- [3] Hàm làm mờ nền ----------
        public static void BlurBackground(Form model, Form parentForm)
        {
            Form background = new Form
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = 0.5d,
                BackColor = Color.Black,
                Size = parentForm.Size,
                Location = parentForm.Location,
                ShowInTaskbar = false
            };

            background.Show();
            model.Owner = background;
            model.ShowDialog();
            background.Dispose();
        }

    }

    // ---------- [4] Thông tin người dùng đăng nhập ----------
    public class User
    {
        public string Username { get; set; }      // Tài khoản đăng nhập vào app
        public string Password { get; set; }      // Mật khẩu Oracle (chỉ dùng nội bộ)
    }


}
