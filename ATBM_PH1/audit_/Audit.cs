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

namespace ATBM_PH1.audit_
{
    public partial class Audit : Form
    {
        public Audit()
        {
            InitializeComponent();
            this.Load += Audit_Load; // Đăng ký sự kiện Load
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            ExecuteAuditControl("ENABLE");
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            ExecuteAuditControl("DISABLE");
        }

        private void ExecuteAuditControl(string action)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }
                using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.PROC_AUDIT_CONTROL", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameter for the stored procedure
                    cmd.Parameters.Add("Action", OracleDbType.Varchar2).Value = action;

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Đã {(action.ToLower() == "enable" ? "bật" : "tắt")} audit.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void tablePrivs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadAuditLog(string auditType)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.PROC_LOAD_AUDIT_LOG", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_type", OracleDbType.Varchar2).Value = auditType;
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            // Nếu không có dữ liệu, hiển thị DataGridView trống
                            DataTable emptyTable = new DataTable();
                            emptyTable.Columns.Add("AUDIT_TYPE", typeof(string));
                            emptyTable.Columns.Add("DBUSERNAME", typeof(string));
                            emptyTable.Columns.Add("ACTION_NAME", typeof(string));
                            emptyTable.Columns.Add("OBJECT_NAME", typeof(string));
                            emptyTable.Columns.Add("SQL_TEXT", typeof(string));
                            emptyTable.Columns.Add("RETURN_CODE", typeof(int));
                            emptyTable.Columns.Add("EVENT_TIME", typeof(string));

                            tablePrivs.DataSource = emptyTable;
                        }
                        else
                        {
                            tablePrivs.DataSource = dataTable;
                        }

                        // Đặt tiêu đề cột in hoa
                        foreach (DataGridViewColumn column in tablePrivs.Columns)
                        {
                            column.HeaderText = column.HeaderText.ToUpper();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                {
                    MainClass.conn.Close();
                }
            }
        }

        private void STANDARD_Click(object sender, EventArgs e)
        {
            LoadAuditLog("STANDARD"); // Tải dữ liệu audit loại STANDARD
        }

        private void FGA_Click(object sender, EventArgs e)
        {
            LoadAuditLog("FineGrainedAudit"); // Tải dữ liệu audit loại FineGrainedAudit
        }

        private void ALL_Click(object sender, EventArgs e)
        {
            LoadAuditLog("ALL"); // Tải tất cả dữ liệu audit
        }

        private void Audit_Load(object sender, EventArgs e)
        {
            LoadAuditLog("ALL"); // Mặc định tải tất cả dữ liệu audit khi form được tải
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa tất cả dữ liệu unified audit trail?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Kiểm tra người dùng chọn Yes hay No
                if (result == DialogResult.Yes)
                {
                    if (MainClass.conn.State == ConnectionState.Closed)
                    {
                        MainClass.conn.Open();
                    }

                    using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.PROC_DELETE_AUDIT_UNIFIED", MainClass.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xoá tất cả dữ liệu unified audit trail!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu vào DataGridView
                        LoadAuditLog("ALL");
                    }
                }
                else
                {
                    MessageBox.Show("Hành động xóa đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
