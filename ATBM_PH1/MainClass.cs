using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using System.Data;

namespace Sushi_Restaurant
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

        // ---------- [3] Load config từ file JSON ----------
        public static void LoadFromJson(string path = "config.json")
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("Không tìm thấy file cấu hình: config.json");
                return;
            }

            var json = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<DbConfig>(json);

            CurrentUser.Username = config.username;
            CurrentUser.Password = config.password;

            // Nếu login bằng SYSDBA, bạn thêm " as sysdba" ở đây:
            ConnectionString = $"User Id={config.username};Password={config.password};Data Source=localhost:1521/QLDULIEUNOIBO;";
            conn = new OracleConnection(ConnectionString);
        }
        // ---------- [4] Kết nối đến Oracle ----------
        public static void ConnectToOracle()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối CSDL Oracle: " + ex.Message);
            }
        }
        public static DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " + ex.Message);
                throw;
            }

            return dataTable;
        }

        // ---------- [6] Cấu trúc file config ----------
        private class DbConfig
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }

    // ---------- [7] Thông tin người dùng đăng nhập ----------
    public class User
    {
        public string Username { get; set; }      // Tài khoản đăng nhập vào app
        public string Password { get; set; }      // Mật khẩu Oracle (chỉ dùng nội bộ)
    }
}