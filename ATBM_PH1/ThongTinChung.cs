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
    public partial class ThongTinChung : Form
    {
        public ThongTinChung()
        {
            InitializeComponent();
            ThongTinChungLoad();
        }

        void ThongTinChungLoad()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("PROC_GET_MYINFO", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Tạo REF CURSOR
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtMaSV.Text = reader["MASV"].ToString();
                        txtHoTen.Text = reader["HOTEN"].ToString();
                        txtGioiTinh.Text = reader["PHAI"].ToString();
                        txtNgaySinh.Text = Convert.ToDateTime(reader["NGSINH"]).ToString("dd/MM/yyyy");
                        txtDiaChi.Text = reader["DCHI"].ToString();
                        txtDienThoai.Text = reader["DT"].ToString();
                        txtKhoa.Text = reader["KHOA"].ToString();
                        txtTinhTrang.Text = reader["TINHTRANG"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string diaChi = txtDiaChi.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();

            if (string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(dienThoai))
            {
                MessageBox.Show("Vui lòng không để trống thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OracleCommand cmd = new OracleCommand("PROC_UPDATE_CONTACT", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_dchi", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi;
                cmd.Parameters.Add("p_dt", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(dienThoai) ? (object)DBNull.Value : dienThoai;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnThayDoi.Location = btnLuu.Location;
            btnThayDoi.Visible = true;
            btnLuu.Visible = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            btnLuu.Location = btnThayDoi.Location;
            btnThayDoi.Visible = false;
            btnLuu.Visible = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
        }
    }
}
